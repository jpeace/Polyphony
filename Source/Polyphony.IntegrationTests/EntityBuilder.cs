namespace Polyphony.IntegrationTests
{
    public delegate TEntity EntityBuilder<TEntity>() where TEntity : class;
}