// Services/CieloService.cs
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteCielo.Models;

namespace BlazorCieloApp.Services
{
    public class CieloService
    {
        private readonly string _urlRequest = "https://apisandbox.cieloecommerce.cielo.com.br/1/sales";
        private string _merchantId = "*****************";
        private string _merchantKey = "*****************";
        
        public async Task<Dictionary<bool, string>> CreateTransactionCreditCard(CreditCardTransactionModel transaction)
        {
            var resultCreateTransactionCreditCard = new Dictionary<bool, string>();

            try
            {
                var client = new RestClient(_urlRequest);
                Console.WriteLine("client" + client);
                var request = new RestRequest();
                Console.WriteLine("request" + request);
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("MerchantId", _merchantId);
                request.AddHeader("MerchantKey", _merchantKey);
                request.AddJsonBody(transaction);
                Console.WriteLine("transaction" + transaction);

                var response = await client.ExecuteAsync(request);
                Console.WriteLine("response" + response);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
                {
                    var objResponse = JsonConvert.DeserializeObject<CreditCardTransactionModel>(response.Content);
                    resultCreateTransactionCreditCard.Add(true, "");
                }
                else
                {
                    resultCreateTransactionCreditCard.Add(false, response.Content);
                }
            }
            catch (Exception ex)
            {
                resultCreateTransactionCreditCard.Add(false, ex.Message);
            }

            return resultCreateTransactionCreditCard;
        }

        public async Task<Dictionary<bool, string>> CancelTransactionCreditCard(CancelTransactionModel cancelModel)
        {
            var resultCancelTransactionCreditCard = new Dictionary<bool, string>();

            try
            {
                var client = new RestClient(_urlRequest);
                var request = new RestRequest("/{paymentId}/void", Method.Put); // Endpoint para cancelar transação
                request.AddUrlSegment("paymentId", cancelModel.PaymentId);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("MerchantId", _merchantId);
                request.AddHeader("MerchantKey", _merchantKey);
                request.AddJsonBody(cancelModel);

                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.NoContent)
                {
                    resultCancelTransactionCreditCard.Add(true, "");
                }
                else
                {
                    resultCancelTransactionCreditCard.Add(false, response.Content);
                }
            }
            catch (Exception ex)
            {
                resultCancelTransactionCreditCard.Add(false, ex.Message);
            }

            return resultCancelTransactionCreditCard;
        }

    }
}