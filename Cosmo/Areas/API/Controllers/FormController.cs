using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beefry.FormBuilder;
using System.Web.Http.Cors;

namespace Cosmo.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormController : ApiController
    {
        // GET api/form
        public Form Get(int? templateID = null)
        {
            if (templateID.HasValue)
            {
                Form f = new Form();
                f.New(templateID.Value, User);
                return f;
            }
            else
            {
                return null;
            }
        }

        // GET api/form/5
        public Object Get(int id)
        {
            try
            {
                Form f = new Form();
                f.Load(id, User);
                return f;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/form
        [HttpPost]
        public object Post(Form dataForm)
        {
            if (dataForm != null)
            {
                try
                {
                    dataForm.Save();
                    return new { result = "success" };
                }
                catch (Exception ex)
                {
                    return new { result = "error", error = ex.Message };
                }
            }
            else
            {
                return new { result = "error", error = "No data was passed to save" };
            }
        }

        // PUT api/form/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/form/5
        public void Delete(int id)
        {
        }
    }
}
