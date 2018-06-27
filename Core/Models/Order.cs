using System;
using System.ComponentModel.DataAnnotations;
using WebApiJwt.Core;
using WebApiJwt.Resources.ModelsDto;

namespace WebApiJwt.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        //TODO: [Required]
        public ApplicationUser ApplicationUser { get; set; }
        //TODO: [Required]
        public string CreatedBy { get; set; }
        //TODO: [Required]
        public string Description { get; set; }
        //TODO: [Required]
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
