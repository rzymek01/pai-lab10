using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{

    public partial class Form1 : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private GUI gui = new GUI();
        private Robot robot = new Robot();

        private TransactionObserver tOb = new TransactionObserver();
        private StateObserver stateOb = new StateObserver();
        private StatisticsObserver statsOb = new StatisticsObserver();

        public Form1()
        {
            InitializeComponent();

            tOb.Gui = gui;
            tOb.Robot = robot;

            stateOb.Form = this;
            stateOb.Robot = robot;

            statsOb.Form = this;
            statsOb.Robot = robot;

            gui.Attach(tOb);
            robot.Attach(stateOb);
            robot.Attach(statsOb);

            this.Load += new System.EventHandler(Form1_Load);
        }

        private void ListChanged(object sender, ListChangedEventArgs e)
        {
            //Console.WriteLine(e.ToString());

            if (e.ListChangedType.Equals(System.ComponentModel.ListChangedType.ItemAdded))
            {
                TransactionTO t = (TransactionTO)bindingSource1.List[e.NewIndex];
                gui.RegistryNewTransaction(t);
            }
            else if (e.ListChangedType.Equals(System.ComponentModel.ListChangedType.ItemChanged))
            {
                //@todo: wyslanie zmodyfikowanego obiektu na serwer
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource1;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Price";
            column.Name = "Cena";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Amount";
            column.Name = "Liczba";
            dataGridView1.Columns.Add(column);

            // Initialize the form. 
            panel1.Controls.Add(dataGridView1);
            panel1.AutoSize = true;
            //panel1.Text = "DataGridView object binding demo";

            bindingSource1.ListChanged += new ListChangedEventHandler(ListChanged);
            // Populate the data source.
            bindingSource1.Add(new TransactionTO(10.0f, 99));
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        internal void updateState(ITransactionState state)
        {
            stateLabel.Text = state.Name;
        }

        internal void updateStats(Statictics stats)
        {
            totalAmountLabel.Text = Convert.ToString(stats.TotalAmount);
        }

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    TransactionTO t = new TransactionTO();
        //    t.Price = (float)Convert.ToDouble(tPrice.Text);
        //    t.Amount = (int)Convert.ToInt32(tAmount.Text);

        //    bindingSource1.Add(t);
        //}
    }
}
