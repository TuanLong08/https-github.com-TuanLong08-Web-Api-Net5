using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_Web_ApI_5.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }

        [Required] //Bắt buộc phải nhập
        [MaxLength(100)] //kí tự mã là 100 kí tự
        public string TenHh { get; set; }

        public string MoTa { get; set; }


        [Range(0,double.MaxValue)] // Đơn giá nếu không có thì nhận giá trị 0
                                   // còn giá trị max thì ko có
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public ICollection<DonHangChiTiet> donHangChiTiets { get; set; }
        public HangHoa()
        {
            donHangChiTiets = new HashSet<DonHangChiTiet>();
        }
    }
}
