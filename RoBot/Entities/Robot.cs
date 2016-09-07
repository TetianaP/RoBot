using RoBot.Classes;

namespace RoBot.Entities
{
    public class Robot : Item
    {
        /// <summary>
        /// Direction of cource
        /// </summary>
        public Direction Direction { get; set; }

        public BidimensionalPoint GetPosition()
        {
            return this.Position as BidimensionalPoint;
        }

        public void SetPosition(BidimensionalPoint point)
        {
            this.Position = point;
        }
    }
}
