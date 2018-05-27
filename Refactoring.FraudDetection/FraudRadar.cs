// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using Payvision.CodeChallenge.Refactoring.FraudDetection.Implementations;
    using Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;


    public class FraudRadar
    {
        private readonly IOrderProcessProvider _orderProcessProvider;
        private readonly IFraudCheckProvider _fraudCheckProvider;

        public FraudRadar()
        {
            _orderProcessProvider = new DefaultOrderProcessProvider();
            _fraudCheckProvider = new DefaultFraudCheckProvider();
        }

        public FraudRadar(IOrderProcessProvider orderProcessProvider, IFraudCheckProvider fraudCheckProvider)
        {
            _orderProcessProvider = orderProcessProvider;
            _fraudCheckProvider = fraudCheckProvider;
        }



        /// I Leave this commented function as a alternative to the memorystream input variant,
        /// In some scenarios this option would be more optimal

        #region IEnumerable_FraudResult_Check_byte_array_binaryFil)

        //public IEnumerable<FraudResult> Check(byte[] binaryFile)
        //{
        //    MemoryStream ms = new MemoryStream(binaryFile);
        //    StreamReader orderReader = new StreamReader(ms, System.Text.Encoding.UTF8, true);
        //    List<string> orderLines = new List<string>();

        //    // READ FRAUD LINES FROM MemoryStream
        //    string line;
        //    while ((line = orderReader.ReadLine()) != null)
        //    {
        //        orderLines.Add(line);
        //    }
        //    var orders = _orderProcessProvider.GetOrderList(orderLines.ToArray());

        //    // CHECK FRAUD
        //    var fraudResults = _fraudCheckProvider.Check(orders);


        //    return fraudResults;
        //}   

        #endregion

        public IEnumerable<FraudResult> Check(MemoryStream fileStream)
        {
            StreamReader orderReader = new StreamReader(fileStream, System.Text.Encoding.UTF8, true);
            List<string> orderLines = new List<string>();

            // READ FRAUD LINES FROM MemoryStream
            string line;
            while ((line = orderReader.ReadLine()) != null)
            {
                orderLines.Add(line);
            }
            var orders = _orderProcessProvider.GetOrderList(orderLines.ToArray());

            // CHECK FRAUD
            var fraudResults = _fraudCheckProvider.Check(orders);


            return fraudResults;

        }
        
        public IEnumerable<FraudResult> Check(string filePath)
        {

            // READ FRAUD LINES
            var orders = _orderProcessProvider.GetOrderList(File.ReadAllLines(filePath));

            // CHECK FRAUD
            var fraudResults = _fraudCheckProvider.Check(orders);

            return fraudResults;
        }


        public class FraudResult
        {
            public int OrderId { get; set; }

            public bool IsFraudulent { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }

            public int DealId { get; set; }

            public string Email { get; set; }

            public string Street { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string ZipCode { get; set; }

            public string CreditCard { get; set; }
        }

    }
}