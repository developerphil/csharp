using System.Collections.Generic;

namespace CodeSnippets.Reflection.GenericFactory
{
    public interface IRepository<T, TKey>
    {
        IEnumerable<T> GetItems();

        T GetItem(TKey key);

        void AddItem(T newItem);

        void UpdateItem(TKey key, T updatedItem);

        void DeleteItem(TKey key);

        void UpdateItems(IEnumerable<T> updatedItems);
    }
}