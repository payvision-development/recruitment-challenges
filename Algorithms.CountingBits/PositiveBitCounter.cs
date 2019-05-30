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
                throw new ArgumentException("The input value should be positive.");
            else if (input == 0)
                return new List<int>() { 0 };
            else
            {
                char[] binaryRepresentation = Convert.ToString(input, 2).ToCharArray();
                List<int> result = new List<int>();
                int binaryLength = binaryRepresentation.Length;
                for (int index = binaryLength - 1; index >= 0; index--)
                {
                    if(binaryRepresentation[index] == '1')
                    {
                        result.Add(binaryLength - 1 - index);
                    }
                }
                result.Insert(0, result.Count);
                return result;
            }            
        }
    }
}