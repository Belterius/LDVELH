using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LDVELH_WPF
{
    public class SQLiteDatabaseFunction : IDisposable
    {
        static MySQLiteDBContext heroSaveContext;

        public SQLiteDatabaseFunction()
        {
            heroSaveContext = new MySQLiteDBContext();
            heroSaveContext.MyBackPack.Load();
            heroSaveContext.MyItems.Load();
            heroSaveContext.MySpecialItem.Load();
            heroSaveContext.MyWeaponHolders.Load();
            heroSaveContext.MyWeapons.Load();
            heroSaveContext.MyCapacities.Load();
            heroSaveContext.MyHero.Load();
        }

        public void SaveHero(Hero hero)
        {
            try
            {
                Hero savedHero = SelectHeroFromID(hero.CharacterID);

                if (savedHero != null)
                {
                    DeleteHero(savedHero);
                }
                heroSaveContext.MyHero.Add(hero);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void DeleteHero(Hero hero)
        {
            try
            {
                Hero savedHero = SelectHeroFromID(hero.CharacterID);

                if (savedHero.getSpecialItems != null)
                {
                    heroSaveContext.MySpecialItem.RemoveRange(savedHero.getSpecialItems);
                }
                if (savedHero.capacities != null)
                {
                    heroSaveContext.MyCapacities.RemoveRange(savedHero.capacities);
                }
                heroSaveContext.MyHero.Remove(savedHero);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Hero SelectHeroFromID(int HeroID)
        {
                try
                {
                    return heroSaveContext.MyHero.Where(x => x.CharacterID == HeroID).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
        }

        public List<Hero> GetAllHeroes()
        {
            try
            {
                var query = from hero in heroSaveContext.MyHero select hero;
                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            try
            {
                heroSaveContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    SaveChanges();
                    heroSaveContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
