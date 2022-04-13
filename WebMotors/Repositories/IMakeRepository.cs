using Refit;
using WebMotors.ViewModels;

namespace WebMotors.Repositories
{
    public interface IMakeRepository
    {
        [Get("/Make")]
        public Task<IEnumerable<MakeViewModel>> GetMake();
    }
}
