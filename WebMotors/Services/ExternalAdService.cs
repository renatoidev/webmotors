using WebMotors.Interfaces;
using WebMotors.ViewModels;

namespace WebMotors.Services
{
    public class ExternalAdService : IExternalAdService
    {        
        public Task<IEnumerable<MakeViewModel>> GetMake()
        {
            
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelViewModel>> GetModels(int makeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VersionViewModel>> GetVersions(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
