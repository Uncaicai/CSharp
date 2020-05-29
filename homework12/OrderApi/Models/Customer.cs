//顾客类
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models {
    public class Customer{
        //key
        [Key]
        //主键自增
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID{get;set;}
        [Required]
        public string Name{get;set;}
        public string Address{get;set;}

        // public Customer(){}

        // public Customer(string name,string address) {
        //     Name = name;
        //     Address = address;
        // }
    }
}