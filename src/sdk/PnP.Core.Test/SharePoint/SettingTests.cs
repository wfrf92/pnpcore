﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using PnP.Core.Model.SharePoint;
using PnP.Core.Test.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Core.Test.SharePoint
{
    [TestClass]
    public class SettingTests
    {

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Configure mocking default for all tests in this class, unless override by a specific test
            TestCommon.Instance.Mocking = false;

            //Reference
            // b6917cb1-93a0-4b97-a84d-7cf49975d4ec - SitePages - Read this only - modern sites already have this activated
            // 3bae86a2-776d-499d-9db8-fa4cdc7884f8 - SharePoint Viewers - Web Scoped
            // 3bae86a2-776d-499d-9db8-fa4cdc7884f8 - Document Sets - Site Scoped
        }

        [TestMethod]
        public async Task GetFeaturesAsync()
        {
            TestCommon.Instance.Mocking = false;
            using (var context = TestCommon.Instance.GetContext(TestCommon.TestSite))
            {
                IWeb web = await context.Web.GetAsync(p => p.Features);
                Assert.IsTrue(web.Features.Length > 0);
            }
        }
        
        [TestMethod]
        public async Task EnableWebFeatureAsync()
        {
            TestCommon.Instance.Mocking = false;
            using (var context = TestCommon.Instance.GetContext(TestCommon.TestSite))
            {
                
                IWeb web = await context.Web.GetAsync(p => p.Features);

                var id = new Guid("fa6a1bcc-fb4b-446b-8460-f4de5f7411d5"); // SharePoint Viewers - Web Scoped
                IFeature feature = await web.Features.EnableAsync(id);

                Assert.IsNotNull(feature);
                Assert.IsNotNull(feature.DefinitionId);
                Assert.IsTrue(feature.DefinitionId != Guid.Empty);
            }
        }

        [TestMethod]
        public async Task DisableWebFeatureAsync()
        {
            TestCommon.Instance.Mocking = false;
            using (var context = TestCommon.Instance.GetContext(TestCommon.TestSite))
            {

                IWeb web = await context.Web.GetAsync(p => p.Features);

                var id = new Guid("fa6a1bcc-fb4b-446b-8460-f4de5f7411d5"); // SharePoint Viewers - Web Scoped
                await web.Features.DisableAsync(id);

                Assert.IsTrue(!web.Features.Any(o => o.DefinitionId == id));
            }
        }

        [TestMethod]
        public async Task EnableSiteFeatureAsync()
        {
            TestCommon.Instance.Mocking = false;
            using (var context = TestCommon.Instance.GetContext(TestCommon.TestSite))
            {
                //ISite site = await context.Site.GetAsync(p => p.Features);

                //var id = new Guid("3bae86a2-776d-499d-9db8-fa4cdc7884f8"); // Document Sets - Site Scoped
                //IFeature feature = await site.Features.EnableAsync(id);

                //Assert.IsNotNull(feature);
                //Assert.IsNotNull(feature.DefinitionId);
                //Assert.IsTrue(feature.DefinitionId != Guid.Empty);

                throw new NotImplementedException();

            }
        }

        [TestMethod]
        public async Task DisableSiteFeatureAsync()
        {
            TestCommon.Instance.Mocking = false;
            using (var context = TestCommon.Instance.GetContext(TestCommon.TestSite))
            {
                //ISite site = await context.Site.GetAsync(p => p.Features);

                //var id = new Guid("3bae86a2-776d-499d-9db8-fa4cdc7884f8"); // Document Sets - Site Scoped
                //IFeature feature = await site.Features.DisableAsync(id);

                //Assert.IsNotNull(feature);
                //Assert.IsNotNull(feature.DefinitionId);
                //Assert.IsTrue(feature.DefinitionId != Guid.Empty);

                throw new NotImplementedException();

            }
        }

    }
}
