using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beefry.FormBuilder;

namespace Cosmo.Areas.API.Controllers
{
    public class FormController : ApiController
    {
        // GET api/form
        public Form Get()
        {
            Form f = new Form();
            f.ID = 2;
            f.Template = new Template();
            f.Sections = new List<Section>();
            return f;
        }

        // GET api/form/5
        public object Get(int id)
        {
            try
            {
                Template Template = new Template();
                Template.Load(id);
                return Template;
            }
            catch (Exception ex)
            {
                return new { result="error",error=ex.Message };
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
