using Code_Web_ApI_5.Models;

namespace Code_Web_ApI_5.Services
{
    public class LoaiRespositoryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM>
        {
            new LoaiVM { MaLoai = 1,TenLoai = "Ti vi"},
            new LoaiVM { MaLoai = 2,TenLoai = "Tủ lạnh"},
            new LoaiVM { MaLoai = 3,TenLoai = "Điều hòa "},
            new LoaiVM { MaLoai = 4,TenLoai = "Máy giặt"},
        };
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new LoaiVM {
                MaLoai =  loais.Max(c=>c.MaLoai) +1,
                TenLoai = loai.TenLoai,
            };
            loais.Add(_loai);
            return _loai;
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(c => c.MaLoai == id);
            loais.Remove(_loai);

        }

        public List<LoaiVM> GetAll()
        {
            return  loais;
        }

        public LoaiVM GetbyId(int id)
        {
            return loais.SingleOrDefault(c => c.MaLoai == id);
        }

        public void Update(LoaiVM loai)
        {
            var _loai= loais.SingleOrDefault(c => c.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
        }
    }
}
