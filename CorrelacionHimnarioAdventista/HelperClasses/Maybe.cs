using System;
using System.Collections;
using System.Collections.Generic;

namespace HelperClasses
{
    /// <summary>
    /// Generic class that allow us to use it on return ocations when we need to return something but
    /// we are not sure if It will return anything or not.
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class Maybe<T> : IEnumerable<T>
    {
        #region Fields
        private readonly IEnumerable<T> values;
        #endregion

        #region Constructors
        /// <summary>
        /// Create an empty collection of Maybe
        /// </summary>
        public Maybe()
        {
            this.values = new T[0];
        }

        //TODO: implement a better Guard Code on the constructor for avoid invalid entry on value
        /// <summary>
        /// Create a collection of Maybe with just one element inside
        /// </summary>
        /// <param name="value">The only item in the collection</param>
        public Maybe(T value)
        {
            Type t = typeof(T);

            if (!t.IsPrimitive)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                //TODO: Implement a check for string when they are empty or have just spaces
            }

            this.values = new[] { value };
        }
        #endregion


        #region IEnumerable Implementations 
        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
