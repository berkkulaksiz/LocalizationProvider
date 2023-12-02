// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System;

namespace DbLocalizationProvider.Logging;

/// <summary>
/// Interface to implement if you want to get logging from localization provider into your logging infrastructure
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Debugging is hard (been there). This method might be implemented to get more diagnostics out of library.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">Arguments for the formatting or structural logging messages</param>
     void Debug(string message, params object?[] args);

    /// <summary>
    /// Usually spam, but sometimes something useful also could be found in this severity.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">Arguments for the formatting or structural logging messages</param>
    void Info(string message, params object?[] args);

    /// <summary>
    /// Disaster happens. Look for this severity if something blows up.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">Arguments for the formatting or structural logging messages</param>
    void Error(string message, params object?[] args);

    /// <summary>
    /// Strongly typed disaster.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">Arguments for the formatting or structural logging messages</param>
    void Error(string message, Exception exception, params object?[] args);
}
