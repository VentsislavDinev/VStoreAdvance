﻿using Abp.Web.Mvc.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VStoreAdvances.Web.Views
{
    /// <summary>
    /// The education web view page base.
    /// </summary>
    public abstract class VStoreAdvanceWebViewPageBase : VStoreAdvanceWebViewPageBase<dynamic>
    {
    }

    /// <summary>
    /// The education web view page base.
    /// </summary>
    /// <typeparam name="TModel">
    /// </typeparam>
    public abstract class VStoreAdvanceWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EducationWebViewPageBase{TModel}"/> class.
        /// </summary>
        protected VStoreAdvanceWebViewPageBase()
        {
            //LocalizationSourceName =  "Education";
        }
    }
}