using System.ComponentModel.DataAnnotations;

namespace learn {
    class TypeData<T> {
        public static void Check(dynamic ob){
            //  Type Integ = typeof(int);
            // if(Integ == arr.GetType()){
            //     System.Console.WriteLine("day la kieu so");
            // }
            if(typeof(int) == ob.GetType()){
                
            }
            else if (typeof(string) == ob.GetType()){

            }
           else if (typeof(float) == ob.GetType()){

            }
             else if (typeof(Array) == ob.GetType()){

            }
        
     
           
        }

            public static List<ValidationResult> ChecKDataInput(T t){
            ValidationContext validation = new ValidationContext(t, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(t, validation, results, true);
            if(valid){
                return null;
            }
            return results;
           

        }
          
    }
}