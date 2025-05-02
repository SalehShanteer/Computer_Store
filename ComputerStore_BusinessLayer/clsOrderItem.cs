using ComputerStore_DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;

namespace ComputerStore_BusinessLayer
{
    public class clsOrderItem
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public short? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalItemsPrice { get; set; } // Computed, read-only

        public int? UserID { get; set; } // Optional, not used in the original code
                                         // (for create new order if item added using userid)

        public OrderItemDto OrderItemDto
        {
            get
            {
                return new OrderItemDto
                {
                    OrderID = this.OrderID,
                    ProductID = this.ProductID,
                    Quantity = this.Quantity,
                    Price = this.Price,
                    TotalItemsPrice = this.TotalItemsPrice,
                    UserID = this.UserID // Optional, not used in the original code
                };
            }
        }

        public clsOrderItem()
        {
            this.OrderID = 0;
            this.ProductID = 0;
            this.Quantity = 0;
            this.Price = 0m;
            this.TotalItemsPrice = 0m;
            this.UserID = 0; // Optional, not used in the original code
        }

        public clsOrderItem(OrderItemDto orderItemDto)
        {
            this.OrderID = orderItemDto.OrderID;
            this.ProductID = orderItemDto.ProductID;
            this.Quantity = orderItemDto.Quantity;
            this.Price = orderItemDto.Price;
            this.TotalItemsPrice = orderItemDto.TotalItemsPrice;
            this.UserID = orderItemDto.UserID; // Optional, not used in the original code
        }

        public OrderItemResultDto AddNew() => clsOrderItemData.AddNewOrderItem(this.OrderItemDto);

        public bool Update() => clsOrderItemData.UpdateOrderItem(this.OrderItemDto);

        public static bool Delete(OrderItemKeyDto orderItemKey) => clsOrderItemData.DeleteOrderItem(orderItemKey);

        public static clsOrderItem Find(OrderItemKeyDto orderItemKey)
        {
            OrderItemDto orderItemDto = clsOrderItemData.GetOrderItem(orderItemKey);
            if (orderItemDto is not null)
            {
                return new clsOrderItem(orderItemDto);
            }
            return null;
        }

        public static bool IsExist(OrderItemKeyDto orderItemKey) => clsOrderItemData.IsOrderItemExist(orderItemKey);


        public static List<OrderItemDto> GetOrderItemsByOrderID(int orderId) => clsOrderItemData.GetOrderItemsByOrderID(orderId);
    }
}