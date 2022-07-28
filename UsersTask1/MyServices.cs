using UserTask1.Repo;

namespace UserTask1
{
    public static class MyServices
    {

        public static void InitServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUsers, UsersRepo>();
            Services.AddScoped<IPosts, PostsRepo>();

        }
    }
}
