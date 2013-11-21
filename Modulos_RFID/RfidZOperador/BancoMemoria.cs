using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZOperador
{
 
      /// <summary>
    /// The memory banks available on a transponder
    /// </summary>
    public enum  BancoMemoria
    {
        /// <summary>
        /// The EPC memory bank
        /// </summary>
        ElectronicProductCode,

        /// <summary>
        /// The User memory bank
        /// </summary>
        User,

        /// <summary>
        /// The TID memory bank
        /// </summary>
        TransponderIdentifier,

        /// <summary>
        /// The reserved memory bank (access and kill password)
        /// </summary>
        Reserved
    }
}
