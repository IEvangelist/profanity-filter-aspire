using ProfanityFilter.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ClientServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="ProfanityFilterClient"/> to the underlying <paramref name="services"/>
    /// as a singleton, with the given <paramref name="clientBaseAddress"/>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="clientBaseAddress">The base address for the profanity filter client.</param>
    /// <returns>The same service collection, with the added client registration.</returns>
    /// <exception cref="ArgumentNullException">
    /// Throws an argument null exception when <paramref name="services"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Throws an argument exception when <paramref name="clientBaseAddress"/> is <see langword="null"/>, empty or whitespace.
    /// </exception>
    public static IServiceCollection AddProfanityFilterClient(
        this IServiceCollection services,
        string? clientBaseAddress)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(clientBaseAddress);

        services.AddSingleton(
            implementationFactory: _ => ClientFactory.Create(clientBaseAddress));

        return services;
    }
}
