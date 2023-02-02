namespace learn {
    class FormatString {
        public static void PrintData(int [] arr){
            for (int i = 0; i < arr.Length; i++){
                System.Console.WriteLine($"Phần tử thứ {i} : " + arr[i]);
            }
        }
        public void Insert(){

        }
    }
}