using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace LDVELH_WPF
{
    [Obsolete("Replaced with SQLite", true)]
    public static class LocalDatabaseFunction
    {
        public static Hero SelectHeroFromId(string heroId){
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
                    return heroSaveContext.MyHero.FirstOrDefault(x => x.CharacterID.ToString() == heroId);
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
                Hero savedHero = heroSaveContext.MyHero.FirstOrDefault(x => x.CharacterID == hero.CharacterID);
                if (savedHero == null) return;
                if (savedHero.GetSpecialItems != null)
                {
                    heroSaveContext.MySpecialItem.RemoveRange(savedHero.GetSpecialItems);
                }
                if (savedHero.Capacities != null)
                {
                    heroSaveContext.MyCapacities.RemoveRange(savedHero.Capacities);
                }
                heroSaveContext.MyHero.Remove(savedHero);
                heroSaveContext.SaveChanges();
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
                    Hero savedHero = heroSaveContext.MyHero.FirstOrDefault(x => x.CharacterID == hero.CharacterID);
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
                    return (from hero in heroSaveContext.MyHero select hero).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
