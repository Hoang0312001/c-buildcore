namespace learn{
    class Delegates{
       public  delegate int TinhToan (int a, int b);
       public static void Result(){
            TinhToan tinhToan = (int x, int y) =>
            {
                return x + y;
            };
            int rs = tinhToan(2, 3);
            Console.WriteLine(rs);

            Func<int, int, int> tb = (int x, int y) =>
            {
                return x + y;
            };
            int func = tb(2, 4);
            Action<string> action = (string b) =>
            {
                Console.WriteLine(b);
            };
            action("hoang");
            Console.WriteLine(func);
        }
    }
}