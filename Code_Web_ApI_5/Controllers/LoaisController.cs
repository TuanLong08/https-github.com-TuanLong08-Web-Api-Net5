using Code_Web_ApI_5.Data;
using Code_Web_ApI_5.Models;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);
            }
            catch (Exception)
            {

                return BadRequest();
            }
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
                return NotFound();//khong tìm thấy id
            }
        }

        [HttpPost]
        //[Authorize]
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
                //return Ok(loai); //Cách 1 
                //Cách 2
                return StatusCode(StatusCodes.Status201Created, loai);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (Loai != null)
            {
                _context.Loais.Remove(Loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();//khong tìm thấy id
            }
        }
    }
}
