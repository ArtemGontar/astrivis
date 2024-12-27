namespace Astrivis.Domain.Entities;

/// <summary>
/// Represents metadata for a non-fungible token (NFT).
/// </summary>
public record NftMetadata
{
    /// <summary>
    /// The name of the NFT.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// The symbol of the NFT.
    /// </summary>
    public string Symbol { get; init; }

    /// <summary>
    /// The URI that points to the metadata of the NFT.
    /// </summary>
    public string Uri { get; init; }

    /// <summary>
    /// The URI that points to the image associated with the NFT.
    /// </summary>
    public string ImageUri { get; init; }
}
