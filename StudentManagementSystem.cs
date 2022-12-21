using System.Data;
using System.Data.SqlClient;
class Student{
  public int registerNumber;
  public string name;
  public int age;
  public string address;
  public long mobileNumber;

  public int totalMarks;

  // public student(int regNumber,string name,int age,string address,long mobileNumber,int totalMarks){
  //   this.registerNumber = regNumber;
  //   this.name = name;
  //   this.age = age;
  //   this.address = address;
  //   this.mobileNumber = mobileNumber;
  //   this.totalMarks = totalMarks;
  // }

  public void displayOptions(){
    char ch='n';
            Console.WriteLine("\n\tSTUDENT MANAGEMENT SYSTEM"); 
            Console.WriteLine("----------------------------------------");
            do{
                Console.WriteLine("1. New Student\n2. View Student Details\n3. View All Student's Details\n4. Exit\n");
                Console.Write("\nSelect your choice : ");
                int choice = 0;
                bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);
                
                if(!IsConversionSuccessful)
                   Console.Write("\nPlease enter a valid format");
                else
                {
                    switch(choice)
                    {
                        case 1:
                            enterDetails();
                            break;

                        case 2:
                            viewStudent(); break;

                        case 3:
                            viewAllStudents(); break;

                        case 4:
                            return;

                        default:
                            Console.Write("\nInvalid Choice, Please enter a valid choice");
                            break;
                    }

                    do
                    {
                        Console.Write("\n\nDo you want to continue to the Application, Say (yes or no)");
                        ch = Console.ReadLine()[0];

                        if(ch != 'y' && ch != 'n')
                            Console.Write("\n\nInvalid Choice, Please say (yes or no)");

                    }while(ch != 'y' && ch != 'n');
                }

            }while(ch == 'y');

            Console.WriteLine("\n\n  *** Program Terminated *** "); 
  }

  public void enterDetails()
  {
            Console.WriteLine("\n\nPlease provide the details below");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            
            enterRegisterNumber();
            enterName();
            enterAge();
            enterAddress();
            enterMobileNumber();
            enterTotalMarks();
            insertStudentDetails(registerNumber,name,age,address,mobileNumber);
                        
  }
  public void enterRegisterNumber()
  {
    Console.WriteLine("Enter your Register Number:");
    registerNumber = Convert.ToInt32(Console.ReadLine());
  }
  public void enterName()
  {
    Console.Write("\nEnter Name : ");
    name = Console.ReadLine();   
  }

  public void enterAge(){
    Console.WriteLine("Enter your age:");
    age = Convert.ToInt32(Console.ReadLine());
  }
  public void enterAddress(){
    Console.WriteLine("Enter your address: ");
    address = Console.ReadLine();
  }
  public void enterMobileNumber(){
    Console.WriteLine("Enter your Mobile Number:");
    mobileNumber = Convert.ToInt64(Console.ReadLine());
  }
  public void enterTotalMarks(){
    Console.WriteLine("Enter your total marks: ");
    totalMarks = Convert.ToInt32(Console.ReadLine());
  }

  public void insertStudentDetails(int registerNumber,string name,int age,string address,long mobileNumber){

    // Connection String
    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

    // Establishing Connection
    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();

    // Insert Student details into database
    string userquery = "INSERT INTO studentdetails(reg_no,name,age,address,mobile_number) VALUES("+registerNumber+",+'" +name+"',"+age+",'" +address+"',"+mobileNumber+")";

    SqlCommand insertCommand = new SqlCommand(userquery,con);

    insertCommand.ExecuteNonQuery(); //is used to run command which does not return any data
    Console.WriteLine("Data is successfully inserted into table");
    con.Close();
  }

  public void viewStudent(){

    Console.WriteLine("Enter your register number:");
    int regNumber = Convert.ToInt32(Console.ReadLine());
    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();

    string displayQuery = "SELECT reg_no,name,age,address,mobile_number FROM studentdetails WHERE reg_no ="+regNumber+"";
    SqlCommand displayCommand = new SqlCommand(displayQuery,con);
    // ExecuteReader method is used to execute command which returns some value.
    SqlDataReader dataReader = displayCommand.ExecuteReader(); 

    // Display student details
    while(dataReader.Read()){

      Console.WriteLine("------------------- THE STUDENT DETAILS ARE -------------------\n");

      Console.WriteLine("Register Number: "+dataReader.GetValue(0).ToString()+"\nName: "+dataReader.GetValue(1).ToString()+"\nAge: "+dataReader.GetValue(2).ToString()+"\nAddress: "+dataReader.GetValue(3).ToString());

      Console.WriteLine();

      
    }
    con.Close();
  }
  public void viewAllStudents(){
    
    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";  // Connection string

    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();  

    // RETRIEVING DATA FROM DATABASE USING C#
    string displayQuery = "SELECT * FROM studentdetails";

    SqlCommand displayCommand = new SqlCommand(displayQuery,con);

    // ExecuteReader method is used to execute command which returns some value.
    SqlDataReader dataReader = displayCommand.ExecuteReader(); 

    while(dataReader.Read()){

      Console.WriteLine("Register Number:\t"+dataReader.GetValue(0).ToString()+"\tName:\t"+dataReader.GetValue(1).ToString()+"\tAge\t"+dataReader.GetValue(2).ToString()+"\tAddress\t"+dataReader.GetValue(3).ToString());

    }
    con.Close();
  }


}