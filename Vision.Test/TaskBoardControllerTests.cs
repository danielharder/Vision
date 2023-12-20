using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Vision.test;
using Vision.Server;
using System.Net;
using Vision.Server.DTO.CreateDTOs;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using Vision.Server.Models;

public class TaskBoardControllerTests : IClassFixture<WebApplicationFactory<IStartup>>
{
    

    [Fact]
    public async Task TestPipline()
    {
        
        CreateBoardDTO createBoardDTO = new CreateBoardDTO();
        createBoardDTO.Name = "UnitTestName";
        createBoardDTO.Description = "UnitTestDescription";
        var createBoardDTOContent = JsonContent.Create(createBoardDTO);


        var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var postResponse = await client.PostAsync("Taskboard", createBoardDTOContent);

        var postResponseContent = await postResponse.Content.ReadAsStringAsync();
        Console.WriteLine(postResponseContent);

        Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
        //postResponse.EnsureSuccessStatusCode();

        //// Deserialize the response content (assuming the response is JSON)
        //var responseContent = await postResponse.Content.ReadAsStringAsync();
        //var returnedBoardDTO = System.Text.Json.JsonSerializer.Deserialize<BoardDTO>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });



        //var response = await client.GetAsync($"Taskboard/{returnedBoardDTO.PK}");
        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}
