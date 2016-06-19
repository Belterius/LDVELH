using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public static class CreateParagraph
    {

        public static Paragraph CreateAParagraph(int paragraphNumber)
        {
            Paragraph paragraph;
            switch (paragraphNumber)
            {
                case 1:
                    {
                        List<Loot> startingItems = new List<Loot>();
                        startingItems.Add(CreateLoot.CreateWeapon.spear());
                        startingItems.Add(CreateLoot.CreateWeapon.sword());
                        startingItems.Add(CreateLoot.CreateSpecialItem.buckler());
                        startingItems.Add(CreateLoot.CreateSpecialItem.chainMail());
                        startingItems.Add(CreateLoot.CreateFood.ration());
                        startingItems.Add(CreateLoot.CreateConsummable.minorHealthPotion());
                        paragraph = new Paragraph("le contenu du premier paragraph qui s'affichera \n retour a la ligne peut etre", paragraphNumber);
                        Event startingItemsLoot = new LootEvent(startingItems);
                        paragraph.addMainEvent(startingItemsLoot);
                        Event moveToParagraph2 = new MoveEvent(2, "Go to East");
                        Event moveToParagraph3 = new MoveEvent(3, "Go to South");
                        paragraph.addDecision(moveToParagraph2);
                        paragraph.addDecision(moveToParagraph3);
                        return paragraph;

                    }
                case 2:
                    {
                        paragraph = new Paragraph("le contenu du second paragraph qui s'affichera \n retour a la ligne peut etre", paragraphNumber);
                        return paragraph;
                    }
                case 3:
                    {
                        paragraph = new Paragraph("le contenu du troisieme paragraph qui s'affichera \n retour a la ligne peut etre", paragraphNumber);
                        return paragraph;
                    }
                default :
                        paragraph = new Paragraph("DEFAULT qui s'affichera PAS \n retour a la ligne peut etre", paragraphNumber);
                        return paragraph;

            }
        }
    }
}
