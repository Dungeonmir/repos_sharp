//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agent
    {
        public int idAgent { get; set; }
        public int idCompany { get; set; }
        public int idAgentType { get; set; }
        public string adress { get; set; }
        public string inn { get; set; }
        public string kpp { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int priority { get; set; }
    
        public virtual AgentType AgentType { get; set; }
        public virtual Company Company { get; set; }
    }
}