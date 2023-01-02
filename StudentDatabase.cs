using System.Text.RegularExpressions;
using System.Data.SqlClient;
class StudentDatabase{
  int userId;string password;

  public void insertStudentDetails(){
    Console.WriteLine("--------------REGISTER NOW--------------");
    Console.WriteLine("\nPlease provide the details below");
    Console.WriteLine("+++++++++++++++++++++++++++++++++");

    Student student = new Student();
    student.FirstName = getFirstName();
    student.LastName = getLastName();
    student.Age = getAge();
    student.DateofBirth = getDateOfBirth();
    student.MobileNumber = getMobileNumber();
    student.EmailId = getEmailId();
    student.Address = getAddress();
    student.collegeName = getCollegeName();
    student.courseName = getCourseName();
    student.specialization = getSpecialization();
    student.Cgpa = getCgpa();
    student.Password = setPassword();

    // Insert student details into the database
    try{
      string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=IFET_StudentInfo;User Id=sa;Password = Arul@2002";
      SqlConnection con = new SqlConnection(ConnectionString);
      con.Open();
      string userquery = "INSERT INTO studentdetails(firstName,lastname,age,address,mobileNumber,emailId,clgName,courseName,specialization,cgpa,password) VALUES('" +student.FirstName+"','" +student.LastName+"',"+student.Age+",'" +student.Address+"',"+student.MobileNumber+",'" +student.EmailId+"',+'"+student.collegeName+"','" +student.courseName+"','" +student.specialization+"',"+student.Cgpa+",'"+student.Password+"'"+")";
      SqlCommand insertCommand = new SqlCommand(userquery,con);

      insertCommand.ExecuteNonQuery(); //is used to run command which does not return any data
      Console.WriteLine("------------- You're successfully registered... -------------");
      getRegisterNumberFromDB(student.EmailId);
      con.Close();
    }
    catch(Exception ex){
      Console.WriteLine("Something went wrong.");
      Console.WriteLine(ex.Message);
    }
  }

  public string getFirstName(){
    string firstName;
    while(true){
      Console.Write("Enter First Name: ");
      firstName = Console.ReadLine();
      
      if(isValidName(firstName)){
        break;
      }
      else{
        Console.WriteLine("The First Name is not in correct format. Please enter a valid First Name.");
      }
    }
    return firstName;
  }

  public string getLastName(){
    string lastName;
    while(true){
      Console.Write("Enter Last Name: ");
      lastName = Console.ReadLine();
      
      if(isValidName(lastName)){
        break;
      }
      else{
        Console.WriteLine("The Last Name is not in correct format. Please enter a valid Last Name.");
      }
    }
    return lastName;
  }

  
  public int getAge(){
    int age;
    while(true){
      Console.Write("Enter your age:");
      try{
        age = int.Parse(Console.ReadLine());
        break;
      }
      catch(Exception ex){
        Console.WriteLine("The input is not in valid format. \nPlease enter numerical digits(0-9)\nExample: 21");
        Console.WriteLine(ex.Message);
      }
    }
    return age;
  }

  public DateTime getDateOfBirth(){
    DateTime dateOfBirth;
    //Input date
    while (true)
    {
      Console.Write("Enter Date of Birth: ");
      try
      {
        dateOfBirth = DateTime.Parse(Console.ReadLine());
        break;
      } catch (Exception ex)
      {
        Console.WriteLine ("The date is not in the correct format!");
        Console.WriteLine (ex.Message);
      }
    }
    return dateOfBirth;
  }

  public long getMobileNumber(){
    long mobileNumber;
    while (true)
    {
      Console.Write("Enter Mobile Number: ");
      try
      {
        mobileNumber = long.Parse(Console.ReadLine());
        int size = mobileNumber.ToString().Length;
        if(size==10){
          break;
        }
        else if(size<10){
          Console.WriteLine("Please enter a valid mobile number with 10 digits.");
        }
        
      } catch (Exception ex)
      {
        Console.WriteLine ("The mobile number is not in the correct format!");
        Console.WriteLine (ex.Message);
      }
    }
    return mobileNumber;
  }
  public string getEmailId(){
    string emailID; 
    while(true){
      Console.Write("Enter Email Id: ");
      emailID = Console.ReadLine();
      if(isValidEmailId(emailID)){
        break;
      }
    }
    return emailID;
  }

  public string getAddress(){
    Console.WriteLine("Enter your address: ");
    string address = Console.ReadLine();
    return address;
  }
  
  public string getCollegeName(){
    string collegeName;
    while(true){
      Console.Write("Enter College Name: ");
      collegeName = Console.ReadLine();
      
      if(isValidString(collegeName)){
        break;
      }
      else{
        Console.WriteLine("The college name is not in correct format. Please enter a valid college name.");
      }
    }
    return collegeName;
  }

