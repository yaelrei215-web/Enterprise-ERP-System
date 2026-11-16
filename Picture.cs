using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace GUIYael
{
    public class Picture
    {
        public static string SaveImage(string sourcefileName)
        {
            if (sourcefileName != null)
            {
                //חותכת את שם הקובץ
                string fileName = System.IO.Path.GetFileName(sourcefileName);
                //מייצרת נתיב חדש ממיקום התיקייה פלוס שם הקובץ
                string path = GetCurrentPath() + @"Pictures\" + fileName;
                //אם הקובץ הזה לא קיים כבר בתיקייה
                if (!File.Exists(path))
                {
                    //קוראת את הקובץ לתוך מערך ביטים
                    byte[] imgArray = File.ReadAllBytes(sourcefileName);
                    //מייצרת ממנו אובייקט חדש
                    var stream = new MemoryStream(imgArray);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                    //שומרת בנתיב לתיקייה שלנו
                    img.Save(path);
                }
                return fileName;
            }
            return null;
        }

        //מביאה את הנתיב של הפרויקט שכרגע רץ
        public static string GetCurrentPath()
        {
            //מחזירה את מיקום קובץ ההרצה של הפרויקט
            string path = System.IO.Directory.GetCurrentDirectory();
            //מייצרים ממנו מחרוזת חדשה ללא 2 התיקיות האחרונות
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 2; i++)
            {
                path += arr[i] + "\\";
            }
            return path;//קיבלנו את המיקום של תיקיית הפרויקט
        }
        public static string UploadImage_Dlg()
        {
            string filename = null;
            // יצירת אוביקט שיודע לפתוח חלון 
            OpenFileDialog dlg = new OpenFileDialog();
            // קביעת מסנן לבחירת קובץ רק סיומות אלו יוכלו להיבחר 
            dlg.Filter = "All Images | *.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.png|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            //פותח חלונית בחירת תמונה ומחזיר האם נבחרה תמונה 
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filename = SaveImage(dlg.FileName);
            }
            return filename;
        }
        public static BitmapImage GetImage(string name)
        {
            if (name == null || name == "")
                return null;
            string path = GetCurrentPath() + @"Pictures\" + name;
            if (File.Exists(path))//אם הקובץ לא קיים בתיקייה מקומית
            {
                return new BitmapImage(new Uri(path));
            }
            return null;
        }
    }
}


