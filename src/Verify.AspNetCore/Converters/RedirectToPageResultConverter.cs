﻿using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

class RedirectToPageResultConverter :
    ResultConverter<RedirectToPageResult>
{
    protected override void InnerWrite(JsonWriter writer, RedirectToPageResult result, JsonSerializer serializer)
    {
        writer.WritePropertyName("Host");
        serializer.Serialize(writer, result.Host);
        writer.WritePropertyName("Fragment");
        serializer.Serialize(writer, result.Fragment);
        writer.WritePropertyName("Protocol");
        serializer.Serialize(writer, result.Protocol);
        writer.WritePropertyName("PreserveMethod");
        serializer.Serialize(writer, result.PreserveMethod);
        writer.WritePropertyName("PageHandler");
        serializer.Serialize(writer, result.PageHandler);
        writer.WritePropertyName("PageName");
        serializer.Serialize(writer, result.PageName);
        var values = result.RouteValues;
        if (values != null && values.Any())
        {
            writer.WritePropertyName("RouteValues");
            serializer.Serialize(writer, values.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}