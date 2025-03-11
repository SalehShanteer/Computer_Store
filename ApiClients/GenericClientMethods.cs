using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClients
{
    public class GenericClientMethods
    {
        public static async Task<T> SendRequestAsync<T>(HttpRequestMessage request, HttpClient httpClient)
        {
            try
            {
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    // Log the response for debugging purposes
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;

                    // Log the exception to the event log
                    EventLog.WriteEntry(clsUtility.sourceName,
                        $"HTTP Error: {statusCode}. Response: {errorContent}",
                        EventLogEntryType.Error);

                    return default(T);
                }
            }
            catch (Exception ex)
            {
                // Log the exception to the event log
                EventLog.WriteEntry(clsUtility.sourceName,
                    $"An unexpected error occurred: {ex.Message}",
                    EventLogEntryType.Error);

                // Rethrow the exception to propagate it to the caller
                throw;
            }
        }
    }
}
