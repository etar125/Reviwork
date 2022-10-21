/*
 * Created by XereX(codaaj)
 * SharpDevelop 5.1 -> C# NET FrameWork 4.5.2
 * Thanks forums :)
 */
using System;
using System.IO;

namespace reviwork
{
	class Program
	{
		public static void Main(string[] args)
		{
			if(File.Exists("code.rwproj"))
			{
				string[] l = File.ReadAllLines("code.rwproj");
				for(int i = 0; i < l.Length; i++)
				{
					if(l[i].StartsWith("writeln:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 8);
						l[i] = l[i].TrimEnd(';');
						string text = l[i];
						l[i] = "echo " + text;
					}
					else if(l[i].StartsWith("readln:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 7);
						l[i] = l[i].TrimEnd(';');
						string var = l[i].Substring(0, l[i].IndexOf("="));
						string text = l[i].Substring(l[i].IndexOf("=") + 1);
						l[i] = "set /p " + var + "=" + text;
					}
					else if(l[i].StartsWith("set:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 4);
						l[i] = l[i].TrimEnd(';');
						string var = l[i].Substring(0, l[i].IndexOf("="));
						string text = l[i].Substring(l[i].IndexOf("=") + 1);
						l[i] = "set " + var + "=" + text;
					}
					else if(l[i] == "readkey;")
					{
						l[i] = "pause";
					}
					else if(l[i] == "sysoff;")
					{
						l[i] = "echo off";
					}
					else if(l[i] == "sc;")
					{
						l[i] = "cls";
					}
					else if(l[i].StartsWith("void:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 5);
						l[i] = l[i].TrimEnd(';');
						string text = l[i];
						l[i] = ":" + text;
					}
					else if(l[i].StartsWith("go:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 3);
						l[i] = l[i].TrimEnd(';');
						string text = l[i];
						l[i] = "goto " + text;
					}
					else if(l[i].StartsWith("ifg:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 4);
						l[i] = l[i].TrimEnd(';');
						string var = l[i].Substring(0, l[i].IndexOf("="));
						string text = l[i].Substring(l[i].IndexOf("="));
						text = text.Remove(0, 1);
						// l[i].IndexOf(":")
						string func = l[i].Substring(l[i].IndexOf(":") + 1);
						l[i] = "if %" + var + "%==" + text + " goto " + func;
					}
					else if(l[i].StartsWith("title:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 6);
						l[i] = l[i].TrimEnd(';');
						string text = l[i];
						l[i] = "title " + text;
					}
					else if(l[i].StartsWith("color:") && l[i].EndsWith(";"))
					{
						l[i] = l[i].Remove(0, 6);
						l[i] = l[i].TrimEnd(';');
						string text = l[i];
						l[i] = "color " + text;
					}
				}
				File.WriteAllLines("rwprojapp.bat", l);
			}
		}
	}
}