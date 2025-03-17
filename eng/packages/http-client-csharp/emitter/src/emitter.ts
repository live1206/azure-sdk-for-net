// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import {
  $onEmit as $onMTGEmit,
  CSharpEmitterOptions
} from "@typespec/http-client-csharp";

export async function $onEmit(context: EmitContext<CSharpEmitterOptions>) {
  context.options["plugin-name"] ??= "AzureClientPlugin";
  context.options["emitter-extension-path"] = import.meta.url;
  await $onMTGEmit(context);
}
