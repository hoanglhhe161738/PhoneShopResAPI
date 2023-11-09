using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;
using PhoneShopResAPI.Services;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPAYController : Controller
    {
        private readonly IVnPayService _vnPayService;

        public VNPAYController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost(Name = "create-payment")]
        public Link CreatePaymentUrl(PaymentInformationModel model)
        {
            Link link = new Link();
            link.name = model.Name;
            link.value = _vnPayService.CreatePaymentUrl(model, HttpContext);
            return link;
        }
        [HttpGet]
        public IActionResult PaymentCallback()
        {
            PaymentResponseModel response = (PaymentResponseModel)_vnPayService.PaymentExecute(Request.Query);
            ViewBag.Response = response;
            return View("/Views/Result.cshtml", response);
        }
        public IActionResult Index()
        {
            return View();
        }
    }

}
