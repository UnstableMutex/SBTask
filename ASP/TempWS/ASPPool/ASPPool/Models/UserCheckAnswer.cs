//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPPool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCheckAnswer
    {
        public int ID { get; set; }
        public short User_ID { get; set; }
        public int CheckAnswer_ID { get; set; }
    
        public virtual CheckAnswer CheckAnswer { get; set; }
        public virtual User User { get; set; }
    }
}