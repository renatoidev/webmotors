using Microsoft.AspNetCore.Mvc;
using WebMotors.Models;
using WebMotors.ViewModels;

namespace WebMotors.Interfaces
{
    public interface IAdService
    {
        public Ad CreateAd(AdViewModel model);
    }
}
