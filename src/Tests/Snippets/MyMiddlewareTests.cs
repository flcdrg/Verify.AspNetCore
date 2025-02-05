﻿using Microsoft.AspNetCore.Http;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class MyMiddlewareTests
{
    #region MyMiddlewareTest
    [Fact]
    public async Task Test()
    {
        var nextCalled = false;
        var middleware = new MyMiddleware(
            _ =>
            {
                nextCalled = true;
                return Task.CompletedTask;
            });

        var context = new DefaultHttpContext();
        await middleware.Invoke(context);

        await Verifier.Verify(
            new
            {
                context.Response,
                nextCalled
            });
    }
    #endregion
}