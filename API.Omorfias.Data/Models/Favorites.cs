namespace API.Omorfias.Data.Models
{
    public class Favorites
    {
        public int Id { get; set; }

        #region Foreing Keys
        public virtual Enterprise Enterprise { get; set; }
        #endregion

    }
}