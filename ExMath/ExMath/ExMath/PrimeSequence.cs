using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ExMath
{
    /// <summary>
    /// Prime Sequence
    /// </summary>
    public sealed class PrimeSequence
    {
        #region Singleton
        private static PrimeSequence _instance;
        private static PrimeSequence instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PrimeSequence(255);
                
                return _instance;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// List of prime number
        /// </summary>
        private List<BigInteger> _PrimeList;
        private static List<BigInteger> PrimeList
        {
            get
            {
                return instance._PrimeList;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">initial size</param>
        private PrimeSequence(int size)
        {
            _PrimeList = new List<BigInteger>();
            _PrimeList.Add(2);
            _PrimeList.Add(3);

            BigInteger i;
            bool isPrime;
            for (i = 5; _PrimeList.Count < size; i += 2)
            {
                isPrime = true;
                for (int j = 0; j < _PrimeList.Count; j++)
                {
                    if (_PrimeList[j] * _PrimeList[j] <= i)
                    {
                        if (i % _PrimeList[j] == 0)
                        {
                            isPrime = false;
                        }
                    }
                }
                if (isPrime)
                    _PrimeList.Add(i);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the index th prime number
        /// </summary>
        public static BigInteger Get(int index)
        {
            if (index < 0)
                throw new InvalidOperationException("Index cannot be negative.");

            if (index >= PrimeList.Count)
            {
                BigInteger i = PrimeList[PrimeList.Count - 1] + 2;
                bool isPrime;
                for (; PrimeList.Count < index + 1 + 16; i = i + 2)
                {
                    isPrime = true;
                    for (int j = 0; j < PrimeList.Count; j++)
                    {
                        if (PrimeList[j] * PrimeList[j] <= i)
                        {
                            if (i % PrimeList[j] == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }
                    if (isPrime)
                    {
                        PrimeList.Add(i);
                    }
                }
            }
            return PrimeList[index];
        }

        /// <summary>
        /// Check if n is prime
        /// </summary>
        /// <param name="n">number</param>
        public static bool isPrime(BigInteger n)
        {
            if(n > PrimeList[PrimeList.Count - 1])
            {
                BigInteger i = PrimeList[PrimeList.Count - 1] + 2;
                bool isPrime;
                for (; i <= n; i = i + 2)
                {
                    isPrime = true;
                    for (int j = 0; j < PrimeList.Count; j++)
                    {
                        if (PrimeList[j] * PrimeList[j] <= i)
                        {
                            if (i % PrimeList[j] == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }
                    if (isPrime)
                    {
                        PrimeList.Add(i);
                    }
                }
            }
            return PrimeList.Contains(n);
        }
        #endregion
    }
}
