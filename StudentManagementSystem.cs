using System.Data;
using System.Data.SqlClient;
class student{
  public int registerNumber;
  public string name;
  public int age;
  public string address;
  public long mobileNumber;

  public int totalMarks;

  public student(int regNumber,string name,int age,string address,long mobileNumber,int totalMarks){
    this.registerNumber = regNumber;
    this.name = name;
    this.age = age;
    this.address = address;
    this.mobileNumber = mobileNumber;
    this.totalMarks = totalMarks;
  }

  public void displayOptions(){
    char ch='';
            Console.WriteLine("\n\tSTUDENT MANAGEMENT SYSTEM"); 
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("1. New Student\n2. Update Student\n3. Delete Student\n4. View Student\n5. View All Students\n6. View Student Result\n7. Exit\n");

            do{
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
                            updateStudent(); break;

                        case 3:
                            deleteStudent(); break;

                        case 4:
                            enterSno();
                            viewStudent(sno); break;

                        case 5:
                            viewAllStudents(); break;

                        case 6:
                            viewStudentResult(); break;

                        case 7:
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
                        
  }
  public void enterRegisterNumber()
  {
    Console.Write("\nEnter Sno : ");
    bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out sno);

    if(!IsConversionSuccessful)
      Console.Write("\nPlease enter a valid format");  
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
    totalMarks = Convert.ToInt32("Enter your total marks:");
  }


}