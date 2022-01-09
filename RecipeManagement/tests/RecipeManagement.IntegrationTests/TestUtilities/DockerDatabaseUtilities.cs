namespace RecipeManagement.IntegrationTests.TestUtilities;

using System.Threading.Tasks;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Model.Builders;
using Ductus.FluentDocker.Services;
using Ductus.FluentDocker.Services.Extensions;

public static class DockerDatabaseUtilities
{
    public const string DB_PASSWORD = "#testingDockerPassword#";
    private const string DB_USER = "postgres";
    private const string DB_NAME = "RecipeManagement";
    private const string DB_IMAGE = "postgres";
    private const string DB_IMAGE_TAG = "latest";
    private const string DB_CONTAINER_NAME = "IntegrationTesting_RecipeManagement";
    private const string DB_VOLUME_NAME = "IntegrationTesting_RecipeManagement";

    public static async Task<int> EnsureDockerStartedAndGetPortPortAsync()
    {
        await DockerUtilities.CleanupRunningContainers(DB_CONTAINER_NAME);
        await DockerUtilities.CleanupRunningVolumes(DB_CONTAINER_NAME);
        var freePort = DockerUtilities.GetFreePort();

        var hosts = new Hosts().Discover();
        var docker = hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");     

        // create a volume, if one doesn't already exist
        var volume = docker?.GetVolumes().FirstOrDefault(v => v.Name == DB_VOLUME_NAME) ?? new Builder()
            .UseVolume()
            .WithName(DB_VOLUME_NAME)
            .Build();

        // create container, if one doesn't already exist
        var existingContainer = docker?.GetContainers().FirstOrDefault(c => c.Name == DB_CONTAINER_NAME);

        if (existingContainer == null)
        {
            var container = new Builder().UseContainer()
                .WithName(DB_CONTAINER_NAME)
                .UseImage($"{DB_IMAGE}:{DB_IMAGE_TAG}")
                .ExposePort(freePort, 5432)
                .WithEnvironment(
                    $"POSTGRES_DB={DB_NAME}",
                    $"POSTGRES_PASSWORD={DB_PASSWORD}")
                .WaitForPort("5432/tcp", 30000 /*30s*/)
                .MountVolume(volume, "/var/lib/postgresql/data", MountType.ReadWrite)
                .Build();
    
            container.Start();

            await DockerUtilities.WaitUntilDatabaseAvailableAsync(GetSqlConnectionString(freePort.ToString()));
            return freePort;
        }

        return existingContainer.ToHostExposedEndpoint("5432/tcp").Port;
    }

    public static string GetSqlConnectionString(string port)
    {
        return DockerUtilities.GetSqlConnectionString(port, DB_PASSWORD, DB_USER, DB_NAME);
    }
}