public class FastCommands
{
    ///<summary>
    /// Console WriteLine
    ///</summary>
    public void cwl(Object msg)
    {
        System.Console.WriteLine(msg);
    }

    ///<summary>
    /// Console Write
    ///</summary>
    public void cw(Object msg)
    {
        System.Console.Write(msg);
    }
    public void errorWriter(Exception excp)
    {
        try
        {
            cwl(createLine("=", 10) + "Error" + createLine("=", 10));
            cwl(excp.Message);
            cwl(excp.ToString().Substring(excp.ToString().LastIndexOf(":")));
            cwl(createLine("=", 25));
        }
        catch
        {
            cwl(excp.Message);
        }
    }
    public string createLine(string ch, int len)
    {
        string res = "";
        for (int i = 0; i < len; i++)
        {
            res += ch;
        }
        return res;
    }
    public int getMaxLength(string[] strs)
    {
        if (strs.Length < 1)
        {
            return 0;
        }
        int mxlen = strs[0].Length;
        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i].Length > mxlen)
            {
                mxlen = strs[i].Length;
            }
        }
        return mxlen;
    }

    public int createdTitleLength = 0;
    public string createTitleLine(string msg, string titleChar, int titleCharLen)
    {
        createdTitleLength = (createLine(titleChar, titleCharLen) + msg + createLine(titleChar, titleCharLen)).Length;
        return createLine(titleChar, titleCharLen) + msg + createLine(titleChar, titleCharLen);
    }

    public ConsoleKeyInfo WaitForKey(string? msg = null, bool writeLine = false)
    {
        if (writeLine) { cwl((msg != null) ? msg : ""); }
        else { cw((msg != null) ? msg : ""); }
        return Console.ReadKey();
    }

    ///<summary>
    /// converts int[65,91] to char <br></br>
    /// ascii [65,91] = uppercase chars
    ///</summary>
    public string GetRandomString(int length)
    {
        string result = "";
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            result += Convert.ToChar(rnd.Next(65, 91));
        }
        return result;
    }


    ///<summary>
    /// Converts int to char (ascii) <br></br>
    /// Random.Range = [Min,Max]
    ///</summary>
    public string GetRandomString(int length, int asciiMin, int asciiMax)
    {
        string result = "";
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            result += Convert.ToChar(rnd.Next(asciiMin, asciiMax));
        }
        return result;
    }
    public int RandomNumber(int min, int max)
    {
        return (new Random()).Next(min, max);
    }

    ///<summary>
    /// Checks is TXT and Target equal
    ///</summary>
    public bool IsItSays(string txt, string target)
    {
        if (txt == null || target == null)
        {
            return false;
        }
        else
        {
            if (target.Length > 0 && txt.ToLower().StartsWith(target.ToLower()[0]))
            {
                return true;
            }
        }
        return false;
    }


    public bool CanConvertToInt(string txt)
    {
        try
        {
            Convert.ToInt32(txt);
            return true;
        }
        catch
        {

            return false;
        }
    }


}