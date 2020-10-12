using API.Omorfias.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.DataAgent.Interfaces
{
    public interface IDataAgentService
    {
        string GenerateToken(User user);
    }
}
