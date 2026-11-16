using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUIYael
{
  
        public class ValidationTZ : ValidationRule
        {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
        //    string val = value as string;
        //    if (val.Length != 9)
        //    {
        //        return new ValidationResult(false, "הקש 9 ספרות");
        //    }

            //    return ValidationResult.ValidResult;
            //    int sum = 0;
            //    int[] arr = new int[9];
            //    for (int i = 0; i < 9; i++)

            //        arr[i] = val[i] - '0';
            //        for (int i = 0; i < 9; i++)
            //        {
            //            if (i % 2 == 0)
            //                sum += arr[i];
            //            else sum += arr[i] * 2 / 10 + arr[i] * 2 % 10;

            //        }

            //        if (sum % 10 != 0)
            //            return new ValidationResult(false, "תז לא חוקית");

            //        return ValidationResult.ValidResult;

            //}
   
            string val = value as string;

            // בדיקה שהקלט אינו ריק ומכיל רק ספרות
            if (string.IsNullOrEmpty(val) || !val.All(char.IsDigit))
            {
                return new ValidationResult(false, "נא להזין ספרות בלבד");
            }

          
            val = val.PadLeft(9, '0');

            if (val.Length > 9)
            {
                return new ValidationResult(false, "תעודת זהות לא יכולה להכיל יותר מ-9 ספרות");
            }

         
            if (!IsValidIsraeliID(val))
            {
                return new ValidationResult(false, "מספר תעודת הזהות אינו תקין");
            }

            return ValidationResult.ValidResult;
        }
        private bool IsValidIsraeliID(string id)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
           
                int digit = id[i] - '0';

             
                int weight = (i % 2 == 0) ? 1 : 2;
                int step = digit * weight;

               
                if (step > 9)
                {
                    step = (step % 10) + (step / 10);
                }

                sum += step;
            }

         
            return sum % 10 == 0;
        }

    }
  
    
    public class ValidationDate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            // 1. בדיקה שהמשתמש בכלל הקליד משהו
            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "נא להזין תוקף כרטיס");
            }

            // 2. בדיקה שהאורך הוא בדיוק 5 תווים (למשל: 12/26)
            if (input.Length != 5)
            {
                return new ValidationResult(false, "יש להזין 5 תווים בדיוק בפורמט MM/YY");
            }

            // 3. בדיקה שהתו האמצעי הוא לוכסן
            if (input[2] != '/')
            {
                return new ValidationResult(false, "חובה לשים לוכסן (/) בין החודש לשנה");
            }

            // 4. חיתוך הטקסט ובדיקה בטוחה שמדובר במספרים בלבד (מונע קריסות)
            string monthPart = input.Substring(0, 2);
            string yearPart = input.Substring(3, 2);

            if (!int.TryParse(monthPart, out int month) || !int.TryParse(yearPart, out int year))
            {
                return new ValidationResult(false, "נא להזין ספרות בלבד");
            }

            // 5. בדיקה שהחודש תקין (בין 1 ל-12)
            if (month < 1 || month > 12)
            {
                return new ValidationResult(false, "חודש לא תקין, חייב להיות בין 01 ל-12");
            }

            // 6. קבלת שנה וחודש נוכחיים (נכון לשנת 2026)
            int currentYear = DateTime.Today.Year % 100; // יחזיר 26
            int currentMonth = DateTime.Today.Month;

            // 7. בדיקת תוקף הכרטיס (האם פג תוקף?)
            if (year < currentYear)
            {
                return new ValidationResult(false, "פג תוקפו של הכרטיס (שנה עברה)");
            }

            if (year == currentYear && month < currentMonth)
            {
                return new ValidationResult(false, "פג תוקפו של הכרטיס (חודש עבר)");
            }

            // אם הכל עבר בהצלחה
            return ValidationResult.ValidResult;
        }
    }

}

    

