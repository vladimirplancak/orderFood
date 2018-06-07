using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Resources.Models;

namespace WebApiJwt.Resources.ModelsDto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public string CreatedBy { get; set; }

        public static OrderDto ConvertFromOrder(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                UserId = order.ApplicationUser != null ? order.ApplicationUser.Id : null,
                Description = order.Description,
                CreatedBy = order.ApplicationUser != null ? order.ApplicationUser.FullName : null
            };
        }
    }
}
