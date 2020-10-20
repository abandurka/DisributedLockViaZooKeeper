using System;
using System.Collections.Concurrent;

namespace DisributedLockViaZooKeeper.Taxes.WepApi
{
    public class TaxRepository
    {
        private readonly ConcurrentDictionary<string, int> _taxes = new ConcurrentDictionary<string, int>();
        private readonly Random Rnd = new Random();
        
        public string GetTax(string index)
        {
            _taxes[index] = _taxes.ContainsKey(index) 
                ? _taxes[index] + 1
                : 0;

            return (Rnd.NextDouble() * 100).ToString();
        }

        public void Clear(string index) => 
            _taxes.TryRemove(index, out _);

        public int GetHits(string index) =>
            _taxes.TryGetValue(index, out var result) 
                ? result 
                : 0;
    }
}