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


        [TestMethod]
        public void Solver_Test2()
        {
            // arrange
            SodukuBoard board = new SodukuBoard();
            // row 0
            board.SetCell(0, 6);
            board.SetCell(4, 1);
            board.SetCell(5, 2);
            // row 1
            board.SetCell(12, 6);
            board.SetCell(15, 3);
            board.SetCell(16, 7);
            // row 2
            board.SetCell(20, 5);
            board.SetCell(22, 9);
            board.SetCell(25, 6);
            // row 3
            board.SetCell(28, 4);
            board.SetCell(35, 5);
            // row 4
            board.SetCell(36, 3);
            board.SetCell(38, 8);
            board.SetCell(42, 6);
            board.SetCell(44, 7);
            // row 5
            board.SetCell(45, 1);
            board.SetCell(52, 9);
            // row 6
            board.SetCell(55, 1);
            board.SetCell(58, 3);
            board.SetCell(60, 8);
            // row 7
            board.SetCell(64, 7);
            board.SetCell(65, 3);
            board.SetCell(68, 6);
            // row 8
            board.SetCell(75, 4);
            board.SetCell(76, 5);
            board.SetCell(80, 6);


            // act
            SodukuBoard result = Solver.Solve(board);

            // assert
            Assert.IsTrue(result.IsSolved);
            foreach (Cell c in result.Cells)
            {
                Assert.IsTrue(c.IsSet);
            }
        }
    }
}
