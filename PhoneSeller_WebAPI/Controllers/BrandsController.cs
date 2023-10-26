using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Brands.GetBrand;
using PhoneSeller_WebAPI.App.Brands.GetBrands;
using PhoneSeller_WebAPI.Models;
using MediatR;
using PhoneSeller_WebAPI.Response;
using PhoneSeller_WebAPI.App.Brands.CreateBrand;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    //[Route("[controller]/[action]")]
    public class BrandsController : BaseController
    {
        //private readonly PhoneSellerContext _context;
        //public BrandsController(PhoneSellerContext context)
        //{
        //    _context = context;

        //}
        [HttpGet("brands")]
        public async Task<BaseListResponse<GetBrandsResponseModel>> GetBrandsList([FromQuery] GetBrandsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("brand/{brandId}")]
        public async Task<GetBrandResponseModel> GetBrand([FromQuery] GetBrandCommand command, [FromRoute] int brandId)
        {
            command.BrandId = brandId;

            return await Mediator.Send(command);
        }

        [HttpPost("brand")]
        public async Task<CreateBrandResponseModel> CreateBrand([FromQuery] CreateBrandCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("brand/{brandId}")]
        public async Task<UpdateBrandResponseModel> UpdateBrand([FromQuery] UpdateBrandCommand command, [FromRoute] int brandId)
        {
            command.BrandId = brandId;

            return await Mediator.Send(command);
        }

        [HttpDelete("brand/{brandId}")]
        public async Task<DeleteBrandResponseModel> DeleteBrand([FromQuery] DeleteBrandCommand command, [FromRoute] int brandId)
        {
            command.BrandId = brandId;

            return await Mediator.Send(command);
        }
    }
}
