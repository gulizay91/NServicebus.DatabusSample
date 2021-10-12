namespace Receiver
{
  using NServiceBus;
  using System;

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
      var endpointCallbackConfiguration = new EndpointConfiguration("Samples.DataBusCallback.Receiver");
      var dataBusCallback = endpointCallbackConfiguration.UseDataBus<FileShareDataBus>();
      dataBusCallback.BasePath(@"..\..\..\storage");
      endpointCallbackConfiguration.UsePersistence<LearningPersistence>();
      endpointCallbackConfiguration.UseTransport<LearningTransport>();
      endpointCallbackConfiguration.EnableCallbacks();
      endpointCallbackConfiguration.MakeInstanceUniquelyAddressable(Environment.MachineName);
      var endpointCallbackInstance = Endpoint.Start(endpointCallbackConfiguration).GetAwaiter().GetResult();
      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
      endpointCallbackInstance.Stop().GetAwaiter().GetResult();
    }

    #endregion
  }
}
