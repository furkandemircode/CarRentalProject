﻿using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper;

public class FileHelperManager : IFileHelper
{
    public void Delete(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public string Update(IFormFile file, string filePath, string root)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        return Upload(file, root);
    }

    public string Upload(IFormFile file, string root)
    {
        if (file.Length > 0)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string existsion = Path.GetExtension(file.FileName);
            string guid = GuidHelper.GuidHelper.CreateGuid();
            string filePath = guid + existsion;

            using (FileStream fileStream = File.Create(root + filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }
        }

        return null;
    }
}
