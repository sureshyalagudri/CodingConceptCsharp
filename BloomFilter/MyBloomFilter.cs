using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
    class MyBloomFilter
    {
        private BitArray hashData;
        private int hashFunctions = 0;
        public MyBloomFilter(int size)
        {
            // Find error rate.
            float errorRate = (float)(1.0 / size);

            // Find the actual size.
            int validSize = (int)Math.Ceiling(size * Math.Log(errorRate, (1.0 / Math.Pow(2, Math.Log(2.0)))));

            // Find number of hash functions should be used.
            hashFunctions = (int)Math.Round(Math.Log(2.0) * validSize / size);

            // Create an array with avlid size.
            hashData = new BitArray(validSize);
        }

        /// <summary>
        /// To add data
        /// </summary>
        /// <param name="item"></param>
        public void Add(string item)
        {
            int itemHash = item.GetHashCode();
            // Process for number of has functions.
            for (int i = 0; i < hashFunctions; i++)
            {
                int hash = Math.Abs((int)((itemHash + i) % hashData.Count));
                hashData[hash] = true;
            }
        }

        /// <summary>
        /// To find data
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(string item)
        {
            int itemHash = item.GetHashCode();
            for (int i = 0; i < hashFunctions; i++)
            {
                int hash = Math.Abs((int)((itemHash + i) % hashData.Count));
                if (hashData[hash] == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
