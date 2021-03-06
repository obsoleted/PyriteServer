﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="VersionController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace PyriteServer.Controllers
{
    using System.Diagnostics;
    using System.Web.Http;
    using PyriteServer.Contracts;

    public class VersionController : ApiController
    {
        [HttpGet]
        [Route("sets/{setid}/{versionid}")]
        [CacheControl(15)]
        public IHttpActionResult Get(string setid, string versionid)
        {
            try
            {
                SetVersionResultContract result = Dependency.Storage.GetSetVersion(setid, versionid);
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "SetController::Get");
                return this.NotFound();
            }
        }
    }
}