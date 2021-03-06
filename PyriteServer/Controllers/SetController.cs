﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="SetController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace PyriteServer.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Http;
    using PyriteServer.Contracts;
    using PyriteServer.DataAccess.Json;

    public class SetController : ApiController
    {
        [HttpGet]
        [Route("sets/{setid}")]
        [CacheControl(15)]
        public IHttpActionResult Get(string setid)
        {
            try
            {
                IOrderedEnumerable<VersionResultContract> result = Dependency.Storage.EnumerateSetVersions(setid).OrderBy(version => version.Name);
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "SetController::Get");
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("sets")]
        [CacheControl(15)]
        public IHttpActionResult GetAll()
        {
            IOrderedEnumerable<SetResultContract> result = Dependency.Storage.EnumerateSets().OrderBy(set => set.Name);
            return this.Ok(ResultWrapper.OkResult(result));
        }
    }
}