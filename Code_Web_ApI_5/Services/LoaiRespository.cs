using Code_Web_ApI_5.Data;
using Code_Web_ApI_5.Models;

namespace Code_Web_ApI_5.Services
{
    public class LoaiRespository : ILoaiRepository
    {
        private MyDbContext _context;

        public LoaiRespository(MyDbContext context) 
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai,
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai,
            };
        }

        public void Delete(int id)
        {
            var loais = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (loais != null) 
            {
                _context.Remove(loais);
                _context.SaveChanges() ;
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(
                lo => new LoaiVM
                {
                    MaLoai = lo.MaLoai,
                    TenLoai = lo.TenLoai,
                });
            return loais.ToList();
        }

        public LoaiVM GetbyId(int id)
        {
            var loais = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (loais != null)
            {
                return new LoaiVM 
                {
                    MaLoai = loais.MaLoai,
                    TenLoai = loais.TenLoai,
                };
            }
            return null;
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(c => c.MaLoai == loai.MaLoai);
            _loai.TenLoai = loai.TenLoai;
            _context.SaveChanges();
        }
    }
}
