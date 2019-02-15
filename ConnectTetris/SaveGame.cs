using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTetris
{
    [Serializable]
    class SaveGame
    {
        public int turnNo;
        public int[,] gameBoard = new int[GameManager.height + 2, GameManager.width + 2];
    }
}
