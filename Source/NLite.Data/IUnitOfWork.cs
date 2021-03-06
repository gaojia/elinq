﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NLite.Data
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// DbConfigurationName
        /// </summary>
        /// <remarks>
        /// 用DbConfigurationName标致不同的UnitOfWork,目的是为了支持多数据库
        /// </remarks>
        string DbConfigurationName { get;  }
        /// <summary>
        /// 创建仓储
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> CreateRepository<T>();
        /// <summary>
        /// 启用Ado.net事务
        /// </summary>
        /// <param name="action"></param>
        /// <param name="isolationLevel"></param>
        void UsingTransaction(Action action, IsolationLevel isolationLevel = IsolationLevel.Unspecified);

    }
}
