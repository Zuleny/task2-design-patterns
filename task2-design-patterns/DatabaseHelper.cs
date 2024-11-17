using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace task2_design_patterns
{
    public sealed class DatabaseHelper
    {
        private static DatabaseHelper _instance;
        private DataSet dbInMemory;

        private DatabaseHelper()
        {
            dbInMemory = new DataSet("Task2DB");
            InitializeTables();
        }

        public static DatabaseHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseHelper();
            }
            return _instance;
        }

        private void InitializeTables()
        {

            DataTable pizzaTable = new DataTable("Pizza");
            pizzaTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            pizzaTable.Columns["Id"].AutoIncrementSeed = 1;
            pizzaTable.Columns.Add("Name", typeof(string));
            pizzaTable.Columns.Add("Price", typeof(decimal));
            pizzaTable.Columns.Add("Size", typeof(string));
            pizzaTable.Columns.Add("Diameter", typeof(double));
            dbInMemory.Tables.Add(pizzaTable);

            DataTable orderTable = new DataTable("Order");
            orderTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            orderTable.Columns["Id"].AutoIncrementSeed = 1;
            orderTable.Columns.Add("Number", typeof(int));
            orderTable.Columns.Add("DateTime", typeof(DateTime));
            orderTable.Columns.Add("Total", typeof(decimal));
            orderTable.Columns.Add("DeliveryType", typeof(string));
            orderTable.Columns.Add("PaymentMethod", typeof(string));
            dbInMemory.Tables.Add(orderTable);

            DataTable deliveryTable = new DataTable("Delivery");
            deliveryTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            deliveryTable.Columns["Id"].AutoIncrementSeed = 1;
            deliveryTable.Columns.Add("Description", typeof(string));
            deliveryTable.Columns.Add("Price", typeof(decimal));
            deliveryTable.Columns.Add("Latitude", typeof(double));
            deliveryTable.Columns.Add("Longitude", typeof(double));
            dbInMemory.Tables.Add(deliveryTable);

            DataTable promotionTable = new DataTable("Promotion");
            promotionTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            promotionTable.Columns["Id"].AutoIncrementSeed = 1;
            promotionTable.Columns.Add("Name", typeof(string));
            promotionTable.Columns.Add("InitDate", typeof(DateTime));
            promotionTable.Columns.Add("EndDate", typeof(DateTime));
            promotionTable.Columns.Add("Discount", typeof(decimal));
            promotionTable.Columns.Add("State", typeof(string));
            dbInMemory.Tables.Add(promotionTable);

            DataTable orderPromotionTable = new DataTable("OrderPromotion");
            orderPromotionTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            orderPromotionTable.Columns["Id"].AutoIncrementSeed = 1;
            orderPromotionTable.Columns.Add("OrderId", typeof(int));
            orderPromotionTable.Columns.Add("PromotionId", typeof(int));
            dbInMemory.Tables.Add(orderPromotionTable);

            DataTable ingredientTable = new DataTable("Ingredient");
            ingredientTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            ingredientTable.Columns["Id"].AutoIncrementSeed = 1;
            ingredientTable.Columns.Add("Name", typeof(string));
            ingredientTable.Columns.Add("Type", typeof(string));
            dbInMemory.Tables.Add(ingredientTable);

            DataTable pizzaIngredientTable = new DataTable("PizzaIngredient");
            pizzaIngredientTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            pizzaIngredientTable.Columns["Id"].AutoIncrementSeed = 1;
            pizzaIngredientTable.Columns.Add("PizzaId", typeof(int));
            pizzaIngredientTable.Columns.Add("IngredientId", typeof(int));
            pizzaIngredientTable.Columns.Add("Quantity", typeof(int));
            dbInMemory.Tables.Add(pizzaIngredientTable);

            DataTable pizzaOrderTable = new DataTable("PizzaOrder");
            pizzaOrderTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            pizzaOrderTable.Columns["Id"].AutoIncrementSeed = 1;
            pizzaOrderTable.Columns.Add("PizzaId", typeof(int));
            pizzaOrderTable.Columns.Add("OrderId", typeof(int));
            pizzaOrderTable.Columns.Add("Quantity", typeof(int));
            dbInMemory.Tables.Add(pizzaOrderTable);

            dbInMemory.Relations.Add("Order_Delivery", orderTable.Columns["Id"], deliveryTable.Columns["Id"], false);
            dbInMemory.Relations.Add("Order_Promotion", orderTable.Columns["Id"], orderPromotionTable.Columns["OrderId"], false);
            dbInMemory.Relations.Add("Promotion_OrderPromotion", promotionTable.Columns["Id"], orderPromotionTable.Columns["PromotionId"], false);
            dbInMemory.Relations.Add("Pizza_PizzaOrder", pizzaTable.Columns["Id"], pizzaOrderTable.Columns["PizzaId"], false);
            dbInMemory.Relations.Add("Order_PizzaOrder", orderTable.Columns["Id"], pizzaOrderTable.Columns["OrderId"], false);
            dbInMemory.Relations.Add("Pizza_PizzaIngredient", pizzaTable.Columns["Id"], pizzaIngredientTable.Columns["PizzaId"], false);
            dbInMemory.Relations.Add("Ingredient_PizzaIngredient", ingredientTable.Columns["Id"], pizzaIngredientTable.Columns["IngredientId"], false);

            ingredientTable.Rows.Add(null, "Mozzarella", "Cheese");
            ingredientTable.Rows.Add(null, "Tomato Sauce", "Sauce");
            ingredientTable.Rows.Add(null, "Pepperoni", "Meat");
            ingredientTable.Rows.Add(null, "Mushrooms", "Vegetable");
            ingredientTable.Rows.Add(null, "Olives", "Vegetable");

        }

        public DataTable GetTable(string tableName)
        {
            if (!dbInMemory.Tables.Contains(tableName))
            {
                throw new ArgumentException($"Table '{tableName}' does not exist.");
            }

            return dbInMemory.Tables[tableName];
        }


    }
}
