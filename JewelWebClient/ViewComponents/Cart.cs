﻿using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using JewelWebClient.Models;

using JewelWebClient.Services;
using JewelWebClient.ViewModels;

namespace JewelWebClient.ViewComponents
    {
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public Cart(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user) 
        {

            
            var vm = new CartComponentViewModel();
            try
            {
                var cart = await _cartSvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch(BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
            }
            
            return View(vm);
        }

    }
}
