using System;
using WebApiJwt.Core;

namespace WebApiJwt.Resources.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string OrderDescrpition { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
