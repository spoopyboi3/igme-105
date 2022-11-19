using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE16
{
    class King: IPiece
    {
        
        bool alive = true;
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        int row;
        int col;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        public int MoveUp(int val, int Row)
        {
            row = row - val;
            Console.WriteLine("Your king has moved up " + val + " spaces");
            return row;
        }

        public int MoveDown(int val, int Row)
        {
            row = row + val;
            Console.WriteLine("Your king has moved down " + val + " spaces");
            return row;
        }

        public int MoveRight(int val, int Col)
        {
            col = col + val;
            Console.WriteLine("Your king has moved right " + val + " spaces");
            return col;
        }

        public void MoveDiagonalDR(int val, int val2, int Row, int Col)
        {
            MoveRight(val, col);
            MoveDown(val2, row);
            Console.WriteLine("Your king has moved diagonally 2 spaces");
        }
    }
}
