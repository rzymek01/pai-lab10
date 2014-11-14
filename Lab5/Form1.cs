using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{

    public partial class Form1 : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();

        private GUI gui = new GUI();
        private Robot robot = new Robot();

        private TransactionObserver tOb = new TransactionObserver();
        private StateObserver stateOb = new StateObserver();
        private StatisticsObserver statsOb = new StatisticsObserver();

        private const int totalRecords = 35;
        private const int pageSize = 10;

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
                Console.WriteLine("zarejestrowanie nowej transakcji");
                TransactionTO t = (TransactionTO)bindingSource1.List[e.NewIndex];
                gui.RegistryNewTransaction(t);
            }
            else if (e.ListChangedType.Equals(System.ComponentModel.ListChangedType.ItemChanged))
            {
                // wyslanie zmodyfikowanego obiektu na serwer
                Console.WriteLine("wyslanie zmodyfikowanego obiektu na serwer");
                TransactionTO t = (TransactionTO)bindingSource1.List[e.NewIndex];

                var sClient = new ServiceReference1.Service1Client();
                sClient.Open();
                bool result = sClient.Save(t);
                sClient.Close();

                if (result)
                {
                    MessageBox.Show("Zapisano zmiany");
                }
                else
                {
                    MessageBox.Show("Nie udało się zapisać zmian");
                }

                // dla celów dev, wyświetlenie obiektu w postaci json
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TransactionTO));
                ser.WriteObject(stream1, t);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                Console.Write("JSON of TransactionTO object: ");
                Console.WriteLine(sr.ReadToEnd());

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

            dataGridView1.Height = 280;
            dataGridView1.Width = 300;
            dataGridView1.AutoSize = false;

            // Initialize the form. 
            panel1.Controls.Add(dataGridView1);

            bindingSource1.ListChanged += new ListChangedEventHandler(ListChanged);
            // Populate the data source.
            //bindingSource1.Add(new TransactionTO(10.0f, 99));

            // init navigator
            bindingNavigator1.BindingSource = bindingSource2;
            bindingSource2.CurrentChanged += new System.EventHandler(bindingSource2_CurrentChanged);
            bindingSource2.DataSource = new PageOffsetList();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource2.Current;
            int pageNo = (offset / pageSize) + 1;
            Console.WriteLine("pageNo: " + pageNo.ToString());
            
            // pobranie strony z serwera
            var sClient = new ServiceReference1.Service1Client();
            sClient.Open();
            var list = sClient.GetPage(pageNo, pageSize);
            sClient.Close();

            bindingSource1.Clear();
            foreach (var t in list)
            {
                bindingSource1.Add(t);
            }
            //dataGridView1.Refresh();
            //panel1.Update();
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
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

        private void refreshCacheBtn_Click(object sender, EventArgs e)
        {
            var sClient = new ServiceReference1.Service1Client();
            sClient.Open();
            sClient.Refresh();
            sClient.Close();
        }

        private void dumpDataBtn_Click(object sender, EventArgs e)
        {
            var sClient = new ServiceReference1.Service1Client();
            sClient.Open();
            sClient.DumpData();
            sClient.Close();
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
