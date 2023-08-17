using Code_Web_ApI_5.Data;
using Code_Web_ApI_5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_Web_ApI_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        //DI : dependency injection : tiêm phụ thuộc 
        public LoaisController(MyDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var dsLoai =   _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var Loai = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (Loai != null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai,
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id,LoaiModel model)
        {
            var Loai = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (Loai != null)
            {
                Loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
