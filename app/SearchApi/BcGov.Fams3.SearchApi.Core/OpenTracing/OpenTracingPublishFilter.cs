﻿using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using OpenTracing.Propagation;
using OpenTracing.Util;

namespace BcGov.Fams3.SearchApi.Core.OpenTracing
{
    public class OpenTracingPublishFilter : IFilter<PublishContext>
    {
        public void Probe(ProbeContext context)
        { }

        public async Task Send(PublishContext context, IPipe<PublishContext> next)
        {
            try
            {
                var operationName = $"Publishing Message: {context.DestinationAddress.GetExchangeName()}";

                var spanBuilder = GlobalTracer.Instance.BuildSpan(operationName)
                    .AsChildOf(GlobalTracer.Instance.ActiveSpan.Context)
                    .WithTag("destination-address", context.DestinationAddress?.ToString())
                    .WithTag("source-address", context.SourceAddress?.ToString())
                    .WithTag("initiator-id", context.InitiatorId?.ToString())
                    .WithTag("message-id", context.MessageId?.ToString());

                using (var scope = spanBuilder.StartActive())
                {
                    GlobalTracer.Instance.Inject(
                        GlobalTracer.Instance.ActiveSpan.Context,
                        BuiltinFormats.TextMap,
                        new MassTransitPublishContextTextMapInjectAdapter(context));

                    await next.Send(context);
                }
            }
            catch
            {
                await next.Send(context);
            }
        }
    }
}
