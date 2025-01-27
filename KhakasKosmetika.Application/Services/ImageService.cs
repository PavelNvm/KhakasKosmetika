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
            //_folderPath = "C:\\Users\\Дарья\\Desktop\\latestImages";
            //files = Directory.GetFiles(_folderPath, "*.png", SearchOption.AllDirectories);
            //updateImages();
        }

        private void updateImages()
        {
            var cats  = _categoryRepository.GetCategoriesDepthZeroAsync().Result;
            foreach (var cat in cats)
            {
                if (files.FirstOrDefault(n => n.Contains(cat.Id)) != null)
                {
                    var temp = _imageRepository.GetImageByCategoryIdAsync(cat.Id).Result;
                    if (temp != null)
                        _imageRepository.UpdateImage(files.FirstOrDefault(n => n.Contains(cat.Id)), cat.Id);
                    else
                        _imageRepository.AddImage(files.FirstOrDefault(n => n.Contains(cat.Id)), cat.Id);
                }
            }
        }
        public async Task<byte[]> GetImagebyCategoryIdAsync(string catId)
        {
            
            var res = await _imageRepository.GetImageByCategoryIdAsync(catId);
            return res;
            
        }


    }
}
