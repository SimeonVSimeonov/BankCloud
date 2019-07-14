//using BankCloud.Data.Entities.Enums;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace BankCloud.Data.Entities
//{
//    public class Order
//    {
//        public Order()
//        {
//            this.OrderLoans = new HashSet<OrderLoans>();
//            this.OrderInsurances = new HashSet<OrderInsurances>();
//        }

//        public string Id { get; set; }

//        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

//        public DateTime? CompletedOn { get; set; }

//        public decimal CostPrice { get; set; }

//        [Required]
//        public string ContractorId { get; set; }
//        public BankUser Contractor { get; set; }

//        public ICollection<OrderLoans> OrderLoans { get; set; }
//        public ICollection<OrderInsurances> OrderInsurances { get; set; }

//        [Required]
//        public OrderStatus Status { get; set; }

//    }
//}