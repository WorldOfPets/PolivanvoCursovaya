using AppCurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCurs.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Item> itemsComplate;
        readonly List<Item> itemsJustDoIt;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Come home", Description="You need to come home." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Chek VK", Description="You need to chek your VK." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Read a book", Description="You need to read a book." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Learn English", Description="Youn need to learn English." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Go to sleep", Description="You need to go to sleep." },
            };
            itemsComplate = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wake Up", Description="You need to wake up." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Have breakfast", Description="You need to have breakfast." },
            };
            itemsJustDoIt = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "How to properly plan your day", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Where to find motivation", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "How to pump willpower", Description="" },
            };
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }
        public async Task<bool> AddItemComplateAsync(Item item)
        {
            itemsComplate.Add(item);
            return await Task.FromResult(true);
        }
        public async Task<bool> AddItemJustDoIt(Item item)
        {
            itemsJustDoIt.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateItemCAsync(Item item)
        {
            var oldItem = itemsComplate.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            itemsComplate.Remove(oldItem);
            itemsComplate.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateItemJAsync(Item item)
        {
            var oldItem = itemsJustDoIt.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            itemsJustDoIt.Remove(oldItem);
            itemsJustDoIt.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemCAsync(string id)
        {
            var oldItem = itemsComplate.Where((Item arg) => arg.Id == id).FirstOrDefault();
            itemsComplate.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemJAsync(string id)
        {
            var oldItem = itemsJustDoIt.Where((Item arg) => arg.Id == id).FirstOrDefault();
            itemsJustDoIt.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Item> GetItemComlateAsync(string id)
        {
            return await Task.FromResult(itemsComplate.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Item> GetItemJustDoItAsync(string id)
        {
            return await Task.FromResult(itemsJustDoIt.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Item>> GetItemComlateAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(itemsComplate);
        }

        public async Task<IEnumerable<Item>> GetItemJustDoItAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(itemsJustDoIt);
        }
    }
}