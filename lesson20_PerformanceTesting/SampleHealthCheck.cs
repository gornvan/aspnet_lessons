﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace lesson20_PerformanceTesting
{
    public sealed class SampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // All is well!
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
