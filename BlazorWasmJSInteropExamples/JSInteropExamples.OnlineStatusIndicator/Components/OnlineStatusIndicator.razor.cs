using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSInteropExamples.OnlineStatusIndicator.Components
{
	public partial class OnlineStatusIndicator
	{
		private string _color;

		[Inject]
		public IJSRuntime JSRuntime { get; set; }

		protected async override Task OnAfterRenderAsync(bool firstRender)
		{
			if(firstRender)
			{
				var dotNetObjRef = DotNetObjectReference.Create(this);
				await JSRuntime.InvokeVoidAsync("onlineStatusIndicator.registerOnlineStatusHandler", dotNetObjRef);
			}
		}

		[JSInvokable]
		public void SetOnlineStatusColor(bool isOnline)
		{
			_color = isOnline ? "green" : "red";
			StateHasChanged();
		}
	}
}
