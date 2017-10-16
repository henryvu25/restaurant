using System;
using System.ComponentModel.DataAnnotations;

namespace restaurant_project.Models
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
    public abstract class BaseEntity {}
    public class Review
    {
        public int id {get;set;}
        [Required]
        public string name {get;set;}
        [Required]
        public string restaurant {get;set;}
        [Required]
        [MinLength(10)]
        public string review {get;set;}
        [Required]
        public int stars {get;set;}
        [Required]
        [CurrentDate(ErrorMessage = "Cannot input future date")]
        public DateTime visited {get;set;}
    }
}