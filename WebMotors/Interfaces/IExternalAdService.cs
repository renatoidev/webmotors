using Refit;
using WebMotors.ViewModels;

namespace WebMotors.Interfaces
{
    public interface IExternalAdService
    {
        [Get("/Make")]
        public Task<IEnumerable<MakeViewModel>> GetMake();

        [Get("/Model?MakeID={makeId}")]
        public Task<IEnumerable<ModelViewModel>> GetModels(int makeId);

        [Get("/Version?ModelID={modelId}")]
        public Task<IEnumerable<VersionViewModel>> GetVersions(int modelId);
    }
}
