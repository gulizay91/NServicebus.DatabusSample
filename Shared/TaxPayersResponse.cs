namespace Shared
{
  using NServiceBus;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the <see cref="TaxPayersResponse" />.
  /// </summary>
  public class TaxPayersResponse : IMessage
  {
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="TaxPayersResponse"/> class.
    /// </summary>
    /// <param name="taxPayers">The taxPayers<see cref="DataBusProperty{IEnumerable{Model.TaxPayer.TaxPayersModel}}"/>.</param>
    public TaxPayersResponse(DataBusProperty<IEnumerable<TaxPayersModel>> taxPayers)
    {
      TaxPayers = taxPayers;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the TaxPayers.
    /// </summary>
    public DataBusProperty<IEnumerable<TaxPayersModel>> TaxPayers { get; protected set; }

    #endregion
  }
}
