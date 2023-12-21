namespace BA.HR_Project.WEB.HelperMethods
{
    public class Helper
    {
        public string SaveImageFile(IFormFile imageFile)
        {
            var fileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var imagePath = Path.Combine("wwwroot", "images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return "/images/" + fileName;
        }
    }
}
