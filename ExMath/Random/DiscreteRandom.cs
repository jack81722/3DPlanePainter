using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.RandomTool
{
    /// <summary>
    /// Discrete contribution random of data T
    /// </summary>
    /// <typeparam name="T">defined data</typeparam>
    public class DiscreteRandom<T>
    {
        #region Properties
        /// <summary>
        /// Basic random
        /// </summary>
        private System.Random random;

        /// <summary>
        /// Intervals of datas
        /// </summary>
        private List<ComcreteInterval<T>> _intervals;
        public List<ComcreteInterval<T>> intervals
        {
            get
            {
                return _intervals;
            }
        }
        #endregion

        #region Interval Structure
        /// <summary>
        /// Interval data structure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public struct ComcreteInterval<T>
        {
            public T element;
            public double weight, min, max;

            public ComcreteInterval(T element, double weight, double min, double max)
            {
                this.element = element;
                this.weight = weight;
                this.min = min;
                this.max = max;
            }

            public override string ToString()
            {
                return string.Format("{0}, weight = {1}, [{2}, {3})", element.ToString(), weight, min, max);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscreteRandom()
        {
            _intervals = new List<ComcreteInterval<T>>();
            random = new System.Random();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Refresh intervals
        /// </summary>
        private void Refresh()
        {
            double sum = 0;
            for (int i = 0; i < _intervals.Count; i++)
            {
                sum += _intervals[i].weight;
            }
            double min = 0;
            for (int i = 0; i < _intervals.Count; i++)
            {
                _intervals[i] = new ComcreteInterval<T>(_intervals[i].element, _intervals[i].weight, min, min + _intervals[i].weight / sum);
                min += _intervals[i].weight / sum;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get one random data
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            if(intervals.Count <= 0)
            {
                return default(T);
            }
            double value = random.NextDouble();
            return intervals.FindLast(x => x.min <= value && x.max > value).element;
        }

        /// <summary>
        /// Add new element with weight
        /// </summary>
        /// <param name="element"></param>
        /// <param name="weight"></param>
        public void AddElement(T element, double weight)
        {
            if (weight == 0)
                throw new InvalidOperationException("Weight cannot be zero.");
            _intervals.Add(new ComcreteInterval<T>(element, weight, 0, 0));
            Refresh();
        }


        /// <summary>
        /// Remove one element by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveElement(int index)
        {
            _intervals.RemoveAt(index);
            Refresh();
        }
        #endregion
    }


}
