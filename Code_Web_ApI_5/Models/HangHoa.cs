namespace Code_Web_ApI_5.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }

    public class HangHoa : HangHoaVM 
    {
        public Guid MaHangHoa { get; set; }
        
    }
}
