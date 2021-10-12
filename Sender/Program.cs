namespace Sender
{
  using NServiceBus;
  using NServiceBus.Features;
  using Shared;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  /// <summary>
  /// Defines the <see cref="Program" />.
  /// </summary>
  internal class Program
  {
    #region Methods

    /// <summary>
    /// The Main.
    /// </summary>
    /// <param name="args">The args<see cref="string[]"/>.</param>
    internal static void Main(string[] args)
    {
      var endpointCallbackConfiguration = new EndpointConfiguration("Samples.DataBusCallback.Sender");
      var dataBusCallback = endpointCallbackConfiguration.UseDataBus<FileShareDataBus>();
      dataBusCallback.BasePath(@"..\..\..\storage");
      endpointCallbackConfiguration.EnableCallbacks();
      endpointCallbackConfiguration.UsePersistence<InMemoryPersistence>();
      endpointCallbackConfiguration.MakeInstanceUniquelyAddressable(Environment.MachineName);
      endpointCallbackConfiguration.DisableFeature<AutoSubscribe>();
      endpointCallbackConfiguration.UseTransport<LearningTransport>();

      var endpointCallbackInstance = Endpoint.Start(endpointCallbackConfiguration).GetAwaiter().GetResult();
      Console.WriteLine("Press 'C' to send a normal callback large message");
      Console.WriteLine("Press any other key to exit");
      while (true)
      {
        var key = Console.ReadKey();
        Console.WriteLine();
        if (key.Key == ConsoleKey.C)
        {
          SendMessageTaxPayer(endpointCallbackInstance);
          continue;
        }
        break;
      }
      endpointCallbackInstance.Stop().GetAwaiter().GetResult();
    }

    /// <summary>
    /// The SendMessageTaxPayer.
    /// </summary>
    /// <param name="endpointInstance">The endpointInstance<see cref="IEndpointInstance"/>.</param>
    internal static void SendMessageTaxPayer(IEndpointInstance endpointInstance)
    {
      var sendOptions = new SendOptions();
      sendOptions.SetDestination("Samples.DataBusCallback.Receiver");
      var source = new CancellationTokenSource();
      source.CancelAfter(TimeSpan.FromSeconds(240));
      TaxPayersRequest message = new TaxPayersRequest(new List<string> { "*" }, true, null);
      var callbackResult = endpointInstance.Request<TaxPayersResponse>(message, sendOptions, source.Token).GetAwaiter().GetResult();
      Console.WriteLine(callbackResult.TaxPayers.Value?.Select(r => r.Id).FirstOrDefault());
      Console.WriteLine(@"Message sent, the payload is stored in: ..\..\storage");
      System.IO.File.Delete($@"..\..\..\storage\{callbackResult.TaxPayers.Key}");
    }

    #endregion
  }
}
