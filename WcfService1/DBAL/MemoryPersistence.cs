using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace WcfService1.DBAL
{
    public class MemoryPersistence
    {
        private List<Transaction> mData = new List<Transaction>();
        private List<Brocker> mBrockers = new List<Brocker>();
        private List<InvestorCE> mInvestors = new List<InvestorCE>();
        private String mFilePath;

        public MemoryPersistence(String filePath = "")
        {
            mFilePath = filePath;
        }

        //
        public List<InvestorCE> GetInvestors()
        {
            return mInvestors;
        }

        public InvestorCE GetSingleInvestor(int id)
        {
            var result = mInvestors.Find(item => item.Person.ID == id);
            return result;
        }

        //public List<Transaction> GetInvestorTransactions(int id)
        //{

        //}

        //
        public List<Brocker> GetBrockers()
        {
            return mBrockers;
        }

        public Brocker GetSingleBrocker(int id)
        {
            var result = mBrockers.Find(item => item.ID == id);
            return result;
        }

        //
        public List<Transaction> GetCollection()
        {
            return mData;
        }

        public Transaction GetSingle(int id)
        {
            var result = mData.Find(item => item.ID == id);
            return result;
        }

        public int UpdateOrInsert(TransactionTO t)
        {
            var existingT = GetSingle(t.ID);
            if (null == existingT)
            {
                // nowy rekord
                int newId = mData.Last().ID + 1;
                var newT = new Transaction(t.Price, t.Amount, newId);
                mData.Add(newT);

                return newId;
            }
            else
            {
                // aktualizacja rekordu
                existingT.Amount = t.Amount;
                existingT.Price = t.Price;

                return existingT.ID;
            }
        }

        public bool SaveToFile()
        {
            if (mFilePath.Equals(""))
            {
                return false;
            }

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Transaction>));
            ser.WriteObject(stream1, mData);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            String content = sr.ReadToEnd();

            Console.WriteLine("JSON of List<TransactionTO>:");
            Console.WriteLine(content);

            // zapis do pliku
            System.IO.File.WriteAllText(mFilePath, content);

            return true;
        }

        public bool LoadFromFile()
        {
            if (mFilePath.Equals(""))
            {
                return false;
            }

            //@see http://philcurnow.wordpress.com/2013/12/29/serializing-and-deserializing-json-in-c/

            // Brockers
            mBrockers.Add(new Brocker("Deutsche Bank DB Makler", 1));
            mBrockers.Add(new Brocker("mBank Biuro Maklerskie", 2));

            // Transactions
            Random rand = new Random();
            mData.Add(new Transaction(9.1f, mockAmount(rand), 1));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 2));
            mData.Add(new Transaction(9.3f, mockAmount(rand), 3));
            mData.Add(new Transaction(9.4f, mockAmount(rand), 4));
            mData.Add(new Transaction(9.0f, mockAmount(rand), 5));
            mData.Add(new Transaction(9.1f, mockAmount(rand), 6));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 7));
            mData.Add(new Transaction(9.8f, mockAmount(rand), 8));
            mData.Add(new Transaction(9.8f, mockAmount(rand), 9));
            mData.Add(new Transaction(9.6f, mockAmount(rand), 10));
            mData.Add(new Transaction(9.6f, mockAmount(rand), 11));
            mData.Add(new Transaction(9.1f, mockAmount(rand), 12));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 13));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 14));
            mData.Add(new Transaction(9.22f, mockAmount(rand), 15));
            mData.Add(new Transaction(9.58f, mockAmount(rand), 16));
            mData.Add(new Transaction(9.8f, mockAmount(rand), 17));
            mData.Add(new Transaction(9.77f, mockAmount(rand), 18));
            mData.Add(new Transaction(9.76f, mockAmount(rand), 19));
            mData.Add(new Transaction(9.60f, mockAmount(rand), 20));
            mData.Add(new Transaction(9.50f, mockAmount(rand), 21));
            mData.Add(new Transaction(9.3f, mockAmount(rand), 22));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 23));
            mData.Add(new Transaction(9.1f, mockAmount(rand), 24));
            mData.Add(new Transaction(9.0f, mockAmount(rand), 25));
            mData.Add(new Transaction(8.95f, mockAmount(rand), 26));
            mData.Add(new Transaction(8.8f, mockAmount(rand), 27));
            mData.Add(new Transaction(9.0f, mockAmount(rand), 28));
            mData.Add(new Transaction(9.0f, mockAmount(rand), 29));
            mData.Add(new Transaction(9.1f, mockAmount(rand), 30));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 31));
            mData.Add(new Transaction(9.3f, mockAmount(rand), 32));
            mData.Add(new Transaction(9.2f, mockAmount(rand), 33));
            mData.Add(new Transaction(9.1f, mockAmount(rand), 34));
            mData.Add(new Transaction(9.0f, mockAmount(rand), 35));

            // Investors
            var iDAO = new InvestorDAO(this);
            mInvestors.Add(new InvestorCE(iDAO, new Person("Jan", "Kowalski", 1), mData.GetRange(0, 5)));
            mInvestors.Add(new InvestorCE(iDAO, new Person("Adam", "Kulczyk", 2), mData.GetRange(5, 5)));
            mInvestors.Add(new InvestorCE(iDAO, new Person("Joanna", "Smith", 3), mData.GetRange(10, 5)));

            return true;
        }

        private int mockAmount(Random rand)
        {
            return rand.Next(1, 1000);
        }
    }
}