using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Polyphony.Core.NHibernate.Conventions
{
    /// <summary>
    /// Provides a user type convention for mapping enumerations.
    /// </summary>
    public class EnumConvention : IUserTypeConvention
    {
        /// <summary>
        /// Whether this convention will be applied to the target.
        /// </summary>
        /// <param name="criteria">Instance that could be supplied</param>
        /// <returns>
        /// Apply on this target?
        /// </returns>
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        /// <summary>
        /// Apply changes to the target
        /// </summary>
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }
    }
}