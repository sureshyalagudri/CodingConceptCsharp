﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Zza.Entities;
using AppClient.AppService;

namespace AppClient
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Product> _Products;
        private ObservableCollection<Customer> _Customers;
        private ObservableCollection<OrderItemModel> _Items = new ObservableCollection<OrderItemModel>();
        private Order _CurrentOrder = new Order();

        public MainWindowViewModel()
        {
            _CurrentOrder.OrderDate = DateTime.Now;
            _CurrentOrder.OrderStatusId = 1;
            SubmitOrderCommand = new DelegateCommand(OnSubmitOrder);
            AddOrderItemCommand = new DelegateCommand<Product>(OnAddItem);
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadProductsAndCustomers();
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return _Products; }
            set { SetProperty(ref _Products, value); }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set { SetProperty(ref _Customers, value); }
        }

        public ObservableCollection<OrderItemModel> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }

        public Order CurrentOrder
        {
            get { return _CurrentOrder; }
            set { SetProperty(ref _CurrentOrder, value); }
        }

        public DelegateCommand SubmitOrderCommand { get; private set; }
        public DelegateCommand<Product> AddOrderItemCommand { get; private set; }

        private void OnAddItem(Product product)
        {
            var existingOrderItem = _CurrentOrder.OrderItems.Where(oi => oi.ProductId == product.Id).FirstOrDefault();
            var existingOrderItemModel = _Items.Where(i => i.ProductId == product.Id).FirstOrDefault();
            if (existingOrderItem != null && existingOrderItemModel != null)
            {
                existingOrderItem.Quantity++;
                existingOrderItemModel.Quantity++;
                existingOrderItem.TotalPrice = existingOrderItem.UnitPrice * existingOrderItem.Quantity;
                existingOrderItemModel.TotalPrice = existingOrderItem.TotalPrice;
            }
            else
            {
                var orderItem = new OrderItem { ProductId = product.Id, Quantity = 1, UnitPrice = 9.99m, TotalPrice = 9.99m };
                _CurrentOrder.OrderItems.Add(orderItem);
                Items.Add(new OrderItemModel { ProductId = product.Id, ProductName = product.Name, Quantity = orderItem.Quantity, TotalPrice = orderItem.TotalPrice });
            }

        }

        private async void LoadProductsAndCustomers()
        {
            AppServiceClient proxy=null;
            try
            {
                proxy = new AppServiceClient("BasicHttpBinding_IAppService");
                Products = await proxy.GetProductsAsync();
                Customers = await proxy.GetCustomersAsync();
                proxy.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (proxy != null)
                    proxy.Close();
            }

        }

        private void OnSubmitOrder()
        {
            AppServiceClient proxy = null;
            try
            {
                proxy = new AppServiceClient("BasicHttpBinding_IAppService");
                proxy.SubmitOrder(_CurrentOrder);
                CurrentOrder = new Order();
                CurrentOrder.OrderDate = DateTime.Now;
                CurrentOrder.OrderStatusId = 1;
                Items = new ObservableCollection<OrderItemModel>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
    }
}
