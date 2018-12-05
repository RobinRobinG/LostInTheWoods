using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LostInWoods.Models
{
    public class Trail
    {
        [Key]
        public int Id { get; set; }
 
        [Required (ErrorMessage = "Name is required")]
        [MinLength(3)]
        [DisplayName("Trail Name")]
        public string Name { get; set; }
 
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
 
        [Required]
        [DisplayName("Elevation")]
        public int Elevation { get; set; }

        [Required]
        [DisplayName("Length")]
        public float Length { get; set; }  

        [Required]
        [DisplayName("Longitude")]
        public float Longitude { get; set; }

        [Required]
        [DisplayName("Latitude")]
        public float Latitude { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }  

      // create an empty contruactor 
        public Trail(){}
    }
}