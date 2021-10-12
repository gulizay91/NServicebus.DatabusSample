namespace Receiver
{
  using NServiceBus;
  using Shared;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  /// <summary>
  /// Defines the <see cref="CallbackMessageHandler" />.
  /// </summary>
  public class CallbackMessageHandler : IHandleMessages<TaxPayersRequest>
  {
    #region Methods

    /// <summary>
    /// The Handle.
    /// </summary>
    /// <param name="message">The message<see cref="TaxPayersRequest"/>.</param>
    /// <param name="context">The context<see cref="IMessageHandlerContext"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public async Task Handle(TaxPayersRequest message, IMessageHandlerContext context)
    {
      List<TaxPayersModel> taxPayers = new List<TaxPayersModel>();
      taxPayers.Add(
          new TaxPayersModel() { Id = Guid.NewGuid(), AccountType = 1, Alias = "xxxx", Identifier = "1111222233", Title = "dddd", FirstCreationTime = DateTime.UtcNow, }
      );
      var response = new TaxPayersResponse(new DataBusProperty<IEnumerable<TaxPayersModel>>(taxPayers.AsEnumerable()));
      await context.Reply(response);
    }

    #endregion
  }
}
