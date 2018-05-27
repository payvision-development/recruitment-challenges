// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException("input should be a zero or a positive number");

            if (input == 0)
                return new[] { 0 };

            var binaryRepresentation = Convert.ToString(input, 2).Reverse().ToArray();

            var result = new List<int>();
            for (var i=0; i< binaryRepresentation.Length; i++)
            {
                if (binaryRepresentation[i] == '1')
                {
                    result.Add(i);
                }
            }

            result.Insert(0, result.Count);

            return result;
        }


    }
}