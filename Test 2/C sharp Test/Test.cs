using C_sharp_Test;

int[][] goodSudoku1 = {
            new int[] {7,8,4, 1,5,9, 3,2,6},
            new int[] {5,3,9, 6,7,2, 8,4,1},
            new int[] {6,1,2, 4,3,8, 7,5,9},
            new int[] {9,2,8, 7,1,5, 4,6,3},
            new int[] {3,5,7, 8,4,6, 1,9,2},
            new int[] {4,6,1, 9,2,3, 5,8,7},
            new int[] {8,7,6, 3,9,4, 2,1,5},
            new int[] {2,4,3, 5,6,1, 9,7,8},
            new int[] {1,9,5, 2,8,7, 6,3,4}
        };
Sudoku sudoku = new Sudoku();
bool goodSudokuValid = sudoku.IsValidSudoku(goodSudoku1);

int[][] badSudoku = {
    new int[] {5,3,5, 6,7,8, 9,1,2}, // ← duplicate '5' in this row
    new int[] {6,7,2, 1,9,5, 3,4,8},
    new int[] {1,9,8, 3,4,2, 5,6,7},
    new int[] {8,5,9, 7,6,1, 4,2,3},
    new int[] {4,2,6, 8,5,3, 7,9,1},
    new int[] {7,1,3, 9,2,4, 8,5,6},
    new int[] {9,6,1, 5,3,7, 2,8,4},
    new int[] {2,8,7, 4,1,9, 6,3,5},
    new int[] {3,4,5, 2,8,6, 1,7,9}
};

bool badSudokuValid = sudoku.IsValidSudoku(badSudoku);

Console.WriteLine($"Is the goodSudoku1 valid? {goodSudokuValid}");
Console.WriteLine($"Is the badSudoku valid? {badSudokuValid}");