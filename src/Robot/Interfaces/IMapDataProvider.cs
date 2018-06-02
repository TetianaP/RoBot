using Robot.Models;

namespace Robot.Interfaces
{
    /// <summary>
    /// Represents a surface provider for interaction. Should be widen with exact map that could be changed
    /// </summary>
    public interface IMapDataProvider
    {
        bool IsPositionAvailable(IPosition position);
    }
}
