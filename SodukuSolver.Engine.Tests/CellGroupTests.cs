using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodukoSolver.Engine;

namespace SodukuSolver.Engine.Tests
{
    [TestClass]
    public class CellGroupTests
    {
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

    }
}
