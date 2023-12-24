using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Helper
{
   public static class FileUploader
    {
        public static string UploadFile(string LocalPath,IFormFile File)
        {
            try {
                // 1 ) Get Directory

                string FilePath = Directory.GetCurrentDirectory() + LocalPath /*"/wwwroot/Files/Imgs"*/;


                //2) Get File Name
                //Guid.NewGuid() for making number of digit before photo

                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);


                // 3) Merge Path with File Name 
                //using combine for تعديل المسار ووضع/ )ع)

                string FinalPath = Path.Combine(FilePath, FileName);


                //4) Save File As Streams "Data Overtime"

                using (var Stream = new FileStream(FinalPath, FileMode.Create))

                {

                    File.CopyTo(Stream);

                }
                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


         
        }

        public static string RemoveFile(string LocalPath, string FileName)
        {
            try
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + LocalPath + FileName))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + LocalPath + FileName);
                }
                var result = "Deleted";
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }



        }
    }
}
