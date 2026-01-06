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
    public class ApplicationServiceForms : IApplicationServiceForms
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5224/api/Applicant";

        public ApplicationServiceForms()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ApplicationSummaryDTOResponse>> GetApplicationsAsync(int applicantId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{applicantId}/Application");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ApplicationSummaryDTOResponse>>(
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return new List<ApplicationSummaryDTOResponse>();
        }

        public async Task AddApplicationAsync(int applicantId, ApplicationSummaryDTOResponse app)
        {
            var request = new ApplicationDTORequest
            {
                CompanyName = app.CompanyName,
                PositionTitle = app.PositionTitle,
                Status = app.Status,
                AppliedDate = app.AppliedDate,
                PreviewAnswerDate = app.PreviewAnswerDate
            };

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{applicantId}/Application", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error creating application: {error}");
            }
        }

        public async Task UpdateApplicationAsync(int applicantId, ApplicationSummaryDTOResponse app)
        {
            var request = new ApplicationDTORequest
            {
                CompanyName = app.CompanyName,
                PositionTitle = app.PositionTitle,
                Status = app.Status,
                AppliedDate = app.AppliedDate,
                PreviewAnswerDate = app.PreviewAnswerDate
            };

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{applicantId}/Application/{app.Id}", request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update application.");
            }
        }

        public async Task DeleteApplicationAsync(int applicantId, int applicationId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{applicantId}/Application/{applicationId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete application.");
            }
        }
    }
}
