namespace Shared
{
    using NServiceBus;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="TaxPayersRequest" />.
    /// </summary>
    public class TaxPayersRequest : ICommand
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxPayersRequest"/> class.
        /// </summary>
        /// <param name="vknList">The vknList<see cref="List{string}"/>.</param>
        /// <param name="nonSapRequest">The nonSapRequest<see cref="bool"/>.</param>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        public TaxPayersRequest(List<string> vknList, bool nonSapRequest, DateTime? startDate = null)
        {
            VknList = vknList;
            NonSapRequest = nonSapRequest;
            StartDate = startDate;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether NonSapRequest.
        /// </summary>
        public bool NonSapRequest { get; protected set; }

        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        public DateTime? StartDate { get; protected set; }

        /// <summary>
        /// Gets or sets the VknList.
        /// </summary>
        public List<string> VknList { get; protected set; }

        #endregion
    }
}
