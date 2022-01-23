using CardGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class Card
    {
        public CardValue CardValue { get; set; }
        public CardSuit CardSuit { get; set; }

        public override string ToString()
        {
            return $"{CardValue.ToString()} {CardSuit.ToString()}";
        }
    }
}
