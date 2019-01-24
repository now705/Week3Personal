using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl.Models;

namespace Crawl.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "The Sword of the Morning", Description="A mighty weapon that has slayn countless beasts of the dark, but only between the hours of 6:00 am and 11:00 am." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "The Ring of Invisibility", Description="This ring has the power to turn its wearer invisible. But seeing as the ring itself is invisible you may have some trouble finding it." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tunic of Endless Style", Description="Tired of being mocked for a lack of fashion when plundering ancient tombs? Well than you need the Tunic of Endless Style, it goes with everything. However it is just a tunic and will not protect you in anyway." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Boots of Average Speed", Description="These boots will let their wearer move at an average speed. Not to fast, not to slow, just right." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Greaves of protection", Description="These Greaves way over 400 lb and are made of solid steel! They will stop any attack in its tracks, as long as that attack is aimed at your incredibly well defended legs." },

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}