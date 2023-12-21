namespace BA.HR_Project.WEB.HelperMethods
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageFile(IFormFile imageFile)
        {
            //var fileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            //var imagePath = Path.Combine("wwwroot", "images", fileName);

            //using (var stream = new FileStream(imagePath, FileMode.Create))
            //{
            //    await imageFile.CopyToAsync(stream);
            //}
            //return "/images/" + fileName;

            string imageExtension = Path.GetExtension(imageFile.FileName);

            string imageName = Guid.NewGuid() + imageExtension;

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/mexant/assets/images/{imageName}");

            using var stream = new FileStream(path, FileMode.Create);

            await imageFile.CopyToAsync(stream);

            return $"/mexant/assets/images/{imageName}";
        }
    }
}
