using System.Collections.Generic;
using System.Web.Http;
using WEBAPI_MultipleParameters.Models;
using Newtonsoft.Json.Linq;

namespace WEBAPI_MultipleParameters.Controllers
{
    public class OrderAPIController : ApiController
    {
        OrderEntities ctx;

        public OrderAPIController()
        {
            ctx = new OrderEntities(); 
        }
        public IHttpActionResult Post(JObject objData)
        {
            List<ItemDetails> lstItemDetails = new List<ItemDetails>();
            //1.
            dynamic jsonData = objData;
            //2.
            JObject orderJson = jsonData.order;
            //3.
            JArray itemDetailsJson = jsonData.itemDetails;
            //4.
            var Order = orderJson.ToObject<Order>();
            //5.
            foreach (var item in itemDetailsJson)
            {
                lstItemDetails.Add(item.ToObject<ItemDetails>());
            }
            //6.
            ctx.Orders.Add(Order);
            //7.
            foreach (ItemDetails itemDetail in lstItemDetails)
            {
                ctx.ItemDetails.Add(itemDetail);
            }

            ctx.SaveChanges();

            return Ok();
        }
    }
}

//public IHttpActionResult Post(OrderItemDetailsViewModel orderInfo)
//{
//    Order ord = orderInfo.order;
//    var ordDetails = orderInfo.itemDetails;
//    return Ok();
//}
