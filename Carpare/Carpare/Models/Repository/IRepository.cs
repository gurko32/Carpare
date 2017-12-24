using System.Collections.Generic;

namespace Carpare.Models.Repository
{
    public interface IRepository
    {
        bool IsOpen { get; }

        /* Initialize the database */
        bool Initialize();
        //aaaaa

        /* Open the database */
        bool Open();

        /* Close the database */
        void Close();

        /* Execute an SQL command */
        int DoCommand(string sqlCommand);

        /* Execute an SQL query */
        List<object[]> DoQuery(string sqlQuery);
    }
}