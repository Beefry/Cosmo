using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beefry.FormBuilder;

namespace Cosmo.Areas.API.Controllers
{
    public class FormsController : ApiController
    {
        // GET api/forms
        public List<Form> Get()
        {
            FormDataAdapter adapter = new FormDataAdapter();
            List<Form> Forms = adapter.GetForms(User);
            return Forms;
        }
    }
}
