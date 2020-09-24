using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DDDT.Implementation.Commands
{
    public class RawSqlCreateGroupCommand : ICreateGroupCommand
    {
        private readonly IDbConnection _dbConnection;

        public RawSqlCreateGroupCommand(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Id => 2;

        public string Name => "Create group command using raw sql";

        public void Execute(GroupDto request)
        {
            var query = "INSERT INTO GROUPS (name) VALUES(" + request.Name + ")";

            var command = _dbConnection.CreateCommand();
            command.CommandText = query;

            command.ExecuteNonQuery();
        }
    }
}
