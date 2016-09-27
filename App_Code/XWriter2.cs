﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for XWriters
/// </summary>
public class XWriter2
{
    public string errmsg = "";
    public int succ;
   

    public int ReadFromFile(string filepath)
    {
        try
        {
            TextReader reader = new StreamReader(filepath);
            reader.ReadLine();
            reader.Close();
            this.succ = 1;
        }
        catch (Exception exception)
        {
            this.errmsg = exception.Message;
            this.succ = 0;
        }
        return this.succ;
    }

    public int WriteToFile(string text, string filepath)
    {
        try
        {
            File.WriteAllText(filepath, text);
            this.succ = 1;
        }
        catch (Exception exception)
        {
            this.errmsg = exception.Message;
            this.succ = 0;
        }
        return this.succ;
    }
}