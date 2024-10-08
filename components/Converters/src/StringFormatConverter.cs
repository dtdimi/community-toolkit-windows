// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;

namespace CommunityToolkit.WinUI.Converters;

/// <summary>
/// This class provides a binding converter to display formatted strings
/// </summary>
public partial class StringFormatConverter : IValueConverter
{
    /// <summary>
    /// Return the formatted string version of the source object.
    /// </summary>
    /// <param name="value">Object to transform to string.</param>
    /// <param name="targetType">The type of the target property, as a type reference</param>
    /// <param name="parameter">An optional parameter to be used in the string.Format method.</param>
    /// <param name="language">The language of the conversion. If language is null or empty then <see cref="CultureInfo"/> will be used.</param>
    /// <returns>Formatted string.</returns>
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is null)
        {
            return null!;
        }

        // Retrieve the format string and use it to format the value.
        string? formatString = parameter as string;
        if (string.IsNullOrEmpty(formatString))
        {
            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString()!;
        }

        try
        {
            CultureInfo culture = string.IsNullOrWhiteSpace(language) ? CultureInfo.InvariantCulture : new CultureInfo(language);
            return string.Format(culture, formatString, value);
        }
        catch
        {
            return value;
        }
    }

    /// <summary>
    /// Not implemented.
    /// </summary>
    /// <param name="value">The target data being passed to the source.</param>
    /// <param name="targetType">The type of the target property, as a type reference (System.Type for Microsoft .NET, a TypeName helper struct for Visual C++ component extensions (C++/CX)).</param>
    /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
    /// <param name="language">The language of the conversion.</param>
    /// <returns>The value to be passed to the source object.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
