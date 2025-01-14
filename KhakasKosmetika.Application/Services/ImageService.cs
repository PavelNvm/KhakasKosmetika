using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;


namespace KhakasKosmetika.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly string _folderPath;
        string[] files;
        public ImageService(IImageRepository imageRepository,ICategoryRepository categoryRepository)
        {
            _imageRepository = imageRepository;
            //_categoryRepository = categoryRepository;
            //_folderPath = "C:\\Users\\Дарья\\Desktop\\Images";
            //files = Directory.GetFiles(_folderPath, "*.jpg", SearchOption.AllDirectories);
            //insertAllPictures();
        }

        private void insertAllPictures()
        {
            var cats  = _categoryRepository.GetCategoriesDepthZeroAsync().Result;
            foreach (var cat in cats)
            {
                if (files.FirstOrDefault(n => n.Contains(cat.Id)) != null)
                {
                    _imageRepository.UpdateImage(files.FirstOrDefault(n => n.Contains(cat.Id)),cat.Id);
                }
            }
        }
        public async Task<byte[]> GetImagebyCategoryId(string catId)
        {
            var res = await _imageRepository.GetImageByCategoryIdAsync(catId);
            return res;
        }


    }
}
