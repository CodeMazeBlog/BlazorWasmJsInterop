using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorWasmJSInteropExamples.Pages
{
	public partial class CallJavaScriptInDotNet
	{
		[Inject]
		public IJSRuntime JSRuntime { get; set; }

		private IJSObjectReference _jsModule;
		private string _registrationResult;
		private string _detailsMessage;

		protected override async Task OnInitializedAsync()
		{
			_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/jsExamples.js");
		}

		private async Task ShowAlertWindow() => 
			await _jsModule.InvokeVoidAsync("showAlert", new { Name = "John", Age = 35 });

		private async Task RegisterEmail() =>
			_registrationResult = await _jsModule.InvokeAsync<string>("emailRegistration", "Please provide your email");

		private async Task ExtractEmailInfo()
		{
			var emailDetails = await _jsModule.InvokeAsync<EmailDetails>("splitEmailDetails", "Please provide your email");

			if (emailDetails != null)
				_detailsMessage = $"Name: {emailDetails.Name}, Server: {emailDetails.Server}, Domain: {emailDetails.Domain}";
			else
				_detailsMessage = "Email is not provided.";
		}
	}
}
