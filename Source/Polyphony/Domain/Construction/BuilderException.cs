using System;

namespace Polyphony.Domain.Construction
{
    public class BuilderException : Exception
    {
        public object Entity { get; private set; }
        
        public BuilderException(object domainEntity, string message) 
            : base(message)
        {
            Entity = domainEntity;
        }
    }
}