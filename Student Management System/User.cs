class User{
  int registerNumber;
  string password;
  int userInput;
  public void signUpAccount(){
    StudentDatabase studentDB = new StudentDatabase();
    Console.WriteLine("********************* SIGN UP NOW *********************");
    studentDB.insertStudentDetails();
    Console.WriteLine("Please Login to continue.");
    loginAccount();
  }
  public void loginAccount(){
    bool isvalidUser = false;
    Console.WriteLine("********************* SIGN IN *********************");
    StudentDatabase studentDB = new StudentDatabase();
    registerNumber = studentDB.getRegisterNumber();
    password = studentDB.getPassword();
    do{
      if(studentDB.authenticateUser(registerNumber,password)){
        isvalidUser = true;
        Console.WriteLine("Successfully Logged In.");
        string ch = "";
        Console.WriteLine("----------------------------------------");
        int choice = 0;
        do{
          Console.WriteLine("\n##############################\n");
          Console.WriteLine("1. View Student Details\n2. Update Student Details\n3. View Student CGPA\n");
          Console.WriteLine("\n##############################\n");
          choice = getChoice();
          switch(choice){
            case 1: 
              studentDB.viewStudentDetails(registerNumber);
              break;
            case 2:
              studentDB.updateStudentDetails(registerNumber);
              break;
            case 3:
              studentDB.viewStudentCGPA(registerNumber);
              break;
            default:
              Console.WriteLine("Invalid Choice, Please enter valid choice.");
              break;
          }
          
          do{
            Console.Write("\n\nDo you want to continue to the Application, Say (yes or no)");
            ch = Console.ReadLine().Trim().ToLower();
          }while((!ch.Equals("yes"))&&(!ch.Equals("no")));

        }while(ch.Equals("yes"));
        Console.WriteLine("\n\n  *** Program Terminated *** ");     
    }
    else{
      Console.WriteLine("Your Register Number or Password might be incorrect.");
      isvalidUser = false;
    }

    }while(!isvalidUser);
    
  }

  public void showOptions(){
    Console.WriteLine("###################################################################");
    Console.WriteLine("\n\t\t\tSTUDENT MANAGEMENT SYSTEM");
    Console.WriteLine("\n###################################################################");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine(" 1.Are you a new User? Sign Up...");
    Console.WriteLine(" 2.Already Registered! Sign In using Register Number and Password.");
    Console.WriteLine(" 3.Exit");
    do{
      int userInput = getChoice();
      switch(userInput){
        case 1:
          signUpAccount();
          break;
        case 2:
          loginAccount();
          break;
        case 3:
          Console.WriteLine("The program has been terminated.");
          return;
        default:
          Console.WriteLine("Invalid Choice...");
          break;
      }
    }while(userInput!=1 || userInput!=2 || userInput!=3);
    

  }

  public int getChoice(){
    int choice;
    while(true){
      Console.Write("\nEnter your Choice: ");
      try{
        choice = int.Parse(Console.ReadLine());
        break;
      }
      catch(Exception ex){
        Console.WriteLine("\nPlease enter your choice in valid format. ( Example: 1 )");
        Console.Write(ex.Message);
      }
    }
    return choice;
  }

  
}
