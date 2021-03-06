﻿using Beef.Data.Database;
using System.Data.Common;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Represents the <b>Beef.Demo</b> database.
    /// </summary>
    public class DemoDb : Database<DemoDb>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoDb{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="provider">The optional data provider.</param>
        public DemoDb(string connectionString, DbProviderFactory? provider = null) : base(connectionString, provider) { }

        /// <summary>
        /// Set the SQL Session Context when the connection is opened.
        /// </summary>
        /// <param name="dbConnection">The <see cref="DbConnection"/>.</param>
        public override void OnConnectionOpen(DbConnection dbConnection)
        {
            SetSqlSessionContext(dbConnection);
        }
    }
}