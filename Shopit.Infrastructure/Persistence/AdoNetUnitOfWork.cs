using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Infrastructure.Persistence
{
	public class AdoNetUnitOfWork : IUnitOfWork
	{
		private string connectionString;
		private string providerName;
		private IDbConnection connection;
		private DbProviderFactory factory;
		private IDbTransaction transaction;

		public AdoNetUnitOfWork(string connectionName, bool openConnection = true)
		{
			this.connectionString = ConfigurationManager.ConnectionStrings[connectionName].ToString();
			this.providerName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
			this.factory = DbProviderFactories.GetFactory(providerName);

			this.CreateConnection(openConnection);
		}

		public void CreateConnection(bool openConnection = true)
		{
			try
			{
				if (null != this.connection)
					return;

				this.connection = factory.CreateConnection();
				this.connection.ConnectionString = this.connectionString;

				if (true == openConnection)
					this.connection.Open();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void StartTransaction()
		{
			this.transaction = this.connection.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public IDbCommand CreateCommand()
		{
			IDbCommand command = this.connection.CreateCommand();
			command.Transaction = this.transaction;
			
			return command;
		}

		public void Commit()
		{
			this.SaveChanges();
		}

		public void SaveChanges()
		{
			if (null == this.transaction)
				return;

			this.transaction.Commit();
			this.transaction.Dispose();
			this.transaction = null;
		}

		public void CloseConnection()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (null == this.connection || ConnectionState.Closed == this.connection.State)
				return;

			this.connection.Close();
			this.connection.Dispose();
			this.connection = null;
		}
	}
}
