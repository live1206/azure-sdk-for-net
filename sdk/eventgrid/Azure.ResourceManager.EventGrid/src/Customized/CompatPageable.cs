// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Internal helper that projects one Pageable type into another by applying a selector
// function to each item on every page. Used by backward-compat collection classes.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;

namespace Azure.ResourceManager.EventGrid
{
    internal sealed class CompatPageable<TSource, TResult> : Pageable<TResult>
    {
        private readonly Pageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        public CompatPageable(Pageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        public override IEnumerable<Page<TResult>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (Page<TSource> page in _source.AsPages(continuationToken, pageSizeHint))
            {
                yield return Page<TResult>.FromValues(
                    page.Values.Select(_selector).ToList(),
                    page.ContinuationToken,
                    page.GetRawResponse());
            }
        }
    }
}
