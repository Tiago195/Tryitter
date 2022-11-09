using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Tryitter.Repository;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Tryitter.Model;
using Tryitter.DTO;
using System.Text;

namespace Tryitter.Test;

public class UserSucessIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
  public HttpClient client;
  public UserSucessIntegrationTest(WebApplicationFactory<Program> factory)
  {
    client = factory.WithWebHostBuilder(builder =>
    {
      builder.ConfigureServices(service =>
      {
        var descriptor = service.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TryitterContext>));
        if (descriptor != null)
        {
          service.Remove(descriptor);
          // service.Remove(service.Select(x => x))
        }
        service.AddDbContext<TryitterContextTest>(options =>
        {
          options.UseInMemoryDatabase("InMemory");
        });

        service.AddScoped<ITryitterContext, TryitterContextTest>();
        service.AddScoped<IUserRepository, UserRepository>();
        var sp = service.BuildServiceProvider();
        var scope = sp.CreateScope();
        var appContext = scope.ServiceProvider.GetRequiredService<TryitterContextTest>();


        appContext.Database.EnsureDeleted();
        appContext.Database.EnsureCreated();
        appContext.users.AddRange(Helpers.GetUsers());

        appContext.SaveChanges();

      });
    }).CreateClient();
  }

  [Fact]
  public async Task TestUserGetAll()
  {
    var response = await client.GetAsync("user");
    var usersJSON = await response.Content.ReadAsStringAsync();
    var users = JsonConvert.DeserializeObject<List<UserModel>>(usersJSON);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    users.Count.Should().Be(2);
  }

  [Fact]
  public async Task TestUserGetById()
  {
    var response = await client.GetAsync("/user/1");
    var usersJSON = await response.Content.ReadAsStringAsync();
    var users = JsonConvert.DeserializeObject<UserModel>(usersJSON);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    users.UserId.Should().Be(1);
  }

  [Fact]
  public async Task TestUserCreate()
  {
    var user = new UserModel { Email = "testando@create.com", Name = "testado", Password = "test123" };
    var userJson = JsonConvert.SerializeObject(user);
    var content = new StringContent(userJson, Encoding.UTF8, "application/json");

    var response = await client.PostAsync("user", content);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
  }

  [Fact]
  public async Task TestUserLogin()
  {
    var user = new UserLoginDto { Email = "userTwo@email.com", Password = "123456" };
    var userJson = JsonConvert.SerializeObject(user);
    var content = new StringContent(userJson, Encoding.UTF8, "application/json");

    var response = await client.PostAsync("login", content);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }

  [Fact]
  public async Task TestUserUpdate()
  {
    var userLogin = new UserLoginDto { Email = "userTwo@email.com", Password = "123456" };
    var userJsonLogin = JsonConvert.SerializeObject(userLogin);
    var contentLogin = new StringContent(userJsonLogin, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("login", contentLogin);
    var token = await response.Content.ReadAsStringAsync();

    var userUpdate = new UserUpdateDto { Email = "user2@email.com", Password = "123321", Name = "newName" };
    var userJsonUpdate = JsonConvert.SerializeObject(userUpdate);
    var contentUpdate = new StringContent(userJsonUpdate, Encoding.UTF8, "application/json");

    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

    var responseUpdate = await client.PutAsync("user/2", contentUpdate);
    var responseUpdateString = await responseUpdate.Content.ReadAsStringAsync();
    var responseUpdateJson = JsonConvert.DeserializeObject<UserModel>(responseUpdateString);

    responseUpdate.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    responseUpdateJson.Name.Should().Be("newName");
    responseUpdateJson.Email.Should().Be("user2@email.com");
    responseUpdateJson.Password.Should().Be("123321");
  }

  [Fact]
  public async Task TestUserDelete()
  {
    var userLogin = new UserLoginDto { Email = "user1@gmail.com", Password = "123321" };
    var userJsonLogin = JsonConvert.SerializeObject(userLogin);
    var contentLogin = new StringContent(userJsonLogin, Encoding.UTF8, "application/json");
    var responseLogin = await client.PostAsync("login", contentLogin);
    var token = await responseLogin.Content.ReadAsStringAsync();

    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

    var responseDelete = await client.DeleteAsync("user/1");

    responseDelete.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

  }
}