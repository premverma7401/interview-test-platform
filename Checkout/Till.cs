using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {

        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 1},
            {'B', 0},
            {'C',0},
            {'D',0}
        };

        public double Total()
        {
            double total = 0;
            int maxItems = 0;
            foreach (var item in _items)
            {
                if (item.Key.Equals('A'))
                {
                    total += AddA(item.Value.ToString(), item);
                }
                else if (item.Key.Equals('B'))
                {
                    total += AddB(item.Value.ToString(), item);
                }
                else if (item.Key.Equals('C'))
                {
                    total = AddItemC(total, item, maxItems);
                }
                else total = AddItemD(total, item);
            }
            return total;
        }

        public double AddItemD(double total, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('D'))
            {
                total += 15 * item.Value;
            }

            return total;
        }

        public double AddItemC(double total, KeyValuePair<char, int> item, int maxItems)
        {
            if (maxItems <= 6 && item.Key.Equals('C'))
            {
                total += 15 * item.Value;
            }
            else
            {
                Console.WriteLine("Value should be less than 6");
            }
            return total;
        }

        public double AddB(string numberItems, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('B'))
            {
                double items = double.Parse(numberItems);
                if (items == 0) return 0;
                var singleItem = items % 2;
                var singleItemPrice = singleItem * 30;
                var clubItem = (items - singleItem) / 2;
                var clubItemPrice = clubItem * 45;
                Console.WriteLine($"{singleItemPrice},{ clubItemPrice},{ clubItem}, {singleItem}");
                return singleItemPrice + clubItemPrice;
            }
            return 0;
        }

        public double AddA(string numberItems, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('A'))
            {
                double items = double.Parse(numberItems);
                if (items == 0) return 0;
                var singleItem = items % 3;
                var singleItemPrice = singleItem * 50;
                var clubItem = (items - singleItem) / 3;
                var clubItemPrice = clubItem * 130;
                Console.WriteLine($"{singleItemPrice},{ clubItemPrice},{ clubItem}, {singleItem}");
                return singleItemPrice + clubItemPrice;
            }
            return 0;
        }

        // item quantity
        public void Scan(string items)
        {
            foreach (var item in items)
            {
                _items[item]++;
            }
        }
    }
}