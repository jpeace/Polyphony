using System;
using NUnit.Framework;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    public class LambdaSpecificationRule<TEntity> : IEntitySpecificationRule<TEntity> where TEntity : class
    {
        private readonly Func<TEntity, bool> _action;
        private readonly string _errorMsg;

        public LambdaSpecificationRule(Func<TEntity, bool> action, string errorMsg)
        {
            _action = action;
            _errorMsg = errorMsg;
        }

        public void Execute(TEntity entity)
        {
            if(!_action(entity))
            {
                Assert.Fail(_errorMsg);
            }
        }
    }
}