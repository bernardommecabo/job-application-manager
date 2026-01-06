using ProjectShared.DTOs;
using ProjectShared.DTOs.request;
using ProjectShared.DTOs.response;
using ProjectWinForms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectWinForms.Services
{
    public class ApplicantServiceForms : IApplicantServiceForms
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5224/api/Applicant";

        public ApplicantServiceForms()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<LoginDTOResponse?> LoginAsync(string request)
        {
            var loginDTO = new LoginDTORequest();
            loginDTO.Input = request;

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/login", loginDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginDTOResponse>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                var errorContent = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException($"Requisition error: {response.StatusCode}. Details: {errorContent}");
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to connect to API: {ex.Message}");
            }
        }

        public async Task CreateAsync(ApplicantDTORequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, request);

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var errorContent = await response.Content.ReadAsStringAsync();

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var errorObj = JsonSerializer.Deserialize<ErrorResponse>(errorContent, options);

                if (errorObj != null && errorObj.Errors != null && errorObj.Errors.Count > 0)
                {
                    string errorMessage = string.Join("\n", errorObj.Errors);
                    throw new Exception(errorMessage);
                }

                if (errorObj != null && !string.IsNullOrEmpty(errorObj.Message))
                {
                    throw new Exception(errorObj.Message);
                }
            }
            catch (JsonException)
            { }
            throw new Exception($"API Error ({response.StatusCode}): {errorContent}");
        }
    }
}
