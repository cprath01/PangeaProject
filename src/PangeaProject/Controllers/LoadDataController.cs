using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PangeaProject.Domain.Queues.Interfaces;
using PangeaProject.Domain.LoadData;
using System.Net;

namespace PangeaProject.Controllers
{
    [Route("api/[controller]")]
    public class LoadDataController : Controller
    {
        IMQProducer _MQProducerManager;
        public LoadDataController(IMQProducer MQProducerManager)
        {
            _MQProducerManager = MQProducerManager;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            string result = "LoadData request has been submitted.";

            try
            {
                _MQProducerManager.DropMessage<LoadDataRequest>("All");
            }
            catch (Exception)
            {
                result = "LoadData request had an error.";
            }

            return result;
        }
        // GET api/values
        [HttpGet("{ByRequest}")]
        public string Get(string request)
        {
            string result = "LoadData request has been submitted. Request2";

            try
            {
                //LoadData                
                _MQProducerManager.DropMessage<LoadDataRequest>(WebUtility.UrlEncode(request));
            }
            catch (Exception)
            {
                result = "LoadData request had an error.";
            }

            return result;
        }


    }
}
