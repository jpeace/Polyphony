using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Polyphony.Core.NHibernate.Conventions
{
    public class CollectionAccessConvention : ICollectionConvention
    {
        /// <summary>
        /// Apply changes to the target
        /// </summary>
        public void Apply(ICollectionInstance instance)
        {
            instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }
    }
}