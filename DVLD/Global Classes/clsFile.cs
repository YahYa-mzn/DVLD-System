// Class: File Operations Utility
// Provides file and image handling methods:
//   - GUID generation for unique filenames
//   - Image format detection and conversion
//   - Image copying with format preservation
//   - File existence checking and deletion
//   - Text file reading and writing

using System;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace DVLD.Global_Classes
{
    internal class clsFile
    {
        // Generates unique identifier for filenames
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        // Detects image format from file
        public static ImageFormat GetImageFormat(string Path)
        {
            using (Image Img = Image.FromFile(Path))
            {
                if (Img.RawFormat.Equals(ImageFormat.Jpeg)) return ImageFormat.Jpeg;
                if (Img.RawFormat.Equals(ImageFormat.Png)) return ImageFormat.Png;
                if (Img.RawFormat.Equals(ImageFormat.Bmp)) return ImageFormat.Bmp;
                if (Img.RawFormat.Equals(ImageFormat.Gif)) return ImageFormat.Gif;
                if (Img.RawFormat.Equals(ImageFormat.Tiff)) return ImageFormat.Tiff;
                if (Img.RawFormat.Equals(ImageFormat.Icon)) return ImageFormat.Icon;

                return ImageFormat.MemoryBmp; // Fallback
            }
        }

        // Gets file extension from ImageFormat
        public static string GetExtensionFromImageFormat(ImageFormat Format)
        {
            if (Format.Equals(ImageFormat.Jpeg)) return ".jpg";
            if (Format.Equals(ImageFormat.Png)) return ".png";
            if (Format.Equals(ImageFormat.Bmp)) return ".bmp";
            if (Format.Equals(ImageFormat.Gif)) return ".gif";
            if (Format.Equals(ImageFormat.Tiff)) return ".tiff";
            if (Format.Equals(ImageFormat.Icon)) return ".ico";

            return ".bmp"; // Default fallback
        }

        // Copies image to new location with new filename and format
        public static string CopyImageIntoNewPath(string SourcePath, string DestFolder, string NewFileName, ImageFormat ImgFormat)
        {
            try
            {
                if (!Directory.Exists(DestFolder))
                    Directory.CreateDirectory(DestFolder);

                string Extension = GetExtensionFromImageFormat(ImgFormat);
                string DestPath = Path.Combine(DestFolder, NewFileName + Extension);

                using (Image Img = Image.FromFile(SourcePath))
                {
                    Img.Save(DestPath, ImgFormat);
                }

                return DestPath;
            }
            catch
            {
                return "";
            }
        }

        public static bool IsFileExists(string FilePath)
        {
            return File.Exists(FilePath);
        }

        public static bool DeleteFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                return false;

            File.Delete(FilePath);
            return true;
        }


        // Writes list of strings to file (for Remember Me feature)
        public static void WriteOnFile(string FilePath, List<string> StrList)
        {
            File.WriteAllLines(FilePath, StrList);
        }

        public static void ClearFile(string FilePath)
        {
            File.WriteAllText(FilePath, string.Empty);
        }

        // Reads file lines into list
        public static List<string> ReadFromFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                return new List<string>();

            return File.ReadAllLines(FilePath).ToList();
        }
    }
}