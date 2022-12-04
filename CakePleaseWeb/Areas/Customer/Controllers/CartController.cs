using CakePlease.DataAccess.Repository.IRepository;
using CakePlease.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CakePleaseWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public int OrderTotal { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM() { 
                ListshoppingCart = _unitOfWork.ShoppingCart.GetAll(c=>c.ApplicationUserId == claim.Value, 
                includeProperties:"Product")
            };
            foreach(var cart in ShoppingCartVM.ListshoppingCart)
            {
                ShoppingCartVM.CartPrice += (cart.Product.Price * cart.Count);

			}
            return View(ShoppingCartVM);
        }

        public IActionResult Plus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c=>c.Id== cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            _unitOfWork.Save();

			return RedirectToAction(nameof(Index));

		}

		public IActionResult Minus(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.Id== cartId);
            if (cart.Count < 1)
            {
				_unitOfWork.ShoppingCart.Remove(cart);
			}
            else
            {
				_unitOfWork.ShoppingCart.DecrementCount(cart, 1);
			}
			_unitOfWork.Save();

			return RedirectToAction(nameof(Index));

		}

		public IActionResult Remove(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.Id== cartId);
			_unitOfWork.ShoppingCart.Remove(cart);
			_unitOfWork.Save();

			return RedirectToAction(nameof(Index));

		}





	}
}
