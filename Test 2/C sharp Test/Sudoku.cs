using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C_sharp_Test
{
    internal class Sudoku
    {
        private int grid_size;
        public bool IsValidSudoku<T>(T[][] sudoku)
        {
            return this.IsSquare(sudoku) &&
                this.IsAllIntegers(sudoku) &&
                this.NoRowDuplicates(sudoku) &&
                this.NoColumnDuplicate(sudoku) &&
                this.AreSubgridsValid(sudoku);
        }

        private bool IsAllIntegers<T>(T[][] sudoku) {
            return sudoku.All(
                row => row.All(
                    element => element is int && (int)(object)element > 0 && (int)(object)element < 10
                    )
                );
        }

        private bool IsSquare<T>(T[][] sudoku)
        {
            int rows = sudoku.Length;
            return this.IsPerfectSquare(rows) && sudoku.All(row => row.Length == rows);
        }

        private bool IsPerfectSquare(int number) {
            if(number < 1) {  
                return false; 
            }
            double sqrt = Math.Sqrt(number);
            this.grid_size = (int)Math.Floor(sqrt);
            return sqrt == Math.Floor(sqrt);
        }

        private bool NoRowDuplicates<T>(T[][] sudoku) {
            return sudoku.All(row => row.Distinct().Count() == row.Length);
        }

        private bool NoColumnDuplicate<T>(T[][] sudoku)
        {
            int rows = sudoku.Length;
            return Enumerable.Range(0, rows).All(i =>
                sudoku.Select(row => row[i]).Distinct().Count() == rows);
        }

        private bool AreSubgridsValid<T>(T[][] sudoku)
        {
            int rows = sudoku.Length;

            return Enumerable.Range(0, 9).Where(i => i % this.grid_size == 0).All(rowStart =>
                Enumerable.Range(0, 9).Where(j => j % this.grid_size == 0).All(colStart =>
                    IsSubgridValid(sudoku, rowStart, colStart)
                )
            );
        }

        private bool IsSubgridValid<T>(T[][] sudoku, int rowStart, int colStart)
        {
            return sudoku
                .Skip(rowStart)
                .Take(this.grid_size)
                .SelectMany(row => row.Skip(colStart).Take(this.grid_size))
                .Distinct()
                .Count() == ((int)Math.Pow(this.grid_size, 2));
        }
    }
}
