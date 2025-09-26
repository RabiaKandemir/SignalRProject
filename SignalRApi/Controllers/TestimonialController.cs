using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstact;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
               Comment = createTestimonialDto.Comment,
               ImageUrl = createTestimonialDto.ImageUrl,
               Name = createTestimonialDto.Name,
               Status = createTestimonialDto.Status,
               Title = createTestimonialDto.Title,
            });
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID=updateTestimonialDto.TestimonialID,
                Comment=updateTestimonialDto.Comment,
                ImageUrl=updateTestimonialDto.ImageUrl,
                Name=updateTestimonialDto.Name,
                Status=updateTestimonialDto.Status,
                Title=updateTestimonialDto.Title,
            });
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde Güncellendi.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
