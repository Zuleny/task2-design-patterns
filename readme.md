
# task2_design_patterns

## Endpoints

### POST /Order
#### Description:
Este endpoint permite crear un nuevo pedido

#### Request Body:
- **Example 1:**
```json
{
  "number": 2,
  "dateTime": "2024-11-15T04:42:40Z",
  "deliveryType": "entrega",
  "paymentMethod": "efectivo",
  "pizzaOrderDto": [
    {
      "pizzaId": 1,
      "quantity": 3
    }
  ],
  "promotionIds": [
    1
  ]
}
```

### POST /Pizza
#### Description:
Este endpoint permite crear una nueva pizza

#### Nota: 
El parametro type (string) es el tipo de pizza (Ej. "Margarita", "Peperoni","Personalizada").

#### Request Body:
- **Example 1 (Pizza Margarita):**
```json
{
  "name": "Margarita Familiar",
  "price": 80,
  "size": "grande",
  "diameter": 50.8,
  "type": "Margarita"
}
```
- **Example 2 (Pizza Personalizada):**
```json
{
  "name": "Pizza Hawaina",
  "price": 45.5,
  "size": "grande",
  "diameter": 30.5,
  "type": "Personalizada",
  "pizzaIngredientDto": [
    {
      "ingredientId": 1,
      "quantity": 1
    }
  ]
}
```
### POST /Promotion
#### Description:
Este endpoint permite crear una nueva promocion

#### Request Body:
- **Example 1:**
```json
{
  "name": "2x1",
  "initDate": "2024-11-15T04:42:40Z",
  "endDate": "2025-11-15T04:42:40Z",
  "discount": 50,
  "state": "enabled"
}
```