using Code_Web_ApI_5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_Web_ApI_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]

        public IActionResult GetAll() 
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id) 
        {

            try
            {
                //LinQ Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                    // NotFound sẽ trả về 1 cái status code 404
                }
                return Ok(hangHoa);
            }
            catch (Exception)
            {

                return BadRequest();
                //BadRequest trả về 1 yêu cầu này không hợp lệ 
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,Data = hanghoa
            });;
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit) 
        {
            try
            {
                //LinQ Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                    // NotFound sẽ trả về 1 cái status code 404
                }
                if (id != hangHoa.MaHangHoa.ToString()) 
                {
                    return BadRequest();
                }
                //Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
                //BadRequest trả về 1 yêu cầu này không hợp lệ 
            }   
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id) 
        {
            try
            {
                //LinQ Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                    // NotFound sẽ trả về 1 cái status code 404
                }
                //Delete 
                hangHoas.Remove(hangHoa);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
                //BadRequest trả về 1 yêu cầu này không hợp lệ 
            }
        }
    }
}
