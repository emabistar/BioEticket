﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Models;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Data.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly AppDbContext _context;

        public OrdersService (AppDbContext context)
        {
            _context = context;
        }
       

        public Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = _context.Orders.Include(n=>n.OrderItems).ThenInclude(n=>n.Movie).Where(n=>n.UserId == userId).ToListAsync();
            return orders;
        }

        public async  Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                { Amount = item.Amount,
                  MovieId = item.Movie.Id,
                  OrderId = order.Id,
                  Price = item.Movie.Price

                };

                await _context.OrderItems.AddAsync(orderItem);

            }
            await _context.SaveChangesAsync();
        }
    }
}
