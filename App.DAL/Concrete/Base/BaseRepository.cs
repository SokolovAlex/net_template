namespace App.DAL.Concrete.Base
{
    public class BaseRepository
    {
        protected readonly DataContext Context;

        public BaseRepository()
        {
            Context = new DataContext();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
