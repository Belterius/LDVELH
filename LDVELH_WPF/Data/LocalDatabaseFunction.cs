using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace LDVELH_WPF
{
    [Obsolete("Replaced with SQLite", true)]
    public static class LocalDatabaseFunction
    {
        public static Hero SelectHeroFromID(String heroID){
            using (HeroSaveContext HeroSaveContext = new HeroSaveContext())
            {
                try
                {
                    
                    HeroSaveContext.MyItems.Load();
                    HeroSaveContext.MyWeapons.Load();
                    HeroSaveContext.MySpecialItem.Load();
                    HeroSaveContext.MyCapacities.Load();
                    HeroSaveContext.MyWeaponHolders.Load();
                    HeroSaveContext.MyBackPack.Load();
                    HeroSaveContext.MyHero.Load();
                    return HeroSaveContext.MyHero.Where(x => x.CharacterID.ToString() == heroID).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void DeleteHero(Hero hero)
        {
            using (HeroSaveContext HeroSaveContext = new HeroSaveContext())
            {
                HeroSaveContext.MyItems.Load();
                HeroSaveContext.MyWeapons.Load();
                HeroSaveContext.MyWeaponHolders.Load();
                HeroSaveContext.MyBackPack.Load();
                HeroSaveContext.MySpecialItem.Load();
                HeroSaveContext.MyCapacities.Load();
                HeroSaveContext.MyHero.Load();
                Hero savedHero = HeroSaveContext.MyHero.Where(x => x.CharacterID == hero.CharacterID).FirstOrDefault();
                if (savedHero != null)
                {
                    if (savedHero.GetSpecialItems != null)
                    {
                        HeroSaveContext.MySpecialItem.RemoveRange(savedHero.GetSpecialItems);
                    }
                    if (savedHero.Capacities != null)
                    {
                        HeroSaveContext.MyCapacities.RemoveRange(savedHero.Capacities);
                    }
                    HeroSaveContext.MyHero.Remove(savedHero);
                    HeroSaveContext.SaveChanges();
                }
            }
        }

        public static void SaveHero(Hero hero)
        {
            try
            {
                using (HeroSaveContext HeroSaveContext = new HeroSaveContext())
                {
                    HeroSaveContext.MyBackPack.Load();
                    HeroSaveContext.MyHero.Load();
                    HeroSaveContext.MyItems.Load();
                    HeroSaveContext.MySpecialItem.Load();
                    HeroSaveContext.MyWeaponHolders.Load();
                    HeroSaveContext.MyWeapons.Load();
                    HeroSaveContext.MyCapacities.Load();
                    Hero savedHero = HeroSaveContext.MyHero.Where(x => x.CharacterID == hero.CharacterID).FirstOrDefault();
                    if (savedHero == null)
                    {
                        HeroSaveContext.MyHero.Add(hero);
                    }
                    else
                    {
                        HeroSaveContext.Entry(savedHero).CurrentValues.SetValues(hero);//May not work, did not have the time for intensive testing before switching to SQLite
                    }
                    HeroSaveContext.SaveChanges();
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
                using (HeroSaveContext HeroSaveContext = new HeroSaveContext())
                {
                    return (from hero in HeroSaveContext.MyHero select hero).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
