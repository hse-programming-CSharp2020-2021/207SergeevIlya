using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Task_1
{
    static void DirectoryOverview(string DirPath)
    {
        // Текущая директория
        DirectoryInfo Dir = new DirectoryInfo(DirPath);

        Console.WriteLine(Dir.Name);
        Console.WriteLine(Dir.Attributes.ToString());
        Console.WriteLine(Dir.CreationTime.ToString());
        Console.WriteLine(Dir.LastAccessTime.ToString());

        // Поддиректории
        string[] SubDirs = Directory.GetDirectories(DirPath);

        foreach (string dir in SubDirs)
            DirectoryOverview(dir);
    }

    public static void Main(string[] args)
    {
        string DirPath = Console.ReadLine();

        try
        {
            DirectoryOverview(DirPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}