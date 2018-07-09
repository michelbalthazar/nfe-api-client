using ServiceInvoice.Domain.Common;
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
        public static async Task<Result<InvoiceResource>> ResponseValidate(HttpResponseMessage response)
        {
            var status = response?.StatusCode;

            if (status == HttpStatusCode.BadRequest)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<InvoiceResource>(ResultStatusCode.BadRequest, responseData);
            }
            else
            if (status == HttpStatusCode.Unauthorized)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<InvoiceResource>(ResultStatusCode.Unauthorized, responseData);
            }
            else
            if (status == HttpStatusCode.RequestTimeout)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<InvoiceResource>(ResultStatusCode.TimedOut, responseData ?? "timeout");
            }
            else
            if (status == HttpStatusCode.InternalServerError)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<InvoiceResource>(ResultStatusCode.Error, responseData);
            }
            else
            if (status != HttpStatusCode.Accepted && status != HttpStatusCode.OK && status != HttpStatusCode.NoContent)
            {
                var responseData = await response?.Content.ReadAsStringAsync();
                return new Result<InvoiceResource>(ResultStatusCode.Error, responseData ?? "The HTTP status code of the response was not expected");
            }

            var responseResult = await response.Content.ReadAsStringAsync();
            try
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceResource>(responseResult);
                return result;
            }
            catch (Exception ex)
            {
                return new Result<InvoiceResource>(ResultStatusCode.Error, ex.Message);
            }
        }
    }
}
