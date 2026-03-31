// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Internal helper that projects one AsyncPageable type into another by applying a selector
// function to each item on every page. Used by backward-compat collection classes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.EventGrid
{
    internal sealed class CompatAsyncPageable<TSource, TResult> : AsyncPageable<TResult>
    {
        private readonly AsyncPageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        public CompatAsyncPageable(AsyncPageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        public override async IAsyncEnumerable<Page<TResult>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            IAsyncEnumerator<Page<TSource>> enumerator = _source.AsPages(continuationToken, pageSizeHint).GetAsyncEnumerator();
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    Page<TSource> page = enumerator.Current;
                    yield return Page<TResult>.FromValues(
                        page.Values.Select(_selector).ToList(),
                        page.ContinuationToken,
                        page.GetRawResponse());
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
