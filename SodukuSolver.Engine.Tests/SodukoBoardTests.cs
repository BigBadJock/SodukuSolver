using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodukoSolver.Engine;

namespace SodukuSolver.Engine.Tests
{
    /// <summary>
    /// Summary description for SodukoBoardTests
    /// </summary>
    [TestClass]
    public class SodukoBoardTests
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
        public void Board_Retrieve_Row_0_Test()
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
        public void Board_Retrieve_Row_8_Test()
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
        public void Board_Retrieve_Column_0_Test()
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
        public void Board_Retrieve_Column_8_Test()
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
        public void Board_Retrieve_Grid_0_Test()
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
        public void Board_Retrieve_Grid_8_Test()
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
        public void Board_Cell_SetValue_Test()
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

    }
}
