using System.Data;
using System.Data.SqlClient;
class Program{
  public static void Main(string[] args){
    Console.WriteLine("Hello World");
    SqlConnection con = new SqlConnection(ConnectionString);
  }
}
