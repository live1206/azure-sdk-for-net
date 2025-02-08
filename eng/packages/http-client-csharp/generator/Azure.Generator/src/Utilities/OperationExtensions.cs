﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Microsoft.Generator.CSharp.Input;
using System;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class OperationExtensions
    {
        public static RequestPath GetHttpPath(this InputOperation operation)
        {
            var path = operation.Path;
            // Do not trim the tenant resource path '/'.
            return new RequestPath(path?.Length == 1 ? path : path?.TrimEnd('/') ??
                throw new InvalidOperationException($"Cannot get HTTP path from operation {operation.Name}"));
        }

        public static OperationResponse? GetServiceResponse(this InputOperation operation, int code = 200)
        {
            return operation.Responses.FirstOrDefault(r => r.StatusCodes.Contains(code));
        }
    }
}
