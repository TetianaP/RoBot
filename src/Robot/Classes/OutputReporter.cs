using Robot.Interfaces;
using System;

namespace Robot.Classes
{
    public class OutputReporter : IReporter
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
