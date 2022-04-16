using Microsoft.AspNetCore.Mvc;
using WebMotors.Interfaces;
using WebMotors.Models;
using WebMotors.ViewModels;

namespace WebMotors.Services
{
    public class AdService 
    {
        private readonly IExternalAdService _repository;

        public AdService(IExternalAdService repository)
        {
            _repository = repository;
        }

        public Ad CreateAd(AdViewModel model)
        {
            var make = _repository.GetMake();
            var resultMake = make.Result.FirstOrDefault(x => x.Id == model.IdMake);

            var carModel = _repository.GetModels(model.IdMake);
            var resultModel = carModel.Result.FirstOrDefault(x => x.MakeID == model.IdMake);

            var version = _repository.GetVersions(model.IdModel);
            var resultVersion = version.Result.FirstOrDefault(x => x.ModelID == model.IdModel);

            var ad = new Ad(resultMake.Name, resultModel.Name, resultVersion.Name, model.Year, model.Km, model.Note);

            return ad;
        }

        public Ad EditAd(Ad ad, AdViewModel model)
        {
            var make = _repository.GetMake();
            var resultMake = make.Result.FirstOrDefault(x => x.Id == model.IdMake);

            var carModel = _repository.GetModels(model.IdMake);
            var resultModel = carModel.Result.FirstOrDefault(x => x.MakeID == model.IdMake);

            var version = _repository.GetVersions(model.IdModel);
            var resultVersion = version.Result.FirstOrDefault(x => x.ModelID == model.IdModel);

            ad.Make = resultMake.Name;
            ad.Model = resultModel.Name;
            ad.Version = resultVersion.Name;
            ad.Year = model.Year;
            ad.Km = model.Km;
            ad.Note = model.Note;

            return ad;

        }
    }
}
