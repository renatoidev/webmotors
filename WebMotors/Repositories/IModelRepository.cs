using Refit;
using WebMotors.ViewModels;

namespace WebMotors.Repositories
{
    public interface IModelRepository
    {
        [Get("/Model?MakeID={makeId}")]
        public Task<IEnumerable<ModelViewModel>> GetModels([AliasAs("makeId")]int makeId);
    }
}
