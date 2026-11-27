using Supabase.Core.Attributes;
namespace Supabase.Storage;

/// <summary>
/// Represents the options for a destination in the context of Supabase Storage.
/// </summary>
public class DestinationOptions
{
    /// <summary>
    /// Gets or sets the name of the destination bucket in the context of Supabase Storage.
    /// </summary>
    [ImplementedCapability("storage.file_buckets.copy_cross_bucket")]
    [ImplementedCapability("storage.file_buckets.move_cross_bucket")]
    public string? DestinationBucket { get; set; }

    /// <summary>
    /// Gets or sets the version ID of the source file in the context of Supabase Storage.
    /// </summary>
    [ImplementedCapability("storage.file_buckets.copy_specific_version")]
    [ImplementedCapability("storage.file_buckets.move_specific_version")]
    public string? SourceVersionId { get; set; }
}
