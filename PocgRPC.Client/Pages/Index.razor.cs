using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using PocgRPC.Client.Protos;
using System.Threading.Tasks;

namespace PocgRPC.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        protected string Greeting;

        protected async Task SayHello()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Blazor gRPC Client" });
            Greeting = reply.Message;

            await channel.ShutdownAsync();
        }
    }
}
