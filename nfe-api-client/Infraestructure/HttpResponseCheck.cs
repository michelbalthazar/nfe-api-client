﻿using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace nfe.api.client.Infraestructure
{
    public static class HttpResponseCheck
    {
        public static async Task<Result<Invoice>> ResponseValidate(HttpResponseMessage response)
        {
            var status = response?.StatusCode;

            if (status == HttpStatusCode.BadRequest)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<Invoice>(ResultStatusCode.BadRequest, responseData);
            }
            else
            if (status == HttpStatusCode.Unauthorized)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<Invoice>(ResultStatusCode.Unauthorized, responseData);
            }
            else
            if (status == HttpStatusCode.RequestTimeout)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<Invoice>(ResultStatusCode.TimedOut, responseData ?? "timeout");
            }
            else
            if (status == HttpStatusCode.InternalServerError)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<Invoice>(ResultStatusCode.Error, responseData);
            }
            else
            if (status != HttpStatusCode.OK && status != HttpStatusCode.NoContent)
            {
                var responseData = await response?.Content.ReadAsStringAsync();
                return new Result<Invoice>(ResultStatusCode.Error, responseData ?? "The HTTP status code of the response was not expected");
            }

            var responseResult = await response.Content.ReadAsStringAsync();
            try
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Invoice>(responseResult);
                return result;
            }
            catch (Exception ex)
            {
                return new Result<Invoice>(ResultStatusCode.Error, ex.Message);
            }
        }
    }
}
