
class Student{
  //attributes 
  private string firstName;
  private string lastName;
  private int age;
  private DateTime dateOfBirth;
  private string address;
  private long mobileNumber;
  private string emailId;
  public string collegeName;
  public string courseName;
  public string specialization;
  private float cgpa;
  private string password;

  // getters and setters for private attributes

  public string FirstName{
    get{return firstName;}
    set{firstName =value;}
  }

  public string LastName{
    get{return lastName;}
    set{lastName =value;}
  }
  
  public int Age{
    get{return age;}
    set{age = value;}
  }
  public string Address{
    get{return address;}
    set{address = value;}
  }

  public long MobileNumber{
    get{return mobileNumber;}
    set{mobileNumber = value;}
  }
  public string EmailId{
    get{return emailId;}
    set{emailId = value;}
  } 
  public DateTime DateofBirth{
    get{return dateOfBirth;}
    set{dateOfBirth = value;}
  }

  public float Cgpa{
    get{return cgpa;}
    set{cgpa = value;}
  }

  public string Password{
    get{return password;}
    set{password = value;}
  }

  public void displayStudentDetails(){
    Console.WriteLine("------------- The Student Details are --------------");
    Console.WriteLine($"First Name: {firstName}");
    Console.WriteLine($"Last Name: {lastName}");
    Console.WriteLine($"Age: {age}");
    Console.WriteLine($"Date of Birth: {age}");
    Console.WriteLine($"Mobile Number: {mobileNumber}");
    Console.WriteLine($"Email Id: {emailId}");
    Console.WriteLine($"Address: {address}");
    Console.WriteLine($"College Name: {collegeName}");
    Console.WriteLine($"Course Name: {courseName}");
    Console.WriteLine($"Specialization: {specialization}");
    Console.WriteLine($"CGPA: {cgpa}");  
  }
}