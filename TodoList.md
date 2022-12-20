<table border="1px" >
<tr>
    <td colspan="2" width="500px"><b>To Do List</b></td>
</tr>
<tr>
    <td width="50px">Waiting</td>
    <td>[add system] Doctors can leave for week or month </td>
</tr>
<tr>
    <td width="50px">Waiting</td>
    <td>[add system] Medicines </td>
</tr>
<tr>
    <td width="50px">Waiting</td>
    <td>[add system] Prescriptions </td>
</tr>
<tr style="background-color:rgb(30,120,30);">
    <td width="50px">Dev.ing</td>
    <td>[add system] Locations </td>
</tr>
<tr>
    <td width="50px">Waiting</td>
    <td>[Info Panel] list all members[hospital] with their ranks </td>
</tr>
<tr style="background-color:rgb(30,120,30);">
    <td width="50px">Dev.ing</td>
    <td>LobbySelection - Add Selection S&P s</td>
</tr>
<tr style="background-color:rgb(30,120,30);">
    <td width="50px">Dev.ing</td>
    <td>Patient class <br>
change PatientCredential to interface
create Patient object with implemention of patientCredential & patientAuth
    </td>
</tr>
</table>


---

# *How it Works?*
## **ScanAndProcess Method**


<p>
in this method we are reading input and repeating till user wants to exit.
Every Class might need to this method because if we try to manage every input from one class
it might cause to big problems so we are multiplying the methods
</p>


### here is the code
```Csharp
    ///<summary>
    /// for exit the snp , write e<br></br>
    ///</summary>
    public virtual void ScanAndProcess()
    {
        cwl("[S&P]> exit = e");
        cw("[S&P]> Waiting Entry : ");
        string line = Console.ReadLine() + "";
        bool ExitCondition = IsItSays(line, "e");
        while (ExitCondition == false)
        {
            // you can write your code here


            // the exit condition
            if (ExitCondition == false)
            {
                cwl("[S&P]> exit = e");
                cw("[S&P]> Waiting Entry : ");
                line = Console.ReadLine() + "";
                ExitCondition = IsItSays(line, "e");
            }
        }
    }
```
- `IsItSays(txt,target);`
    - From FastCommands class
