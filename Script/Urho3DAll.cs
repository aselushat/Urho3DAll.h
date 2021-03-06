﻿using System;
using System.IO;


class Urho3DAll
{
    static string PATH = @"d:\MyGames\Urho3D15\Build\include";

    static void Main()
    {
        PATH = PATH.Replace('\\', '/');
        if (PATH[PATH.Length - 1] != '/')
            PATH += '/';

        StreamWriter result = File.CreateText("Urho3DAll.h");
        result.WriteLine("// Version: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        result.WriteLine("// Latest version: https://github.com/1vanK/Urho3DAll.h");
        result.WriteLine();
        result.WriteLine("#pragma once");
        result.WriteLine();
        result.WriteLine("#include <Urho3D/Urho3D.h>");
        result.WriteLine();

        foreach (string path in Directory.EnumerateFiles(PATH, "*.*", SearchOption.AllDirectories))
        {
            string str = path.Replace('\\', '/').Replace(PATH, "");
            if (str.StartsWith("Urho3D/ThirdParty"))
                continue;
            if (str.StartsWith("Urho3D/Graphics/Direct3D"))
                continue;
            if (str.StartsWith("Urho3D/Graphics/OpenGL"))
                continue;
            if (str.StartsWith("Urho3D/Database"))
                continue;
            if (str.StartsWith("Urho3D/AngelScript"))
                continue;
            if (str.StartsWith("Urho3D/Network"))
                continue;
            if (str.StartsWith("Urho3D/Physics"))
                continue;
            if (str == "Urho3D/LuaScript/ToluaUtils.h")
                continue;
            if (str == "Urho3D/DebugNew.h")
                continue;
            if (str == "Urho3D/librevision.h")
                continue;
            if (str == "Urho3D/Precompiled.h")
                continue;
            if (str == "Urho3D/Urho3D.h")
                continue;
            str = "#include <" + str + ">";
            result.WriteLine(str);
        }

        result.WriteLine();
        result.WriteLine("#ifdef URHO3D_ANGELSCRIPT");
        foreach (string path in Directory.EnumerateFiles(PATH + @"Urho3D\AngelScript\", "*.*", SearchOption.AllDirectories))
        {
            string str = path.Replace('\\', '/').Replace(PATH, "");
            str = "#    include <" + str + ">";
            result.WriteLine(str);
        }
        result.WriteLine("#endif");
        
        result.WriteLine();
        result.WriteLine("#ifdef URHO3D_NETWORK");
        foreach (string path in Directory.EnumerateFiles(PATH + @"Urho3D\Network\", "*.*", SearchOption.AllDirectories))
        {
            string str = path.Replace('\\', '/').Replace(PATH, "");
            str = "#    include <" + str + ">";
            result.WriteLine(str);
        }
        result.WriteLine("#endif");

        result.WriteLine();
        result.WriteLine("#ifdef URHO3D_PHYSICS");
        foreach (string path in Directory.EnumerateFiles(PATH + @"Urho3D\Physics\", "*.*", SearchOption.AllDirectories))
        {
            string str = path.Replace('\\', '/').Replace(PATH, "");
            str = "#    include <" + str + ">";
            result.WriteLine(str);
        }
        result.WriteLine("#endif");

        result.WriteLine();
        result.WriteLine("#if defined(URHO3D_DATABASE_ODBC) || defined(URHO3D_DATABASE_SQLITE)");
        result.WriteLine("#    include <Urho3D/Database/Database.h>");
        result.WriteLine("#    include <Urho3D/Database/DatabaseEvents.h>");
        result.WriteLine("#    include <Urho3D/Database/DbConnection.h>");
        result.WriteLine("#    include <Urho3D/Database/DbResult.h>");
        result.WriteLine("#endif");
        result.WriteLine();
        result.WriteLine("#include <Urho3D/DebugNew.h>");
        result.WriteLine();
        result.WriteLine("using namespace Urho3D;");
        result.Close();
    }
}
