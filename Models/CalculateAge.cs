using System;

namespace Chefs_n_Dishes.Models
{
    public class CalculateAge
    {
        // DateTime dob = Convert.ToDateTime("1988/12/20");  
        // string text = CalculateYourAge(dob);  
        // int age = CalculateAge(dob); 

        public static int CalculateAgeFunc(DateTime Dob)
        {
            
            
            int age = 0;  
            age = DateTime.Now.Year - Dob.Year;  
            if (DateTime.Now.DayOfYear < Dob.DayOfYear)  
                age = age - 1;  
        
            return age;
        }
    }
}