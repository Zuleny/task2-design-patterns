using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using task2_design_patterns.Dtos;
namespace task2_design_patterns.Services
{
    public class OrderService
    {
        private readonly DatabaseHelper DbHelper;

        public OrderService()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }

        public int CreateOrder(CreateOrderDto orderDto)
        {
            var orderTable = DbHelper.GetTable("Order");
            var pizzaOrderTable = DbHelper.GetTable("PizzaOrder");
            var orderPromotionTable = DbHelper.GetTable("OrderPromotion");

            var newRow = orderTable.NewRow();
            newRow["number"] = orderDto.Number;
            newRow["datetime"] = orderDto.DateTime.ToString();
            newRow["deliverytype"] = orderDto.DeliveryType;
            newRow["paymentmethod"] = orderDto.PaymentMethod;
            orderTable.Rows.Add(newRow);

            int orderId = (int)newRow["id"];

            foreach (var pizzaOrderDto in orderDto.PizzaOrderDto)
            {
                var pizzaOrderRow = pizzaOrderTable.NewRow();
                pizzaOrderRow["OrderId"] = orderId;
                pizzaOrderRow["PizzaId"] = pizzaOrderDto.PizzaId;
                pizzaOrderRow["quantity"] = pizzaOrderDto.Quantity;
                pizzaOrderTable.Rows.Add(pizzaOrderRow);
            }

            foreach (var promotionId in orderDto.PromotionIds)
            {
                var orderPromotionRow = orderPromotionTable.NewRow();
                orderPromotionRow["OrderId"] = orderId;
                orderPromotionRow["PromotionId"] = promotionId;
                orderPromotionTable.Rows.Add(orderPromotionRow);
            }

            return orderId;

        }
    }
}
