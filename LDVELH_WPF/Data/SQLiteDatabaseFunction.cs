using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace LDVELH_WPF
{
    public class SQLiteDatabaseFunction : IDisposable
    {
        static MySQLiteDBContext HeroSaveContext;

        public SQLiteDatabaseFunction()
        {
            HeroSaveContext = new MySQLiteDBContext();
            HeroSaveContext.MyBackPack.Load();
            HeroSaveContext.MyItems.Load();
            HeroSaveContext.MySpecialItem.Load();
            HeroSaveContext.MyWeaponHolders.Load();
            HeroSaveContext.MyWeapons.Load();
            HeroSaveContext.MyCapacities.Load();
            HeroSaveContext.MyHero.Load();
        }

        public void SaveHero(Hero hero)
        {
            try
            {
                Hero SavedHero = SelectHeroFromID(hero.CharacterID);

                if (SavedHero != null)
                {
                    DeleteHero(SavedHero);
                }
                HeroSaveContext.MyHero.Add(hero);
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
                Hero SavedHero = SelectHeroFromID(hero.CharacterID);
                HeroSaveContext.MyHero.Remove(SavedHero);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Hero SelectHeroFromID(int heroID)
        {
                try
                {
                    return HeroSaveContext.MyHero.Where(x => x.CharacterID == heroID).FirstOrDefault();
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
                return (from hero in HeroSaveContext.MyHero select hero).ToList();
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
                HeroSaveContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    SaveChanges();
                    HeroSaveContext.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
