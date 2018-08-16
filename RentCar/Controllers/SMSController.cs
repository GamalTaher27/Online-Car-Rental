using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.AspNet.Mvc;
using Twilio.Types;

namespace RentCar.Controllers
{
    public class SMSController : TwilioController
    {
        
        public ActionResult SendSms()
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(ConfigurationManager.AppSettings["+201014322217"]);
            var from= new PhoneNumber("+16013006123");

            var message = MessageResource.Create(
                to:to,
                from:from,
                body:"Check your Mail , New Car is Rent"
                );

            return Content(message.Sid);
        }
	}
}