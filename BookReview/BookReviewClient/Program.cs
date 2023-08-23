using BookReviewClient;
using BookReviewClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddHttpClient<IBookService, BookService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7190");
});


await builder.Build().RunAsync();
