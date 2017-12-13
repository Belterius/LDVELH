﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    /// <summary>
    /// A Weapon that will take a spot in the Hero WeaponHolder
    /// <para /> It posses a Name and a Type
    /// </summary>
    public class Weapon : Loot
    {

        [Column("Name")]
        private string _Name{get;set;}
        public string Name
        {
            get
            {
                return _Name;
            }
            private set
            {
                if (_Name != value)
                {
                    _Name = value;
                }
            }
        }
        [Column("WeaponType")]
        private WeaponTypes _WeaponType { get; set; }
        public WeaponTypes WeaponType
        {
            get
            {
                return _WeaponType;
            }
            set
            {
                if (_WeaponType != value)
                {
                    _WeaponType = value;
                }
            }
        }

        private Weapon()
        {

        }
        public Weapon(string name, WeaponTypes weaponType){
            Name = name;
            WeaponType = weaponType;
        }
        public override void Remove(Hero hero)
        {
            hero.WeaponHolder.Remove(this);
        }
        public override void Add(Hero hero)
        {
            hero.WeaponHolder.Add(this);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Weapon))
                return false;


            Weapon Weapon = (Weapon)obj;
            if (Name != Weapon.Name)
                return false;
            if (WeaponType != Weapon.WeaponType)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, WeaponType}.GetHashCode();
        }

        

        

        public string DisplayName => Name + "(" + GlobalTranslator.Instance.Translator.ProvideValue(WeaponType.ToString()) + ")";
    }
    public enum WeaponTypes
    {
        None,
        Sword,
        Spear,
        Mace,
        Dagger,
        Sabre,
        WarHammer,
        Axe,
        Baton,
        TwoEdgedSword
    }
    static class WeaponTypesMethods
    {

        public static String GetTranslation(this WeaponTypes weapon)
        {
            return GlobalTranslator.Instance.Translator.ProvideValue(weapon.ToString());
        }
    }
}
