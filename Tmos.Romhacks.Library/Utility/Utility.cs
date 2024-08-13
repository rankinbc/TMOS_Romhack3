using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Library.Utility
{
    public static class Utility
    {
        public static T[,] TrimArray<T>(T[,] originalArray, int paddingAmount)
        {
            int rows = originalArray.GetLength(0);
            int cols = originalArray.GetLength(1);

            int minRow = rows, maxRow = 0, minCol = cols, maxCol = 0;
            bool found = false;

            // Find the bounds of the non-null data
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!Equals(originalArray[i, j], default(T)))
                    {
                        if (i < minRow) minRow = i;
                        if (i > maxRow) maxRow = i;
                        if (j < minCol) minCol = j;
                        if (j > maxCol) maxCol = j;
                        found = true;
                    }
                }
            }

            // If no non-null elements were found, return an empty array
            if (!found)
            {
                return new T[0, 0];
            }

			// Adjust the bounds to include one row/column of padding on each side
			minRow = Math.Max(0, minRow - paddingAmount);
			maxRow = Math.Min(rows - paddingAmount, maxRow + paddingAmount);
			minCol = Math.Max(0, minCol - paddingAmount);
			maxCol = Math.Min(cols - paddingAmount, maxCol + paddingAmount);


			// Determine the size of the new array
			int newRows = maxRow - minRow + 1;
            int newCols = maxCol - minCol + 1;

            // Create the new trimmed array
            T[,] trimmedArray = new T[newRows, newCols];

            // Copy the data to the new array
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newCols; j++)
                {
                    trimmedArray[i, j] = originalArray[minRow + i, minCol + j];
                }
            }

            return trimmedArray;
        }
    }
}
