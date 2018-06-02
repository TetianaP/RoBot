namespace Robot.Interfaces
{
    public interface IReporter
    {
        /// <summary>
        /// Produce information message
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);
    }
}
