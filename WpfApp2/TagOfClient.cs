//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class TagOfClient
    {
        public int ClientID { get; set; }
        public int TagID { get; set; }
    
        public virtual Tag Tag { get; set; }
        public virtual Клиенты Клиенты { get; set; }
    }
}