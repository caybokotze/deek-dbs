using System.Data;
using DapperDoodle;

namespace DeekDBS.BLL.DBMS.MySql
{
    public class InsertTransactionTable : Command<int>
    {
        private IDbConnection _connection;
        public InsertTransactionTable()
        {
            
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}