using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ExMath
{
    /// <summary>
    /// Fibonacci Sequence
    /// </summary>
    public sealed class FibonacciSequence
    {
        #region Singleton
        private static FibonacciSequence _instance;
        private static FibonacciSequence instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new FibonacciSequence(255);
                }
                return _instance;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// List of Fibonacci Sequence
        /// </summary>
        private List<BigInteger> _FList;
        private static List<BigInteger> FList
        {
            get
            {
                return instance._FList;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">initial size</param>
        private FibonacciSequence(int size)
        {
            if (size < 2)
                throw new InvalidOperationException("Size cannot smaller than 2");
            _FList = new List<BigInteger>();
            _FList.Add(1);
            _FList.Add(2);
            for (int i = 2; i < size; i++)
            {
                _FList.Add(_FList[i - 1] + _FList[i - 2]);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the index th number
        /// </summary>
        public static BigInteger Get(int index)
        {
            if (index < 0)
                throw new InvalidOperationException("Index cannot smaller than 2");
            lock (FList)
            {
                if (index >= FList.Count)
                {
                    int start = FList.Count;
                    for (int i = start; i < index + 1; i++)
                    {
                        instance._FList.Add(FList[i - 1] + FList[i - 2]);
                    }
                }
            }
            return FList[index];
        }
        #endregion
    }
}
