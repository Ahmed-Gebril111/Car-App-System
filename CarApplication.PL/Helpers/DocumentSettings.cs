namespace CarApplication.PL.Helpers
{
    public static class DocumentSettings
    {

        public static string UploadFile(IFormFile file, string folderName)
        {

            // 1. Get Loacated Folder Path
            //Directory.GetCurrentDirectory()\wwwroot\Files\Images\
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            // 2. Get File Name And Make It Unique

            string FileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3. Get File Path {FolderPath + FileName}
            string FilePath = Path.Combine(FolderPath, FileName);

            // 4. Save File As Stream 
            using var Fs = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(Fs);

            // 5. Return File Name
            return FileName;

        }


        public static void DeleteFile(string FileName, string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, FileName);

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

        }
    }
}
