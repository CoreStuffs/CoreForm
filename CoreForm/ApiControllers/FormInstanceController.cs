using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStuffs.CoreForm.Data;
using CoreStuffs.CoreForm.DataInterfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreStuffs.CoreForm.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormInstanceController : ControllerBase
    {
        private IFormDefinitionProvider formDefinitionProvider;
        public FormInstanceController(IFormDefinitionProvider formDefinitionProvider)
        {
            this.formDefinitionProvider = formDefinitionProvider;
        }


        // GET: api/<FormDefinitionController>
        [HttpGet]
        public IEnumerable<DataInterfaces.DataEntities.FormDefinition> Get()
        {
            return formDefinitionProvider.GetFormDefinitions();
        }

        // GET api/<FormDefinitionController>/5
        [HttpGet("{id}")]
        public Object Get(Guid id)
        {
            string fd = System.IO.File.ReadAllText("Form1Definition.json");
            string fdm = System.IO.File.ReadAllText("Flow1DataModel.json");
            string fid = System.IO.File.ReadAllText("Flow1InstanceData.json");
            string o = "{\"formDefinition\" : " + fd + ", \"formDataModel\" : " + fdm + ", \"formInstanceData\" : " + fid + "}";
            return base.Content(o, "application/json", System.Text.Encoding.UTF8);
        }

        // POST api/<FormDefinitionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FormDefinitionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormDefinitionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
