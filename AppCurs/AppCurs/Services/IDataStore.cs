using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCurs.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> AddItemComplateAsync(T item);
        Task<bool> AddItemJustDoIt(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> UpdateItemCAsync(T item);
        Task<bool> UpdateItemJAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<bool> DeleteItemCAsync(string id);
        Task<bool> DeleteItemJAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<T> GetItemComlateAsync(string id);
        Task<T> GetItemJustDoItAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetItemComlateAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetItemJustDoItAsync(bool forceRefresh = false);
    }
}
