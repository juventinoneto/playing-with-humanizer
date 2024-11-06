using System.Globalization;
using Humanizer;
using PlayingWithHumanizer;

ConfigureConsole();

OutputCasings("The cat sat on the mat");
OutputCasings("THE CAT SAT ON THE MAT");
OutputCasings("the cat sat on the mat, the frog jumped");

OutputSpacesAndDashes();

OutputEnumNames();

static void ConfigureConsole(string culture = "en-US")
{
    var encoding = System.Text.Encoding.UTF8;
    Thread t = Thread.CurrentThread;
    t.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    t.CurrentUICulture = t.CurrentCulture;
    WriteLine("Current culture: {0}", t.CurrentCulture.DisplayName);
    WriteLine();
}

static void OutputCasings(string original)
{
    WriteLine("Original casing: {0}", original);
    WriteLine("Lower casing: {0}", original.Transform(To.LowerCase));
    WriteLine("Upper casing: {0}", original.Transform(To.UpperCase));
    WriteLine("Title casing: {0}", original.Transform(To.TitleCase));
    WriteLine("Sentence casing: {0}", original.Transform(To.SentenceCase));
    WriteLine("Lower, then Sentence casing: {0}", original.Transform(To.LowerCase, To.SentenceCase));
    WriteLine();
}

static void OutputSpacesAndDashes()
{
    string ugly = "ERROR_MESSAGE_FROM_SERVICE";
    WriteLine("Original string: {0}", ugly);
    WriteLine("Humanized: {0}", ugly.Humanize());
    WriteLine("Humanized lower case: {0}", ugly.Humanize(LetterCasing.LowerCase));
    WriteLine("Transformed (lower case, then sentence case): {0}", ugly.Transform(To.LowerCase, To.SentenceCase));
    WriteLine("Humanized, Transformed (lower case, then sentence case): {0}", ugly.Humanize().Transform(To.LowerCase, To.SentenceCase));
    WriteLine();
}

static void OutputEnumNames()
{
    var favoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
    WriteLine("Raw enum value name: {0}", favoriteAncientWonder);
    WriteLine("Humanized: {0}", favoriteAncientWonder.Humanize());
    WriteLine("Humanized, then Titlelized: {0}", favoriteAncientWonder.Humanize().Titleize());
    WriteLine("Truncated to 8 characters: {0}", favoriteAncientWonder.ToString().Truncate(length: 8));
    WriteLine("Kebaberized: {0}", favoriteAncientWonder.ToString().Kebaberize());
}