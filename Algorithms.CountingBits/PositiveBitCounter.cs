// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            List<int> result = new List<int>();
            if ( input >= 0)
            {
                var str = Convert.ToString(input, 2);
                int numberTimesOne = str.Count(x => x == '1');
                result.Add(numberTimesOne);
                var strReverse = str.Reverse().ToArray();
                for ( int i =0; i< strReverse.Count();i++)
                {
                    if (strReverse[i] == '1')
                        result.Add(i);
                    if ((numberTimesOne+1) == result.Count())
                        return result;
                }
            }
            else
            {
                throw new ArgumentException();
            }
            return result;
        }
   
    }
}
