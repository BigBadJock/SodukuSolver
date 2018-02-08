using SodukoSolver.Engine;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SodokuSolver.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initialiseGrid();
        }

        private SodukuBoard board;

        public void initialiseGrid()
        {
            board = new SodukuBoard();
            this.DataContext = board;
            board.Clear();
            BindGrid();
        }

        private void BindGrid()
        {
            for (int i = 0; i < 81; i++)
            {
                var boxName = string.Format("box{0}", i);
                var textBox = (TextBox)this.FindName(boxName);
                var bindingText = string.Format("Cells[{0}].Value", i);
                var binding = new Binding(bindingText)
                {
                    StringFormat = "{0:#.#;-#.#;}"
                };
                textBox.SetBinding(TextBox.TextProperty, binding);
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            board = Solver.Solve(board);
            this.DataContext = board;
        }


        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            initialiseGrid();

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

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            initialiseGrid();
        }
    }
}
