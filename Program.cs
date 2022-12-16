namespace Program
{
    class HospitalLobby
    {
        static PatientAuth pAuth = new PatientAuth();
        static ActionController1 ac = new ActionController1();
        ///<summary> 
        ///HospitalLobby Depended to ActionController1
        ///</summary>
        static void Main(string[] args)
        {
            try
            {
                ac.Intro();
                ac.ScanAndProcess();
                //pAuth.Load();
            }
            catch (Exception excp)
            {
                ac.errorWriter(excp);
            }
        }
        
        ///<summary> 
        /// ActionController1 inherited TypeWriter
        ///</summary>
        class ActionController1 : TypeWriter
        {
            public void Intro()
            {
                Console.Clear();
                cwl(createTitleLine(" Hospital ", "=", 10));
                ListAvailableActions();
                cwl(createLine("=", createdTitleLength));
            }

            public enum AvailableActions
            {
                Appointment,
                AskLocation,
                EmergencyEntry,
                SignUp,
                SignOut,
            }

            public void ListAvailableActions()
            {
                for (int i = 0; i < Enum.GetValues<AvailableActions>().Length; i++)
                {
                    cwl(i + " | " + Enum.GetValues<AvailableActions>()[i]);
                }
            }

            ///<summary>
            /// Reads input and manages for moving to locations <br></br>
            /// for exit the snp , write e
            ///</summary>
            public void ScanAndProcess()
            {
                ac.cwl("[S&P]> exit = e");
                ac.cw("[Lobby]> Waiting Entry : ");
                string line = Console.ReadLine() + "";
                bool ExitCondition = IsItSays(line, "e");
                while (ExitCondition == false)
                {
                    if (CanConvertToInt(line))
                    {
                        for (int i = 0; i < Enum.GetValues<AvailableActions>().Length; i++)
                        {
                            if (Convert.ToInt32(line) > 0 && Convert.ToInt32(line) < Enum.GetValues<AvailableActions>().Length)
                            {
                                ExitCondition = true;
                            }
                            if (i.ToString().StartsWith(line))
                            {
                                switch (Enum.GetValues<AvailableActions>()[i])
                                {
                                    case AvailableActions.Appointment:
                                        cwl("[Moving To]> " + AvailableActions.Appointment);
                                        
                                        break;
                                    case AvailableActions.AskLocation:
                                        cwl("[Moving To]> " + AvailableActions.AskLocation);
                                        break;
                                    case AvailableActions.EmergencyEntry:
                                        cwl("[Moving To]> " + AvailableActions.EmergencyEntry);
                                        break;
                                    case AvailableActions.SignUp:
                                        cwl("[Moving To]> " + AvailableActions.SignUp);
                                        break;
                                    case AvailableActions.SignOut:
                                        cwl("[Moving To]> " + AvailableActions.SignOut);
                                        break;
                                }
                            }
                        }
                    }




                    if (ExitCondition == false)
                    {
                        Intro();
                        ac.cwl("[S&P]> exit = e");
                        ac.cw("[Lobby]> Waiting Entry : ");
                        line = Console.ReadLine() + "";
                        ExitCondition = IsItSays(line, "e");
                    }

                }
            }
        }
    }
}