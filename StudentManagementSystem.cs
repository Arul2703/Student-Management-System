using System.Data;
using System.Data.SqlClient;
class Student{

  //attributes 
  public int registerNumber;
  public string name;
  public int age;
  public string address;
  private long mobileNumber;
  public string emailId;
  public string collegeName;

  public string courseName;
  public string specialization;
  public float cgpa;

  private string password;

  public void displayOptions(){ 
    char ch='n';
            Console.WriteLine("\n\tSTUDENT MANAGEMENT SYSTEM"); 
            Console.WriteLine("----------------------------------------");
            do{
                Console.WriteLine("1. New Student\n2. View Student Details\n3. View All Student's Details\n4. Update Student Details\n5. Exit\n");
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
                            viewStudentDetails(choice); break;

                        case 3:
                            viewStudentDetails(choice); break;

                        case 4:
                            if(authenticateUser()){
                              updateStudentDetails(); break;
                            }
                            else{
                              Console.WriteLine("Sorry, Your user id or password might be incorrect.");
                              break;
                            }

                        case 5:
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
  {         Console.WriteLine("--------------REGISTER NOW--------------");
            Console.WriteLine("\nPlease provide the details below");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            
            enterRegisterNumber();
            enterName();
            enterAge();
            enterAddress();
            enterMobileNumber();
            enterEmailId();
            enterCollegeName();
            enterCourseName();
            enterSpecialization();
            enterCgpa();
            enterPassword();
            
            insertStudentDetails(registerNumber,name,age,address,mobileNumber,emailId,collegeName,courseName,specialization,cgpa);
                        
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
  
  public void enterEmailId(){
    Console.WriteLine("Enter your Email Id: ");
    emailId = Console.ReadLine();
  }

  public void enterCollegeName(){
    Console.WriteLine("Enter your College Name: ");
    collegeName = Console.ReadLine();
  }

  public void enterCourseName(){
    Console.WriteLine("Enter your Course Name: ");
    courseName = Console.ReadLine();
  }

  public void enterSpecialization(){
    Console.WriteLine("Enter the Specialization: ");
    specialization = Console.ReadLine();
  }
  
  public void enterCgpa(){
    Console.WriteLine("Enter your CGPA: ");
    cgpa = float.Parse(Console.ReadLine());
  }

  public void enterPassword(){
    Console.WriteLine("\n ---- Set your Password ---- ");

  }

  public void insertStudentDetails(int registerNumber,string name,int age,string address,long mobileNumber,string emailId,string collegeName,string courseName,string specialization,float cgpa){

    // Connection String
    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

    // Establishing Connection
    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();

    // Insert Student details into database
    string userquery = "INSERT INTO studentdetails(registerNo,name,age,address,mobileNumber,emailId,clgName,courseName,specialization,cgpa) VALUES("+registerNumber+",+'" +name+"',"+age+",'" +address+"',"+mobileNumber+",'" +emailId+"',+'"+collegeName+"','" +courseName+"','" +courseName+"',"+cgpa+")";

    SqlCommand insertCommand = new SqlCommand(userquery,con);

    insertCommand.ExecuteNonQuery(); //is used to run command which does not return any data
    Console.WriteLine("Data is successfully inserted into table");
    con.Close();
  }

  public void viewStudentDetails(int choice){

    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();

    string displayQuery = "SELECT * FROM studentdetails";

    if(choice==2){
      Console.WriteLine("Enter your register number:"); // Get Register Number from user
      int regNumber = Convert.ToInt32(Console.ReadLine());

      displayQuery = "SELECT registerNo,name,age,address,mobileNumber,emailId,clgName,courseName,specialization,cgpa FROM studentdetails WHERE registerNo ="+regNumber+"";
    }

    SqlCommand displayCommand = new SqlCommand(displayQuery,con);
    // ExecuteReader method is used to execute command which returns some value.
    SqlDataReader dataReader = displayCommand.ExecuteReader(); 

    // Display student details
    while(dataReader.Read()){

      Console.WriteLine("------------------- THE STUDENT DETAILS ARE -------------------\n");

      Console.WriteLine("Register Number: "+dataReader.GetValue(0).ToString()+
      "\nName: "+dataReader.GetValue(1).ToString()+
      "\nAge: "+dataReader.GetValue(2).ToString()+
      "\nAddress: "+dataReader.GetValue(3).ToString()+
      "\nMobile Number: "+dataReader.GetValue(4).ToString()+
      "\nEmail Id: "+dataReader.GetValue(5).ToString()+
      "\nCollege Name: "+dataReader.GetValue(6).ToString()+
      "\nCourse Name: "+dataReader.GetValue(7).ToString()+
      "\nSpecialization: "+dataReader.GetValue(8).ToString()+
      "\nSCGPA: "+dataReader.GetValue(9).ToString()
      );

      Console.WriteLine();  
    }
    con.Close();
  }
  public void viewAllStudentDetails(){
    
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


  public void updateStudentDetails(){
    char ch = 'n';
    bool isValidUser = false;
    enterRegisterNumber();
    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";  // Connection string

    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();  

    string updateQuery = "SELECT * FROM studentdetails";
    do{
          Console.Write("\nSelect the property which you want to update : ");
          Console.WriteLine("\n1. Update Name\n2. Update Age\n3. Update Address\n4. Update Email Id\n5. Update College Name\n6. Update Course Name\n7. Update Specialization");

          int choice = 0;
          Console.WriteLine("Enter your choice: ");
          choice = Convert.ToInt32(Console.ReadLine());
          switch(choice){
            case 1:
              enterName();
              updateQuery = "UPDATE studentdetails SET name ='"+name+"' WHERE registerNo = "+registerNumber+"";
              break;

            case 2:
              enterAge();
              updateQuery = "UPDATE studentdetails SET age ="+age+"WHERE registerNo="+registerNumber+"";
              break;

            case 3:
              enterAddress();
              updateQuery = "UPDATE studentdetails SET address ='"+address+"'WHERE registerNo = "+registerNumber+"";
              break;

            case 4:
              enterEmailId();
              updateQuery = "UPDATE studentdetails SET emailId ='"+emailId+"'WHERE registerNo = "+registerNumber+"";
              break;

            case 5:
              enterCollegeName();
              updateQuery = "UPDATE studentdetails SET clgName ='"+collegeName+"'WHERE registerNo = "+registerNumber+"";
              break;
            
            case 6:
              enterCourseName();
              updateQuery = "UPDATE studentdetails SET courseName ='"+courseName+"'WHERE registerNo = "+registerNumber+"";
              break;

            case 7:
              enterSpecialization();
              updateQuery = "UPDATE studentdetails SET specialization ='"+specialization+"'WHERE registerNo = "+registerNumber+"";
              break;


          }
        }while(ch == 'y');
      Console.WriteLine(updateQuery);
      SqlCommand updateCommand = new SqlCommand(updateQuery,con);

      updateCommand.ExecuteNonQuery(); //is used to run command which does not return any data
      Console.WriteLine("Data is successfully inserted into table");
      con.Close();

  }


  public bool authenticateUser(){
    bool isValidUser = false;
    Console.WriteLine("Enter register number and password: ");
    int regNumber = Convert.ToInt32(Console.ReadLine());
    string password = Console.ReadLine();

    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";  // Connection string

    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();  
    string displayQuery = "SELECT registerNo,password FROM studentdetails WHERE registerNo ="+regNumber+"";

    SqlCommand displayCommand = new SqlCommand(displayQuery,con);
    SqlDataReader dataReader = displayCommand.ExecuteReader(); 
    while(dataReader.Read()){
      int regNo = Convert.ToInt32(dataReader.GetValue(0));
      string pwd = dataReader.GetValue(1).ToString();
      if(regNumber == regNo && password.Equals(pwd)){
        isValidUser = true;
        return isValidUser;
      }
    }
    return false;
  }
}