using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Cart;
using bioticket.Data.Services;
using bioticket.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bioticket.Controllers
{
    public class OrdersController : Controller
    {
        private  readonly IMoviesService _movieservice;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IMoviesService movieservice, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _movieservice = movieservice;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public  async Task <IActionResult> Index()
        {
            var userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            // Return a list of choppingcartItem
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task <ActionResult> AddItemToShoppingCart( int id)
        {
            var item = await _movieservice.GetMovieByIdAsync(id);
            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<ActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieservice.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task <IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";
            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View();
        }
    }
}
