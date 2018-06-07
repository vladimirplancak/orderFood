using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Core;
using WebApiJwt.Core.Repositories;
using WebApiJwt.Interfaces.Repositories;
using WebApiJwt.Resources.Models;

namespace WebApiJwt.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public OrderController(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.orderRepository = orderRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("api/Order")]
        [HttpGet]
        public ActionResult GetOrders()
        {
            var orders = orderRepository.Get();

            return Ok(orders);
        }

        [Route("api/Order")]
        [HttpPost]
        public async Task<ActionResult> SaveOrderAsync([FromBody]Order order)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            order.ApplicationUser = user;
            var savedOrder = orderRepository.Save(order);

            return Ok(savedOrder);
        }
    }
}