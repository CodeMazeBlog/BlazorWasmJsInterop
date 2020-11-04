using BlazorWasm.Toastr;
using BlazorWasm.Toastr.Enumerations;
using BlazorWasm.Toastr.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmJSInteropExamples.Pages
{
	public partial class WrappingJsLibraryInDotNet
	{
		[Inject]
		public ToastrService ToastrService { get; set; }

		private async Task ShowToastrInfo()
		{
			var message = "This is a message sent from the C# method";
			var options = new ToastrOptions
			{ 
				CloseButton = true, 
				HideDuration = 300,
				HideMethod = ToastrHideMethod.SlideUp,
				ShowMethod = ToastrShowMethod.SlideDown,
				Position = ToastrPosition.BottomRight
			};

			await ToastrService.ShowInfoMessage(message, options);
		}
	}
}
