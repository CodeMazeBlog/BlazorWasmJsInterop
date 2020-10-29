using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmJSInteropExamples.Pages
{
	public partial class CallDotNetFromJavaScript
	{
		private MouseCoordinates _coordinates = new MouseCoordinates();

		[Inject]
		public IJSRuntime JSRuntime { get; set; }

		[JSInvokable]
		public static string CalculateSquareRoot(int number)
		{
			var result = Math.Sqrt(number);

			return $"The square from {number} is {result}";
		}

		[JSInvokable("CalculateSquareRootWithJustResult")]
		public static string CalculateSquareRoot(int number, bool justResult)
		{
			var result = Math.Sqrt(number);

			return !justResult ?
				$"The square root of {number} is {result}" :
				result.ToString();
		}

		private async Task SendDotNetInstanceToJS()
		{
			var dotNetObjRef = DotNetObjectReference.Create(this);
			await JSRuntime.InvokeVoidAsync("jsFunctions.registerMouseCoordinatesHandler", dotNetObjRef);
		}
		
		[JSInvokable]
		public void ShowCoordinates(MouseCoordinates coordinates)
		{
			_coordinates = coordinates;
			StateHasChanged();
		}
	}

	public class MouseCoordinates
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
