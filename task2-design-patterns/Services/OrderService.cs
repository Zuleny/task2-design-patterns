using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using task2_design_patterns.Dtos;
using task2_design_patterns.Models;

namespace task2_design_patterns.Services
{
    public class OrderService
    {
        private readonly DatabaseHelper DbHelper;

        public OrderService()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }

        public Order CreateOrder(CreateOrderDto orderDto)
        {
            var orderTable = DbHelper.GetTable("Order");
            var pizzaOrderTable = DbHelper.GetTable("PizzaOrder");
            var orderPromotionTable = DbHelper.GetTable("OrderPromotion");

            var newRow = orderTable.NewRow();
            newRow["number"] = orderDto.Number;
            newRow["datetime"] = orderDto.DateTime.ToString();
            newRow["total"] = 0;
            newRow["deliverytype"] = orderDto.DeliveryType;
            newRow["paymentmethod"] = orderDto.PaymentMethod;
            orderTable.Rows.Add(newRow);

            int orderId = (int)newRow["id"];

            decimal basePrice = 0;
            foreach (var pizzaOrderDto in orderDto.PizzaOrderDto)
            {
                var pizzaOrderRow = pizzaOrderTable.NewRow();
                pizzaOrderRow["OrderId"] = orderId;
                pizzaOrderRow["PizzaId"] = pizzaOrderDto.PizzaId;
                pizzaOrderRow["quantity"] = pizzaOrderDto.Quantity;
                pizzaOrderTable.Rows.Add(pizzaOrderRow);

                basePrice += GetPizzaPrice(pizzaOrderDto.PizzaId) * pizzaOrderDto.Quantity;
            }

            decimal finalPrice = basePrice;
            foreach (var promotionId in orderDto.PromotionIds)
            {
                var strategy = PromotionStrategyFactory.GetStrategy(promotionId);
                finalPrice = strategy.ApplyPromotion(orderDto, finalPrice);

                var orderPromotionRow = orderPromotionTable.NewRow();
                orderPromotionRow["OrderId"] = orderId;
                orderPromotionRow["PromotionId"] = promotionId;
                orderPromotionTable.Rows.Add(orderPromotionRow);
            }

            newRow["total"] = finalPrice;

            return new Order(orderId, orderDto.Number, orderDto.DateTime, finalPrice, orderDto.DeliveryType, orderDto.PaymentMethod);

        }

        private decimal GetPizzaPrice(int pizzaId)
        {
            var pizzaTable = DbHelper.GetTable("Pizza");

            var rows = pizzaTable.Select($"Id = {pizzaId}");

            if (rows.Length > 0)
            {
                return Convert.ToDecimal(rows[0]["Price"]);
            }

            return 0;
        }

    }
}
