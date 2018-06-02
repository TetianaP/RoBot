namespace Robot.Classes
{
    /// <summary>
    /// General action result
    /// </summary>
    public class Result
    {
        public Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
    }
}
