using System.Data.OleDb;
public class PatientAuth : FastCommands
{
    private static OleDbConnection dbCon =new OleDbConnection();
    private static string dbTableName = "HospitalPatientsTable";
    DatabaseController dbController=new DatabaseController();

    public PatientAuth()
    {
        //dbCon.ConnectionString=dbController.CreateConnectionString();
        dbCon.ConnectionString=dbController.ConnectionStringbase+@"C:\Users\Computer\Documents\! Software\CSharp\HospitalSimulator\Database\HospitalDatabase.accdb";
    }

    public void Load()
    {
        // for (int i = 0; i < 5; i++)
        // {
        //     PatientCredential pcred = new PatientCredential()
        //     {
        //         ID = RandomNumber(10000000, 999999999),
        //         Name = GetRandomString(5, 97, 122),
        //         Surname = GetRandomString(5),
        //         Blood = PatientCredential.BloodType.Zn
        //     };
        //     AddPatient(pcred);
        // }

        //RemovePatient(GetPatientById(78709683));
        //CheckPatientExists(pcred);
        //RemovePatient(pcred);
        //CheckPatientExists(pcred);
        //ListPatients(7);
        //GetPatientById(213788121, true);
    }

    ///<summary>
    /// no issue : returns true <br></br>
    ///    issue : returns false
    ///</summary>
    public bool UseDbConnection(Action action, bool writeErrorMsg = false, bool WriteMethodName = true)
    {
        try
        {
            if (WriteMethodName)
            {
                cwl("[Db Con Request From]>" + action.Method.Name);
            }
            dbCon.Open();
            action.Invoke();
            return true;
        }
        catch (Exception excp)
        {
            if (WriteMethodName)
            {
                cwl("[Db Con Request Failure]> " + action.Method.Name + " = " + excp.Message);
            }
            if (writeErrorMsg)
            {
                cwl(excp.Message);
            }
            return false;
        }
        finally
        {
            dbCon.Close();
            cwl("[Db Con ]> Connection Closed");
        }
    }

    ///<summary>
    /// uses Patient ID for finding patients
    ///</summary>
    public bool CheckPatientExists(PatientCredential Patient)
    {
        try
        {
            bool result = false;
            UseDbConnection(() =>
            {
                OleDbCommand dbCom = new OleDbCommand("select IdentityNo from " + dbTableName + " where IdentityNo=" + Patient.ID, dbCon);
                dbCom.ExecuteNonQuery();
                result = dbCom.ExecuteReader().Read();
            }, WriteMethodName: false);
            return result;
        }
        catch
        {
            return false;
        }
    }
    ///<summary>
    /// uses Patient ID for finding patients
    ///</summary>
    public bool CheckPatientExists(int PatientID)
    {
        try
        {
            bool result = false;
            UseDbConnection(() =>
            {
                OleDbCommand dbCom = new OleDbCommand("select IdentityNo from " + dbTableName + " where IdentityNo=" + PatientID, dbCon);
                dbCom.ExecuteNonQuery();
                result = dbCom.ExecuteReader().Read();
            });
            return result;
        }
        catch
        {
            return false;
        }
    }


    public void AddPatient(PatientCredential Patient)
    {
        if (CheckPatientExists(Patient) == false)
        {
            if (UseDbConnection(() =>
            {
                OleDbCommand dbCom = new OleDbCommand("insert into " + dbTableName + " (IdentityNo,Name,Surname,Blood) values (" + Patient.ID + ",\"" + Patient.Name + "\",\"" + Patient.Surname + "\",\"" + ((int)Patient.Blood) + "\")", dbCon);
                dbCom.ExecuteNonQuery();
            }, true))
            {
                cwl("Data Added");
            }
        }
        else
        {
            cwl("Data Already Exists");
        }
    }

    public void RemovePatient(PatientCredential Patient)
    {
        if (CheckPatientExists(Patient) == true)
        {
            if (UseDbConnection(() =>
            {
                OleDbCommand dbCom = new OleDbCommand("delete from " + dbTableName + " where IdentityNo=" + Patient.ID, dbCon);
                dbCom.ExecuteNonQuery();
            }, true))
            {
                cwl("Data Removed");
            }
        }
        else
        {
            cwl("Data Does Not Exists");
        }
    }

    public void ListPatients(int AmountPerList)
    {
        UseDbConnection(() =>
        {
            OleDbCommand dbCom = new OleDbCommand("select * from " + dbTableName, dbCon);
            dbCom.ExecuteNonQuery();
            OleDbDataReader dbRead = dbCom.ExecuteReader();
            int writen = 1;
            while (dbRead.Read())
            {
                cwl("| " + dbRead[0] + " | " + dbRead[1] + " | " + dbRead[2] + " | " + dbRead[3]);
                if (writen++ % 5 == 0)
                {
                    cwl("Type E for Stop listing,any other key to continue");
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        break;
                    }
                }
            }
        });
    }

    ///<summary>
    /// Returns null if cant find patient
    ///</summary>
    public PatientCredential GetPatientById(int patientID, bool WriteIfNull = false)
    {
        if (CheckPatientExists(patientID) == false)
        {
            cwl("Cant fint patient with this id : " + patientID);
            return new PatientCredential();
        }
        else
        {
            PatientCredential patient = new PatientCredential();
            UseDbConnection(() =>
            {
                OleDbCommand command = new OleDbCommand("select IdentityNo from " + dbTableName + " where IdentityNo=" + patientID, dbCon);
                command.ExecuteNonQuery();
                OleDbDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    patient.ID = int.Parse(read[0] + "");
                    patient.Name = read[1] + "";
                    patient.Surname = read[2] + "";
                    patient.Blood = Enum.GetValues<PatientCredential.BloodType>()[0];
                }
            });
            return patient;
        }
    }

    #region DoctorPart
    ///<summary>
    /// doctor system will require this 
    /// returns number <br></br>
    /// if something cause to error , returns null
    ///</summary>
    public int? GetAvailableNextID()
    {
        try
        {

            return 0;
        }
        catch
        {
            return null;
        }
    }

    public void RowRequestForDoctor()
    {

    }
    #endregion

}