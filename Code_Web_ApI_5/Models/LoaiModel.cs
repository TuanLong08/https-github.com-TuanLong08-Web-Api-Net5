using Code_Web_ApI_5.Data;
using System.ComponentModel.DataAnnotations;

namespace Code_Web_ApI_5.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}
