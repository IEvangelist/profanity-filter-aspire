// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ProfanityFilter.Client.Models
{
    #pragma warning disable CS1591
    public class ProfanityFilterResponse : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The containsProfanity property</summary>
        public bool? ContainsProfanity { get; set; }
        /// <summary>The filteredText property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FilteredText { get; set; }
#nullable restore
#else
        public string FilteredText { get; set; }
#endif
        /// <summary>The filtrationSteps property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ProfanityFilter.Client.Models.ProfanityFilterStep>? FiltrationSteps { get; set; }
#nullable restore
#else
        public List<ProfanityFilter.Client.Models.ProfanityFilterStep> FiltrationSteps { get; set; }
#endif
        /// <summary>The inputText property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? InputText { get; set; }
#nullable restore
#else
        public string InputText { get; set; }
#endif
        /// <summary>The matches property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Matches { get; set; }
#nullable restore
#else
        public List<string> Matches { get; set; }
#endif
        /// <summary>The replacementStrategy property</summary>
        public int? ReplacementStrategy { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="ProfanityFilter.Client.Models.ProfanityFilterResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ProfanityFilter.Client.Models.ProfanityFilterResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProfanityFilter.Client.Models.ProfanityFilterResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "containsProfanity", n => { ContainsProfanity = n.GetBoolValue(); } },
                { "filteredText", n => { FilteredText = n.GetStringValue(); } },
                { "filtrationSteps", n => { FiltrationSteps = n.GetCollectionOfObjectValues<ProfanityFilter.Client.Models.ProfanityFilterStep>(ProfanityFilter.Client.Models.ProfanityFilterStep.CreateFromDiscriminatorValue)?.ToList(); } },
                { "inputText", n => { InputText = n.GetStringValue(); } },
                { "matches", n => { Matches = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                { "replacementStrategy", n => { ReplacementStrategy = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("containsProfanity", ContainsProfanity);
            writer.WriteStringValue("filteredText", FilteredText);
            writer.WriteCollectionOfObjectValues<ProfanityFilter.Client.Models.ProfanityFilterStep>("filtrationSteps", FiltrationSteps);
            writer.WriteStringValue("inputText", InputText);
            writer.WriteCollectionOfPrimitiveValues<string>("matches", Matches);
            writer.WriteIntValue("replacementStrategy", ReplacementStrategy);
        }
    }
}
