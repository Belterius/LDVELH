namespace LDVELH_WPF
{
    public static class CreateParagraph
    {

        public static StoryParagraph CreateAParagraph(int paragraphNumber)
        {
            StoryParagraph paragraph;
            switch (paragraphNumber)
            {
                case 1:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1"), paragraphNumber);
                        //Starting Item
                        //D10 Gold + Axe
                        paragraph.AddMainEvent(new LootEvent(new Gold(DiceRoll.D10Roll())));
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.Hache()));
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateConsummable.potionDeLampsur(5)));
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateConsummable.potionDeLampsur(5)));
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateFood.ration(3)));
                        //Random loot
                        switch (DiceRoll.D10Roll())
                        {
                            case 1:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.sword()));
                                break;
                            case 2:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateSpecialItem.helmet()));
                                break;
                            case 3:
                                paragraph.AddMainEvent( new LootEvent(CreateLoot.CreateFood.ration(2)));
                                break;
                            case 4:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateSpecialItem.chainMail()));
                                break;
                            case 5:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.masseDArme()));
                                break;
                            case 6:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateConsummable.potionDeGuerison()));
                                break;
                            case 7:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.Baton()));
                                break;
                            case 8:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.Lance()));
                                break;
                            case 9:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateGold.Gold(12)));
                                break;
                            case 10:
                                paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateWeapon.Glaive()));
                                break;
                        }
                        paragraph.AddDecision(new MoveEvent(85, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1To85")));
                        paragraph.AddDecision(new MoveEvent(275, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1To275")));
                        paragraph.AddDecision(new CapacityEvent(141, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 2:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph2"), paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand > 4 && rand < 10)
                        {
                            paragraph.AddDecision(new MoveEvent(276, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph2To276")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(343, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph2To343")));
                        }
                        return paragraph;
                    }
                case 3:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph3"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(196, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph3To196")));
                        paragraph.AddDecision(new MoveEvent(144, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph3To144")));
                        return paragraph;
                    }
                case 4:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph4"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(75, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph4To75")));
                        paragraph.AddDecision(new MoveEvent(175, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph4To175")));
                        paragraph.AddDecision(new CapacityEvent(218, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 5:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph5"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(111, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph5To111")));
                        return paragraph;
                    }
                case 6:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph6"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(183, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph6To183")));
                        paragraph.AddDecision(new MoveEvent(200, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph6To200")));
                        return paragraph;
                    }
                case 7:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph7"), paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand > 2 && rand < 10)
                        {
                            paragraph.AddDecision(new MoveEvent(25, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph7To25")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(108, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph7To108")));
                        }
                        return paragraph;
                    }
                case 8:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph8"), paragraphNumber);

                        paragraph.AddDecision(new MoveEvent(70, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph8To70")));
                        return paragraph;
                    }
                case 9:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph9"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(292, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph9To292")));
                        paragraph.AddDecision(new ItemRequieredEvent(236, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph9To236")));
                        return paragraph;
                    }
                case 10:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph10"), paragraphNumber);

                        paragraph.AddDecision(new MoveEvent(115, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph10To115")));
                        paragraph.AddDecision(new MoveEvent(83, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph10To83")));
                        return paragraph;
                    }
                case 11:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph11"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(139, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph11To139")));
                        return paragraph;
                    }
                case 12:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph12"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(247, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph12To247")));
                        paragraph.AddDecision(new BuyEvent(new MoveEvent(262), 10, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph12BuyEvent1")));
                        return paragraph;
                    }
                case 13:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph13"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(307, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph13To307")));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph13To213")));
                        return paragraph;
                    }
                case 14:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph14"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(43, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph14To43")));
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph14To106")));
                        return paragraph;
                    }
                case 15:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph15"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(new Weapon("Sword(paragraph 15)", WeaponTypes.Sword), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph15LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(207, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph15To207")));
                        paragraph.AddDecision(new MoveEvent(201, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph15To201")));
                        paragraph.AddDecision(new MoveEvent(35, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph15To35")));
                        return paragraph;
                    }
                case 16:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph16"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(192, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph16To192")));
                        return paragraph;
                    }
                case 17:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph17"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Kraan", 17, 24, EnemyTypes.Beast)));
                        int rand = DiceRoll.D10Roll();
                        if (rand == 10)
                        {
                            paragraph.AddDecision(new MoveEvent(53, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph17To53")));
                        }
                        else
                            if (rand > 2 && rand < 10)
                            {
                                paragraph.AddDecision(new MoveEvent(274, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph17To274")));
                            }
                            else
                            {
                                paragraph.AddDecision(new MoveEvent(316, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph17To316")));
                            }
                        return paragraph;
                    }
                case 18:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph18"), paragraphNumber);

                        paragraph.AddDecision(new MoveEvent(239, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph18To239")));
                        paragraph.AddDecision(new MoveEvent(29, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph18To29")));
                        paragraph.AddDecision(new CapacityEvent(114, CapacityType.Hiding));
                        return paragraph;
                    }
                case 19:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph19"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(272, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph19To272")));
                        paragraph.AddDecision(new MoveEvent(119, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph19To119")));
                        paragraph.AddDecision(new CapacityEvent(69, CapacityType.Orientation));
                        return paragraph;
                    }
                case 20:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph20"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Poignard(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph20LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateFood.ration(2), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph20LootEvent2")));
                        paragraph.AddDecision(new MoveEvent(273, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph20To273")));
                        return paragraph;
                    }
                case 21:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph21"), paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand <= 4 || rand == 10)
                        {
                            rand = DiceRoll.D10Roll();
                            if (rand <= 7 || rand == 10)
                            {
                                rand = DiceRoll.D10Roll();
                                if (rand != 9)
                                {
                                    paragraph.AddDecision(new DeathEvent("Tentez votre chance", GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph21DeathEvent1")));
                                }
                                else
                                {
                                    paragraph.AddDecision(new MoveEvent(312, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph21To312")));
                                }
                            }
                            else
                            {
                                paragraph.AddDecision(new MoveEvent(189, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph21To189")));
                            }

                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(189, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph21To189")));
                        }
                        return paragraph;
                    }
                case 22:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph22"), paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand == 10 || rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(181, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph22To181")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(145, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph22To145")));
                        }
                        return paragraph;
                    }
                case 23:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph23"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(337, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph23To337")));
                        paragraph.AddDecision(new ItemRequieredEvent(326, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph23To326")));
                        paragraph.AddDecision(new CapacityEvent(151, CapacityType.Telekinesis));
                        return paragraph;
                    }
                case 24:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph24"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(234, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph24To234")));
                        paragraph.AddDecision(new MoveEvent(184, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph24To184")));
                        return paragraph;
                    }
                case 25:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph25"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(139, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph25To139")));
                        return paragraph;
                    }
                case 26:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph26"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(249, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph26To249")));
                        paragraph.AddDecision(new MoveEvent(100, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph26To100")));
                        return paragraph;
                    }
                case 27:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph27"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(250, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph27To250")));
                        paragraph.AddDecision(new MoveEvent(52, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph27To52")));
                        return paragraph;
                    }
                case 28:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph28"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(130, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph28To130")));
                        paragraph.AddDecision(new MoveEvent(147, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph28To147")));
                        return paragraph;
                    }
                case 29:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph29"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(CapacityType.PsychicShield, 2));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vordak", 17, 25, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(270, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph29To270")));
                        return paragraph;
                    }
                case 30:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph30"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(194, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph30To194")));
                        paragraph.AddDecision(new MoveEvent(261, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph30To261")));
                        return paragraph;
                    }
                case 31:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph31"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph31To264")));
                        return paragraph;
                    }
                case 32:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph32"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(176, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph32To176")));
                        paragraph.AddDecision(new MoveEvent(340, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph32To340")));
                        return paragraph;
                    }
                case 33:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph33"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(3)));
                        paragraph.AddDecision(new MoveEvent(248, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph33To248")));
                        return paragraph;
                    }
                case 34:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph34"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(CapacityType.PsychicShield, 2));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vordak", 17, 25, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(328, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph34To328")));
                        return paragraph;
                    }
                case 35:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph35"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(207, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph35To207")));
                        return paragraph;
                    }
                case 36:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph36"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            LinkedEvent linkedEvent = new LinkedEvent(140, "Tenter votre chance");
                            linkedEvent.AddEvent(new DamageEvent("Tenter votre chance", "vous tombez", 2));
                            paragraph.AddDecision(linkedEvent);
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(323, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph36To323")));
                        }
                        return paragraph;
                    }
                case 37:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph37"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(289, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph37To289")));
                        paragraph.AddDecision(new CapacityEvent(282, CapacityType.Hiding));
                        return paragraph;
                    }
                case 38:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph38"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(128, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph38To128")));
                        paragraph.AddDecision(new MoveEvent(347, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph38To347")));
                        return paragraph;
                    }
                case 39:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph39"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(228, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph39To228")));
                        return paragraph;
                    }
                case 40:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph40"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(105, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph40To105")));
                        return paragraph;
                    }
                case 41:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph41"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(116, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph41To116")));
                        paragraph.AddDecision(new MoveEvent(174, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph41To174")));
                        return paragraph;
                    }
                case 42:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph42"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(86, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph42To86")));
                        paragraph.AddDecision(new MoveEvent(238, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph42To238")));
                        paragraph.AddDecision(new MoveEvent(157, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph42To157")));
                        paragraph.AddDecision(new MoveEvent(147, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph42To147")));
                        return paragraph;
                    }
                case 43:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph43"), paragraphNumber);
                        paragraph.AddMainEvent(new RunEvent(new Enemy("Ours Noir", 16, 10, EnemyTypes.Beast), 3, new MoveEvent(106, "vous enfuir en courant au bas de la colline")));
                        paragraph.AddDecision(new MoveEvent(195, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph43To195")));
                        return paragraph;
                    }
                case 44:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph44"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {

                            paragraph.AddDecision(new MoveEvent(277, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph44To277")));
                        }
                        else
                        {

                            paragraph.AddDecision(new MoveEvent(338, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph44To338")));
                        }
                        return paragraph;
                    }
                case 45:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph45"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(180, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph45To180")));
                        return paragraph;
                    }
                case 46:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph46"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(296, CapacityType.SixthSense));
                        paragraph.AddDecision(new MoveEvent(90, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph46To90")));
                        paragraph.AddDecision(new BuyEvent(new MoveEvent(246), 2, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph46BuyEvent1")));
                        return paragraph;
                    }
                case 47:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph47"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(136, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph47To136")));
                        paragraph.AddDecision(new MoveEvent(322, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph47To322")));
                        return paragraph;
                    }
                case 48:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph48"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(243, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph48To243")));
                        return paragraph;
                    }
                case 49:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph49"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {

                            paragraph.AddDecision(new MoveEvent(339, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph49To339")));
                        }
                        else
                        {

                            paragraph.AddDecision(new MoveEvent(60, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph49To60")));
                        }
                        return paragraph;
                    }
                case 50:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph50"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(97, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph50To97")));
                        paragraph.AddDecision(new MoveEvent(243, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph50To243")));
                        return paragraph;
                    }
                case 51:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph51"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(288, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph51To288")));
                        paragraph.AddDecision(new MoveEvent(221, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph51To221")));
                        return paragraph;
                    }
                case 52:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph52"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(250, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph52To250")));
                        paragraph.AddDecision(new CapacityEvent(225, CapacityType.BeastWhisperer));
                        return paragraph;
                    }
                case 53:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph53"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 54:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph54"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 55:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph55"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(-4));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 9, 9, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(325, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph55To325")));
                        return paragraph;
                    }
                case 56:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph56"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(222, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph56To222")));
                        return paragraph;
                    }
                case 57:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph57"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(164, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph57To164")));
                        paragraph.AddDecision(new MoveEvent(109, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph57To109")));
                        paragraph.AddDecision(new MoveEvent(308, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph57To308")));
                        return paragraph;
                    }
                case 58:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph58"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(251, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph58To251")));
                        paragraph.AddDecision(new MoveEvent(160, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph58To160")));
                        return paragraph;
                    }
                case 59:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph59"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(124, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph59To124")));
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph59To106")));
                        paragraph.AddDecision(new MoveEvent(211, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph59To211")));
                        return paragraph;
                    }
                case 60:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph60"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 61:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph61"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(268, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph61To268")));
                        return paragraph;
                    }
                case 62:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph62"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(28)));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateFood.ration(3), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph62LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.sword(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph62LootEvent2")));
                        paragraph.AddDecision(new MoveEvent(288, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph62To288")));
                        return paragraph;
                    }
                case 63:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph63"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vieil homme fou", 11, 10, EnemyTypes.Human)));
                        paragraph.AddDecision(new MoveEvent(269, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph63To269")));
                        return paragraph;
                    }
                case 64:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph64"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(16, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph64To16")));
                        paragraph.AddDecision(new MoveEvent(188, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph64To188")));
                        return paragraph;
                    }
                case 65:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph65"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(104, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph65To104")));
                        return paragraph;
                    }
                case 66:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph66"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(350, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph66To350")));
                        return paragraph;
                    }
                case 67:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph67"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(140, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph67To252")));
                        return paragraph;
                    }
                case 68:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph68"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(15, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph68To15")));
                        paragraph.AddDecision(new MoveEvent(130, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph68To130")));
                        return paragraph;
                    }
                case 69:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph69"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(272, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph69To272")));
                        return paragraph;
                    }
                case 70:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph70"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(28, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph70To28")));
                        paragraph.AddDecision(new MoveEvent(157, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph70To157")));
                        paragraph.AddDecision(new CapacityEvent(8, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 71:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph71"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(104, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph71To104")));
                        paragraph.AddDecision(new CapacityEvent(65, CapacityType.SixthSense));
                        paragraph.AddDecision(new MoveEvent(242, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph71To242")));
                        return paragraph;
                    }
                case 72:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph72"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok monté", 15, 24, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(265, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph72To265")));
                        return paragraph;
                    }
                case 73:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph73"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(243, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph73To243")));
                        return paragraph;
                    }
                case 74:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph74"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(138, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph74To138")));
                        paragraph.AddDecision(new MoveEvent(281, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph74To281")));
                        return paragraph;
                    }
                case 75:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph75"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(260, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph75To260")));
                        paragraph.AddDecision(new MoveEvent(163, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph75To163")));
                        return paragraph;
                    }
                case 76:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph76"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(2));
                        paragraph.AddDecision(new MoveEvent(118, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph76To118")));
                        return paragraph;
                    }
                case 77:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph77"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(19, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph77To19")));
                        return paragraph;
                    }
                case 78:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph78"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(132, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph78To132")));
                        paragraph.AddDecision(new MoveEvent(12, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph78To12")));
                        paragraph.AddDecision(new MoveEvent(220, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph78To220")));
                        return paragraph;
                    }
                case 79:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph79"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(204, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph79To204")));
                        return paragraph;
                    }
                case 80:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph80"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph80To7")));
                        return paragraph;
                    }
                case 81:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph81"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(183, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph81To183")));
                        paragraph.AddDecision(new MoveEvent(200, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph81To200")));
                        return paragraph;
                    }
                case 82:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph82"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(235, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph82To235")));
                        return paragraph;
                    }
                case 83:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph83"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(205, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph83To205")));
                        paragraph.AddDecision(new MoveEvent(180, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph83To180")));
                        paragraph.AddDecision(new MoveEvent(232, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph83To232")));
                        paragraph.AddDecision(new CapacityEvent(45, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 84:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph84"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(188, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph84To188")));
                        return paragraph;
                    }
                case 85:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph85"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(229, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph85To229")));
                        paragraph.AddDecision(new MoveEvent(99, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph85To99")));
                        return paragraph;
                    }
                case 86:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph86"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(6, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph86To6")));
                        paragraph.AddDecision(new MoveEvent(35, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph86To35")));
                        paragraph.AddDecision(new MoveEvent(167, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph86To167")));
                        paragraph.AddDecision(new MoveEvent(42, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph86To42")));
                        return paragraph;
                    }
                case 87:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph87"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(61, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph87To61")));
                        return paragraph;
                    }
                case 88:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph88"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(216, CapacityType.Healing));
                        paragraph.AddDecision(new MoveEvent(31, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph88To31")));
                        return paragraph;
                    }
                case 89:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph89"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 2)
                        {
                            paragraph.AddDecision(new MoveEvent(53, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph89To53")));

                        }
                        else
                            if (rand < 5)
                            {
                                paragraph.AddDecision(new MoveEvent(274, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph89To274")));

                            }
                            else
                            {
                                paragraph.AddDecision(new MoveEvent(316, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph89To316")));

                            }
                        return paragraph;
                    }
                case 90:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph90"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(18, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph90To18")));
                        return paragraph;
                    }
                case 91:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph91"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(152, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph91To152")));
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph91To7")));
                        paragraph.AddDecision(new CapacityEvent(198, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 92:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph92"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(13, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph92To13")));
                        return paragraph;
                    }
                case 93:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph93"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph93To106")));
                        return paragraph;
                    }
                case 94:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph94"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(16)));
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph94To7")));
                        return paragraph;
                    }
                case 95:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph95"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(240, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph95To240")));
                        paragraph.AddDecision(new MoveEvent(5, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph95To5")));
                        return paragraph;
                    }
                case 96:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph96"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(33, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph96To33")));
                        paragraph.AddDecision(new MoveEvent(248, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph96To248")));
                        return paragraph;
                    }
                case 97:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph97"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(255, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph97To255")));
                        paragraph.AddDecision(new MoveEvent(306, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph97To306")));
                        return paragraph;
                    }
                case 98:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph98"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(139, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph98To139")));
                        return paragraph;
                    }
                case 99:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph99"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(222, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph99To222")));
                        return paragraph;
                    }
                case 100:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph100"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(161, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph100To161")));
                        paragraph.AddDecision(new MoveEvent(133, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph100To133")));
                        paragraph.AddDecision(new MoveEvent(257, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph100To257")));
                        return paragraph;
                    }
                case 101:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph101"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(281, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph101To281")));
                        return paragraph;
                    }
                case 102:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph102"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(284, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph102To284")));
                        return paragraph;
                    }
                case 103:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph103"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(13, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph103To13")));
                        paragraph.AddDecision(new MoveEvent(287, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph103To287")));
                        return paragraph;
                    }
                case 104:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph104"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(26, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph104To26")));
                        paragraph.AddDecision(new MoveEvent(100, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph104To100")));
                        return paragraph;
                    }
                case 105:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph105"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(298, CapacityType.BeastWhisperer));
                        paragraph.AddDecision(new MoveEvent(335, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph105To335")));
                        return paragraph;
                    }
                case 106:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph106"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(263, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph106To263")));
                        paragraph.AddDecision(new MoveEvent(334, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph106To334")));
                        return paragraph;
                    }
                case 107:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph107"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(23, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph107To23")));
                        return paragraph;
                    }
                case 108:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph108"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 109:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph109"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(164, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph109To164")));
                        paragraph.AddDecision(new MoveEvent(308, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph109To308")));
                        return paragraph;
                    }
                case 110:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph110"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(55, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph110To55")));
                        return paragraph;
                    }
                case 111:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph111"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(57, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph111To57")));
                        paragraph.AddDecision(new MoveEvent(308, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph111To308")));
                        return paragraph;
                    }
                case 112:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph112"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 13, 10, EnemyTypes.Orc)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 12, 10, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(33, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph112To33")));
                        paragraph.AddDecision(new MoveEvent(248, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph112To248")));
                        return paragraph;
                    }
                case 113:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph113"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateConsummable.potionDeLampsur()));
                        paragraph.AddDecision(new MoveEvent(347, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph113To347")));
                        paragraph.AddDecision(new MoveEvent(295, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph113To295")));
                        return paragraph;
                    }
                case 114:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph114"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(239, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph114To239")));
                        return paragraph;
                    }
                case 115:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph115"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(150, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph115To150")));
                        paragraph.AddDecision(new MoveEvent(177, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph115To177")));
                        paragraph.AddDecision(new MoveEvent(83, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph115To83")));
                        return paragraph;
                    }
                case 116:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph116"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(321, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph116To321")));
                        return paragraph;
                    }
                case 117:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph117"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(330, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph117To330")));
                        return paragraph;
                    }
                case 118:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph118"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(224, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph118To224")));
                        return paragraph;
                    }
                case 119:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph119"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(2));
                        paragraph.AddDecision(new MoveEvent(226, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph119To226")));
                        paragraph.AddDecision(new MoveEvent(38, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph119To38")));
                        return paragraph;
                    }
                case 120:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph120"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(84, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph120To84")));
                        paragraph.AddDecision(new MoveEvent(171, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph120To171")));
                        paragraph.AddDecision(new MoveEvent(54, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph120To54")));
                        return paragraph;
                    }
                case 121:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph121"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(342, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph121To342")));
                        paragraph.AddDecision(new MoveEvent(309, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph121To309")));
                        paragraph.AddDecision(new MoveEvent(283, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph121To283")));
                        return paragraph;
                    }
                case 122:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph122"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(206, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph122To206")));
                        return paragraph;
                    }
                case 123:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph123"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(304, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph123To304")));
                        paragraph.AddDecision(new MoveEvent(2, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph123To2")));
                        return paragraph;
                    }
                case 124:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph124"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(15)));
                        paragraph.AddMainEvent(new LootEvent(new QuestItem("CleDArgent")));
                        paragraph.AddDecision(new MoveEvent(211, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph124To211")));
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph124To106")));
                        return paragraph;
                    }
                case 125:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph125"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(301, CapacityType.Orientation));
                        paragraph.AddDecision(new MoveEvent(27, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph125To27")));
                        paragraph.AddDecision(new MoveEvent(214, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph125To214")));
                        return paragraph;
                    }
                case 126:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph126"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(46, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph126To46")));
                        paragraph.AddDecision(new MoveEvent(143, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph126To143")));
                        return paragraph;
                    }
                case 127:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph127"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 128:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph128"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(297, CapacityType.Hunting));
                        paragraph.AddDecision(new MoveEvent(336, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph128To336")));
                        return paragraph;
                    }
                case 129:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph129"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(3, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph129To3")));
                        paragraph.AddDecision(new MoveEvent(144, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph129To144")));
                        return paragraph;
                    }
                case 130:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph130"), paragraphNumber);
                        paragraph.AddDecision(new MealEvent(28, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph130To28")));
                        paragraph.AddDecision(new MealEvent(201, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph130To201")));
                        return paragraph;
                    }
                case 131:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph131"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(241, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph131To241")));
                        paragraph.AddDecision(new MoveEvent(55, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph131To55")));
                        paragraph.AddDecision(new MoveEvent(302, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph131To302")));
                        paragraph.AddDecision(new MoveEvent(101, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph131To101")));
                        return paragraph;
                    }
                case 132:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph132"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(64, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph132To64")));
                        return paragraph;
                    }
                case 133:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph133"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Serpend Ailé", 16, 18, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(266, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph133To266")));
                        return paragraph;
                    }
                case 134:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph134"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(305, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph134To305")));
                        paragraph.AddDecision(new MoveEvent(40, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph134To40")));
                        return paragraph;
                    }
                case 135:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph135"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(223, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph135To223")));
                        paragraph.AddDecision(new MoveEvent(4, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph135To4")));
                        return paragraph;
                    }
                case 136:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph136"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(-1));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 13, 10, EnemyTypes.Orc)));
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(-1));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 12, 10, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(313, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph136To313")));
                        return paragraph;
                    }
                case 137:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph137"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new QuestItem("20PierresPrecieuses")));
                        paragraph.AddDecision(new MoveEvent(23, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph137To23")));
                        return paragraph;
                    }
                case 138:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph138"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 13, 10, EnemyTypes.Orc)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 12, 10, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(291, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph138To291")));
                        return paragraph;
                    }
                case 139:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph139"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(66, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph139To66")));
                        return paragraph;
                    }
                case 140:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph140"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(14, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph140To14")));
                        paragraph.AddDecision(new MoveEvent(252, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph140To252")));
                        paragraph.AddDecision(new MoveEvent(215, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph140To215")));
                        paragraph.AddDecision(new MoveEvent(36, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph140To36")));
                        return paragraph;
                    }
                case 141:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph141"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(56, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph141To56")));
                        paragraph.AddDecision(new MoveEvent(333, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph141To333")));
                        return paragraph;
                    }
                case 142:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph142"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(58, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph142To58")));
                        paragraph.AddDecision(new MoveEvent(135, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph142To135")));
                        paragraph.AddDecision(new MoveEvent(102, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph142To102")));
                        return paragraph;
                    }
                case 143:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph143"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(149, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph143To149")));
                        return paragraph;
                    }
                case 144:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph144"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(2));
                        paragraph.AddDecision(new MoveEvent(63, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph144To63")));
                        paragraph.AddDecision(new MoveEvent(217, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph144To217")));
                        return paragraph;
                    }
                case 145:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph145"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(165, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph145To165")));
                        return paragraph;
                    }
                case 146:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph146"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(3));
                        paragraph.AddDecision(new MoveEvent(154, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph146To154")));
                        return paragraph;
                    }
                case 147:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph147"), paragraphNumber);
                        paragraph.AddDecision(new MealEvent(42, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph147To42")));
                        paragraph.AddDecision(new MealEvent(28, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph147To28")));
                        return paragraph;
                    }
                case 148:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph148"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.MarteauDeGuerre(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph148LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(81, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph148To81")));
                        paragraph.AddDecision(new MoveEvent(320, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph148To320")));
                        paragraph.AddDecision(new MoveEvent(199, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph148To199")));
                        return paragraph;
                    }
                case 149:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph149"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(256, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph149To256")));
                        return paragraph;
                    }
                case 150:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph150"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(83, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph150To83")));
                        return paragraph;
                    }
                case 151:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph151"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(87, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph151To87")));
                        return paragraph;
                    }
                case 152:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph152"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(49, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph152To49")));
                        paragraph.AddDecision(new MoveEvent(231, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph152To231")));
                        return paragraph;
                    }
                case 153:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph153"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(202, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph153To202")));
                        paragraph.AddDecision(new MoveEvent(135, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph153To135")));
                        paragraph.AddDecision(new MoveEvent(329, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph153To329")));
                        return paragraph;
                    }
                case 154:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph154"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 155:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph155"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(70, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph155To70")));
                        return paragraph;
                    }
                case 156:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph156"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(294, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph156To294")));
                        paragraph.AddDecision(new MoveEvent(245, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph156To245")));
                        return paragraph;
                    }
                case 157:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph157"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(30, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph157To30")));
                        paragraph.AddDecision(new MoveEvent(167, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph157To167")));
                        return paragraph;
                    }
                case 158:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph158"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(6));
                        int rand = DiceRoll.D10Roll0();
                        if (rand > 5)
                        {
                            paragraph.AddMainEvent(new DamageEvent("", "l'éclair vous frappe dans le dos", 4));
                        }
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph158To106")));
                        return paragraph;
                    }
                case 159:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph159"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(191, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph159To191")));
                        paragraph.AddDecision(new MoveEvent(234, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph159To234")));
                        return paragraph;
                    }
                case 160:
                    {
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph160"), paragraphNumber);
                            paragraph.AddDecision(new MoveEvent(286, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph160To286")));
                        }
                        else
                        {
                            paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph160"), paragraphNumber);
                            paragraph.AddDecision(new MoveEvent(10, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph160To10")));
                        }


                        return paragraph;
                    }
                case 161:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph161"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(209, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph161To209")));
                        return paragraph;
                    }
                case 162:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph162"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(258, CapacityType.Telekinesis));
                        paragraph.AddDecision(new MoveEvent(127, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph162To127")));
                        return paragraph;
                    }
                case 163:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph163"), paragraphNumber);

                        paragraph.AddDecision(new MoveEvent(321, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph163To321")));
                        return paragraph;
                    }
                case 164:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph164"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new QuestItem("EssenceDAlether")));
                        paragraph.AddDecision(new MoveEvent(308, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph164To308")));
                        return paragraph;
                    }
                case 165:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph165"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(212, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph165To212")));
                        return paragraph;
                    }
                case 166:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph166"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(4));
                        paragraph.AddDecision(new MoveEvent(104, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph166To104")));
                        return paragraph;
                    }
                case 167:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph167"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(88, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph167To88")));
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph167To264")));
                        paragraph.AddDecision(new CapacityEvent(178, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 168:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph168"), paragraphNumber);
                        paragraph.AddDecision(new MealEvent(64, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph168To64")));
                        return paragraph;
                    }
                case 169:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph169"), paragraphNumber);
                        paragraph.AddMainEvent(new RunEvent(new Enemy("Monstres des cryptes", 16, 16, EnemyTypes.Beast), 1, new MoveEvent(23, "s'enfuir")));
                        paragraph.AddDecision(new MoveEvent(137, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph169To137")));
                        return paragraph;
                    }
                case 170:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph170"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(new Miscellaneous("Torche"), 3));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Gluatre des profondeurs", 17, 7, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(319, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph170To319")));
                        return paragraph;
                    }
                case 171:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph171"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(303, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph171To303")));
                        return paragraph;
                    }
                case 172:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph172"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(239, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph172To239")));
                        paragraph.AddDecision(new MoveEvent(29, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph172To29")));
                        paragraph.AddDecision(new CapacityEvent(114, CapacityType.Hiding));
                        return paragraph;
                    }
                case 173:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph173"), paragraphNumber);
                        paragraph.AddDecision(new ItemRequieredEvent(158, "CleDArgent"));
                        paragraph.AddDecision(new MoveEvent(259, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph173To259")));
                        return paragraph;
                    }
                case 174:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph174"), paragraphNumber);
                        paragraph.AddMainEvent(new LoseBackPack());
                        paragraph.AddMainEvent(new LoseWeaponHolder());
                        paragraph.AddDecision(new MoveEvent(190, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph174To190")));
                        return paragraph;
                    }
                case 175:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph175"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(41, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph175To41")));
                        paragraph.AddDecision(new MoveEvent(116, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph175To116")));
                        paragraph.AddDecision(new CapacityEvent(182, CapacityType.Hiding));
                        return paragraph;
                    }
                case 176:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph176"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(253, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph176To253")));
                        paragraph.AddDecision(new MoveEvent(126, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph176To126")));
                        return paragraph;
                    }
                case 177:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph177"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(83, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph177To83")));
                        return paragraph;
                    }
                case 178:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph178"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(88, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph178To88")));
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph178To264")));
                        return paragraph;
                    }
                case 179:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph179"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(318, "Paragraph179To318"));
                        paragraph.AddDecision(new MoveEvent(51, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph179To51")));
                        return paragraph;
                    }
                case 180:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph180"), paragraphNumber);
                        paragraph.AddMainEvent(new RunEvent(new Enemy("Chef des soldats", 15, 22, EnemyTypes.Human), 1, new MoveEvent(22, "prendre la fuite")));
                        paragraph.AddMainEvent(new RunEvent(new Enemy("soldat", 13, 20, EnemyTypes.Human), 1, new MoveEvent(22, "prendre la fuite")));
                        paragraph.AddMainEvent(new RunEvent(new Enemy("soldat", 13, 20, EnemyTypes.Human), 1, new MoveEvent(22, "prendre la fuite")));
                        paragraph.AddDecision(new MoveEvent(62, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph180To62")));
                        return paragraph;
                    }
                case 181:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph181"), paragraphNumber);
                        paragraph.AddMainEvent(new LoseBackPack());
                        paragraph.AddDecision(new MoveEvent(288, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph181To288")));
                        return paragraph;
                    }
                case 182:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph182"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(174, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph182To174")));
                        return paragraph;
                    }
                case 183:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph183"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(97, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph183To97")));
                        paragraph.AddDecision(new MoveEvent(200, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph183To200")));
                        return paragraph;
                    }
                case 184:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph184"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(new Gold(40), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph184LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.sword(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph184LootEvent2")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateFood.ration(4), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph184LootEvent3")));
                        paragraph.AddDecision(new MoveEvent(64, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph184To64")));

                        return paragraph;
                    }
                case 185:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph185"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 186:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph186"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph186To106")));
                        return paragraph;
                    }
                case 187:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph187"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(186, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph187To186")));
                        paragraph.AddDecision(new MoveEvent(228, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph187To228")));
                        return paragraph;
                    }
                case 188:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph188"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 7)
                        {
                            paragraph.AddMainEvent(new LoseBackPack());
                        }
                        else
                        {
                            paragraph.AddMainEvent(new DamageEvent("", "vous avez été blessé aux deux bras ", 3));
                        }
                        paragraph.AddDecision(new MoveEvent(303, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph188To303")));
                        return paragraph;
                    }
                case 189:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph189"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(118, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph189To118")));
                        return paragraph;
                    }
                case 190:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph190"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(20, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph190To20")));
                        paragraph.AddDecision(new MoveEvent(273, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph190To273")));
                        return paragraph;
                    }
                case 191:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph191"), paragraphNumber);
                        paragraph.AddMainEvent(new RunEvent(new Enemy("Garde du corps", 11, 21, EnemyTypes.Human), 1, new MoveEvent(234, "Sauter de la roulotte")));
                        paragraph.AddDecision(new MoveEvent(24, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph191To24")));
                        return paragraph;
                    }
                case 192:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph192"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(171, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph192To171")));
                        paragraph.AddDecision(new MoveEvent(120, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph192To120")));
                        return paragraph;
                    }
                case 193:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph193"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(new QuestItem("ParcheminGlok"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph193LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(253, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph193To253")));
                        paragraph.AddDecision(new MoveEvent(126, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph193To126")));
                        return paragraph;
                    }
                case 194:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph194"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(208, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph194To208")));
                        paragraph.AddDecision(new MoveEvent(148, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph194To148")));
                        return paragraph;
                    }
                case 195:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph195"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(59, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph195To59")));
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph195To106")));
                        return paragraph;
                    }
                case 196:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph196"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(332, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph196To332")));
                        paragraph.AddDecision(new MoveEvent(144, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph196To144")));
                        return paragraph;
                    }
                case 197:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph197"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(new Gold(6), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph197LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Sabre(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph197LootEvent2")));
                        paragraph.AddDecision(new MoveEvent(172, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph197To172")));
                        return paragraph;
                    }
                case 198:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph198"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph198To7")));
                        paragraph.AddDecision(new MoveEvent(152, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph198To152")));
                        return paragraph;
                    }
                case 199:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph199"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateFood.ration(1), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph199LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(81, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph199To81")));
                        return paragraph;
                    }
                case 200:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph200"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(78, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph200To78")));
                        paragraph.AddDecision(new CapacityEvent(168, CapacityType.Hiding, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph200To168")));
                        return paragraph;
                    }
                case 201:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph201"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(238, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph201To238")));
                        paragraph.AddDecision(new MoveEvent(15, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph201To15")));
                        paragraph.AddDecision(new MoveEvent(130, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph201To130")));
                        return paragraph;
                    }
                case 202:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph202"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(58, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph202To58")));
                        return paragraph;
                    }
                case 203:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph203"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(10));
                        paragraph.AddDecision(new MoveEvent(80, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph203To80")));
                        return paragraph;
                    }
                case 204:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph204"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(111, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph204To111")));
                        return paragraph;
                    }
                case 205:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph205"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(181, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph205To181")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(145, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph205To145")));
                        }
                        return paragraph;
                    }
                case 206:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph206"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(224, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph206To224")));
                        return paragraph;
                    }
                case 207:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph207"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(30, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph207To30")));
                        return paragraph;
                    }
                case 208:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph208"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Gloks", 15, 13, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(148, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph208To148")));
                        paragraph.AddDecision(new MoveEvent(320, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph208To320")));
                        return paragraph;
                    }
                case 209:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph209"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(23, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph209To23")));
                        return paragraph;
                    }
                case 210:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph210"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(332, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph210To332")));
                        paragraph.AddDecision(new MoveEvent(37, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph210To37")));
                        return paragraph;
                    }
                case 211:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph211"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(173, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph211To173")));
                        paragraph.AddDecision(new MoveEvent(106, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph211To106")));
                        paragraph.AddDecision(new CapacityEvent(244, CapacityType.SixthSense));
                        return paragraph;
                    }
                case 212:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph212"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(350, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph212To350")));
                        return paragraph;
                    }
                case 213:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph213"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(331, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph213To331")));
                        return paragraph;
                    }
                case 214:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph214"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(125, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph214To125")));
                        return paragraph;
                    }
                case 215:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph215"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(346, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph215To346")));
                        paragraph.AddDecision(new MoveEvent(14, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph215To14")));
                        return paragraph;
                    }
                case 216:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph216"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph216To264")));
                        return paragraph;
                    }
                case 217:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph217"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(91, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph217To91")));
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph217To7")));
                        return paragraph;
                    }
                case 218:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph218"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(75, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph218To75")));
                        return paragraph;
                    }
                case 219:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph219"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 220:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph220"), paragraphNumber);
                        paragraph.AddMainEvent(new RunEvent(new Enemy("Garde du corps", 11, 20, EnemyTypes.Human), 1, new MoveEvent(234, "Sauter de la roulotte")));
                        paragraph.AddDecision(new MoveEvent(24, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph220To24")));
                        return paragraph;
                    }
                case 221:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph221"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(318, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph221To318")));
                        return paragraph;
                    }
                case 222:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph222"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(140, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph222To140")));
                        paragraph.AddDecision(new MoveEvent(252, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph222To252")));
                        paragraph.AddDecision(new CapacityEvent(67, CapacityType.Orientation));
                        return paragraph;
                    }
                case 223:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph223"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(75, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph223To75")));
                        paragraph.AddDecision(new MoveEvent(175, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph223To175")));
                        return paragraph;
                    }
                case 224:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph224"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(153, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph224To153")));
                        return paragraph;
                    }
                case 225:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph225"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(187, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph225To187")));
                        paragraph.AddDecision(new MoveEvent(39, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph225To39")));
                        return paragraph;
                    }
                case 226:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph226"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(277, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph226To277")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(338, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph226To338")));
                        }
                        return paragraph;
                    }
                case 227:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph227"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vipère des marais", 16, 6, EnemyTypes.Beast)));
                        paragraph.AddDecision(new MoveEvent(348, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph227To348")));
                        return paragraph;
                    }
                case 228:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph228"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(140, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph228To140")));
                        paragraph.AddDecision(new MoveEvent(215, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph228To215")));
                        return paragraph;
                    }
                case 229:
                    {

                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph229"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(-1));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Kraan", 16, 25, EnemyTypes.Human)));
                        paragraph.AddDecision(new MoveEvent(267, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph229To267")));
                        paragraph.AddDecision(new MoveEvent(125, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph229To125")));
                        return paragraph;
                    }
                case 230:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph230"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(179, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph230To179")));
                        return paragraph;
                    }
                case 231:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph231"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Voleur au poignard", 13, 20, EnemyTypes.Human)));
                        paragraph.AddDecision(new MoveEvent(94, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph231To94")));
                        return paragraph;
                    }
                case 232:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph232"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(180, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph232To180")));
                        paragraph.AddDecision(new MoveEvent(22, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph232To22")));
                        return paragraph;
                    }
                case 233:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph233"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(206, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph233To206")));
                        return paragraph;
                    }
                case 234:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph234"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 235:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph235"), paragraphNumber);
                        paragraph.AddDecision(new MealEvent(32, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph235To32")));
                        paragraph.AddDecision(new MealEvent(146, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph235To146")));
                        paragraph.AddDecision(new CapacityEvent(254, CapacityType.Orientation));
                        return paragraph;
                    }
                case 236:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph236"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(6));
                        paragraph.AddMainEvent(new DamageAgilityEvent(1));
                        paragraph.AddDecision(new MoveEvent(104, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph236To104")));
                        return paragraph;
                    }
                case 237:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph237"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(265, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph237To265")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(72, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph237To72")));
                        }
                        return paragraph;
                    }
                case 238:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph238"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(42, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph238To42")));
                        paragraph.AddDecision(new MoveEvent(68, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph238To68")));
                        return paragraph;
                    }
                case 239:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph239"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(34, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph239To34")));
                        paragraph.AddDecision(new MoveEvent(118, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph239To118")));
                        return paragraph;
                    }
                case 240:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph240"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(79, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph240To79")));
                        return paragraph;
                    }
                case 241:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph241"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(349, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph241To349")));
                        return paragraph;
                    }
                case 242:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph242"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(166, CapacityType.PsychicShield));
                        paragraph.AddDecision(new MoveEvent(9, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph242To9")));
                        return paragraph;
                    }
                case 243:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph243"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.masseDArme(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph243LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(97, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph243To97")));
                        return paragraph;
                    }
                case 244:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph244"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(93, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph244To93")));
                        return paragraph;
                    }
                case 245:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph245"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(190, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph245To190")));
                        return paragraph;
                    }
                case 246:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph246"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Drakkarim", 15, 23, EnemyTypes.Human)));
                        paragraph.AddDecision(new MoveEvent(197, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph246To197")));
                        return paragraph;
                    }
                case 247:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph247"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(159, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph247To159")));
                        paragraph.AddDecision(new MoveEvent(220, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph247To220")));
                        return paragraph;
                    }
                case 248:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph248"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(44, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph248To44")));
                        paragraph.AddDecision(new MoveEvent(300, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph248To300")));
                        return paragraph;
                    }
                case 249:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph249"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(169, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph249To169")));
                        paragraph.AddDecision(new MoveEvent(107, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph249To107")));
                        return paragraph;
                    }
                case 250:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph250"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(186, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph250To186")));
                        return paragraph;
                    }
                case 251:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph251"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(10, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph251To10")));
                        return paragraph;
                    }
                case 252:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph252"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(155, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph252To155")));
                        paragraph.AddDecision(new MoveEvent(70, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph252To70")));
                        return paragraph;
                    }
                case 253:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph253"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Loup maudit", 13, 24, EnemyTypes.Beast)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Loup maudit", 14, 23, EnemyTypes.Beast)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Loup maudit", 14, 22, EnemyTypes.Beast)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Loup maudit", 15, 21, EnemyTypes.Beast)));
                        paragraph.AddDecision(new MoveEvent(278, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph253To278")));
                        return paragraph;
                    }
                case 254:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph254"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(32, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph254To32")));
                        paragraph.AddDecision(new MoveEvent(146, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph254To146")));
                        return paragraph;
                    }
                case 255:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph255"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Gourgaz", 20, 30, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(82, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph255To82")));
                        return paragraph;
                    }
                case 256:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph256"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(224, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph256To224")));
                        return paragraph;
                    }
                case 257:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph257"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(133, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph257To133")));
                        paragraph.AddDecision(new MoveEvent(161, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph257To161")));
                        return paragraph;
                    }
                case 258:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph258"), paragraphNumber);
                        paragraph.AddMainEvent(new LoseBackPack());
                        paragraph.AddMainEvent(new LoseWeaponHolder());
                        paragraph.AddDecision(new MoveEvent(50, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph258To50")));
                        return paragraph;
                    }
                case 259:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph259"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 261:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph260"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(208, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph261To208")));
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph261To264")));
                        return paragraph;
                    }
                case 260:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph261"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 11, 18, EnemyTypes.Orc)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 12, 17, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(156, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph260To156")));
                        return paragraph;
                    }
                case 262:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph262"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(191, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph262To191")));
                        paragraph.AddDecision(new MoveEvent(234, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph262To234")));
                        return paragraph;
                    }
                case 263:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph263"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(3)));
                        paragraph.AddDecision(new MoveEvent(70, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph263To70")));
                        paragraph.AddDecision(new MoveEvent(157, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph263To157")));
                        return paragraph;
                    }
                case 264:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph264"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(97, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph264To97")));
                        paragraph.AddDecision(new MoveEvent(6, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph264To6")));
                        return paragraph;
                    }
                case 265:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph265"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(142, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph265To142")));
                        return paragraph;
                    }
                case 266:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph266"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(209, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph266To209")));
                        return paragraph;
                    }
                case 267:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph267"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Poignard(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph267LootEvent1")));
                        paragraph.AddDecision(new LootEvent(new QuestItem("Message"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph267LootEvent2")));
                        paragraph.AddDecision(new MoveEvent(125, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph267To125")));
                        return paragraph;
                    }
                case 268:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph268"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(288, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph268To288")));
                        return paragraph;
                    }
                case 269:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph269"), paragraphNumber);
                        paragraph.AddDecision(new BuyEvent(new MoveEvent(314), 10, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph269BuyEvent1")));
                        paragraph.AddDecision(new MoveEvent(7, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph269To7")));
                        return paragraph;
                    }
                case 270:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph270"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(21, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph270To21")));
                        return paragraph;
                    }
                case 271:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph271"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 272:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph272"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(134, CapacityType.Orientation));
                        paragraph.AddDecision(new MoveEvent(305, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph272To305")));
                        return paragraph;
                    }
                case 273:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph273"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(179, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph273To179")));
                        paragraph.AddDecision(new MoveEvent(51, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph273To51")));
                        return paragraph;
                    }
                case 274:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph274"), paragraphNumber);
                        paragraph.AddMainEvent(new LoseBackPack());
                        paragraph.AddDecision(new MoveEvent(331, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph274To331")));
                        return paragraph;
                    }
                case 275:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph275"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(345, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph275To345")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(74, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph275To74")));
                        }
                        return paragraph;
                    }
                case 276:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph276"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(1));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph276To213")));
                        return paragraph;
                    }
                case 277:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph277"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(113, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph277To113")));
                        return paragraph;
                    }
                case 278:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph278"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(149, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph278To149")));
                        return paragraph;
                    }
                case 279:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph279"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 7)
                        {
                            paragraph.AddDecision(new MoveEvent(112, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph279To112")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(96, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph279To96")));
                        }
                        return paragraph;
                    }
                case 280:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph280"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(327, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph280To327")));
                        paragraph.AddDecision(new MoveEvent(170, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph280To170")));
                        return paragraph;
                    }
                case 281:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph281"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(311, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph281To311")));
                        paragraph.AddDecision(new MoveEvent(77, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph281To77")));
                        return paragraph;
                    }
                case 282:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph282"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(11, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph282To11")));
                        return paragraph;
                    }
                case 283:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph283"), paragraphNumber);
                        paragraph.AddMainEvent(new BuffOrDebuffEvent(CapacityType.PsychicShield, 2));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vordak", 17, 25, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(123, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph283To123")));
                        return paragraph;
                    }
                case 284:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph284"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(71, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph284To71")));
                        return paragraph;
                    }
                case 285:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph285"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(325, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph285To325")));
                        return paragraph;
                    }
                case 286:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph286"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 287:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph287"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(13, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph287To13")));
                        paragraph.AddDecision(new MoveEvent(330, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph287To330")));
                        return paragraph;
                    }
                case 288:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph288"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(129, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph288To129")));
                        return paragraph;
                    }
                case 289:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph289"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(139, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph289To139")));
                        return paragraph;
                    }
                case 290:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph290"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Baton(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph290LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(140, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph290To140")));
                        return paragraph;
                    }
                case 291:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph291"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Poignard(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph291LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Lance(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph291LootEvent2")));
                        paragraph.AddMainEvent(new LootEvent(new Gold(6)));
                        paragraph.AddDecision(new MoveEvent(272, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph291To272")));
                        return paragraph;
                    }
                case 292:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph292"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 293:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph293"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(281, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph293To281")));
                        return paragraph;
                    }
                case 294:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph294"), paragraphNumber);
                        paragraph.AddMainEvent(new LoseBackPack());
                        paragraph.AddMainEvent(new LoseWeaponHolder());
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 3)
                        {
                            paragraph.AddDecision(new MoveEvent(230, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph294To230")));
                        }
                        else
                            if (rand < 7)
                            {
                                paragraph.AddDecision(new MoveEvent(190, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph294To190")));
                            }
                            else
                            {
                                paragraph.AddDecision(new MoveEvent(321, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph294To321")));
                            }
                        return paragraph;
                    }
                case 295:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph295"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(185, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph295To185")));
                        paragraph.AddDecision(new MoveEvent(92, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph295To92")));
                        return paragraph;
                    }
                case 296:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph296"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(90, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph296To90")));
                        return paragraph;
                    }
                case 297:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph297"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(117, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph297To117")));
                        return paragraph;
                    }
                case 298:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph298"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(121, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph298To121")));
                        paragraph.AddDecision(new MoveEvent(38, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph298To38")));
                        return paragraph;
                    }
                case 299:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph299"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(227, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph299To227")));
                        paragraph.AddDecision(new MoveEvent(95, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph299To95")));
                        return paragraph;
                    }
                case 300:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph300"), paragraphNumber);
                        paragraph.AddDecision(new MealEvent(13, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph300To13")));
                        return paragraph;
                    }
                case 301:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph301"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(27, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph301To27")));
                        return paragraph;
                    }
                case 302:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph302"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 3)
                        {
                            paragraph.AddDecision(new MoveEvent(110, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph302To110")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(285, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph302To285")));
                        }
                        return paragraph;
                    }
                case 303:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph303"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(237, CapacityType.Hiding));
                        paragraph.AddDecision(new MoveEvent(72, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph303To72")));
                        return paragraph;
                    }
                case 304:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph304"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new QuestItem("PierreBrulante")));
                        paragraph.AddDecision(new MoveEvent(2, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph304To2")));
                        return paragraph;
                    }
                case 305:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph305"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Lance(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph305LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(105, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph305To105")));
                        return paragraph;
                    }
                case 306:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph306"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 307:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph307"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.MarteauDeGuerre(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph307LootEvent1")));
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateFood.ration(1), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph307LootEvent2")));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph307To213")));
                        return paragraph;
                    }
                case 308:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph308"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(1));
                        paragraph.AddDecision(new CapacityEvent(122, CapacityType.BeastWhisperer));
                        paragraph.AddDecision(new MoveEvent(233, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph308To233")));
                        return paragraph;
                    }
                case 309:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph309"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 310:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph310"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(37, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph310To37")));
                        return paragraph;
                    }
                case 311:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph311"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(324, CapacityType.Hiding));
                        paragraph.AddDecision(new MoveEvent(279, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph311To279")));
                        paragraph.AddDecision(new MoveEvent(47, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph311To47")));
                        return paragraph;
                    }
                case 312:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph312"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(299, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph312To299")));
                        return paragraph;
                    }
                case 313:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph313"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(1));
                        paragraph.AddDecision(new MoveEvent(248, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph313To248")));
                        return paragraph;
                    }
                case 314:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph314"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 7)
                        {
                            paragraph.AddDecision(new MoveEvent(341, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph314To341")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(98, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph314To98")));
                        }
                        return paragraph;
                    }
                case 315:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph315"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new Gold(6)));
                        paragraph.AddDecision(new LootEvent(new Miscellaneous("Savon"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph315LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph315To213")));
                        return paragraph;
                    }
                case 316:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph316"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(331, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph316To331")));
                        return paragraph;
                    }
                case 317:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph317"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(61, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph317To61")));
                        return paragraph;
                    }
                case 318:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph318"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(129, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph318To129")));
                        return paragraph;
                    }
                case 319:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph319"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Poignard(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph319LootEvent1")));
                        paragraph.AddMainEvent(new LootEvent(CreateLoot.CreateGold.Gold(20)));
                        paragraph.AddDecision(new MoveEvent(157, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph319To157")));
                        return paragraph;
                    }
                case 320:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph320"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(2));
                        paragraph.AddDecision(new MoveEvent(264, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph320To264")));
                        return paragraph;
                    }
                case 321:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph321"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(273, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph321To273")));
                        return paragraph;
                    }
                case 322:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph322"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(17, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph322To17")));
                        paragraph.AddDecision(new MoveEvent(89, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph322To89")));
                        return paragraph;
                    }
                case 323:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph323"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(290, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph323To290")));
                        paragraph.AddDecision(new MoveEvent(140, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph323To140")));
                        return paragraph;
                    }
                case 324:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph324"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(33, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph324To33")));
                        paragraph.AddDecision(new MoveEvent(248, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph324To248")));
                        return paragraph;
                    }
                case 325:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph325"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(349, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph325To349")));
                        return paragraph;
                    }
                case 326:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph226"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(61, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph326To61")));
                        return paragraph;
                    }
                case 327:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph327"), paragraphNumber);
                        paragraph.AddDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 328:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph328"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(76, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph328To76")));
                        paragraph.AddDecision(new MoveEvent(118, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph328To118")));
                        return paragraph;
                    }
                case 329:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph329"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(284, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph329To284")));
                        return paragraph;
                    }
                case 330:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph330"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(315, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph330To315")));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph330To213")));
                        return paragraph;
                    }
                case 331:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph331"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(170, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph331To170")));
                        paragraph.AddDecision(new MoveEvent(280, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph331To280")));
                        return paragraph;
                    }
                case 332:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph332"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(350, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph332To350")));
                        return paragraph;
                    }
                case 333:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph333"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(131, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph333To131")));
                        return paragraph;
                    }
                case 334:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph334"), paragraphNumber);
                        paragraph.AddDecision(new CapacityEvent(73, CapacityType.Hiding));
                        paragraph.AddDecision(new CapacityEvent(48, CapacityType.SixthSense));
                        paragraph.AddDecision(new MoveEvent(162, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph334To162")));
                        return paragraph;
                    }
                case 335:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph335"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(121, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph335To121")));
                        return paragraph;
                    }
                case 336:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph336"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 14, 11, EnemyTypes.Orc)));
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok", 13, 11, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(117, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph336To117")));
                        return paragraph;
                    }
                case 337:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph337"), paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {
                            paragraph.AddDecision(new MoveEvent(219, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph337To219")));
                        }
                        else
                        {
                            paragraph.AddDecision(new MoveEvent(317, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph337To317")));
                        }
                        return paragraph;
                    }
                case 338:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph338"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(113, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph338To113")));
                        return paragraph;
                    }
                case 339:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph339"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Voleur", 13, 20, EnemyTypes.Human)));
                        paragraph.AddDecision(new MoveEvent(94, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph339To94")));
                        return paragraph;
                    }
                case 340:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph340"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Glok monté", 14, 24, EnemyTypes.Orc)));
                        paragraph.AddDecision(new MoveEvent(193, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph340To193")));
                        return paragraph;
                    }
                case 341:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph341"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(210, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph341To210")));
                        paragraph.AddDecision(new MoveEvent(37, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph341To37")));
                        paragraph.AddDecision(new CapacityEvent(310, CapacityType.Orientation));
                        return paragraph;
                    }
                case 342:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph342"), paragraphNumber);
                        paragraph.AddMainEvent(new FightEvent(new Enemy("Vordak", 18, 26, EnemyTypes.Hero)));
                        paragraph.AddDecision(new MoveEvent(123, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph342To123")));
                        return paragraph;
                    }
                case 343:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph343"), paragraphNumber);
                        paragraph.AddMainEvent(new DamageEvent(2));
                        paragraph.AddDecision(new MoveEvent(213, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph343To213")));
                        return paragraph;
                    }
                case 344:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph344"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(60, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph344To60")));
                        return paragraph;
                    }
                case 345:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph345"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(272, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph345To272")));
                        paragraph.AddDecision(new MoveEvent(19, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph345To19")));
                        return paragraph;
                    }
                case 346:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph346"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Lance(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph346LootEvent1")));
                        paragraph.AddDecision(new MoveEvent(14, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph346To14")));
                        return paragraph;
                    }
                case 347:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph347"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(CreateLoot.CreateWeapon.Sabre(), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph347LootEvent1")));
                        paragraph.AddDecision(new LootEvent(new Miscellaneous("briquet"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph347LootEvent2")));
                        paragraph.AddDecision(new LootEvent(new Miscellaneous("Torche"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph347LootEvent3")));
                        paragraph.AddDecision(new MoveEvent(103, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph347To103")));
                        return paragraph;
                    }
                case 348:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph348"), paragraphNumber);
                        paragraph.AddDecision(new MoveEvent(95, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph348To95")));
                        return paragraph;
                    }
                case 349:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph349"), paragraphNumber);
                        paragraph.AddMainEvent(new LootEvent(new QuestItem("EtoileDeCrystal")));
                        paragraph.AddDecision(new MoveEvent(293, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph349To293")));
                        return paragraph;
                    }
                case 350:
                    {
                        paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph350"), paragraphNumber);
                        paragraph.AddDecision(new LootEvent(new QuestItem("PreuveDeVictoire"), GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph350LootEvent1")));
                        return paragraph;
                    }
                default:
                    paragraph = new StoryParagraph(GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1"), paragraphNumber);
                    paragraph.AddDecision(new MoveEvent(85, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1To85")));
                    paragraph.AddDecision(new MoveEvent(275, GlobalTranslator.Instance.Translator.TranslateBook1("Paragraph1To275")));
                    paragraph.AddDecision(new CapacityEvent(141, CapacityType.SixthSense));
                    return paragraph;

            }
        }
    }
}
