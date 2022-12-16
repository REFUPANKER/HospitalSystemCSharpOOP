using System.Data.OleDb;
public class DatabaseController : FastCommands
{
    public string? DatabaseFilePath { get; set; }
    public string ConnectionStringbase { get{
        return "Provider=Microsoft.ACE.Oledb.12.0; Data Source=";
    }}
    public string CreateConnectionString()
    {
        cw("\n[CREATE : Database Connection]> Where is the database : ");
        DatabaseFilePath = Console.ReadLine() + "";
        return ("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + DatabaseFilePath);
    }
}