using System;
using WebApiJwt.Core;
using WebApiJwt.Resources.ModelsDto;

namespace WebApiJwt.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public static Order ConvertFromSaveOrderDto(SaveOrderDto orderDto, DateTime createdAt, ApplicationUser applicationUser)
        {
            return new Order
            {
                Description = orderDto.Description,
                CreatedAt = createdAt,
                ApplicationUser = applicationUser
            };
        }
        
        public Order ConvertFormSaveOrderDto(SaveOrderDto orderDto)
        {
            Description = orderDto.Description;

            return this;
        }
    }
}
