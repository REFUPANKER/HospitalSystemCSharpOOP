public class TypeWriter : FastCommands
{
    ///<summary>
    /// uses Thread.Sleep();
    ///</summary>
    public void WriteLine(string msg, int delay)
    {
        for (int i = 0; i < msg.Length; i++)
        {
            cw(msg[i]);
            Thread.Sleep(delay);
        }
        cwl("");
    }
}