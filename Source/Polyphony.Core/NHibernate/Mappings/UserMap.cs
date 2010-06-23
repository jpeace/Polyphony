using FluentNHibernate.Mapping;
using Polyphony.Domain;

namespace Polyphony.Core.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.UserId)
                .GeneratedBy
                .Identity();

            Map(u => u.FirstName)
                .Not
                .Nullable();

            Map(u => u.LastName)
                .Not
                .Nullable();

            HasMany(u => u.EmailAddresses)
                .Where("[ContactMethodType] = 1")
                .AsBag()
                .Cascade
                .AllDeleteOrphan();

            HasMany(u => u.PhoneNumbers)
                .Where("[ContactMethodType] = 2")
                .AsBag()
                .Cascade
                .AllDeleteOrphan();
        }
    }

    public class ContactMethodMap : ClassMap<ContactMethod>
    {
        public ContactMethodMap()
        {
            Id(m => m.ContactMethodId);

            References(m => m.User);

            Map(m => m.Value)
                .Not
                .Nullable();

            DiscriminateSubClassesOnColumn("ContactMethodType");
        }
    }

    public class EmailAddressMap : SubclassMap<EmailAddress>
    {
        public EmailAddressMap()
        {
            DiscriminatorValue((int)ContactMethodType.Email);

            Map(e => e.EmailType);
        }
    }

    public class PhoneNumberMap : SubclassMap<PhoneNumber>
    {
        public PhoneNumberMap()
        {
            DiscriminatorValue((int)ContactMethodType.Phone);

            Map(p => p.PhoneNumberType);
        }
    }
}