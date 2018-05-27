// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
            {
                throw new ArgumentException("The input number is not a positive value");
            }

            List<int> result = new List<int>();

            result.Add(0);

            string binaryValue = Convert.ToString(input, 2);

            for (int i = binaryValue.Length - 1; i >= 0; i--)
            {
                if (binaryValue[i] == '1')
                {
                    result[0]++;
                    result.Add((binaryValue.Length -1) - i);
                }
            }

            return result;
        }
    }
}