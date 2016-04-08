namespace App.DAL.Concrete.Base
{
    public class BaseRepository
    {
        protected readonly DataContext Context;

        public BaseRepository()
        {
            Context = new DataContext();
        }
    }
}
