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
        public void Board_Creation_Test()
        {
            // assemble
            // act
            SodukuBoard board = new SodukuBoard();
            // assert
            Assert.IsInstanceOfType(board, typeof(SodukuBoard));
            Assert.AreEqual(81, board.Cells.Length);
        }

        [TestMethod]
        public void Cell_Creation_Test()
        {
            Cell cell = new Cell();
            Assert.IsFalse(cell.IsSet);
            Assert.AreEqual("123456789", cell.PossibleValues);
        }

        [TestMethod]
        public void Cell_SetValue_Test()
        {
            // arrange
            SodukuBoard board = new SodukuBoard();
            // act
            board.SetCell(5, 1);
            // assert
            Assert.AreEqual(1, board.Cells[5].Value);
            Assert.AreEqual(true, board.Cells[5].IsSet);
            Assert.IsTrue(string.IsNullOrEmpty(board.Cells[5].PossibleValues));
        }


        [TestMethod]
        public void CellGroup_Retrieve_Row_0_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(0, 1);
            board.SetCell(8, 9);

            //Act
            CellGroup group = board.GetRow(0);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
            Assert.AreEqual(1, group.Cells[0].Value);
            Assert.AreEqual(9, group.Cells[8].Value);
        }

        [TestMethod]
        public void CellGroup_Retrieve_Row_8_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(72, 1);
            board.SetCell(80, 9);

            //Act
            CellGroup group = board.GetRow(8);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
            Assert.AreEqual(1, group.Cells[0].Value);
            Assert.AreEqual(9, group.Cells[8].Value);
        }

        [TestMethod]
        public void CellGroup_Retrieve_Column_0_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(0, 1);
            board.SetCell(72, 9);

            //Act
            CellGroup group = board.GetColumn(0);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
            Assert.AreEqual(1, group.Cells[0].Value);
            Assert.AreEqual(9, group.Cells[8].Value);
        }

        [TestMethod]
        public void CellGroup_Retrieve_Column_8_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(8, 1);
            board.SetCell(80, 9);

            //Act
            CellGroup group = board.GetColumn(8);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
            Assert.AreEqual(1, group.Cells[0].Value);
            Assert.AreEqual(9, group.Cells[8].Value);
        }

        [TestMethod]
        public void CellGroup_Retrieve_Grid_0_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(0, 1);
            board.SetCell(20, 9);
            //Act
            CellGroup group = board.GetGrid(0);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
        }

        [TestMethod]
        public void CellGroup_Retrieve_Grid_8_Test()
        {
            //Arrange
            SodukuBoard board = new SodukuBoard();
            board.SetCell(60, 1);
            board.SetCell(80, 9);
            //Act
            CellGroup group = board.GetGrid(8);

            //Assert
            Assert.IsInstanceOfType(group, typeof(CellGroup));
            Assert.AreEqual(9, group.Cells.Length);
        }

        [TestMethod]
        public void CellGroup_SetPossibleValues_Test()
        {
            // arrange
            Cell[] cells = new Cell[9];
            for (int i = 0; i < 9; i++)
                cells[i] = new Cell();

            cells[0].Value = 1;
            cells[1].Value = 9;
            cells[2].Value = 7;
            

            CellGroup group = new CellGroup();
            group.Cells = cells;
            // act

            group.SetPossibleValues();

            // assert
            Assert.AreEqual("", group.Cells[0].PossibleValues);
            Assert.AreEqual("", group.Cells[1].PossibleValues);
            Assert.AreEqual("", group.Cells[2].PossibleValues);
            Assert.AreEqual("234568", group.Cells[3].PossibleValues);
            Assert.AreEqual("234568", group.Cells[4].PossibleValues);
            Assert.AreEqual("234568", group.Cells[5].PossibleValues);
            Assert.AreEqual("234568", group.Cells[6].PossibleValues);
            Assert.AreEqual("234568", group.Cells[7].PossibleValues);
            Assert.AreEqual("234568", group.Cells[8].PossibleValues);
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
