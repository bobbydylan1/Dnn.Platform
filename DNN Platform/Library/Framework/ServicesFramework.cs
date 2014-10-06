﻿// // DotNetNuke® - http://www.dotnetnuke.com
// // Copyright (c) 2002-2014
// // by DotNetNuke Corporation
// // 
// // Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// // documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// // the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// // to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// // 
// // The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// // of the Software.
// // 
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// // TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// // THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// // CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// // DEALINGS IN THE SOFTWARE.

using System;
using DotNetNuke.ComponentModel;
using DotNetNuke.Entities.Portals;

namespace DotNetNuke.Framework
{
    /// <summary>
    /// Enables modules to support Services Framework features
    /// </summary>
    public class ServicesFramework : ServiceLocator<IServicesFramework, ServicesFramework>
    {
        protected override Func<IServicesFramework> GetFactory()
        {
            return () => new ServicesFrameworkImpl();
        }

        public static string GetServiceFrameworkRoot()
        {
            var portalSettings = PortalController.Instance.GetCurrentPortalSettings();
            if (portalSettings == null) return String.Empty;
            var path = portalSettings.PortalAlias.HTTPAlias;
            int index = path.IndexOf('/');
            if (index > 0)
            {
                path = path.Substring(index);
            }
            else
            {
                path = "/";
            }
            path = path.EndsWith("/") ? path : path + "/";

            return path;
        }
    }
}