  public string getCourseName(){
    string courseName;
    while(true){
      Console.Write("Enter Course Name: ");
      courseName = Console.ReadLine();
      
      if(isValidString(courseName)){
        break;
      }
      else{
        Console.WriteLine("The course name is not in correct format. Please enter a valid course name.");
      }
    }
    return courseName;
  }

  public string getSpecialization(){
    string courseName;
    while(true){
      Console.Write("Enter Specialization Name: ");
      courseName = Console.ReadLine();
      
      if(isValidString(courseName)){
        break;
      }
      else{
        Console.WriteLine("The value entered is not in correct format. Please enter a valid specialization name.");
      }
    }
    return courseName;
  }

  public float getCgpa(){
    float cgpa;
    while(true){
      Console.Write("Enter your CGPA: ");
      try{
        cgpa = float.Parse(Console.ReadLine());
        break;
      }
      catch(Exception ex){
        Console.WriteLine("Please Enter CGPA in valid format. ( Example: 8.45 ");
        Console.Write(ex.Message);
      }
    }
    return cgpa;
  }

  public string setPassword(){
    string password;
    while(true){
      Console.Write("*********** SET YOUR PASSWORD ***********");
      password = getPassword();
      
      if(checkPassword(password)){
        break;
      }
      else{
        Console.WriteLine("Your password should contain atleast one upper case,one lower case,one numerical and one special case character.");
      }
    }
    return password;
  }

  public  string getPassword()
   {
      string password = "";
      Console.WriteLine("\nEnter password: ");
      ConsoleKeyInfo info = Console.ReadKey(true);
      while (info.Key != ConsoleKey.Enter)
      {
          if (info.Key != ConsoleKey.Backspace)
          {
             Console.Write("*");
             password += info.KeyChar;
          }
          else if (info.Key == ConsoleKey.Backspace)
          {
             if (!string.IsNullOrEmpty(password))
             {
                // remove one character from the list of password characters
                password = password.Substring(0, password.Length - 1);
                // get the location of the cursor
                int pos = Console.CursorLeft;
                // move the cursor to the left by one character
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                // replace it with space
                Console.Write(" ");
                // move the cursor to the left by one character again
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
             }
          }
          info = Console.ReadKey(true);
      }

      // add a new line because user pressed enter at the end of their password
      Console.WriteLine();
      return password;
   }

  public bool checkPassword(string password){
    int minimumLength = 6;
    bool hasNumber = false;
    bool hasUpperCase = false;
    bool hasLowerCase = false;
    bool hasSpecialCharacter = false;
    char currentCharacter;
    if(password.Length <= minimumLength){
      return false;
    }
    for(int i = 0;i<password.Length;i++){
      currentCharacter = password[i];
      if(char.IsDigit(currentCharacter)){
        hasNumber = true;
      }
      else if(char.IsUpper(currentCharacter)){
        hasUpperCase = true;
      }
      else if(char.IsLower(currentCharacter)){
        hasLowerCase = true;
      }
      else if(!char.IsLetterOrDigit(currentCharacter)){
        hasSpecialCharacter = true;
      }

      if(hasNumber && hasUpperCase && hasLowerCase && hasSpecialCharacter){
        return true;
      }
    }
    return false;
  }
  public void getRegisterNumberFromDB(string emailID){

    try{
      string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=IFET_StudentInfo;User Id=sa;Password = Arul@2002";
      SqlConnection con = new SqlConnection(ConnectionString);
      con.Open();
      string userquery = "SELECT registerNo from studentdetails WHERE emailID='"+emailID+"'";
      SqlCommand displayCommand = new SqlCommand(userquery,con);
      // ExecuteReader method is used to execute command which returns some value.
      SqlDataReader dataReader = displayCommand.ExecuteReader(); 
      while(dataReader.Read()){
        Console.WriteLine("Your Register Number is: "+dataReader.GetValue(0).ToString());
        Console.WriteLine();  
      }
      con.Close();
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    }
  }

  public int getRegisterNumber(){
    int registerNumber;
    while(true){
      Console.Write("Enter your Register Number: ");
      try{
        registerNumber = int.Parse(Console.ReadLine());
        break;
      }
      catch(Exception ex){
        Console.WriteLine("Please enter the register number in valid format (Example: Register Number: 2)");
        Console.Write(ex.Message);
      }
    }
    return registerNumber;
  }
  
