using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LDVELH_WPF
{
    public static class SQLiteDatabaseFunction
    {
        public static void SaveHero(Hero hero)
        {
            try
            {
                using (MySQLiteDBContext heroSaveContext = new MySQLiteDBContext())
                {
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MyCapacities.Load();
                    heroSaveContext.MyHero.Load();
                    Hero savedHero = heroSaveContext.MyHero.Where(x => x.CharacterID == hero.CharacterID).FirstOrDefault();

                    if (savedHero != null)
                    {
                        if (savedHero.getSpecialItems != null)
                        {
                            heroSaveContext.MySpecialItem.RemoveRange(savedHero.getSpecialItems);
                        }
                        if (savedHero.capacities != null)
                        {
                            heroSaveContext.MyCapacities.RemoveRange(savedHero.capacities);
                        }
                        heroSaveContext.MyHero.Remove(savedHero);
                        heroSaveContext.SaveChanges();
                    }
                    heroSaveContext.MyHero.Add(hero);
                    heroSaveContext.SaveChanges();
                    
                }
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
                using (MySQLiteDBContext heroSaveContext = new MySQLiteDBContext())
                {
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MyCapacities.Load();
                    heroSaveContext.MyHero.Load();
                    Hero savedHero = heroSaveContext.MyHero.Where(x => x.CharacterID == hero.CharacterID).FirstOrDefault();

                    if (savedHero.getSpecialItems != null)
                    {
                        heroSaveContext.MySpecialItem.RemoveRange(savedHero.getSpecialItems);
                    }
                    if (savedHero.capacities != null)
                    {
                        heroSaveContext.MyCapacities.RemoveRange(savedHero.capacities);
                    }
                    heroSaveContext.MyHero.Remove(savedHero);
                    heroSaveContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static Hero SelectHeroFromID(String HeroID)
        {
            using (MySQLiteDBContext heroSaveContext = new MySQLiteDBContext())
            {
                try
                {
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MyCapacities.Load();
                    heroSaveContext.MyHero.Load();
                    return heroSaveContext.MyHero.Where(x => x.CharacterID.ToString() == HeroID).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static List<Hero> GetAllHeroes()
        {
            try
            {
                using (MySQLiteDBContext heroSaveContext = new MySQLiteDBContext())
                {
                    var query = from hero in heroSaveContext.MyHero select hero;
                    return query.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
