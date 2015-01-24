namespace MatrixTraversal
{
    using System;
    using System.Text;

    /// <summary>
    /// Used to perform matrix traversal.
    /// </summary>
    public class Matrix
    {
        public const int MaxSize = 10;
        private static Location[] deltas;
        private int[,] matrix;

        static Matrix()
        {
            int directionsCount = Location.DirectionsCount;
            deltas = new Location[directionsCount];

            for (int i = 0; i < directionsCount; i++)
            {
                deltas[i] = new Location((Direction)i);
            }
        }

        public Matrix(int size)
        {
            if (size < 1 || size > MaxSize)
            {
                throw new ArgumentOutOfRangeException(
                    "size",
                    string.Format("The size of the matrix must be in the range between 1 and {0}.", MaxSize));
            }

            this.matrix = new int[size, size];
        }

        /// <summary>
        /// Fills the matrix with consecutive integer values
        /// that correspond to the route of traversal.
        /// </summary>
        public void Traverse()
        {
            this.Clear();

            int counter = 1;
            Position position = new Position(0, 0);
            Location delta = new Location(Direction.Southeast);

            while (true)
            {
                this.matrix[position.Row, position.Col] = counter;

                if (!this.CanContinue(position))
                {
                    bool newPositionFound = this.TryFindNewPosition(out position);
                    if (newPositionFound)
                    {
                        counter++;
                        this.matrix[position.Row, position.Col] = counter;
                        delta.Direction = Direction.Southeast;
                    }
                    else
                    {
                        break;
                    }
                }

                while (!this.CanGoToPosition(position.Row + delta.Row, position.Col + delta.Col))
                {
                    delta.UpdateDirectionClockwise();
                }

                position.Update(delta);
                counter++;
            }
        }

        /// <summary>
        /// Returns the string representation of the matrix.
        /// </summary>
        /// <returns>A string containing the matrix values.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                result.Append("\r\n");
            }

            result.Length -= 2;
            return result.ToString();
        }

        private void Clear()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    this.matrix[row, col] = 0;
                }
            }
        }

        /// <summary>
        /// Checks if <paramref name="row"/> and <paramref name="col"/>
        /// are valid coordinates for the next step in the matrix traversal.
        /// </summary>
        /// <param name="row">The row coordinate of the position.</param>
        /// <param name="col">The col coordinate of the position.</param>
        /// <returns>True if the position is OK, otherwise - false.</returns>
        private bool CanGoToPosition(int row, int col)
        {
            bool validRow = 0 <= row && row < this.matrix.GetLength(0);
            bool validCol = 0 <= col && col < this.matrix.GetLength(1);

            return validRow && validCol && this.matrix[row, col] == 0;
        }

        /// <summary>
        /// Checks if the traversal can continue in any direction
        /// from the specified position.
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <returns>True if another move is possible from the current position, otherwise - false.</returns>
        private bool CanContinue(Position position)
        {
            for (int i = 0; i < deltas.Length; i++)
            {
                if (this.CanGoToPosition(position.Row + deltas[i].Row, position.Col + deltas[i].Col))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a position which has remained unvisited
        /// during matrix traversal.
        /// </summary>
        /// <param name="newPosition">Keeps the first free position which has been found.</param>
        /// <returns>True if such a position has been found, otherwise - false.</returns>
        private bool TryFindNewPosition(out Position newPosition)
        {
            newPosition = new Position(0, 0);

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == 0)
                    {
                        newPosition.Row = row;
                        newPosition.Col = col;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
