﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using NLite.Data.Mapping;
using NLite.Data.Common;
#if SDK4
using System.Dynamic;
#endif
using System.Collections.Specialized;

namespace NLite.Data
{
    #if SDK35
    /// <summary>
    /// SqlHelper 接口
    /// </summary>
    public interface IDbHelper:IDisposable
    {
        /// <summary>
        /// 执行更新
        /// </summary>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, object namedParameters=null);

        /// <summary>
        /// 执行查询并返回DataReader
        /// </summary>
        /// <returns></returns>
        DbDataReader ExecuteReader(string sql, object namedParameters=null);
        /// <summary>
        /// 执行查询并返回DataTable
        /// </summary>
        DataTable ExecuteDataTable(string sql, object namedParameters=null);

        /// <summary>
        /// 执行查询并返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="namedParameters"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string sql, object namedParameters=null);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ExecuteScalar(string sql, object namedParameters=null);

    }
#else
    /// <summary>
    /// SqlHelper 接口
    /// </summary>
    public interface IDbHelper:IDisposable
    {
        /// <summary>
        /// 得到DbConfiguration对象
        /// </summary>
        DbConfiguration DbConfiguration { get; }
        /// <summary>
        /// 得到连接对象
        /// </summary>
        DbConnection Connection { get; }
        /// <summary>
        /// 执行更新
        /// </summary>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, dynamic namedParameters = null);
        /// <summary>
        /// 执行查询并返回DataReader
        /// </summary>
        /// <returns></returns>
        DbDataReader ExecuteReader(string sql, dynamic namedParameters = null);
        /// <summary>
        /// 执行查询并返回DataTable
        /// </summary>
        /// <returns></returns>
        DataTable ExecuteDataTable(string sql, dynamic namedParameters = null);

        /// <summary>
        /// 执行查询并返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="namedParameters"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string sql, dynamic namedParameters = null);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ExecuteScalar(string sql, dynamic namedParameters = null);

    }

#endif
}

