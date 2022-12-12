using FluentValidation;
using lesson11_serilog.Models;
using lesson11_serilog.Models.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace lesson11_serilog.Controllers
{
    public class DataShowController : Controller
    {
        public IActionResult Index(ShowDataViewModel model)
        {
            var validity = ModelState.IsValid;

            var errors = ModelState.SelectMany(kvp => kvp.Value.Errors).ToList();

            return View();
        }

        [HttpGet("/DataShow/EditView/{specialValue?}")]
        public IActionResult EditView([Required] int specialValue)
        {
            return View("Edit");
        }

        [HttpPost]
        public IActionResult EditSubmit(ShowDataViewModel model, int id = 6)
        {
            ValidateWithFluentValidator<ShowDataViewModelValidator, ShowDataViewModel>(model, ModelState);

            // example list of error fetching (unused here):
            var errors = ModelState.SelectMany(kvp => kvp.Value.Errors).ToList();

            var validity = ModelState.IsValid;

            if (!validity)
            {
                return View("Edit", model);
            }

            return RedirectToAction(
                nameof(HomeController.Index),
                nameof(HomeController).Replace("Controller", string.Empty),
                new { id = 77 }
            );
        }

        public void ValidateWithFluentValidator<validatorType, modelType>(modelType model, ModelStateDictionary modelState) {
            var validtator = (AbstractValidator<modelType>) Activator.CreateInstance(typeof(validatorType));

            var fluentModelState = validtator.Validate(model);

            if (! fluentModelState.IsValid)
            {
                fluentModelState.Errors.ForEach(
                    err =>
                    {
                        modelState.AddModelError(err.PropertyName, err.ErrorMessage);
                    }
                );
            }
        }
    }
}
