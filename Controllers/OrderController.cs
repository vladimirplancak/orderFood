using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Core;
using WebApiJwt.Core.Models;
using WebApiJwt.Core.Repositories;
using WebApiJwt.Interfaces;
using WebApiJwt.Interfaces.Repositories;
using WebApiJwt.Resources.ModelsDto;

namespace WebApiJwt.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>Return orders</returns>
        [Route("api/Order")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.Get(includeDetails: true);
            List<OrderDto> ordersDto = orders.Select(it => OrderDto.ConvertFromOrder(it)).ToList();

            return Ok(ordersDto);
        }

        [Route("api/Order/{id}")]
        [HttpGet]
        public IActionResult GetOrder(int id)
        {
            var order = _orderRepository.Get(id, includeDetails: true);
            if (order == null)
                return NotFound();

            var orderDto = OrderDto.ConvertFromOrder(order);

            return Ok(orderDto);
        }

        [Route("api/Order")]
        [HttpPost]
        public async Task<IActionResult> SaveOrderAsync([FromBody]SaveOrderDto saveOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);

            var order = Order.ConvertFromSaveOrderDto(saveOrderDto, DateTime.Now, loggedUser);

            var savedOrder = _orderRepository.Save(order);
            var retVal = OrderDto.ConvertFromOrder(savedOrder);

            return Ok(retVal);

        }

        [Route("api/Order/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]SaveOrderDto saveOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var order = _orderRepository.Get(id);
            if (order == null)
                return NotFound();

            order.ConvertFormSaveOrderDto(saveOrderDto);
            _unitOfWork.SaveChanges();

            var updatedOrder = _orderRepository.Get(order.Id);

            return Ok(OrderDto.ConvertFromOrder(updatedOrder));
            
        }

        [Route("api/Order/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var order = _orderRepository.Get(id);
            if(order != null)
            {
                _orderRepository.Delete(order);
                return NoContent();
            }

            return NotFound();
        }
    }
}