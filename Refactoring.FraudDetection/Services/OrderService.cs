using System;
using System.Collections.Generic;
using System.IO;

namespace Refactoring.FraudDetection
{
    public class OrderService : IOrderService
    {
        private readonly INormalizeService _normalizeService;
        private readonly string _filePath;
        public OrderService(INormalizeService normalizeService,
                            string filePath)
        {
            _normalizeService = normalizeService;
            _filePath = filePath;
        }
        public IEnumerable<Order> LoadOdersFromFile(string filePath)
        {
            var orders = new List<Order>();
            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var order = new Order(
                        orderId: int.Parse(items[0]),
                        dealId: int.Parse(items[1]),
                        email: items[2].ToLower(),
                        street: items[3].ToLower(),
                        city: items[4].ToLower(),
                        state: items[5].ToLower(),
                        zipCode: items[6],
                        creditCard: items[7]
                    );
                    _normalizeService.NormalizeEmail(order.Email);
                    _normalizeService.NormalizeState(order.State);
                    _normalizeService.NormalizeStreet(order.Street);
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
      
    }
}
