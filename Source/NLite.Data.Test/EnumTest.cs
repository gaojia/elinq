﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Collections;
using System.Linq.Expressions;
using System.Globalization;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;
using NLite.Data.Mapping;

namespace NLite.Data.Test.Where
{
    [TestClass]
    public class EnumTest:TestBase<EnumClass>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        [TestMethod]
        public virtual void Equal()
        {
            Db.Set<EnumClass>().Insert(new EnumClass {Int32=roles.Student});
            var item = Db.Set<EnumClass>().FirstOrDefault(p => p.Int32 == roles.Student);
            Assert.IsNotNull(item);
            Db.Set<EnumClass>().Delete(p => p.Int32 ==roles.Student);
        }
        [TestMethod]
        public virtual void Or()
        {
            Db.Set<EnumClass>().Insert(new EnumClass { Int32 = roles.Student|roles.Administrator });
            var item = Db.Set<EnumClass>().FirstOrDefault(p => p.Int32 == (roles.Student|roles.Administrator));
            Assert.IsNotNull(item);
            Db.Set<EnumClass>().Delete(p => p.Int32 == (roles.Student|roles.Administrator));
        }
        [TestMethod]
        public virtual void And()
        {
            Db.Set<EnumClass>().Insert(new EnumClass { Int32 = (roles.Student & roles.Administrator) });
            var item = Db.Set<EnumClass>().FirstOrDefault(p => p.Int32 == (roles.Student & roles.Administrator));
            Assert.IsNotNull(item);
            Db.Set<EnumClass>().Delete(p => p.Int32 == (roles.Student & roles.Administrator));
        }
        [TestMethod]
        public virtual void Null()
        {
            roles? role=null;
            Db.Set<EnumClass>().Insert(new EnumClass { Int32 = role, String = "Enumzxm" });
            var item = Db.Set<EnumClass>().FirstOrDefault(p=>p.Int32==role);
            Assert.IsNotNull(item);
            Console.WriteLine(item.Int32);
            Db.Set<EnumClass>().Delete(p => p.Int32 == role);
        }
    }
}
