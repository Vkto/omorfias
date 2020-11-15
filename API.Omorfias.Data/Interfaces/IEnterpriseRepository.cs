using API.Omorfias.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Data.Interfaces
{
    public interface IEnterpriseRepository
    {
        List<Enterprise> GetBetterRated();
        List<Enterprise> GetNextToYou();
    }
}
