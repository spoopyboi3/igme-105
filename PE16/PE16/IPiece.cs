using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE16
{
    public interface IPiece
    {
        int MoveUp(int val, int Row);

        int MoveDown(int val, int Row);

        int MoveRight(int val, int Col);

        void MoveDiagonalDR(int val, int val2, int Row, int Col);
    }
}
