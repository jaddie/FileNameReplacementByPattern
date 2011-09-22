using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ReplaceNamesByPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var path in args)
            {
                Console.WriteLine("Processing " + path);
                ProcessFiles(path);
            }
        }
		// TODO: 
        static void ProcessFiles(string path)
        {
            var stack = new Stack<string>();
            stack.Push(path);

            while (stack.Count > 0)
            {

                // Pop a directory
                string dir = stack.Pop();
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    try
                    {
                        if (!file.EndsWith(".bak"))
                        {
                            Console.WriteLine("Erasing " + file);
                            File.Delete(file);
                        }
                        else
                        {
                            Console.WriteLine("Renaming File " + file + " to not have .bak on the end");
                            File.Move(file, file.Replace(".bak", ""));
                        }
                    }
                    catch (Exception e)
                    {
                        
                        //throw;
                    }
                }

                string[] directories = Directory.GetDirectories(dir);
                foreach (string directory in directories)
                {
                    // Push each directory into stack
                    stack.Push(directory);
                }
            }
        }
    }
}
