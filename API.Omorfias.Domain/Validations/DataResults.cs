using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Validations
{
    public class DataResults<TEntity>
    {
        public int Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
