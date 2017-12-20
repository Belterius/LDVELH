using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace LDVELH_WPF
{
    public sealed class SqLiteDatabaseFunction : IDisposable
    {
        private static MySqLiteDbContext _heroSaveContext;

        public SqLiteDatabaseFunction()
        {
            _heroSaveContext = new MySqLiteDbContext();
            _heroSaveContext.MyBackPack.Load();
            _heroSaveContext.MyItems.Load();
            _heroSaveContext.MySpecialItem.Load();
            _heroSaveContext.MyWeaponHolders.Load();
            _heroSaveContext.MyWeapons.Load();
            _heroSaveContext.MyCapacities.Load();
            _heroSaveContext.MyHero.Load();
        }

        public void SaveHero(Hero hero)
        {
            try
            {
                Hero savedHero = SelectHeroFromId(hero.CharacterID);

                if (savedHero != null)
                {
                    DeleteHero(savedHero);
                }
                _heroSaveContext.MyHero.Add(hero);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void DeleteHero(Hero hero)
        {
            try
            {
                Hero savedHero = SelectHeroFromId(hero.CharacterID);
                _heroSaveContext.MyHero.Remove(savedHero);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private static Hero SelectHeroFromId(int heroId)
        {
                try
                {
                    return _heroSaveContext.MyHero.FirstOrDefault(x => x.CharacterID == heroId);
                }
                catch (Exception)
                {
                    throw;
                }
        }

        public static List<Hero> GetAllHeroes()
        {
            try
            {
                return (from hero in _heroSaveContext.MyHero select hero).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SaveChanges()
        {
            try
            {
                _heroSaveContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    SaveChanges();
                    _heroSaveContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
