using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodukuSolver.Engine;
using SodukoSolver.Engine;

namespace SodukuSolver.Engine.Tests
{
    [TestClass]
    public class SodukuTests
    {

        [TestMethod]
        public void Cell_Creation_Test()
        {
            Cell cell = new Cell();
            Assert.IsFalse(cell.IsSet);
            Assert.AreEqual("123456789", cell.PossibleValues);
        }





 
        [TestMethod]
        public void Solver_Test()
        {
            // arrange
            SodukuBoard board = new SodukuBoard();
            // row 0
            board.SetCell(1, 6);
            board.SetCell(3, 1);
            board.SetCell(5, 4);
            board.SetCell(7, 5);
            // row 1
            board.SetCell(11, 8);
            board.SetCell(12, 3);
            board.SetCell(14, 5);
            board.SetCell(15, 6);
            // row 2
            board.SetCell(18, 2);
            board.SetCell(26, 1);
            // row 3
            board.SetCell(27, 8);
            board.SetCell(30, 4);
            board.SetCell(32, 7);
            board.SetCell(35, 6);
            // row 4
            board.SetCell(38, 6);
            board.SetCell(42, 3);
            // row 5
            board.SetCell(45, 7);
            board.SetCell(48, 9);
            board.SetCell(50, 1);
            board.SetCell(53, 4);
            // row 6
            board.SetCell(54, 5);
            board.SetCell(62, 2);
            // row 7
            board.SetCell(65, 7);
            board.SetCell(66, 2);
            board.SetCell(68, 6);
            board.SetCell(69, 9);
            // row 8
            board.SetCell(73, 4);
            board.SetCell(75, 5);
            board.SetCell(77, 8);
            board.SetCell(79, 7);


            // act
             SodukuBoard result = Solver.Solve(board);

            // assert
            Assert.IsTrue(result.IsSolved);
            foreach(Cell c in result.Cells)
            {
                Assert.IsTrue(c.IsSet);
            }
        }
    }
}
