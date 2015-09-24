using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ly.MyBarRepository;
using ly.MyBarRepository.DB;
using ly.MyBarRepository.Models;
using MongoDB.Bson;

namespace ly.MyBarRestService.Controllers
{
    public class RestaurantController : ApiController
    {
        private  BarDb<Restaurant> data = new BarDb<Restaurant>();

        // GET api/restaurant
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Value");
            response.Content = new StringContent(data.GetFilter2().ToJson());
            return response;
        }

        // GET api/restaurant/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/restaurant
        public void Post([FromBody]string value)
        {
            data.Insert();
        }

        // PUT api/restaurant/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/restaurant/5
        public void Delete(int id)
        {
        }
    }
}
