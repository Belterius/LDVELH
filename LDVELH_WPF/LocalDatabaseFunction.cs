using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace LDVELH_WPF
{
    [Obsolete("Replaced with SQLite", true)]
    public static class LocalDatabaseFunction
    {
        public static Hero SelectHeroFromID(String HeroID){
            using (HeroSaveContext heroSaveContext = new HeroSaveContext())
            {
                try
                {
                    
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyCapacities.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyHero.Load();
                    return heroSaveContext.MyHero.Where(x => x.CharacterID.ToString() == HeroID).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void DeleteHero(Hero hero)
        {
            using (HeroSaveContext heroSaveContext = new HeroSaveContext())
            {
                heroSaveContext.MyItems.Load();
                heroSaveContext.MyWeapons.Load();
                heroSaveContext.MyWeaponHolders.Load();
                heroSaveContext.MyBackPack.Load();
                heroSaveContext.MySpecialItem.Load();
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
            }
        }

        public static void SaveHero(Hero hero)
        {
            try
            {
                using (HeroSaveContext heroSaveContext = new HeroSaveContext())
                {
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyHero.Load();
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MyCapacities.Load();
                    Hero savedHero = heroSaveContext.MyHero.Where(x => x.CharacterID == hero.CharacterID).FirstOrDefault();
                    if (savedHero == null)
                    {
                        heroSaveContext.MyHero.Add(hero);
                    }
                    else
                    {
                        heroSaveContext.Entry(savedHero).CurrentValues.SetValues(hero);//May not work, did not have the time for intensive testing before switching to SQLite
                    }
                    heroSaveContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static List<Hero> GetAllHeroes()
        {
            try
            {
                using (HeroSaveContext heroSaveContext = new HeroSaveContext())
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
