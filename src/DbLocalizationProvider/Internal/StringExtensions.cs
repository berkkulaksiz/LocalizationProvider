// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System;
using System.Linq;

namespace DbLocalizationProvider.Internal;

internal static class StringExtensions
{
    internal static string JoinNonEmpty(this string target, string separator, string arg)
    {
        ArgumentNullException.ThrowIfNull(target);

        return string.IsNullOrEmpty(arg) ? target : $"{target}{separator}{arg}";
    }
    
    internal static string JoinNonEmpty(this string target, string separator, params string[] args)
    {
        ArgumentNullException.ThrowIfNull(target);

        return string.Join(separator, new[] { target }.Union(args.Where(s => !string.IsNullOrEmpty(s))));
    }
}
