// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public partial class FraudRadar : IFraudRadar
    {
        private string _filePath { get; set; }
        public FraudRadar(string FilePath)
        {
            _filePath = FilePath;
        }
        public IEnumerable<FraudResult> Check()
        {
            // READ FRAUD LINES
            var orders = ReadData();
            // NORMALIZE DATA
            NormalizeData(ref orders);
            // CHECK Fraud
            var fraudResults = CheckFraud(orders);

            return fraudResults;
        }

        #region privatefunctions
        /// <summary>
        /// Read Data from an input file and to load on List<Order>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<Order> ReadData()
        {
            var orders = new List<Order>();
            try
            {
                var lines = File.ReadAllLines(_filePath);

                foreach (var line in lines)
                {
                    var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var order = new Order
                    {
                        OrderId = int.Parse(items[0]),
                        DealId = int.Parse(items[1]),
                        Email = items[2].ToLower(),
                        Street = items[3].ToLower(),
                        City = items[4].ToLower(),
                        State = items[5].ToLower(),
                        ZipCode = items[6],
                        CreditCard = items[7]
                    };
                    orders.Add(order);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            return orders;
        }
        /// <summary>
        /// Normalize Data: normalize the below data
        /// Email - Email format
        /// Street - Street and Road
        /// State - Noramlize some USA states.
        /// </summary>
        /// <param name="orders"></param>
        private void NormalizeData(ref List<Order> orders)
        {
            try
            {
                // NORMALIZE
                foreach (var order in orders)
                {
                    //Normalize email
                    var aux = order.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                    var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                    aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                    order.Email = string.Join("@", new string[] { aux[0], aux[1] });

                    //Normalize street
                    order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");

                    //Normalize state
                    order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        /// <summary>
        ///  Function to check if there is fraud on the order, the constrains are:
        ///  - It's fraud, if the Dean and Email is the same and Credit Card is different
        ///  - It's fraud, if the Dean/Post address is teh same and Credit Card is different
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        private List<FraudResult> CheckFraud(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];
                bool isFraudulent = false;

                for (int j = i + 1; j < orders.Count; j++)
                {
                    isFraudulent = false;

                    if (current.DealId == orders[j].DealId
                        && current.Email == orders[j].Email
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (current.DealId == orders[j].DealId
                        && current.State == orders[j].State
                        && current.ZipCode == orders[j].ZipCode
                        && current.Street == orders[j].Street
                        && current.City == orders[j].City
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (isFraudulent)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }
        #endregion


    }
}