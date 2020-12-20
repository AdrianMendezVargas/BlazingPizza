using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary {
    public static class LocalStorage {
        public static ValueTask<T> GetAsync<T>(IJSRuntime jSRuntime , string key) {
            return jSRuntime.InvokeAsync<T>("blazorLocalStorage.get" , key);
        } 

        public static ValueTask SetAsync(IJSRuntime jSRuntime , string key, object value) {
            return jSRuntime.InvokeVoidAsync("blazorLocalStorage.set" , key , value);
        }

        public static ValueTask DeleteAsync(IJSRuntime jSRuntime , string key) {
            return jSRuntime.InvokeVoidAsync("blazorLocalStorage.delete" , key);
        }
    }
}