  public void viewStudentDetails(){
    int regNumber = getRegisterNumber();
    
    try{
      string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=IFET_StudentInfo;Integrated Security=True";
      SqlConnection con = new SqlConnection(ConnectionString);
      con.Open();
      string displayQuery = "SELECT registerNo,firstName,lastName,age,address,mobileNumber,emailId,clgName,courseName,specialization,cgpa FROM studentdetails WHERE registerNo ="+regNumber+"";
      SqlCommand displayCommand = new SqlCommand(displayQuery,con);
      // ExecuteReader method is used to execute command which returns some value.
      SqlDataReader dataReader = displayCommand.ExecuteReader(); 

      if(!dataReader.Read()){
        Console.WriteLine("No records found");
      }
      else{
        while(dataReader.Read()){
          Console.WriteLine("------------------- THE STUDENT DETAILS ARE -------------------\n");
          Console.WriteLine("Register Number: "+dataReader.GetValue(0).ToString()+
          "\nFirst Name: "+dataReader.GetValue(1).ToString()+
          "\nLast Name: "+dataReader.GetValue(2).ToString()+
          "\nAge: "+dataReader.GetValue(3).ToString()+
          "\nAddress: "+dataReader.GetValue(4).ToString()+
          "\nMobile Number: "+dataReader.GetValue(5).ToString()+
          "\nEmail Id: "+dataReader.GetValue(6).ToString()+
          "\nCollege Name: "+dataReader.GetValue(7).ToString()+
          "\nCourse Name: "+dataReader.GetValue(8).ToString()+
          "\nSpecialization: "+dataReader.GetValue(9).ToString()+
          "\nCGPA: "+dataReader.GetValue(10).ToString()
          );
          Console.WriteLine();  
        }
      }
      // Display student details
      
      con.Close();
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    }
    
  }

  public void updateStudentDetails(){
    try{
      char ch = 'n';
      bool isValidUser = false;
      string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=IFET_StudentInfo;Integrated Security=True";  // Connection string
      int registerNumber = getRegisterNumber();
      SqlConnection con = new SqlConnection(ConnectionString);
      con.Open();  
      string updateQuery="";
      do{
            Console.Write("\nSelect the property which you want to update : ");
            Console.WriteLine("\n1. Update First Name\n2.Update Last Name\n3. Update Age\n4. Update Address\n5. Update Email Id\n6. Update College Name\n7. Update Course Name\n8. Update Specialization");

            int choice = 0;
            Console.WriteLine("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice){
              case 1:
                string firstName = getFirstName();
                updateQuery = "UPDATE studentdetails SET firstName ='"+firstName+"' WHERE registerNo = "+registerNumber+"";
                break;

              case 2: 
                string lastName = getFirstName();
                updateQuery = "UPDATE studentdetails SET lastName ='"+lastName+"' WHERE registerNo = "+registerNumber+"";
                break;

              case 3:
                int age = getAge();
                updateQuery = "UPDATE studentdetails SET age ="+age+"WHERE registerNo="+registerNumber+"";
                break;

              case 4:
                string address = getAddress();
                updateQuery = "UPDATE studentdetails SET address ='"+address+"'WHERE registerNo = "+registerNumber+"";
                break;

              case 5:
                string emailId = getEmailId();
                updateQuery = "UPDATE studentdetails SET emailId ='"+emailId+"'WHERE registerNo = "+registerNumber+"";
                break;

              case 6:
                string collegeName = getCollegeName();
                updateQuery = "UPDATE studentdetails SET clgName ='"+collegeName+"'WHERE registerNo = "+registerNumber+"";
                break;
              
              case 7:
                string courseName = getCourseName();
                updateQuery = "UPDATE studentdetails SET courseName ='"+courseName+"'WHERE registerNo = "+registerNumber+"";
                break;

              case 8:
                string specialization = getSpecialization();
                updateQuery = "UPDATE studentdetails SET specialization ='"+specialization+"'WHERE registerNo = "+registerNumber+"";
                break;


            }
          }while(ch == 'y');
        SqlCommand updateCommand = new SqlCommand(updateQuery,con);

        updateCommand.ExecuteNonQuery(); //is used to run command which does not return any data
        Console.WriteLine("\n ---- Successfully Updated. ---- ");
        con.Close();
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    }
  }

  public bool authenticateUser(){
    bool isValidUser = false;
    int registerNumber = getRegisterNumber();
    string password = getPassword();

    string ConnectionString = @"Data Source=LAPTOP-HS0OJSCM\SQLEXPRESS;Initial Catalog=IFET_StudentInfo;Integrated Security=True";  // Connection string

    SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();  
    string displayQuery = "SELECT registerNo,password FROM studentdetails WHERE registerNo ="+registerNumber+"";

    SqlCommand displayCommand = new SqlCommand(displayQuery,con);
    SqlDataReader dataReader = displayCommand.ExecuteReader(); 
    while(dataReader.Read()){
      int regNo = Convert.ToInt32(dataReader.GetValue(0));
      string pwd = dataReader.GetValue(1).ToString();
      if(registerNumber == regNo && password.Equals(pwd)){
        isValidUser = true;
      }
    }
    return isValidUser;
  }
  public bool isValidEmailId(string email)
  { 
    string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
    return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
  }

  public bool isValidString(string s){
    string regex = @"^[a-z A-Z .]+$";
    return Regex.IsMatch(s,regex,RegexOptions.IgnoreCase);
  }

  public bool isValidName(string s){
    string regex = @"^[a-z A-Z]+$";
    return Regex.IsMatch(s,regex,RegexOptions.IgnoreCase);
  }
}