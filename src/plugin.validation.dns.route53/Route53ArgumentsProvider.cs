﻿using Fclp;
using PKISharp.WACS.Configuration;

namespace PKISharp.WACS.Plugins.ValidationPlugins.Dns
{
    public sealed class Route53ArgumentsProvider : BaseArgumentsProvider<Route53Arguments>
    {
        public override string Name { get; } = "Route53";
        public override string Group { get; } = "Validation";
        public override string Condition { get; } = "--validationmode dns-01 --validation route53";
        public override void Configure(FluentCommandLineParser<Route53Arguments> parser)
        {
            _ = parser.Setup(_ => _.Route53IAMRole)
                .As("route53iamrole")
                .WithDescription("AWS IAM role for the current EC2 instance to login into Amazon Route 53.");

            _ = parser.Setup(_ => _.Route53AccessKeyId)
                .As("route53accesskeyid")
                .WithDescription("Access key ID to login into Amazon Route 53.");

            _ = parser.Setup(_ => _.Route53SecretAccessKey)
                .As("route53secretaccesskey")
                .WithDescription("Secret access key to login into Amazon Route 53.");
        }
    }
}