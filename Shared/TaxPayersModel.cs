namespace Shared
{
    using System;

    /// <summary>
    /// Defines the <see cref="TaxPayersModel" />.
    /// </summary>
    [Serializable]
    public class TaxPayersModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the AccountType.
        /// </summary>
        public short AccountType { get; set; }

        /// <summary>
        /// Gets or sets the Alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the AliasCreationTime.
        /// </summary>
        public DateTime AliasCreationTime { get; set; }

        /// <summary>
        /// Gets or sets the DeletionTime.
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the FirstCreationTime.
        /// </summary>
        public DateTime FirstCreationTime { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Identifier.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        #endregion
    }
}
