using System;

namespace Utility.Attributes
{
    public class IntValueAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public int IntValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public IntValueAttribute(int value)
        {
            this.IntValue = value;
        }

        #endregion
    }
}
