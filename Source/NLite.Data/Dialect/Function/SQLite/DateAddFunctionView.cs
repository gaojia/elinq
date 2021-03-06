﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Common;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.SQLite
{
    class DateAddFunctionView : IFunctionView
    {
        static readonly IFunctionView AddDate = new AddDateFunctionView();
        static readonly Dictionary<DateParts, IFunctionView> functions = new Dictionary<DateParts, IFunctionView>
                    {
                        { DateParts.Year,AddDateTemplateFunctionView.AddYears},
                        { DateParts.Quarter,FunctionView.NotSupport("DateAdd.Quarter")},
                        { DateParts.Month,AddDateTemplateFunctionView.AddMonths},
                        { DateParts.Week,FunctionView.NotSupport("DateAdd.Week")},
                        { DateParts.Day,AddDateTemplateFunctionView.AddDays},
                        { DateParts.Hour,AddDateTemplateFunctionView.AddHours},
                        { DateParts.Minute,AddDateTemplateFunctionView.AddMinutes},
                        { DateParts.Second,AddDateTemplateFunctionView.AddSeconds},
                        { DateParts.Millisecond,FunctionView.NotSupport("DateAdd.Millisecond")},
                        { DateParts.Date,new AddDateFunctionView()},
                       
                    };
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            var datePart = (DateParts)(args[0] as ConstantExpression).Value;
            if (datePart == DateParts.TimeSpan)
            {
                AddDate.Render(builder, args);
                return;
            }
            IFunctionView f;
            if (functions.TryGetValue(datePart, out f))
                f.Render(builder, args[1], args[2]);
            else
                throw new NotSupportedException(string.Format(Res.NotSupported, "The 'DateAdd." + datePart, ""));
        }
    }
}
