using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class OrderFileReader
    {
        private readonly IOrderParser _parser;
        private readonly IOrderModifier _modifier;
        private readonly string _filePath;

        /// <summary>
        /// Constructs an OrderFileReader instance.
        /// </summary>
        /// <param name="filePath">An absolute or a relative path to a file containing orders data</param>
        /// <param name="parser">A parser to process raw data.</param>
        /// <param name="modifier">Modifies the raw parsed data.
        /// Might be an "EmptyModifier" (with no logic required to be applied)
        /// or a number of wrapper classes, e.g. new Normalizer(new NameCapitalizer())                      
        /// </param>
        public OrderFileReader(string filePath, IOrderParser parser, IOrderModifier modifier)
        {
            if (parser == null)
                throw new ArgumentNullException("parser");
            if (modifier == null)
                throw new ArgumentNullException("modifier");
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("A filePath should not be empty.");
            if (!File.Exists(filePath))
                throw new ArgumentException(string.Format("Failed to find a file specified as {0} (the absolute path was resolved as {1})",
                    filePath, Path.Combine(Environment.CurrentDirectory, filePath)));

            _parser = parser;
            _modifier = modifier;
            _filePath = filePath;
        }

        public IEnumerable<FraudRadar.Order> ReadAll()
        {
            return File.ReadAllLines(_filePath)
                .Select(item => _parser.Parse(item))
                .Apply(_modifier);
        }
    }
}
