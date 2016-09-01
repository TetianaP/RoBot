﻿using RoBot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Entities
{
    public class Item
    {
        public delegate Result PositionValidator(Position position);
        public PositionValidator OnPositionChange;

        private Position position;

        public Position Position
        {
            get { return this.position; }
            private set
            {
                if (OnPositionChange != null && !OnPositionChange(value).IsSuccess)
                {
                    return;
                }

                this.position = value;
            }
        }
    }
}