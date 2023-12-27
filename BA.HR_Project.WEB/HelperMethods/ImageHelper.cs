namespace BA.HR_Project.WEB.HelperMethods
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageFile(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                // Eğer dosya seçilmediyse veya dosyanın uzunluğu sıfırsa null dönebilir veya hata mesajı gönderebilirsiniz.
                return null;
            }

            try
            {
                string imageExtension = Path.GetExtension(imageFile.FileName);

                // Yeni bir dosya adı oluşturun
                string imageName = Guid.NewGuid().ToString("N") + imageExtension;

                // Dosyanın kaydedileceği yol
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "mexant", "assets", "images", imageName);

                // Dosyayı oluşturulan yola kaydedin
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Kaydedilen dosyanın yolunu döndürün
                return "/mexant/assets/images/" + imageName;
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya uygun bir işlem yapabilirsiniz.
                // Hata durumunda null dönebilir veya isteğe bağlı olarak bir hata mesajı dönebilirsiniz.
                return null;
            }
        }
    }
}
