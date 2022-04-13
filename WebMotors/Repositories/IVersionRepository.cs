using Refit;
using WebMotors.ViewModels;

namespace WebMotors.Repositories
{
    public interface IVersionRepository
    {
        [Get("/Version?ModelID={modelId}")]
        public Task<IEnumerable<VersionViewModel>> GetVersions(int modelId);
    }
}
