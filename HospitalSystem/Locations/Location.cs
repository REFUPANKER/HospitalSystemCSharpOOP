public class Location : FastCommands
{
    public string? Name { get; set; }
    public List<DoctorCredential> Doctors=new List<DoctorCredential>();
    


    ///<summary>
    /// Reads input and manages for moving to locations <br></br>
    /// for exit the snp , write e<br></br>
    /// All Locations must have this method
    ///</summary>
    public virtual void ScanAndProcess()
    {
        cwl("[S&P]> exit = e");
        cw("["+Name+"]> Waiting Entry : ");
        string line = Console.ReadLine() + "";
        bool ExitCondition = IsItSays(line, "e");
        while (ExitCondition == false)
        {
            if (ExitCondition == false)
            {
                cwl("[S&P]> exit = e");
                cw("["+Name+"]> Waiting Entry : ");
                line = Console.ReadLine() + "";
                ExitCondition = IsItSays(line, "e");
            }
        }
    }
}