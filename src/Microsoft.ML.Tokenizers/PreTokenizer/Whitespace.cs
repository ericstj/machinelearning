﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.ML.Tokenizers
{
    /// <summary>
    /// The pre-tokenizer which split the text at the word boundary.
    /// The word is a set of alphabet, numeric, and underscore characters.
    /// </summary>
    public sealed class WhiteSpace : PreTokenizer
    {
        /// <summary>
        /// Gets a singleton instance of the WhiteSpace pre-tokenizer..
        /// </summary>
        public static readonly WhiteSpace Instance = new WhiteSpace();

        private const string Pattern = @"\w+|[^\w\s]+";

        /// <summary>
        /// Splits the given string in multiple substrings at the word boundary, keeping track of the offsets of said substrings from the original string.
        /// </summary>
        /// <param name="sentence">The string to split into tokens.</param>
        /// <param name="skipSpecialTokens">Indicates whether to skip the special tokens.</param>
        /// <returns>The list of the splits containing the tokens and the token's offsets to the original string.</returns>
        public override IEnumerable<Split> PreTokenize(string sentence, bool skipSpecialTokens = false)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return EmptyList;
            }

            return new RegexSplitEnumerable(sentence, Pattern);
        }
    }
}
