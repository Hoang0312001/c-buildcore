namespace learn {
    class Department
    {
        public int DEPT_ID { set; get; }
        public string DEPT_NAME{set ; get ;}
        public string DEPT_NO;
        public string LOCATION;

        public Department(int DEPT_ID,string DEPT_NAME,string DEPT_NO,string LOCATION){
            this.DEPT_ID = DEPT_ID;
            this.DEPT_NAME = DEPT_NAME;
            this.DEPT_NO = DEPT_NO;
            this.LOCATION = LOCATION;
        }

        public Department(){}


    }
}