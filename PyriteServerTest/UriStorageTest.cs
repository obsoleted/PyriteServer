﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="UriStorageTest.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace PyriteServerTest
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using PyriteServer.DataAccess;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem(@"data\", "data")]
    public class UriStorageTest
    {
        // Disabling test for now. Needs updating post blob acl setting.
        // [TestMethod]
        public async Task Initialization()
        {
            string setsJson = Path.Combine(".", "data", "sets.json");
            setsJson = Path.GetFullPath(setsJson);
            Uri setsJsonUri = new Uri(setsJson);

            UriStorage storage = new UriStorage(setsJsonUri.ToString());

            storage.WaitLoad.WaitOne();

            Assert.IsNotNull(storage.LastKnownGood);
            Assert.AreEqual(0, storage.LastKnownGood.Errors.Length);
            Assert.AreEqual(1, storage.LastKnownGood.Sets.Count);
        }
    }
}