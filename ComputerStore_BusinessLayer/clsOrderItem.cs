using ComputerStore_DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;

namespace ComputerStore_BusinessLayer
{
    public class clsOrderItem
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalItemsPrice { get; set; } // Computed, read-only

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
                    TotalItemsPrice = this.TotalItemsPrice
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

            _Mode = enMode.AddNew;
        }

        public clsOrderItem(OrderItemDto orderItemDto, enMode mode)
        {
            this.OrderID = orderItemDto.OrderID;
            this.ProductID = orderItemDto.ProductID;
            this.Quantity = orderItemDto.Quantity;
            this.Price = orderItemDto.Price;
            this.TotalItemsPrice = orderItemDto.TotalItemsPrice;

            _Mode = mode;
        }

        private bool AddNewOrderItem() => clsOrderItemData.AddNewOrderItem(this.OrderItemDto);

        private bool UpdateOrderItem() => clsOrderItemData.UpdateOrderItem(this.OrderItemDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewOrderItem())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return UpdateOrderItem();
            }
            return false;
        }

        public static bool Delete(int orderId, int productId) => clsOrderItemData.DeleteOrderItem(orderId, productId);

        public static clsOrderItem Find(int orderId, int productId)
        {
            OrderItemDto orderItemDto = clsOrderItemData.GetOrderItemByID(orderId, productId);
            if (orderItemDto is not null)
            {
                return new clsOrderItem(orderItemDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int orderId, int productId) => clsOrderItemData.IsOrderItemExist(orderId, productId);


        public static List<OrderItemDto> GetOrderItemsByOrderID(int orderId) => clsOrderItemData.GetOrderItemsByOrderID(orderId);
    }
}