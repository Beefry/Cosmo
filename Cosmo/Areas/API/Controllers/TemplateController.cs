using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beefry.FormBuilder;

namespace Cosmo.Areas.API.Controllers
{
    public class TemplateController : ApiController
    {
        // GET api/template
        public List<Template> Get()
        {
            return ((new TemplateDataAdapter()).GetTemplates()).ToList();
        }

        // GET api/template/5
        public Template Get(int id)
        {
            return new Template(id);
        }

        // POST api/template
        public object Post(Template template)
        {
            if (template != null)
            {
                try
                {
                    template.Save();
                    return new { result = "success" };
                }
                catch (Exception ex)
                {
                    return new { result = "Error", error = ex };
                }
            }
            else
            {
                return new { result = "Error", error = "Invalid data returned to server." };
            }
        }

        // PUT api/template/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/template/5
        public void Delete(int id)
        {
        }
    }
}
