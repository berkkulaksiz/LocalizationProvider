using System.Collections.Generic;
using System.Linq;
using DbLocalizationProvider.Abstractions;
using DbLocalizationProvider.Internal;
using Xunit;

namespace DbLocalizationProvider.Tests.ComparerTests;

public class TranslationComparerTests
{
    [Fact]
    public void CompareInvariantCultures_UsingExcept_NoChanges()
    {
        var incomingResource = new LocalizationResource("key", false);
        incomingResource.Translations.Add(new LocalizationResourceTranslation { Language = "", Value = "incoming value" });
        var existingResource = new LocalizationResource("key", false);
        existingResource.Translations.Add(new LocalizationResourceTranslation { Language = "", Value = "existing value" });
        var sut = new TranslationComparer(true);

        var differences = incomingResource.Translations.Except(existingResource.Translations, sut).ToList();

        Assert.Empty(differences);
    }

    [Fact]
    public void CompareUsingInvariant_UsingExcept_NewLanguageDetected()
    {
        var incomingResource = new LocalizationResource("key", false);
        incomingResource.Translations.AddRange(
            new List<LocalizationResourceTranslation>
            {
                new() { Language = "", Value = "incoming value" }, new() { Language = "en", Value = "incoming EN value" }
            });

        var existingResource = new LocalizationResource("key", false);
        existingResource.Translations.Add(new LocalizationResourceTranslation { Language = "", Value = "existing value" });
        var sut = new TranslationComparer(true);

        var differences = incomingResource.Translations.Except(existingResource.Translations, sut).ToList();

        Assert.NotEmpty(differences);
    }

    [Fact]
    public void TwoDifferentTranslations_InvariantCulture_ComparerShouldNotIgnore_ChangesDetected()
    {
        var sut = new TranslationComparer(false);

        var result = sut.Equals(new LocalizationResourceTranslation { Language = "", Value = "Value 1" },
                                new LocalizationResourceTranslation { Language = "", Value = "Value 2" });

        Assert.False(result);
    }

    [Fact]
    public void TwoDifferentTranslations_InvariantCulture_NoChangesDetected()
    {
        var sut = new TranslationComparer(true);

        var result = sut.Equals(new LocalizationResourceTranslation { Language = "", Value = "Value 1" },
                                new LocalizationResourceTranslation { Language = "", Value = "Value 2" });

        Assert.True(result);
    }
}
