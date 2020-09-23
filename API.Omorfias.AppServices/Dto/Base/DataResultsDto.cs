using System.Collections.Generic;

namespace API.Omorfias.AppServices.Dto.Base
{
    public class DataResultsDto<TDto>
    {
        public DataResultsDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; private set; }
        public bool IsSuccess { get { return Errors.Count <= 0; } }
        public int Count { get; set; }
        public IEnumerable<TDto> Data { get; set; }
        public TDto Entity { get; set; }

        public void Add(List<string> errors)
        {
            foreach (var item in errors)
                Errors.Add(item);
        }

        public void Add(string error)
        {
            Errors.Add(error);
        }
    }
}
