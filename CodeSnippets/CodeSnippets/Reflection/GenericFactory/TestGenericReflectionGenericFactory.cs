namespace CodeSnippets.Reflection.GenericFactory
{
    public class TestGenericReflectionGenericFactory
    {
        public void Example()
        {
            IRepository<object, string> repository = GenericFactory.Get<IRepository<object, string>>();
            repository.GetItems();
        }
    }
}