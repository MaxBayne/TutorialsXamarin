using System.Threading.Tasks;

namespace TutorialsXamarin.DependencyService
{
    public interface IPhotoShare
    {
        Task<PhotoShare> GetPhotoShare();
    }
}
