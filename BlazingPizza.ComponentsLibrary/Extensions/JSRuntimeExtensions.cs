using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary.Extensions {
    public static class JSRuntimeExtensions {
        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message) {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }

        public static async Task EvalVoidAsync(this IJSRuntime jsRuntime, string script) {
            if (script.Length > 0) {
                await jsRuntime.InvokeVoidAsync("eval" , script);
            }
        }

        public static async Task<T> EvalAsync<T>(this IJSRuntime jsRuntime , string script) {
            T Result = default;
            if (!string.IsNullOrWhiteSpace(script)) {
                script = $"(function(){{{script}}})()";
                Result = await jsRuntime.InvokeAsync<T>("eval" , script); //El objeto eval ejecuta el codigo JavaScript que le pases
            }
            return Result;
        }
    }
}
