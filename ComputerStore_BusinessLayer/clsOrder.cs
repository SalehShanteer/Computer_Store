using ComputerStore_DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;

namespace ComputerStore_BusinessLayer
{
    public class clsOrder
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ID { get; set; }
        public int? UserID { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public byte? Status { get; set; } // 0 => Canceled, 1 => Draft, 2 => Pending, 3 => Processing, 4 => Delivered

        public OrderDto OrderDto
        {
            get
            {
                return new OrderDto
                {
                    ID = this.ID,
                    UserID = this.UserID,
                    TotalAmount = this.TotalAmount,
                    OrderDate = this.OrderDate,
                    Status = this.Status
                };
            }
        }

        public clsOrder()
        {
            this.ID = null;
            this.UserID = null;
            this.TotalAmount = null;
            this.OrderDate = null;
            this.Status = null;

            _Mode = enMode.AddNew;
        }

        public clsOrder(OrderDto orderDto, enMode mode)
        {
            this.ID = orderDto.ID;
            this.UserID = orderDto.UserID;
            this.TotalAmount = orderDto.TotalAmount;
            this.OrderDate = orderDto.OrderDate;
            this.Status = orderDto.Status;

            _Mode = mode;
        }

        private bool AddNewOrder()
        {
            this.ID = clsOrderData.AddNewOrder(this.OrderDto);
            return this.ID is not null;
        }

        private bool UpdateOrder() => clsOrderData.UpdateOrder(this.OrderDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewOrder())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return UpdateOrder();
            }
            return false;
        }

        public static bool ChangeStatus(OrderStatusDto orderStatusDto) => clsOrderData.ChangeOrderStatus(orderStatusDto);

        public static bool Delete(int orderId) => clsOrderData.DeleteOrder(orderId);

        public static clsOrder Find(int orderId)
        {
            OrderDto orderDto = clsOrderData.GetOrderByID(orderId);
            if (orderDto is not null)
            {
                return new clsOrder(orderDto, enMode.Update);
            }
            return null;
        }

        public static clsOrder FindCurrent(int? userId)
        {
            OrderDto orderDto = clsOrderData.GetCurrentOrderByUserID(userId
                );
            if (orderDto is not null)
            {
                return new clsOrder(orderDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? orderId) => clsOrderData.IsOrderExist(orderId);

        public static List<OrderDto> GetAllOrders() => clsOrderData.GetAllOrders();

        public static List<OrderDto> GetOrdersByUserID(int userId) => clsOrderData.GetOrdersByUserID(userId);
    }
}