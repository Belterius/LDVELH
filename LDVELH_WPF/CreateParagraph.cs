using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        paragraph = new StoryParagraph("Votre aventure debute. \nTLDR : un objet random et c'est parti mon kiki \nIl faut vous hâter, car quelque chose vous dit qu'il serait imprudent de vous attarder parmi les ruines fumantes du monastère détruit. Les monstres volants peuvent, en effet, reparaître à tout moment. Il n'y a d'ailleurs pas de temps à perdre : vous devez au plus vite prendre la route de Holmgard, la capitale du Sommerlund, pour aller annoncer au Roi cette terrible nouvelle : les Guerriers Kaï, l'élite du pays, ont tous été massacrés, à l'exception de vous-même. Or sans l'autorité et le savoir des Seigneurs Kaï pour commander l'armée, le royaume du Sommerlund se trouve à la merci de ses plus anciens ennemis: les Maîtres des Ténèbres. En retenant vos larmes à grand-peine, vous dites adieu à vos compagnons morts et vous faites le serment de les venger. Vous tournez alors le dos aux ruines et vous descendez avec précaution le sentier escarpé qui s'ouvre devant vous. Au pied de la colline, le chemin aboutit à une bifurcation. Là, deux autres sentiers mènent l'un et l'autre à une grande forêt en empruntant deux directions différentes", paragraphNumber);
                        //Starting Item
                        //D10 Gold + Axe
                        paragraph.addMainEvent(new LootEvent(new Gold(DiceRoll.D10Roll())));
                        paragraph.addMainEvent(new LootEvent(CreateLoot.CreateWeapon.Hache()));
                        //Random loot
                        switch (DiceRoll.D10Roll())
                        {
                            case 1 :
                                LootEvent lootEvent1 = new LootEvent(CreateLoot.CreateWeapon.sword());
                                paragraph.addMainEvent(lootEvent1);
                                break;
                            case 2:
                                LootEvent lootEvent2 = new LootEvent(CreateLoot.CreateSpecialItem.helmet());
                                paragraph.addMainEvent(lootEvent2);
                                break;
                            case 3:
                                LootEvent lootEvent3 = new LootEvent(CreateLoot.CreateFood.ration(2));
                                paragraph.addMainEvent(lootEvent3);
                                break;
                            case 4:
                                LootEvent lootEvent4 = new LootEvent(CreateLoot.CreateSpecialItem.chainMail());
                                paragraph.addMainEvent(lootEvent4);
                                break;
                            case 5:
                                LootEvent lootEvent5 = new LootEvent(CreateLoot.CreateWeapon.masseDArme());
                                paragraph.addMainEvent(lootEvent5);
                                break;
                            case 6:
                                LootEvent lootEvent6 = new LootEvent(CreateLoot.CreateConsummable.potionDeGuerison());
                                paragraph.addMainEvent(lootEvent6);
                                break;
                            case 7:
                                LootEvent lootEvent7 = new LootEvent(CreateLoot.CreateWeapon.Baton());
                                paragraph.addMainEvent(lootEvent7);
                                break;
                            case 8:
                                LootEvent lootEvent8 = new LootEvent(CreateLoot.CreateWeapon.Lance());
                                paragraph.addMainEvent(lootEvent8);
                                break;
                            case 9:
                                LootEvent lootEvent9 = new LootEvent(CreateLoot.CreateGold.Gold(12));
                                paragraph.addMainEvent(lootEvent9);
                                break;
                            case 10:
                                LootEvent lootEvent10 = new LootEvent(CreateLoot.CreateWeapon.Glaive());
                                paragraph.addMainEvent(lootEvent10);
                                break;
                        }
                        MoveEvent goRight = new MoveEvent(85, "Prendre le sentier de droite");
                        MoveEvent goLeft = new MoveEvent(275, "Prendre le sentier de gauche");
                        CapacityEvent sixiemeSensEvent = new CapacityEvent(141, CapacityType.SixiemeSens);
                        paragraph.addDecision(goRight);
                        paragraph.addDecision(goLeft);
                        paragraph.addDecision(sixiemeSensEvent);
                        return paragraph;
                    }
                case 2:
                    {
                        paragraph = new StoryParagraph("Tandis que vous courez à perdre haleine dans la forêt qui s'épaissit, les cris des Gloks s'évanouissent peu à peu derrière vous. Vous les avez presque semés lorsque vous trébuchez soudain en tombant tête la première dans un enchevêtrement de branches basses", paragraphNumber);
                        Event moveLose = new MoveEvent(343, "Tentez votre chance");
                        Event moveWin = new MoveEvent(276, "Tentez votre chance");
                        int rand = DiceRoll.D10Roll();
                        if ( rand > 4 && rand < 10)
                        {
                            paragraph.addDecision(moveWin);
                        }
                        else
                        {
                            paragraph.addDecision(moveLose);
                        }
                        return paragraph;
                    }
                case 3:
                    {
                        paragraph = new StoryParagraph("Vous emboîtez le pas à l'officier qui franchit une porte en arcade, puis monte quelques marches menant à un grand hall. Des soldats courent en tous sens, porteurs de parchemins ornés qu'ils doivent remettre à des officiers postés le long des murs de la ville. Un homme au visage couturé de cicatrices, l'air hagard, s'approche de vous et vous offre de le suivre jusqu'à la citadelle. Il porte la toge blanche et pourpre en usage à la cour du Roi. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(196, "suivre cet homme"));
                        paragraph.addDecision(new MoveEvent(144, "décliner son offre et retourner dans les rues populeuses"));
                        return paragraph;
                    }
                case 4:
                    {
                        paragraph = new StoryParagraph("C'est un petit canoë à une place, en très mauvais état. Des pièces de bois disjointes laissent apparaître des trous en plusieurs endroits de la coque et il vous faut les boucher à la hâte avec de l'argile. Vous videz ensuite l'embarcation de son eau et il vous semble alors qu'elle est en état de flotter. Vous rangez votre équipement à l'avant du canoë, puis vous descendez le cours de la rivière en pagayant à l'aide d'un débris de bois ramassé à la surface de l'eau. Un instant plus tard, vous entendez des chevaux galoper dans votre direction, le long de la rive gauche", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(75, "se cacher au fond du canoë"));
                        paragraph.addDecision(new MoveEvent(175, "attirer l'attention des cavaliers"));
                        paragraph.addDecision(new CapacityEvent(218, CapacityType.SixiemeSens));
                        return paragraph;
                    }
                case 5:
                    {
                        paragraph = new StoryParagraph("Vous avez marché pendant environ une heure lorsque le sentier s'oriente peu à peu vers l'est. Vous atteignez bientôt un gué qui traverse un ruisseau coulant vers le sud. Le courant en est rapide et le lit, rocheux et escarpé. Au-delà du gué, le sentier que vous suivez croise un chemin plus large, orienté nord-sud. En allant vers le nord, vous vous éloigneriez de la capitale et vous décidez donc de prendre à droite, en direction du sud. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(111, "Marcher"));
                        return paragraph;
                    }
                case 6:
                    {
                        paragraph = new StoryParagraph("Vous entendez au loin des chevaux dont le galop se rapproche et vous vous accroupissez derrière un arbre pour voir passer les cavaliers sans être vu. Bientôt, vous reconnaissez l'uniforme blanc de l'armée du Sommerlund : ce sont des soldats de la Garde du Roi", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(183, "les appeler"));
                        paragraph.addDecision(new MoveEvent(200, "les laisser passer et poursuivre votre chemin à travers la forêt"));
                        return paragraph;
                    }
                case 7:
                    {
                        paragraph = new StoryParagraph("Pendant un moment qui vous semble une éternité, le flot de la foule vous entraîne comme une feuille au fil du courant. Vous essayez désespérément de rester debout, mais vos épreuves vous ont affaibli, vous avez le vertige et vos jambes sont lourdes comme du plomb. \n Soudain, vous apercevez un escalier de pierre, long et étroit, qui mène sur le toit d'une auberge. Rassemblant vos dernières forces, vous vous frayez un chemin jusqu'à ces marches que vous grimpez péniblement.Parvenu au sommet, vous contemplez alors une vue magnifique: les toits et les tours de Holmgard s'étendent sous vos yeux et les hauts murs de pierre de la citadelle resplendissent au soleil. Les maisons et tous les bâtiments de la capitale ont été construits très près les uns des autres et il est tout à fait possible de sauter de toit en toit. Autrefois, les habitants de Holmgard empruntaient volontiers ce « Chemin des Toits » (comme on l'appelle ici) lorsque de trop fortes pluies rendaient impraticables certaines rues non pavées.Mais les accidents ont été si nombreux qu'il est désormais interdit, par décret du Roi, de se déplacer ainsi. Dans votre cas, cependant, seul le Chemin des Toits peut vous mener jusqu'au souverain, et vous décidez donc de vous rendre au palais de cette manière.Après avoir bondi et sauté de maison en maison, vous Pendant un moment qui vous semble une éternité, le flot de la foule vous entraîne comme une feuille au fil du courant. Vous essayez désespérément de rester debout, mais vos épreuves vous ont affaibli, vous avez le vertige et vos jambes sont lourdes comme du plomb. \n Soudain, vous apercevez un escalier de pierre, long et étroit, qui mène sur le toit d'une auberge. Rassemblant vos dernières forces, vous vous frayez un chemin jusqu'à ces marches que vous grimpez péniblement.Parvenu au sommet, vous contemplez alors une vue magnifique: les toits et les tours de Holmgard s'étendent sous vos yeux et les hauts murs de pierre de la citadelle resplendissent au soleil. Les maisons et tous les bâtiments de la capitale ont été construits très près les uns des autres et il est tout à fait possible de sauter de toit en toit. Autrefois, les habitants de Holmgard empruntaient volontiers ce « Chemin des Toits » (comme on l'appelle ici) lorsque de trop fortes pluies rendaient impraticables certaines rues non pavées.Mais les accidents ont été si nombreux qu'il est désormais interdit, par décret du Roi, de se déplacer ainsi. Dans votre cas, cependant, seul le Chemin des Toits peut vous mener jusqu'au souverain, et vous décidez donc de vous rendre au palais de cette manière.Après avoir bondi et sauté de maison en maison, vous parvenez au bout d'une rangée de toits et il ne vous reste bientôt plus qu'une seule rue à franchir pour atteindre la citadelle. Cette rue, malheureusement, est plus large que les autres et il vous faudra réussir un bond spectaculaire si vous voulez passer de l'autre côté. La gorge un peu serrée, le sang battant à vos tempes, vous prenez donc votre élan en courant sur toute la longueur du toit, puis vous vous élancez, le regard fixé sur la maison d'en face.", paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand > 2 && rand < 10)
                        {
                            paragraph.addDecision(new MoveEvent(25, "Tenter votre chance"));
                        }
                        else
                        {
                            paragraph.addDecision(new MoveEvent(108, "Tenter votre chance"));
                        }
                        return paragraph;
                    }
                case 8:
                    {
                        paragraph = new StoryParagraph("Votre Sixième Sens vous avertit qu'une terrible bataille fait rage dans le sud. Mais votre simple bon sens vous rappelle également que le chemin le plus court pour rejoindre la capitale passe précisément par le sud.", paragraphNumber);
                       
                        paragraph.addDecision(new MoveEvent(70, "Etablir votre initineraire"));
                        return paragraph;
                    }
                case 9:
                    {
                        paragraph = new StoryParagraph("Vous ne pouvez plus bouger : une force mystérieuse vous immobilise et vos yeux sont attirés par la bouche du squelette. Montant des profondeurs de la terre, vous entendez alors un bourdonnement grave, comme si des millions d'abeilles en fureur étaient rassemblées là. Puis une lueur rougeâtre s'allume dans les orbites vides du roi mort et le bourdonnement augmente d'intensité jusqu'à devenir assourdissant. Vous êtes en présence d'une force maléfique plus ancienne et plus puissante encore que celle des Maîtres des Ténèbres.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(292, "Ne rien faire"));
                        paragraph.addDecision(new ItemRequieredEvent(236, "PierreDeVordak"));
                        return paragraph;
                    }
                case 10:
                    {
                        paragraph = new StoryParagraph("Vous êtes en sueur et vos jambes vous font mal. Un peu plus loin, vous apercevez quelques maisonnettes rassemblées.", paragraphNumber);
                        
                        paragraph.addDecision(new MoveEvent(115, "entrer dans l'une de ces maisonnettes pour y prendre quelque repos"));
                        paragraph.addDecision(new MoveEvent(83, "poursuivre votre chemin"));
                        return paragraph;
                    }
                case 11:
                    {
                        paragraph = new StoryParagraph("Vous vous dissimulez dans l'entrée d'une écurie et vous cachez votre blouse de médecin dans la paille. Il est en effet préférable d'apparaître comme un Seigneur Kaï que comme un charlatan. Puis, sans perdre une seconde, vous vous dirigez vers l'Entrée Principale, située de l'autre côté de la cour. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(139, "Continuer"));
                        return paragraph;
                    }
                case 12:
                    {
                        paragraph = new StoryParagraph("Le garde du corps vous observe d'un regard soupçonneux puis vous claque la porte au nez. Vous entendez alors des voix à l'intérieur de la roulotte, puis, soudain, la porte s'ouvre à nouveau et un marchand à l'allure prospère apparaît devant vous. Il exige 10 Couronnes pour prix de votre transport.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(247, "vous n'avez pas cette somme, ou si vous ne souhaitez pas la lui payer"));
                        paragraph.addDecision(new BuyEvent(new MoveEvent(262), 10, "Payer la somme exigée"));
                        return paragraph;
                    }
                case 13:
                    {
                        paragraph = new StoryParagraph("Le chemin aboutit bientôt à une vaste clairière. En son centre se dresse un arbre plus haut et plus large que les autres. Nichée dans son feuillage, à quelque huit mètres au-dessus du sol, se trouve une grande maison. Aucune échelle ne permet d'y accéder, mais l'écorce noueuse de l'arbre offre de nombreux points d'appui et il ne doit pas être trop difficile de grimper là haut.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(307, "escalader cet arbre pour inspecter la maison"));
                        paragraph.addDecision(new MoveEvent(213,"poursuivre votre chemin"));
                        return paragraph;
                    }
                case 14:
                    {
                        paragraph = new StoryParagraph("Vous parvenez au sommet d'une petite colline boisée. De gros rocs y sont disposés les uns à côté des autres, formant un cercle grossier. Soudain, vous entendez un grognement sonore qui s'élève de derrière un rocher situé à votre gauche.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(43, "dégainer votre arme et vous préparer à combattre"));
                        paragraph.addDecision(new MoveEvent(106, "prendre la fuite en courant le plus vite possible au bas de la colline"));
                        return paragraph;
                    }
                case 15:
                    {
                        paragraph = new StoryParagraph("Vous longez un long tunnel sombre formé par des branches d'arbres qui s'entrecroisent au-dessus de votre tête et vous arrivez enfin dans une vaste clairière. En son centre se dresse un socle de pierre sur lequel est posée une épée, rangée dans un fourreau de cuir noir. Un mot manuscrit est attaché à la garde de l'épée, mais il est écrit dans une langue qui vous est étrangère. \n Trois chemins permettent de quitter la clairière ", paragraphNumber);
                        paragraph.addDecision(new LootEvent(new Weapon("Epee(paragraph 15)", WeaponTypes.Epee)));
                        paragraph.addDecision(new MoveEvent(207, "voulez aller à l'est"));
                        paragraph.addDecision(new MoveEvent(201, "voulez aller à l'ouest"));
                        paragraph.addDecision(new MoveEvent(35, "voulez aller au sud"));
                        return paragraph;
                    }
                case 16:
                    {
                        paragraph = new StoryParagraph("Vous parvenez à détacher l'un des chevaux de la roulotte. L'odeur des Loups Maudits et les cris des Gloks qui les chevauchent semblent l'effrayer, mais vous arrivez malgré tout à le lancer au galop en direction des monstrueuses créatures qui s'approchent de vous. Les Gloks et leurs montures sataniques ne sont plus qu'à une cinquantaine de mètres, la lance pointée en avant. Face à face à présent, vous foncez les uns vers les autres.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(192, "Continuer"));
                        return paragraph;
                    }
                case 17:
                    {
                        paragraph = new StoryParagraph("Vous levez votre arme pour frapper la créature, dont la gueule hérissée de crocs tranchants comme des rasoirs vient de se refermer d'un claquement sec à quelques centimètres de votre tête. Gêné par le battement de ses ailes, vous avez du mal à vous tenir debout. \n\nSi vous parvenez à tuer votre adversaire, hâtez-vous de descendre le flanc opposé de la colline afin d'éviter les Gloks.  ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Kraan", 17, 24, EnnemyTypes.Beast)));
                        int rand = DiceRoll.D10Roll();
                        if ( rand == 10)
                        {
                            paragraph.addDecision(new MoveEvent(53, "Tenter votre chance"));
                        }
                        else
                        if (rand > 2 && rand < 10)
                        {
                            paragraph.addDecision(new MoveEvent(274, "Tenter votre chance"));
                        }
                        else
                        {
                            paragraph.addDecision(new MoveEvent(331, "Tenter votre chance"));
                        }
                        return paragraph;
                    }
                case 18:
                    {
                        paragraph = new StoryParagraph("Vous êtes réveillé par l'approche d'une troupe au lointain. Vous apercevez alors, de l'autre côté du lac, des silhouettes de Drakkarims vêtus de capes noires et une meute de Loups Maudits chevauchés par leurs habituels cavaliers. Un Kraan apparaît bientôt au-dessus des arbres et atterrit sur le toit de la petite cabane de bois. Il est monté par une créature habillée de rouge. Un instant plus tard, le Kraan prend à nouveau son vol et traverse le lac en s'approchant de l'endroit où vous êtes caché. ", paragraphNumber);
                        
                        paragraph.addDecision(new MoveEvent(239, "vous enfoncer plus profondément dans la forêt"));
                        paragraph.addDecision(new MoveEvent(29, "combattre la créature"));
                        paragraph.addDecision(new CapacityEvent(114, CapacityType.Camouflage));
                        return paragraph;
                    }
                case 19:
                    {
                        paragraph = new StoryParagraph("Un peu plus loin, à travers les arbres, vous apercevez des buissons de couleur rouge. Ce sont des Brosses à Potence dont les épines écarlates et pointues sont communément appelées des Dents de Sommeil : elles ont en effet la propriété, lorsqu'on s'y pique, de provoquer faiblesse et engourdissement. Vous pouvez éviter les Dents de Sommeil en revenant sur le sentier. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(272, "revenir sur le sentier"));
                        paragraph.addDecision(new MoveEvent(119, "vous frayer un chemin parmi ces buissons pour pénétrer plus profondément dans la forêt"));
                        paragraph.addDecision(new CapacityEvent(69, CapacityType.Orientation));
                        return paragraph;
                    }
                case 20:
                    {
                        paragraph = new StoryParagraph("Il semble que le ou les occupants de la péniche soient partis en toute hâte il y a peu de temps. Les restes d'un repas à moitié mangé traînent sur la table ainsi qu'une tasse de Jala encore chaud. En fouillant un coffre et un petit placard, vous trouvez un Sac à Dos, de la Nourriture (l'équivalent de 2 Repas) et un Poignard.", paragraphNumber);
                        paragraph.addDecision(new LootEvent(CreateLoot.CreateWeapon.Poignard(), "Prendre le poignard"));
                        paragraph.addDecision(new LootEvent(CreateLoot.CreateFood.ration(2), "Prendre les rations"));
                        return paragraph;
                    }
                case 21:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru trois kilomètres à cheval parmi les arbres touffus lorsque le sol devient soudain marécageux.", paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if (rand <= 4 || rand == 10) {
                            rand = DiceRoll.D10Roll();
                            if (rand <= 7 || rand == 10)
                            {
                                rand = DiceRoll.D10Roll();
                                if(rand != 9)
                                {
                                    paragraph.addDecision(new DeathEvent("Tentez votre chance", "Le marécage vous englouti sans merci"));
                                }
                                else
                                {
                                    paragraph.addDecision(new MoveEvent(312, "Tentez votre chance"));
                                }
                            }
                            else
                            {
                                paragraph.addDecision(new MoveEvent(189, "Tentez votre chance"));
                            }

                        }
                        else
                        {
                            paragraph.addDecision(new MoveEvent(189, "Tentez votre chance"));
                        }
                        return paragraph;
                    }
                case 22:
                    {
                        paragraph = new StoryParagraph("D'un coup d'épaule, vous bousculez le chef et vous vous enfuyez à toutes jambes le long de la route. Vous entendez aussitôt derrière vous le déclic menaçant d'une arbalète que l'on tend. Un frisson vous parcourt l'échiné ", paragraphNumber);
                        int rand = DiceRoll.D10Roll();
                        if(rand == 10 || rand < 5)
                        {
                            paragraph.addDecision(new MoveEvent(181, "Tentez votre chance"));
                        }
                        else
                        {
                            paragraph.addDecision(new MoveEvent(145, "Tentez votre chance"));
                        }
                        return paragraph;
                    }
                case 23:
                    {
                        paragraph = new StoryParagraph("Le couloir aboutit bientôt à une vaste chambre mortuaire dont les murs sont gravés de motifs anciens. Dans le coin opposé, un escalier de pierre mène à une porte immense. De chaque côté des marches, deux chandelles noires diffusent une faible clarté. Vous remarquez alors qu'aucune cire ne coule le long des chandelles, et tandis que vous vous approchez, vous constatez que leurs flammes ne diffusent aucune chaleur. Soucieux de quitter au plus vite cet endroit sinistre, vous examinez la serrure de la porte. Une broche sculptée semble fermer le panneau, mais un trou de serrure apparaît également. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(337, "Retirer la broche"));
                        paragraph.addDecision(new ItemRequieredEvent(337, "CleDOr"));
                        paragraph.addDecision(new CapacityEvent(151, CapacityType.MaitriseDeLaMatiere));
                        return paragraph;
                    }
                case 24:
                    {
                        paragraph = new StoryParagraph("Le marchand crie au conducteur de la roulotte de sauter. « On nous attaque ! » s'exclame-t-il. Puis il se jette au-dehors par une fenêtre circulaire. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(234, "sauter à votre tour de la roulotte"));
                        paragraph.addDecision(new MoveEvent(184, "attraper les rênes des chevaux pour prendre le contrôle de l'attelage"));
                        return paragraph;
                    }
                case 25:
                    {
                        paragraph = new StoryParagraph("Vous atterrissez si brutalement sur l'autre toit que vous en avez le souffle coupé. La tête vous tourne, et vous restez étendu sur le dos. Au bout d'une minute environ, vous comprenez enfin que vous avez réussi à passer de l'autre côté et que vous êtes indemne. Lorsque vous êtes vraiment sûr que tout va bien, vous vous relevez d'un bond et vous poussez un cri de victoire pour saluer votre adresse et votre audace. Puis vous vous hâtez de gagner le bord opposé du toit où une longue gouttière vous permet de descendre dans la rue. Les hautes portes de fer de la citadelle sont ouvertes et un chariot, tiré par deux grands chevaux, essaie de sortir dans la rue. Mais les chevaux effrayés par le bruit de la foule se cabrent soudain et l'une des roues avant du véhicule se brise en heurtant violemment la porte. Profitant de la confusion, vous vous glissez à l'intérieur de la citadelle juste avant que les gardes aient refermé les lourds battants métalliques.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(139, "Continuer"));
                        return paragraph;
                    }
                case 26:
                    {
                        paragraph = new StoryParagraph("Vous avancez prudemment le long du couloir qui tourne bientôt à angle droit en direction de l'est. Au loin, vous apercevez une étrange lueur verdâtre. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(249, "continuer dans cette direction"));
                        paragraph.addDecision(new MoveEvent(100, "rebrousser chemin et prendre le couloir orienté au sud"));
                        return paragraph;
                    }
                case 27:
                    {
                        paragraph = new StoryParagraph("Vous suivez ce chemin pendant plus d'une heure en surveillant le ciel de peur que le Kraan n'attaque à nouveau. A quelque distance devant vous, un grand arbre s'est abattu en travers du sentier, et lorsque vous vous en approchez, vous entendez des voix qui s'élèvent de l'autre côté du tronc massif.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(250, "passer à l'attaque"));
                        paragraph.addDecision(new MoveEvent(52, "écouter ce que disent ces voix"));
                        return paragraph;
                    }
                case 28:
                    {
                        paragraph = new StoryParagraph("Une centaine de mètres plus loin, le sentier en croise un autre orienté nord-sud. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(130, "prendre la direction du nord"));
                        paragraph.addDecision(new MoveEvent(147, "aller au sud"));
                        return paragraph;
                    }
                case 29:
                    {
                        paragraph = new StoryParagraph("Vous vous approchez de la rive du lac en vous préparant à combattre. Le Kraan et la créature qui le chevauche vous aperçoivent aussitôt et foncent vers vous en volant à ras de l'eau. C'est alors que le maître du Kraan lance un cri qui vous glace le sang. Cette créature est un Vordak, un féroce lieutenant des Maîtres des Ténèbres. Il se rue sur vous, et il vous faut le combattre. Votre adversaire vous attaque à l'aide d'une grosse Masse d'Armes, mais il est également doué d'une redoutable Puissance Psychique dont il va faire usage au cours de l'affrontement. Si vous ne maîtrisez pas la Discipline Kaï du Bouclier Psychique, sa force mentale vous fera perdre 2 points d'HABILETÉ pendant toute la durée du combat. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent( new Ennemy("Vordak", 17, 25, EnnemyTypes.Hero)));
                        paragraph.addDecision(new MoveEvent(270, "Continuer"));
                        return paragraph;
                    }
                case 30:
                    {
                        paragraph = new StoryParagraph("Tous ces gens semblent fatigués et affamés. Ils ont parcouru des dizaines de kilomètres pour fuir leur ville incendiée. Soudain, vous entendez en direction du nord de forts battements d'ailes. « Des Kraans ! Cachez-vous ! » hurlent des voix tout au long du chemin. En face de vous, un chariot transportant des enfants casse un essieu : l'une des roues s'est coincée dans une ornière profonde. Les enfants, saisis de panique, se mettent à hurler.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(194, "aider ces enfants"));
                        paragraph.addDecision(new MoveEvent(261, "vous mettre à l'abri des arbres"));
                        return paragraph;
                    }
                case 31:
                    {
                        paragraph = new StoryParagraph("Vous essayez de réconforter de votre mieux l'homme blessé, mais ses plaies sont profondes et il perd à nouveau connaissance. Vous le couvrez alors de sa cape et vous poursuivez votre chemin en vous enfonçant plus profondément dans la forêt.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(264, "Continuer"));
                        return paragraph;
                    }
                case 32:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru environ cinq kilomètres à cheval lorsque vous apercevez à quelque distance la silhouette caractéristique de cinq grands Loups Maudits. Des Gloks les chevauchent et ils semblent se diriger vers une prairie située au bout du chemin. Soudain, l'un des Gloks s'écarte de ses compagnons et revient sur ses pas, lançant sa monture en direction de l'endroit où vous vous trouvez. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(176, "vous cacher dans les sous-bois et le laisser passer"));
                        paragraph.addDecision(new MoveEvent(340, "le combattre"));
                        return paragraph;
                    }
                case 33:
                    {
                        paragraph = new StoryParagraph("Le sol de la grotte est sec et poussiéreux. Vous vous enfoncez un peu plus profondément dans la pénombre et vous détectez alors une odeur de viande en putréfaction. Des os, des peaux et des dents de petits animaux sont entassés dans une crevasse. Vous trouvez parmi ces restes un petit sac qui contient 3 Pièces d'Or. Vous les empochez et vous quittez cet endroit où quelque bête sauvage a probablement établi sa tanière, puis vous descendez le flanc de la colline. ", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new Gold(3)));
                        paragraph.addDecision(new MoveEvent(248, "Continuer"));
                        return paragraph;
                    }
                case 34:
                    {
                        paragraph = new StoryParagraph("Sans crier gare, une terrifiante apparition fond sur vous. C'est une créature vêtue de longs vêtements rouges et montée sur le dos d'un Kraan. Votre assaillant pousse un cri à vous glacer le sang : il s'agit d'un Vordak, un féroce lieutenant des Maîtres des Ténèbres. Il est juste au-dessus de vous et il vous faut le combattre. Le monstre vous attaque à l'aide d'une grosse Masse d'Armes et il est également doué d'une redoutable Puissance Psychique, dont il va faire usage au cours de l'affrontement. Si vous ne maîtrisez pas la Discipline Kaï du Bouclier Psychique, vous devrez réduire de 2 points votre total d'HABILETÉ pendant toute la durée du combat. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Vordak", 17, 25, EnnemyTypes.Hero)));
                        paragraph.addDecision(new MoveEvent(328, "Continuer"));
                        return paragraph;
                    }
                case 35:
                    {
                        paragraph = new StoryParagraph("La forêt devient de plus en plus dense, et un enchevêtrement de buissons d'épines recouvre le chemin en s'épaississant à mesure que vous avancez. Bien qu'il soit presque entièrement caché par ces broussailles, vous découvrez un autre sentier orienté vers l'est. Celui que vous suivez semble aboutir à un cul-de-sac de buissons inextricables, et vous décidez donc d'emprunter ce nouveau chemin en prenant la direction de l'est.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(207, "Continuer"));
                        return paragraph;
                    }
                case 36:
                    {
                        paragraph = new StoryParagraph("Le bois de l'échelle qui monte à la vieille tour de guet, est pourri et plusieurs barreaux cèdent sous votre poids. ", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if(rand < 5)
                        {
                            LinkedEvent linkedEvent = new LinkedEvent(140, "Tenter votre chance");
                            linkedEvent.addEvent(new DammageEvent("Tenter votre chance", "vous tombez", 2));
                            paragraph.addDecision(linkedEvent);
                        }
                        else
                        {
                            paragraph.addDecision(new MoveEvent(323, "Tentez votre chance"));
                        }
                        return paragraph;
                    }
                case 37:
                    {
                        paragraph = new StoryParagraph("Vous vous sentez fatigué et affamé, et il vous faut faire une halte pour prendre un Repas. Après avoir mangé, vous rebroussez chemin jusqu'à la citadelle et vous marchez le long de ses hautes murailles de pierre. Vous découvrez une autre entrée dans le mur est, gardée, elle aussi, par deux soldats en armes.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(289, "vous approcher d'eux et leur raconter votre histoire"));
                        paragraph.addDecision(new CapacityEvent(282, CapacityType.Camouflage));
                        return paragraph;
                    }
                case 38:
                    {
                        paragraph = new StoryParagraph("Pendant plus d'une demi-heure, vous poursuivez votre chemin dans la forêt, parmi les fougères et les feuillages touffus des arbres et des buissons. Bientôt, vous parvenez au bord d'un ruisseau où vous vous arrêtez quelques instants pour vous laver le visage et boire un peu d'eau. Lorsque vous vous sentez rafraîchi, vous traversez le ruisseau et vous reprenez votre marche. Quelques instants plus tard, vous sentez une odeur de bois brûlé qui semble venir du nord", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(128, "vous souhaitez aller voir d'où vient cette odeur"));
                        paragraph.addDecision(new MoveEvent(347, "vous préférez ne pas y prêter attention"));
                        return paragraph;
                    }
                case 39:
                    {
                        paragraph = new StoryParagraph("Quelques secondes plus tard, deux petites têtes au pelage ras et à la mine inquiète apparaissent derrière le tronc : ce sont des Kakarmis qui se sont cachés là. Ils vous avertissent que les Kraans sont partout et qu'ils ont attaqué leur village, un peu plus loin à l'ouest, ne laissant que ruines sur leur passage. Les Kakarmis essaient de retrouver le reste de leur tribu qui s'est enfuie dans la forêt lorsque les Ailes Noires ont lancé leur assaut sur le village. Les petites créatures apeurées vous montrent la direction de l'est : le chemin semble aboutir à un cul-de-sac, mais d'après elles, si vous vous enfoncez dans les sous-bois, vous trouverez quelques mètres plus loin une tour de guet où le sentier se divise en trois voies. En continuant alors vers l'est, vous arriverez bientôt à la Route du Roi qui relie Holmgard, la capitale, au port de Toran. Vous remerciez les Kakarmis et vous prenez congé d'eux. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(228, "Continuer"));
                        return paragraph;
                    }
                case 40:
                    {
                        paragraph = new StoryParagraph("Vous contournez la clairière avec précaution en progressant à l'abri des arbres et en surveillant les huttes pour y déceler toute présence éventuelle de l'ennemi. Bientôt, vous rejoignez le sentier et vous vous éloignez en hâte du Bois des Brumes. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(105, "Continuer"));
                        return paragraph;
                    }
                case 41:
                    {
                        paragraph = new StoryParagraph("Trois soldats galopent le long de la rive, suivis de près par les Gloks montés sur des Loups Maudits qui poussent des grognements agressifs. La rive est surélevée et, bientôt, le chef des Gloks vous aperçoit au fond du canoë. Il ordonne alors à cinq de ses congénères de vous tirer dessus à l'aide de leurs arcs. Un instant plus tard, une pluie de flèches noires s'abat sur vous.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(116, "gagner la rive opposée et tenter de vous cacher à l'abri des arbres"));
                        paragraph.addDecision(new MoveEvent(174, "vous enfuir en pagayant le plus vite possible le long de la rivière"));
                        return paragraph;
                    }
                case 42:
                    {
                        paragraph = new StoryParagraph("Vous suivez le sentier pendant environ une heure et vous arrivez alors à un croisement", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(86, "continuer vers l'est"));
                        paragraph.addDecision(new MoveEvent(238, "aller au nord"));
                        paragraph.addDecision(new MoveEvent(157, "vous aventurer au sud"));
                        paragraph.addDecision(new MoveEvent(147, "prendre la direction de l'ouest"));
                        return paragraph;
                    }
                case 43:
                    {
                        paragraph = new StoryParagraph("Un énorme ours noir apparaît derrière le rocher et s'avance lentement vers vous, la gueule ouverte. Vous remarquez aussitôt qu'il a l'air d'avoir mal et que sa douleur le rend furieux. Il est gravement blessé, en effet, et du sang coule sur son cou et dans son dos. Il vous faut le combattre. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Ours Noir", 16, 10, EnnemyTypes.Beast)));
                        paragraph.addDecision(new MoveEvent(195, "Continuer"));
                        return paragraph;
                    }
                case 44:
                    {
                        paragraph = new StoryParagraph("Le sentier aboutit brusquement à une pente en à-pic. Le sol, très instable à cet endroit, se dérobe sous vos pas : vous perdez l'équilibre et vous tombez tête la première au bas de la pente. ", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if(rand < 5)
                        {

                            paragraph.addDecision(new MoveEvent(277, "Tenter votre chance"));
                        }
                        else
                        {

                            paragraph.addDecision(new MoveEvent(338, "Tenter votre chance"));
                        }
                        return paragraph;
                    }
                case 45:
                    {
                        paragraph = new StoryParagraph("Ces hommes ne sont pas, en réalité, ce qu'ils semblent être. La tunique de leur chef est authentique, mais elle est tachée de sang autour du col comme si son véritable propriétaire avait été tué. Quant aux armes dont disposent ces prétendus soldats, elles n'appartiennent pas à l'armée ; elles sont, en effet, richement ouvragées comme celles que fabriquent les armuriers du Royaume de Durenor. Le chef porte une arbalète en bandoulière, et une tentative de fuite équivaudrait à un suicide. Vous décidez alors de combattre ces trois hommes, sinon ils vous tueront dès que vous aurez lâché votre arme.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(180, "Continuer"));
                        return paragraph;
                    }
                case 46:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru trois kilomètres environ, et le feuillage des arbres commence à s'éclaircir. Vous apercevez alors, au bord d'un lac, une petite cabane de bois. Un homme vêtu d'une cape s'approche bientôt de vous et vous offre de vous faire traverser le lac sur son bateau, vous et votre cheval, pour la somme de 2 Couronnes.", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(296,CapacityType.SixiemeSens));
                        paragraph.addDecision(new MoveEvent(90, "refuser et contourner le lac à cheval"));
                        paragraph.addDecision(new BuyEvent(new MoveEvent(246), 2, "accepter son offre"));
                        return paragraph;
                    }
                case 47:
                    {
                        paragraph = new StoryParagraph("A bout de souffle et le visage ruisselant de sueur, vous vous frayez un chemin vers le sommet de la colline. Mais, soudain, une immense ombre noire se dessine devant vous : c'est un Kraan qui tournoie dans le ciel tandis que les Gloks, dans votre dos, gagnent peu à peu du terrain", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(136, "attendre les Gloks pour les affronter"));
                        paragraph.addDecision(new MoveEvent(322, "serrer les dents et poursuivre l'escalade "));
                        return paragraph;
                    }
                case 48:
                    {
                        paragraph = new StoryParagraph("Votre Sixième Sens vous avertit que ces soldats ne sont pas ce qu'ils semblent être. Vous percevez une aura maléfique autour d'eux : ce sont des serviteurs des Maîtres des Ténèbres. Il vous faut prendre aussitôt la fuite avant qu'ils vous aperçoivent. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(243, "Continuer"));
                        return paragraph;
                    }
                case 49:
                    {
                        paragraph = new StoryParagraph("Tandis que vous lisez l'inscription, une ombre se dessine derrière le paravent", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if (rand < 5)
                        {

                            paragraph.addDecision(new MoveEvent(339, "Tenter votre chance"));
                        }
                        else
                        {

                            paragraph.addDecision(new MoveEvent(60, "Tenter votre chance"));
                        }
                        return paragraph;
                    }
                case 50:
                    {
                        paragraph = new StoryParagraph("Vous entendez les échos d'un combat qui se déroule à quelque distance. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(97, "poursuivre votre chemin vers le nord en direction de la bataille"));
                        paragraph.addDecision(new MoveEvent(243, "éviter ce combat, prendre une autre direction"));
                        return paragraph;
                    }
                case 51:
                    {
                        paragraph = new StoryParagraph("Après avoir escaladé en toute hâte la berge boisée de la rivière, vous apercevez un peu plus loin la palissade en rondins du camp fortifié dressé autour de la capitale. La bataille fait rage à trois kilomètres environ et le mur en rondins s'est écroulé en plusieurs endroits, là où les Maîtres des Ténèbres ont porté leur attaque. Le camp est presque désert, la plupart des soldats ayant dû le quitter pour rejoindre le champ de bataille. Une porte est aménagée dans la palissade.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(288, "vous en approcher"));
                        paragraph.addDecision(new MoveEvent(221, "escalader le mur de rondins"));
                        return paragraph;
                    }
                case 52:
                    {
                        paragraph = new StoryParagraph("A présent que vous vous êtes approché, vous vous apercevez qu'il ne s'agit pas là de voix humaines. On dirait plutôt des grognements et des cris d'animaux. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(250, "montez sur le tronc de l'arbre pour aller voir qui se cache derrière. "));
                        paragraph.addDecision(new CapacityEvent(225, CapacityType.CommunicationAnimale));
                        return paragraph;
                    }
                case 53:
                    {
                        paragraph = new StoryParagraph("Une douleur fulgurante vous déchire soudain la jambe droite : vous venez de vous tordre la cheville et vous trébuchez en tombant tête la première. Entraîné par le poids de votre corps, vous roulez alors sur vous-même le long du flanc de la colline avant d'atterrir enfin dans un fossé où vous perdez connaissance. Vous êtes réveillé par une autre douleur: quelque chose s'enfonce dans votre poitrine. C'est le fer de la lance d'un Glok. La créature vous plaque au sol en vous gratifiant d'un sourire diabolique, et, d'un geste instinctif, vous essayez de saisir votre arme, mais elle a disparu. Vous êtes désormais sans défense contre les Gloks cruels et avant que toute lumière s'éteigne, vous apercevez dans une ultime vision l'extrémité de la lance qui s'abat à présent sur votre gorge. Votre mission vient de prendre fin.", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 54:
                    {
                        paragraph = new StoryParagraph("Il semble que le ciel soit resté sourd à vos prières car un instant plus tard, une lance siffle à vos oreilles et vient se planter dans le cou de votre cheval. Celui-ci pousse un hennissement de douleur puis s'abat en avant. Vous roulez tous deux dans la poussière du chemin et vous vous retrouvez coincé sous le cadavre de votre monture. Avant de fermer les yeux à jamais, vous avez le temps de saisir une dernière vision : les fers de lance que les Gloks vous auront, dans quelques secondes, enfoncés profondément dans la poitrine. Votre mission a échoué. ", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 55:
                    {
                        paragraph = new StoryParagraph("Au moment où le Glok bondit, vous vous ruez sur lui et vous le frappez de votre arme, l'empêchant ainsi d'atterrir sur le dos du jeune sorcier. Vous profitez de votre avantage pour frapper à nouveau la créature qui se débat et l'effet de surprise de votre attaque vous permet d'ajouter 4 points à votre total d'HABILETÉ pendant toute la durée de ce combat. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok",9,9,EnnemyTypes.Orc)));
                        paragraph.addDecision(new MoveEvent(325, "Continuer"));
                        return paragraph;
                    }
                case 56:
                    {
                        paragraph = new StoryParagraph("Vous entendez un cri au-dessus des arbres : c'est un Kraan, une de ces grandes créatures volantes et sanguinaires qui comptent parmi les plus redoutables serviteurs des Maîtres des Ténèbres. Vous plongez aussitôt dans l'épaisseur des fougères pour vous cacher jusqu'à ce que le cri du monstre se soit évanoui au lointain. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(222, "Continuer"));
                        return paragraph;
                    }
                case 57:
                    {
                        paragraph = new StoryParagraph("La cabane n'a qu'une seule pièce meublée d'une table de bois, de deux bancs et d'un lit fait de bottes de paille attachées ensemble. Un tapis brodé orne le plancher et plusieurs bouteilles contenant des liquides de différentes couleurs sont posées sur la table.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(164, "examiner ces bouteilles"));
                        paragraph.addDecision(new MoveEvent(109, "soulever le tapis"));
                        paragraph.addDecision(new MoveEvent(308, "quitter la cabane et inspecter l'écurie"));
                        return paragraph;
                    }
                case 58:
                    {
                        paragraph = new StoryParagraph("Vous vous lancez sur la route au pas de course en maintenant une allure régulière. A l'ouest, l'armée des Maîtres des Ténèbres ressemble à une immense tache d'encre noire qui se serait répandue entre les montagnes. Vous courez depuis vingt minutes environ lorsque vous apercevez à votre droite une meute de Loups Maudits qui avancent en file indienne le long d'une corniche.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(286, "vous plaquer contre les rochers qui bordent la route"));
                        paragraph.addDecision(new MoveEvent(160, "continuer à courir en tirant votre épée"));
                        return paragraph;
                    }
                case 59:
                    {
                        paragraph = new StoryParagraph("Scrutant l'obscurité, vous distinguez quelques marches taillées grossièrement dans la terre et vous vous apercevez que cette grotte est en fait l'entrée d'un tunnel. Vous descendez prudemment les marches glissantes et vous découvrez au bas de cet escalier de fortune une petite boîte en argent posée sur une étagère.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(124, "ouvrir la boîte"));
                        paragraph.addDecision(new MoveEvent(106, "ressortir et poursuivre votre chemin"));
                        paragraph.addDecision(new MoveEvent(211, "vous enfoncer plus avant dans le tunnel"));
                        return paragraph;
                    }
                case 60:
                    {
                        paragraph = new StoryParagraph("Avant que les ténèbres vous engloutissent, vous apercevez l'éclat d'une longue lame de couteau. Votre nom s'ajoutera à la liste des victimes du Sage et de son fils, le Voleur, celui-là même qui vient de vous trancher la gorge. Votre mission est terminée", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 61:
                    {
                        paragraph = new StoryParagraph("Vous atteignez enfin la palissade en rondins du camp fortifié qui a été dressé autour de la ville. Et tandis que vous courez vers le poste de garde, vous entendez les soldats pousser des acclamations enthousiastes : les Dieux en soient loués, ils vous ont reconnu en dépit de vos vêtements déchirés et de votre triste apparence ! Votre cape est en lambeaux, votre visage écorché et taché de sang, et vous êtes couvert de la tête aux pieds de la poussière du cimetière. \nPataugeant dans un petit ruisseau qu'il vous faut traverser, vous avancez en titubant vers l'une des entrées du camp.Peu à peu, la vision que vous venez d'avoir dans le cimetière vous apparaît dans toute son horreur ; vous êtes épuisé, affaibli, glacé et, juste avant de perdre connaissance, vous vous laissez tomber dans les bras tendus de deux soldats accourus à votre rencontre.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(268, "Continuer"));
                        return paragraph;
                    }
                case 62:
                    {
                        paragraph = new StoryParagraph("Les « soldats » sont étendus raides morts à vos pieds. C'étaient des brigands qui détroussaient les réfugiés de Toran et pillaient les maisons et les fermes abandonnées de la région. \nEn fouillant leurs cadavres, vous trouvez 28 Pièces d'Or et deux Sacs à Dos qui contiennent des provisions équivalant à trois Repas. Ils étaient armés d'une Arbalète et de Trois Epées.L'Arbalète a été endommagée au cours du combat, mais les trois Epées sont intactes, et vous pouvez en emporter une si vous le souhaitez. Vous modifiez, en conséquence, votre Feuille d'Aventure, vous rangez soigneusement vos nouvelles acquisitions et vous jetez un coup d'œil en direction de l'ouest pour voir si la voie est libre.Enfin, vous vous remettez en route vers le camp fortifié, dressé à l'extérieur de la ville.", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new Gold(28)));
                        paragraph.addMainEvent(new LootEvent(CreateLoot.CreateFood.ration(3)));
                        paragraph.addMainEvent(new LootEvent(CreateLoot.CreateWeapon.sword()));
                        paragraph.addDecision(new MoveEvent(288, "Continuer"));
                        return paragraph;
                    }
                case 63:
                    {
                        paragraph = new StoryParagraph("Le vieil homme vous insulte à grands cris. Il vous rend responsable de la guerre en maudissant les Seigneurs Kaï qui sont, selon lui, les agents des Maîtres des Ténèbres. Impossible de lui faire entendre raison, il va falloir le combattre. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Vieil homme fou", 11, 10, EnnemyTypes.Human)));
                        paragraph.addDecision(new MoveEvent(269, "Continuer"));
                        return paragraph;
                    }
                case 64:
                    {
                        paragraph = new StoryParagraph("Vous êtes réveillé par les cris d'un Kraan qui tournoie au-dessus de la roulotte. Il est tôt et le ciel est clair. A moins de cinq cents mètres, vous apercevez alors une meute de Loups Maudits qui s'avancent le long de la route, prêts à attaquer. Il va falloir agir vite. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(16, "détacher l'un des chevaux de la roulotte et foncer vers la meute en espérant pouvoir la traverser et vous enfuir"));
                        paragraph.addDecision(new MoveEvent(188, "ramasser vos affaires et de courir vous cacher à l'abri des arbres"));
                        return paragraph;
                    }
                case 65:
                    {
                        paragraph = new StoryParagraph("Tous vos sens vous avertissent que cet endroit est maléfique. Il faut vous en éloigner au plus vite. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(104, "Continuer"));
                        return paragraph;
                    }
                case 66:
                    {
                        paragraph = new StoryParagraph("Surpris, vous faites volte-face et vous voyez courir vers vous un robuste sergent accompagné de deux soldats. Tous trois brandissent leurs épées, prêts à frapper. A votre tour, vous dégainez votre arme car, apparemment, ils vont vous attaquer sans prendre la peine de poser des questions. Mais, soudain, le sergent ordonne à ses hommes de s'arrêter. Il a, en effet, reconnu votre cape de Seigneur Kaï. Tous trois remettent aussitôt leurs épées au fourreau et se confondent en excuses. Le sergent vous accompagne ensuite vers l'Entrée Principale et envoie un de ses hommes chercher le capitaine de la garde. Vous êtes bientôt accueilli par un soldat de haute taille et de belle allure qui écoute attentivement votre récit. Lorsque vous avez fini de lui raconter votre périlleux voyage jusqu'à la capitale, vous remarquez qu'il a les larmes aux yeux. Il vous demande alors de le suivre et vous parcourez les salons et les couloirs somptueux du palais royal. Tout ici n'est que splendeur et magnificence. Enfin, vous arrivez devant une haute porte sculptée gardée par deux soldats revêtus d'armures en argent. Dans quelques instants, vous serez devant le Roi.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(350, "Continuer"));
                        return paragraph;
                    }
                case 67:
                    {
                        paragraph = new StoryParagraph("Votre Sens de l'Orientation vous permet de découvrir des traces fraîches laissées par les pattes d'un animal. Ces empreintes suivent le chemin orienté au sud. Vous reconnaissez là les traces d'un Ours Noir. C'est un animal connu pour sa férocité et vous estimez préférable d'emprunter le sentier qui mène vers l'est.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(140, "Continuer"));
                        return paragraph;
                    }
                case 68:
                    {
                        paragraph = new StoryParagraph("Bientôt, le chemin que vous suivez en croise un autre orienté estouest. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(15, "prendre la direction de l'est"));
                        paragraph.addDecision(new MoveEvent(130, "aller à l'ouest"));
                        return paragraph;
                    }
                case 69:
                    {
                        paragraph = new StoryParagraph("Vous vous trouvez à proximité d'un village ami. Contournez les Brosses à Potence", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(272, "Continuer"));
                        return paragraph;
                    }
                case 70:
                    {
                        paragraph = new StoryParagraph("Vous arrivez à un petit pont. Un chemin longe le cours d'eau en direction de l'est, et un autre sentier beaucoup plus étroit s'enfonce dans une forêt touffue menant vers le sud. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(28, "aller à l'est"));
                        paragraph.addDecision(new MoveEvent(157, "prendre la direction du sud"));
                        paragraph.addDecision(new CapacityEvent(8, CapacityType.SixiemeSens));
                        return paragraph;
                    }
                case 71:
                    {
                        paragraph = new StoryParagraph("Vous êtes étourdi, mais indemne. Vous avez fait une chute de cinq mètres en passant à travers le plafond d'un caveau souterrain. Les murs en sont parfaitement lisses, et il vous est impossible d'y grimper. Un tunnel voûté part du caveau en direction de l'est. A l'entrée de ce tunnel se trouve le sarcophage de quelque ancien seigneur.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(104, "quitter le tombeau et suivre le tunnel"));
                        paragraph.addDecision(new CapacityEvent(65, CapacityType.SixiemeSens));
                        paragraph.addDecision(new MoveEvent(242, "ouvrir ce sarcophage "));
                        return paragraph;
                    }
                case 72:
                    {
                        paragraph = new StoryParagraph("Il vous faut affronter un Glok grimaçant chevauchant sa monture à la gueule hérissée de dents pointues. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok monté",15,24,EnnemyTypes.Orc)));
                        paragraph.addDecision(new MoveEvent(265, "Continuer"));
                        return paragraph;
                    }
                case 73:
                    {
                        paragraph = new StoryParagraph("Vous ramenez votre cape autour de vos épaules et vous vous fondez dans les rochers et les feuillages. Puis vous observez attentivement les nouveaux arrivants et vous vous apercevez alors avec un frisson d'horreur qu'il ne s'agit pas du tout de soldats du Roi. Ce sont, en fait, des Drakkarims qui comptent parmi les plus cruels serviteurs des Maîtres des Ténèbres. Ils se sont déguisés en gardes de l'armée royale pour n'être pas reconnus et pouvoir ainsi traverser la forêt sans encombre. Votre initiation aux Disciplines Kaï vous a sauvé la vie et vous remerciez intérieurement vos maîtres. Quelques instants plus tard, vous avez quitté la rive du cours d'eau et vous vous enfoncez dans la forêt en prenant garde à ne pas faire de bruit. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(243, "Continuer"));
                        return paragraph;
                    }
                case 74:
                    {
                        paragraph = new StoryParagraph("Les Kraans et leurs maîtres atterrissent sur le chemin, à trois mètres à peine de l'endroit où vous vous êtes caché. Les Gloks sautent alors de leurs montures volantes à la peau couverte d'écaillés et s'avancent vers vous, la lance levée : ils vous ont vu.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(138, "les combattre"));
                        paragraph.addDecision(new MoveEvent(281, "prendre la fuite en courant dans la forêt"));
                        return paragraph;
                    }
                case 75:
                    {
                        paragraph = new StoryParagraph("En jetant un coup d'œil prudent, vous apercevez trois hommes vêtus de vert qui chevauchent le long de la rive. Ce sont des gardes-frontières ; ils appartiennent à un régiment royal chargé de surveiller les frontières ouest du pays. L'un de ces hommes est blessé ; il est affalé sur l'encolure de son cheval. Une vingtaine de Loups Maudits suivent de près les trois soldats. Ils sont montés par des Gloks qui tirent des flèches en direction des gardesfrontières. Bientôt, l'un de ces derniers tombe de son cheval et roule sur la rive : une flèche noire l'a atteint à la jambe droite et s'est profondément enfoncée dans sa cuisse. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(260, "porter secours au soldat"));
                        paragraph.addDecision(new MoveEvent(163, "rester caché et vous laisser dériver"));
                        return paragraph;
                    }
                case 76:
                    {
                        paragraph = new StoryParagraph("La Pierre dégage une intense chaleur et vous brûle la main. Vous perdez 2 points d'ENDURANCE. Vous enveloppez alors la Pierre dans un pan de votre cape et vous la laissez tomber dans une poche de votre tunique. Une Pierre Précieuse de cette taille doit valoir des centaines de Couronnes ! Vous vous réjouissez de votre bonne fortune et vous remontez sur votre cheval que vous lancez au galop sur le chemin orienté au sud. ", paragraphNumber);
                        paragraph.addMainEvent(new DammageEvent(2));
                        paragraph.addDecision(new MoveEvent(118, "Continuer"));
                        return paragraph;
                    }
                case 77:
                    {
                        paragraph = new StoryParagraph("Les Gloks sont des créatures des montagnes peu habituées à poursuivre leurs proies dans les forêts, et vous parvenez bientôt à les distancer. Leurs grognements et leurs jurons s'évanouissent au lointain : ils ont abandonné la course. Vous faites alors une courte halte pour reprendre votre souffle et vérifier votre équipement. Puis vous vous remettez en route après avoir soigneusement rangé les quelques objets que vous avez réussi à arracher aux décombres du monastère. L'image de ses ruines fumantes vous revient en mémoire, et vous serrez les dents tandis que la forêt s'épaissit autour de vous.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(19, "Continuer"));
                        return paragraph;
                    }
                case 78:
                    {
                        paragraph = new StoryParagraph("Au moment où la roulotte passe devant vous, vous faites un bond en avant et vous parvenez à vous y agripper; vous vous retrouvez sur l'échelon inférieur d'un petit escabeau qui permet d'accéder à la porte arrière du véhicule. Vous vous redressez avec précaution en vous efforçant de maintenir votre prise et, soudain, la partie supérieure de la porte qui vous fait face s'ouvre à la volée. Le visage furieux d'un garde du corps apparaît alors dans l'encadrement.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(132, "lui expliquer que vous êtes un Seigneur Kaï"));
                        paragraph.addDecision(new MoveEvent(12, "lui offrir de l'Or pour payer votre voyage jusqu'à la capitale"));
                        paragraph.addDecision(new MoveEvent(220, "attaquer le garde avec votre arme"));
                        return paragraph;
                    }
                case 79:
                    {
                        paragraph = new StoryParagraph("Vous arrivez à un petit pont qui traverse un ruisseau au cours rapide. De l'autre côté du pont, le chemin s'oriente au sud. Vous décidez de franchir le pont et de suivre le sentier", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(204, "Continuer"));
                        return paragraph;
                    }
                case 80:
                    {
                        paragraph = new StoryParagraph("Vous trébuchez en arrière et vous franchissez la porte d'entrée à reculons, les mains crispées sur votre poitrine en feu. De la fumée jaillit de la boutique et il vous faut prendre la fuite avant que le Sage et son Voleur vous attrapent. Vous parvenez à rejoindre la grand-rue et vous vous fondez dans la foule. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(7, "Continuer"));
                        return paragraph;
                    }
                case 81:
                    {
                        paragraph = new StoryParagraph("Une heure plus tard environ, les Kraans et leurs terribles cavaliers disparaissent en direction de l'ouest. Les réfugiés, tremblants de peur, sortent alors de la forêt, et vous entendez au même moment des chevaux au galop s'approcher de l'endroit où vous êtes. Ce sont des soldats de la cavalerie royale qui portent l'uniforme blanc des armées de Sa Majesté.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(183, "leur faire signe"));
                        paragraph.addDecision(new MoveEvent(200, "poursuivre votre chemin vers le sud en longeant la lisière de la forêt"));
                        return paragraph;
                    }
                case 82:
                    {
                        paragraph = new StoryParagraph("Le Gourgaz Géant est étendu à vos pieds ; ses compagnons sifflent de rage en vous lançant des regards furieux, puis ils sautent du pont. Les tirs de flèches reprennent de plus belle tandis que les soldats du Prince forment autour de vous et de leur chef agonisant un mur de protection à l'aide de leurs boucliers. Le Prince moribond vous regarde alors dans les yeux et prononce ces derniers mots : « Seigneur Kaï, il vous faut transmettre un message au Roi, mon père. L'ennemi est trop puissant, nous ne pouvons le contenir. C'est à Durenor que se trouve notre salut; Sa Majesté doit envoyer chercher ce qui peut nous épargner la défaite. Mon père comprendra ce que je veux dire. Prenez mon cheval et gagnez la capitale. Puissent les Dieux vous accompagner au long de votre voyage ! » Le cœur plein de tristesse, vous dites alors adieu au Prince, puis vous enfourchez son étalon blanc que vous lancez au galop en direction du sud, le long du chemin forestier. Derrière vous, l'ennemi repart à l'assaut du pont et les échos d'une féroce bataille retentissent encore longtemps à vos oreilles.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(235, "Continuer"));
                        return paragraph;
                    }
                case 83:
                    {
                        paragraph = new StoryParagraph("Vous avez couru pendant presque deux kilomètres lorsque trois soldats surgissent de sous un petit pont. Ils vous ordonnent de vous arrêter et de déposer à terre vos armes et tout votre équipement. Leurs uniformes sont tachés de sang et ils ont négligé de se raser. Leur chef porte une tunique de la garnison de Toran.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(205, "leur obéir"));
                        paragraph.addDecision(new MoveEvent(180, "les combattre"));
                        paragraph.addDecision(new MoveEvent(232, "leur demander ce qu'ils veulent"));
                        paragraph.addDecision(new CapacityEvent(45, CapacityType.SixiemeSens));
                        return paragraph;
                    }
                case 84:
                    {
                        paragraph = new StoryParagraph("Au moment où vous sentez le vent de ses ailes sur votre dos, vous vous laissez tomber de votre cheval et vous roulez sur vousmême en terminant votre course dans la bouc d'un fossé, au bord de la route. Vous êtes indemne et vous vous relevez d'un bond pour courir vous mettre à l'abri des arbres ; mais il vous reste une trentaine de mètres à parcourir et le Kraan se prépare à fondre sur vous une nouvelle fois. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(188, "Continuer"));
                        return paragraph;
                    }
                case 85:
                    {
                        paragraph = new StoryParagraph("Le chemin est large et mène droit à un enchevêtrement de broussailles. Les arbres sont très hauts à cet endroit, et il y règne un silence inhabituel. Vous parcourez plus de deux kilomètres et vous entendez soudain un battement d'ailes au-dessus de vous. En levant les yeux, vous apercevez alors avec un frémissement d'horreur la silhouette noire et sinistre d'un Kraan qui fond sur vous. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(229, "dégainer votre arme et combattre"));
                        paragraph.addDecision(new MoveEvent(99, "courrir et vous enfoncer plus profondément dans la forêt"));
                        return paragraph;
                    }
                case 86:
                    {
                        paragraph = new StoryParagraph("Vous atteignez bientôt un nouveau croisement.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(6, "aller vers l'est"));
                        paragraph.addDecision(new MoveEvent(35, "prendre la direction du nord"));
                        paragraph.addDecision(new MoveEvent(167, "aller vers le sud"));
                        paragraph.addDecision(new MoveEvent(42, "tourner vers l'ouest"));
                        return paragraph;
                    }
                case 87:
                    {
                        paragraph = new StoryParagraph("Concentrant votre pouvoir de Seigneur Kaï sur la serrure, vous essayez de vous en représenter le mécanisme. Peu à peu son image se forme dans votre esprit et vous constatez qu'il est vieux et usé, mais qu'il fonctionne toujours. L'intensité de votre concentration commence à faiblir dangereusement lorsque vous entendez enfin un faible déclic qui témoigne que vos efforts n'ont pas été vains. Il est plus facile d'ôter la broche qui, lentement, se dégage de ses attaches, puis tombe sur le sol. La porte de granité tourne alors sur des gonds invisibles et la faible clarté qui baigne le cimetière se répand dans le caveau. Le passage menant à l'extérieur est envahi de ronces qui vous écorchent le visage et les mains tandis que vous vous hissez au-dehors. Puis, soudain, au moment où vous reparaissez enfin à l'air libre, un bruit vous fait sursauter. Vous vous retournez et vous apercevez la tête d'un cadavre décapité, une tête de mort aux chairs décomposées : cette tête vous regarde et semble rire de toutes ses dents. Saisi d'une panique aveugle, vous vous mettez aussitôt à courir de toute la force de vos jambes et vous traversez l'effroyable cimetière en direction de la porte sud de la capitale", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(61, "Continuer"));
                        return paragraph;
                    }
                case 88:
                    {
                        paragraph = new StoryParagraph("Vous jetez un regard prudent derrière le rocher et vous apercevez un soldat étendu sur le dos, son épée et son bouclier à ses côtés. Le bouclier porte l'image d'un Pégase blanc : c'est l'emblème du Prince du Sommer-lund. Ce soldat appartient à la garde du Prince ; son uniforme est déchiré et vous constatez qu'il porte au bras une profonde blessure. Lorsque vous vous approchez de lui, il bat des paupières. « Soignez-moi, supplie-t-il, je ne sens plus mon bras. »", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(216, CapacityType.Guerison));
                        paragraph.addDecision(new MoveEvent(31, "le laisser à son sort"));
                        return paragraph;
                    }
                case 89:
                    {
                        paragraph = new StoryParagraph("Vous dévalez le flanc escarpé de la colline dans un nuage de poussière et de cailloux. Le Kraan continue de tournoyer audessus de votre tête comme pour guider les Gloks vers vous. ", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if(rand < 2)
                        {
                            paragraph.addDecision(new MoveEvent(53, "Continuer"));

                        }
                        else
                        if(rand < 5)
                        {
                            paragraph.addDecision(new MoveEvent(274, "Continuer"));

                        }
                        else {
                            paragraph.addDecision(new MoveEvent(316, "Continuer"));

                        }
                        return paragraph;
                    }
                case 90:
                    {
                        paragraph = new StoryParagraph("La nuit tombe et vous vous retrouvez bientôt dans une obscurité totale. Il ne servirait à rien de poursuivre votre chemin, car vous vous perdriez à coup sûr. Vous attachez donc votre cheval à un arbre, vous vous étendez sur le sol en vous couvrant de votre cape et vous sombrez dans un sommeil agité. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(18, "Continuer"));
                        return paragraph;
                    }
                case 91:
                    {
                        paragraph = new StoryParagraph("La petite boutique est sombre et humide. Les murs sont couverts d'étagères, remplies de livres et de bouteilles de toutes les tailles et de toutes les couleurs. Lorsque vous refermez la porte, un petit chien noir se met à aboyer et un homme chauve apparaît en sortant de derrière un grand paravent. L'homme vous souhaite le bonjour et vous demande poliment s'il peut vous être utile, vous proposant notamment un choix d'herbes et de potions rangées dans les cases d'un comptoir de verre.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(152, "jeter un coup d'œil à ces produits"));
                        paragraph.addDecision(new MoveEvent(7, "décliner son offre et ressortir"));
                        paragraph.addDecision(new CapacityEvent(198, CapacityType.SixiemeSens));
                        return paragraph;
                    }
                case 92:
                    {
                        paragraph = new StoryParagraph("Vous plongez pour vous mettre à l'abri : il était temps, car une pluie de flèches noires jaillies de la forêt s'abat en sifflant à l'endroit où vous vous trouviez quelques secondes plus tôt. Vous ramenez votre cape sur vos épaules : sa couleur verte vous permet de vous fondre dans la végétation et vous vous mettez à courir dans la forêt pour fuir le plus loin possible de vos assaillants. Tous les environs sont infestés de Gloks, et il faut vous échapper au plus vite. Vous courez sans vous arrêter pendant plus d'une heure, et vous arrivez enfin sur un chemin forestier qui mène droit vers l'est. Vous décidez de suivre ce chemin en surveillant sans cesse les alentours de peur de voir surgir un ennemi. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(13, "Continuer"));
                        return paragraph;
                    }
                case 93:
                    {
                        paragraph = new StoryParagraph("Vous faites volte-face et vous vous ruez vers l'escalier. Une fraction de seconde plus tard, un énorme bloc de pierre s'écrase sur le sol, juste dans votre dos. L'entrée de la pièce que vous venez de quitter est, à présent, entièrement obstruée et, tandis que vous vous précipitez au-dehors, vous apercevez derrière vous la silhouette voûtée d'un vieux druide qui lève sa crosse. Un instant plus tard, un éclair explose à vos pieds ; vous parvenez cependant à l'éviter et vous descendez en courant le flanc de la colline, furieux d'avoir perdu du temps, mais en remerciant votre Sixième Sens de vous avoir sauvé la vie. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(106, "Continuer"));
                        return paragraph;
                    }
                case 94:
                    {
                        paragraph = new StoryParagraph("Voyant que vous avez tué son fils, le Sage fait volte-face et s'enfuit de la boutique par la porte de derrière. \nVous trouvez 12 Pièces d'Or dans la bourse du Voleur et 4 autres dans une boîte en bois, rangée sous le comptoir. Vous examinez ensuite les potions et la baguette magique, et vous vous apercevez qu'il s'agit de simples imitations sans aucune valeur. Il n'y a rien dans la boutique qui mérite votre attention et vous quittez les lieux pour rejoindre la grand - rue.", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new Gold(16)));
                        paragraph.addDecision(new MoveEvent(7, "Continuer"));
                        return paragraph;
                    }
                case 95:
                    {
                        paragraph = new StoryParagraph("Vous arrivez bientôt sur un chemin forestier orienté nord-sud. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(240, "suivre ce chemin étroit en direction du nord"));
                        paragraph.addDecision(new MoveEvent(5, "aller au sud"));
                        return paragraph;
                    }
                case 96:
                    {
                        paragraph = new StoryParagraph("Retenant votre souffle, vous resserrez votre prise et vous vous préparez à frapper. La tension est insupportable. Les Gloks sont si proches que vous pouvez sentir l'odeur immonde de leurs corps malpropres. Vous les entendez pousser des jurons dans leur étrange dialecte, puis quitter les abords de la grotte pour grimper vers le sommet de la colline. Lorsque, enfin, vous êtes sûr qu'ils se sont éloignés, vous respirez à nouveau et vous essuyez la sueur qui ruisselle sur votre visage. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(33, "inspecter la grotte plus avant"));
                        paragraph.addDecision(new MoveEvent(248, "quitter les lieux et redescendre la colline"));
                        return paragraph;
                    }
                case 97:
                    {
                        paragraph = new StoryParagraph("Un peu plus loin devant vous, une terrible bataille a lieu sur un pont de pierre. Le fracas des armes, les cris des combattants et les hennissements des chevaux retentissent en écho dans la forêt. Une silhouette familière se dessine alors au beau milieu du pont,là où les corps à corps sont les plus violents : vous reconnaissez aussitôt le Prince Pellagayo, le fils du Roi. Il est en train de se battre avec un énorme Gourgaz qui brandit une Hache Noire audessus de sa tête couverte d'écaillés grisâtres. Or, un instant plus tard, le Prince tombe de son cheval et s'écroule sur le pont, atteint par une flèche qui lui a percé le flanc.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(255, "porter secours au Prince Pellagayo"));
                        paragraph.addDecision(new MoveEvent(306, "vous enfuir dans la forêt"));
                        return paragraph;
                    }
                case 98:
                    {
                        paragraph = new StoryParagraph("Les soldats semblent croire votre récit et ils s'inclinent respectueusement, eu égard à votre rang de Seigneur Kaï. L'un d'eux tire sur une grosse corde dissimulée dans le mur et les lourdes portes commencent aussitôt à s'ouvrir. Les gardes vous font alors entrer dans une cour intérieure tandis que les portes se referment derrière vous.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(139, "Continuer"));
                        return paragraph;
                    }
                case 99:
                    {
                        paragraph = new StoryParagraph("Vous plongez dans les broussailles au moment même où le monstre s'apprêtait à vous saisir dans ses serres pointues. Vous entendez son cri lorsqu'il passe au-dessus de votre tête, et vous le voyez virer dans les airs pour se préparer à un nouvel assaut. Vous vous remettez alors sur pied et vous vous enfoncez dans l'épaisseur de la forêt pour vous mettre à l'abri.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(222, "Continuer"));
                        return paragraph;
                    }
                case 100:
                    {
                        paragraph = new StoryParagraph("Le couloir glacial tourne brusquement vers l'est et vous apercevez au loin une lueur verdâtre qui diffuse une faible clarté. Vous constatez bientôt que le couloir aboutit à une grande pièce, et que l'étrange lumière provient d'une sorte de coupe, posée sur le haut dossier d'un trône de granité. Devant le trône, se trouve une statue sur son socle. Elle représente un serpent ailé dont le corps a la forme d'un S.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(161, "vous asseoir sur ce trône"));
                        paragraph.addDecision(new MoveEvent(133, "examiner la statue"));
                        paragraph.addDecision(new MoveEvent(257, "chercher une sortie "));
                        return paragraph;
                    }
                case 101:
                    {
                        paragraph = new StoryParagraph("Le tumulte de la bataille se dissipe derrière vous, mais, dans le silence qui lui succède, une voix intérieure vous traite de poltron et vous reproche d'avoir abandonné un homme en danger. Vous essayez alors de faire taire votre conscience en vous disant que votre mission est beaucoup plus importante, car ce n'est pas seulement la vie de ce jeune magicien qui est menacée, mais celle de tous vos compatriotes si vous n'atteignez pas vivant la capitale du royaume. Or soudain, vous apercevez un peu plus loin une meute de Gloks : vous vous mettez aussitôt à couvert pour leur échapper, mais il est trop tard, ils vous ont vu et il ne vous reste plus qu'à vous enfuir en courant aussi vite que possible. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(281, "Continuer"));
                        return paragraph;
                    }
                case 102:
                    {
                        paragraph = new StoryParagraph("Vous descendez le flanc rocheux de la colline en direction du Cimetière des Anciens et vous apercevez au loin l'étrange nuage de brume qui baigne en permanence ces lieux grisâtres et lugubres. Ce brouillard maléfique, qui jamais ne se lève, est si dense qu'il empêche le soleil de briller sur les tombes. Lorsque vous arrivez à proximité du cimetière, l'air se rafraîchit et devient bientôt glacial. Avec un sentiment de terreur, vous pénétrez alors dans cette sinistre nécropole. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(284, "Continuer"));
                        return paragraph;
                    }
                case 103:
                    {
                        paragraph = new StoryParagraph("Le chemin, couvert de broussailles, bifurque bientôt et un autre sentier permet d'aller vers l'est", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(13, "emprunter ce nouveau chemin orienté à l'est"));
                        paragraph.addDecision(new MoveEvent(287, "poursuivre votre route en direction du nord-est"));
                        return paragraph;
                    }
                case 104:
                    {
                        paragraph = new StoryParagraph("Les parois sont humides et couvertes de moisissure. Il règne ici une odeur de renfermé qui vous étouffe à moitié et des toiles d'araignées vous balaient le visage. Vous sentez la peur vous serrer la gorge tandis que le tunnel s'obscurcit, mais vous continuez cependant d'avancer et vous arrivez bientôt à un croisement : le tunnel aboutit à un couloir orienté nord-sud. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(26, "aller au nord"));
                        paragraph.addDecision(new MoveEvent(100, "prendre la direction du sud"));
                        return paragraph;
                    }
                case 105:
                    {
                        paragraph = new StoryParagraph("Un peu plus loin, vous apercevez un Corbeau, d'un noir de jais, perché sur la branche d'un vieux chêne.", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(298, CapacityType.CommunicationAnimale));
                        paragraph.addDecision(new MoveEvent(335, "Continuer"));
                        return paragraph;
                    }
                case 106:
                    {
                        paragraph = new StoryParagraph("Vous arrivez un peu plus tard au bord d'un ruisseau aux eaux glacées, agitées d'un fort courant. Son eau blanche d'écume court parmi les rocs moussus et disparaît au loin, en direction de l'est. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(263, "longer ce ruisseau vers l'est"));
                        paragraph.addDecision(new MoveEvent(334, "en remonter le cours"));
                        return paragraph;
                    }
                case 107:
                    {
                        paragraph = new StoryParagraph("Vous traversez la pièce en courant et vous vous servez de votre arme pour fracasser les crânes qui se brisent en mille morceaux. Chacun des crânes est rempli d'une gelée grise et bouillonnante qui se met à trembler et à changer de forme. A la surface luisante de cette étrange substance apparaissent bientôt des ailes de chauves-souris et des ventouses. Saisi d'horreur et de dégoût, vous vous précipitez alors vers le couloir et vous quittez les lieux au moment même où une lourde herse s'abat à l'entrée de la pièce dont elle interdit désormais l'accès.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(23, "Continuer"));
                        return paragraph;
                    }
                case 108:
                    {
                        paragraph = new StoryParagraph("Tout semble se dérouler au ralenti tandis que vous décrivez dans les airs un grand arc de cercle. Dans la rue au-dessous, vous distinguez la foule qui grouille sur toute la largeur de la chaussée et vous apercevez, sur votre droite, un nid de moineaux, blotti dans une gouttière. Vous entendez alors leurs pépiements affolés lorsque vous atterrissez avec fracas sur le toit d'en face. C'est malheureusement la dernière chose que vous entendrez, car les tuiles cèdent sous le choc et vous passez au travers des quatre étages de VAuberge de la Pantoufle Verte. Inutile de préciser que vous vous êtes rompu le cou plusieurs fois et qu'il ne reste de vous qu'un misérable petit tas de chair et d'os brisés. Votre mission s'achève ici, en même temps que votre vie. ", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 109:
                    {
                        paragraph = new StoryParagraph("Sous le tapis, vous ne trouvez que de la poussière ! ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(164, "examiner les bouteilles "));
                        paragraph.addDecision(new MoveEvent(308, "quitter la cabane et inspecter l'écurie "));
                        return paragraph;
                    }
                case 110:
                    {
                        paragraph = new StoryParagraph("Vous lancez la pierre de toutes vos forces en visant la tête du Glok, mais la créature se baisse et votre projectile lui siffle aux oreilles sans l'atteindre. Il vous faut agir vite si vous voulez sauver le Sorcier.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(55, "Continuer"));
                        return paragraph;
                    }
                case 111:
                    {
                        paragraph = new StoryParagraph("Quelques minutes après avoir quitté le croisement, vous apercevez un peu plus loin une petite cabane en rondins à côté d'une écurie. Vous vous approchez et vous jetez un coup d'oeil dans la cabane à travers le carreau d'une fenêtre. L'endroit semble désert. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(57, "entrer dans la cabane"));
                        paragraph.addDecision(new MoveEvent(308, "inspecter l'écurie"));
                        return paragraph;
                    }
                case 112:
                    {
                        paragraph = new StoryParagraph("Soudain, le gros rocher derrière lequel vous vous êtes caché roule sur lui-même, poussé par deux Gloks hurlants qui vous font face et qui ont visiblement l'intention de vous tuer. L'entrée de la grotte est étroite, et vous ne pouvez combattre qu'un Glok à la fois. Vous devrez donc les affronter à tour de rôle. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok",13,10,EnnemyTypes.Orc)));
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok",12,10,EnnemyTypes.Orc)));
                        paragraph.addDecision(new MoveEvent(33, "explorer la grotte plus avant"));
                        paragraph.addDecision(new MoveEvent(248, "descendre le flanc de la colline "));
                        return paragraph;
                    }
                case 113:
                    {
                        paragraph = new StoryParagraph("Vous avez marché pendant plus d'une demi-heure lorsque vous apercevez des fleurs d'un rouge vif qui poussent sur un monticule. Vous reconnaissez aussitôt cette plante : c'est du Laumspur, une herbe rare très recherchée pour ses vertus curatives. Vous cueillez alors une bonne poignée de cette herbe que vous rangez dans votre Sac à Dos. Elle vous servira à récupérer des points d'ENDURANCE lorsque vous en mangerez. Chaque dose de Laumspur vous rendra 3 points d'ENDURANCE et vous avez cueilli là l'équivalent de 2 doses. Vous refermez votre Sac à Dos et vous poursuivez votre route. ", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(CreateLoot.CreateConsummable.potionDeLampsur()));
                        paragraph.addDecision(new MoveEvent(347, "vous diriger vers le nord-est"));
                        paragraph.addDecision(new MoveEvent(295, "aller à l'est"));
                        return paragraph;
                    }
                case 114:
                    {
                        paragraph = new StoryParagraph("Vous amenez votre cheval à se coucher et vous le recouvrez, ainsi que vous-même, de branches et de feuilles mortes. Vous entendez les battements d'ailes du Kraan lorsqu'il passe audessus des arbres : il se met à tournoyer au-dessus de vous, mais repart bientôt en direction du lac qu'il traverse dans l'autre sens. Vous décidez alors de partir au plus vite de peur qu'il ne revienne avec quelques-uns de ses compagnons. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(239, "Continuer"));
                        return paragraph;
                    }
                case 115:
                    {
                        paragraph = new StoryParagraph("Vous entrez d'un pas chancelant dans la première maison et vous vous écroulez sur le sol, complètement épuisé. Vous sentez alors une odeur de viande cuite et vous apercevez une marmite suspendue au-dessus des braises d'un feu mourant. Une grande table de chêne est dressée au centre de la pièce : de toute évidence, le ou les habitants de cette maison l'ont quittée en toute hâte le matin même. Au milieu de la table sont posées une cruche d'eau et une miche de pain. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(150, "prendre rapidement un Repas"));
                        paragraph.addDecision(new MoveEvent(177, "inspecter la maison"));
                        paragraph.addDecision(new MoveEvent(83, "quitter les lieux dès maintenant"));
                        return paragraph;
                    }
                case 116:
                    {
                        paragraph = new StoryParagraph("Des flèches noires s'abattent tout autour de vous lorsque vous vous hissez hors de l'eau boueuse. Vous vous précipitez vers les arbres pour vous mettre à couvert et attendre que les Gloks aient quitté la rive opposée. Vous reprenez ensuite votre chemin en direction de la capitale. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(321, "Continuer"));
                        return paragraph;
                    }
                case 117:
                    {
                        paragraph = new StoryParagraph("L'homme est grièvement blessé, et sa mort est proche. Si vous maîtrisez la Discipline Kaï de la Guérison, vous pouvez soulager quelque peu la douleur de ses plaies, mais il est si mal en point que vos seuls talents ne suffiront pas à le tirer d'affaire. Bientôt, l'homme perd à nouveau connaissance. Vous essayez alors de l'installer aussi confortablement que possible en l'allongeant sous un grand chêne, puis vous repartez en direction du nord-est en vous frayant un chemin dans la forêt touffue.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(330, "Continuer"));
                        return paragraph;
                    }
                case 118:
                    {
                        paragraph = new StoryParagraph("Vous lancez votre cheval au galop le long du chemin droit. Vous apercevez à l'horizon les contours de Holmgard dont les hautes murailles et les tours scintillent sous les rayons du soleil. Le sentier que vous suivez rejoint bientôt une grande route orientée nord-sud. C'est la voie principale qui relie le port de Toran à la capitale. Vous prenez donc la direction de Holmgard en surveillant le ciel clair de peur que n'y apparaisse la silhouette d'un Kraan.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(224, "Continuer"));
                        return paragraph;
                    }
                case 119:
                    {
                        paragraph = new StoryParagraph("Les Brosses à Potence déchirent votre cape et vous écorchent bras et jambes tandis que vous vous frayez un chemin dans leur enchevêtrement d'épines. Un quart d'heure plus tard, vous sortez enfin des buissons et vous poursuivez votre route d'un pas chancelant, mais parmi les arbres cette fois. Les plaies occasionnées par les Brosses à Potence vous coûtent 2 points d'ENDURANCE, à déduire de votre total actuel. Alors que vous continuez d'avancer, vous vous sentez pris de vertiges et vos paupières vous semblent lourdes. Bientôt, vous arrivez au bord d'une pente escarpée et couverte d'arbres.", paragraphNumber);
                        paragraph.addMainEvent(new DammageEvent(2));
                        paragraph.addDecision(new MoveEvent(226, "vous laisser glisser le long de cette pente "));
                        paragraph.addDecision(new MoveEvent(38, "marcher le long du bord "));
                        return paragraph;
                    }
                case 120:
                    {
                        paragraph = new StoryParagraph("Vous entendez les Gloks fous et sanguinaires tuer les autres chevaux de la roulotte. Vous jetez alors un coup d'œil par-dessus votre épaule : le Kraan s'est mis à tournoyer dans les airs. A-t-il l'intention de vous attaquer ou s'intéresse-t-il à autre chose ? L'ombre noire qui grandit bientôt tout autour de vous ne laisse plus subsister le moindre doute : c'est bien après vous qu'il en a. Le Kraan, en vérité, est même en train de fondre en piqué à une vitesse fulgurante !", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(84, "sauter de votre cheval"));
                        paragraph.addDecision(new MoveEvent(171, "galoper vers les arbres "));
                        paragraph.addDecision(new MoveEvent(54, "baisser la tête et de prier le ciel de vous protéger"));
                        return paragraph;
                    }
                case 121:
                    {
                        paragraph = new StoryParagraph("Après quelques minutes de marche, vous apercevez la silhouette d'un homme vêtu de rouge qui se tient debout au milieu du chemin. Il vous tourne le dos, et un capuchon lui couvre la tête. Le corbeau noir que vous avez vu un peu plus tôt est perché sur son bras tendu. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(342, "appeler cet homme"));
                        paragraph.addDecision(new MoveEvent(309, "vous approcher de lui avec prudence"));
                        paragraph.addDecision(new MoveEvent(283, "dégainer votre arme et l'attaquer"));
                        return paragraph;
                    }
                case 122:
                    {
                        paragraph = new StoryParagraph("Dès que le cheval sent que vous communiquez directement avec lui, il se calme. Vous vous approchez alors de ce magnifique étalon et vous lui caressez la tête d'un geste rassurant. Vous sentez à présent qu'il ne sait plus très bien s'il doit avoir peur ou pas. Vous montez ensuite sur son dos et vous le lancez sur le chemin, en prenant cette fois encore la direction du sud.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(206, "Continuer"));
                        return paragraph;
                    }
                case 123:
                    {
                        paragraph = new StoryParagraph("Lorsque la créature meurt, son corps se dissout en une espèce de liquide verdâtre et répugnant. Vous remarquez alors que les herbes et les plantes sur lesquelles se répand cette substance fumante se ratatinent et meurent aussitôt. Une Pierre Précieuse de bonne taille apparaît parmi les herbes, près du corps en décomposition. Plus loin sur le sentier, vous apercevez une meute de Gloks qui se précipitent vers vous. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(304, "ramasser la Pierre Précieuse"));
                        paragraph.addDecision(new MoveEvent(2, "partir à l'instant"));
                        return paragraph;
                    }
                case 124:
                    {
                        paragraph = new StoryParagraph("Dans la boîte, vous trouvez 15 Pièces d'Or et une Clé d'Argent.", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new Gold(15)));
                        paragraph.addMainEvent(new LootEvent(new SpecialItemUsage("CleDArgent")));
                        paragraph.addDecision(new MoveEvent(211, "explorer le tunnel "));
                        paragraph.addDecision(new MoveEvent(106, "descendre le flanc de la colline "));
                        return paragraph;
                    }
                case 125:
                    {
                        paragraph = new StoryParagraph("Le chemin mène à une grande clairière. Vous remarquez aussitôt sur le sol d'étranges empreintes de pattes griffues. De toute évidence, des Kraans se sont posés ici même. A en juger par le nombre d'empreintes et la surface qu'elles couvrent, ce sont au moins cinq de ces répugnantes créatures qui se sont rassemblées là dans les dernières douze heures. De l'autre côté de la clairière, deux chemins s'enfoncent dans la forêt. L'un est orienté à l'ouest, l'autre au sud. ", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(301, CapacityType.Orientation));
                        paragraph.addDecision(new MoveEvent(27, "emprunter le sentier orienté au sud"));
                        paragraph.addDecision(new MoveEvent(214, "prendre celui qui va vers l'ouest"));
                        return paragraph;
                    }
                case 126:
                    {
                        paragraph = new StoryParagraph("Vous chevauchez de plus en plus loin dans la forêt et, dans votre for intérieur, vous remerciez le Prince de vous avoir donné un si bon cheval, car bien que le sol soit entièrement recouvert d'un enchevêtrement de buissons et de racines, l'étalon blanc n'a jamais fait le moindre faux pas. Bientôt les Loups Maudits sont loin derrière vous et vous arrêtez votre cheval. La lumière commence à décliner, il fait presque nuit, à présent.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(46, "poursuivre votre chemin dans la même direction"));
                        paragraph.addDecision(new MoveEvent(143, "aller à gauche "));
                        return paragraph;
                    }
                case 127:
                    {
                        paragraph = new StoryParagraph("Après avoir marché pendant une heure, les Drakkarims s'arrêtent soudain tandis qu'une énorme créature couverte d'écaillés grises s'approche sur le chemin. Lorsque la bête répugnante se trouve tout près de vous, son haleine fétide vous fait grimacer. Le monstre pousse un rugissement et vous saisit la tête entre ses pattes palmées. Vous entendez alors un craquement: votre colonne vertébrale vient de se briser à hauteur de votre cou. C'est d'ailleurs le dernier son qui vous parvient en ce bas monde, car vous mourez à l'instant même. Votre mission s'achève ici. ", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 128:
                    {
                        paragraph = new StoryParagraph("Vous écartez prudemment le feuillage, et une vision d'horreur s'offre aussitôt à vous : un peu plus loin, dans une petite clairière, trois Gloks ont attaché un homme à un poteau et sont en train de mettre le feu à un tas de broussailles disposé à ses pieds. Sa tunique est celle d'un Garde-Frontière, il appartient au régiment chargé de surveiller les frontières occidentales du royaume, en bordure des monts Durncrag. L'homme a reçu une sévère correction et il est à demi inconscient. Si vous maîtrisez la ", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(297, CapacityType.Chasse));
                        paragraph.addDecision(new MoveEvent(336, "attaquer les Gloks pour sauver la vie du soldat"));
                        return paragraph;
                    }
                case 129:
                    {
                        paragraph = new StoryParagraph("Vous parvenez devant la porte principale de la ville et vous contemplez avec révérence les murs gigantesques qui se dressent devant vous. Hautes de soixante mètres, les murailles de Holmgard ont résisté tout à la fois au Temps et aux Maîtres des Ténèbres. L'officier et vous-même parcourez au pas de course le tunnel d'une centaine de mètres de long qui traverse le poste fortifié et vous arrivez enfin devant l'entrée de la grande Tour de Guet. Des civils et des soldats en grand nombre courent en tous sens, chacun s'activant à sa tâche.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(3, "continuer à suivre l'officier"));
                        paragraph.addDecision(new MoveEvent(144, "vous débrouiller tout seul"));
                        return paragraph;
                    }
                case 130:
                    {
                        paragraph = new StoryParagraph("Vous parvenez bientôt à une petite clairière. En son centre, vous trouvez un banc taillé dans le tronc d'un arbre. \nVous avez faim, et il vous faut prendre un Repas, sinon, vous perdrez 3 points d'ENDURANCE.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(28, "quitter la clairière par le sud "));
                        paragraph.addDecision(new MoveEvent(201, "s'enfonçer dans la forêt a l'est"));
                        return paragraph;
                    }
                case 131:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru environ cinq cents mètres lorsque vous entendez des cris et des bruits semblables au fracas du tonnerre. En vous approchant, vous apercevez bientôt une clairière que vous connaissez déjà. C'est là que s'élèvent les ruines de Raumas, un ancien temple de la forêt. Une troupe de Gloks dont vous évaluez le nombre à vingt-cinq ou trente sont en train d'attaquer les ruines qu'ils encerclent. D'autres Gloks, plus nombreux encore, sont étendus raides morts ou agonisent parmi les vestiges de marbre du temple. \n L'assaut des Gloks survivants ne faiblit pas pour autant et ils continuent de mener l'attaque contre les ruines.Qui s'y cache ? Vous l'ignorez.Or, soudain, un éclair jaillit et vient frapper le premier rang des Gloks.Les monstres revêtus de leurs armures sont alors projetés en tous sens, trébuchant et roulant sur euxmêmes.L'un d'eux, plus grand que les autres et couvert de la tête aux pieds d'une grosse cotte de mailles noire, lance des jurons à ses congénères et les incite à repartir à l'attaque en les frappant à grands coups d'un fouet aux lanières de fer barbelé. Vous dégainez votre arme et vous vous approchez de la clairière en restant à l'abri du feuillage.Vous essayez de voir qui défend ainsi les ruines du temple et, à votre grand étonnement, vous vous apercevez bientôt que c'est un jeune homme seul, guère plus âgé que vous, qui tient ainsi tête aux créatures déchaînées. Vous reconnaissez aussitôt sa toge bleu ciel brodée d'étoiles: c'est un jeune Théurgiste de la Guilde des Magiciens de Toran, un apprenti en magie blanche. Cinq Gloks, la lance brandie, chargent le jeune homme qui bat rapidement en retraite à l'intérieur des ruines.Vous le voyez alors se tourner et lever la main gauche: au même instant, un éclair bleu jaillit du bout de ses doigts et vient frapper les Gloks hurlants.Non loin del'endroit où vous êtes caché, un autre Glok contourne les ruines en courant et grimpe au sommet d'une des colonnes du temple.Il serre entre ses dents un long poignard à la lame recourbée et s'apprête à sauter sur le jeune sorcier qui se tient debout juste au-dessous de lui. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(241, "crier pour avertir le sorcier  "));
                        paragraph.addDecision(new MoveEvent(55, "vous précipiter en avant pour attaquer le Glok"));
                        paragraph.addDecision(new MoveEvent(302, "ramasser une pierre dans les ruines et la jeter à la tête du Glok"));
                        paragraph.addDecision(new MoveEvent(101, "quitter ce champ de bataille et retourner dans la foret"));
                        return paragraph;
                    }
                case 132:
                    {
                        paragraph = new StoryParagraph("Le garde du corps vous observe d'un regard soupçonneux et vous claque la porte au nez. Vous entendez parler à l'intérieur de la roulotte puis, soudain, la porte s'ouvre à nouveau et le visage d'un marchand prospère apparaît. Il reconnaît aussitôt votre cape de Seigneur Kaï et vous demande de bien vouloir excuser la conduite de son serviteur. Il vous fait entrer dans la roulotte et vous raconte qu'il a été attaqué plusieurs fois depuis qu'il a quitté le port de Toran, notamment par des Kraans et par des brigands. Son garde du corps a tout de suite pensé que vous pouviez être un bandit, ce qui explique son comportement. La roulotte est remplie de soieries et d'épices. Le marchand vous propose quelque chose à manger et vous acceptez avec gratitude. Après avoir fait un somptueux repas, la fatigue accumulée au cours de vos épreuves a raison de vous et vous sombrez dans un sommeil profond. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(64, "Continuer"));
                        return paragraph;
                    }
                case 133:
                    {
                        paragraph = new StoryParagraph("Quand vous vous approchez de la statue, celle-ci commence à se craqueler et, soudain, elle explose devant vous tandis qu'un véritable serpent ailé, débarrassé de son manteau de pierre vous attaque férocement.", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Serpend Ailé", 16,18, EnnemyTypes.Hero)));
                        paragraph.addDecision(new MoveEvent(266, "Continuer"));
                        return paragraph;
                    }
                case 134:
                    {
                        paragraph = new StoryParagraph("Vos talents de Seigneur Kaï vous permettent de déceler des traces de Gloks tout autour de la clairière. Les empreintes sont fraîches, et il ne fait aucun doute que ces cruels serviteurs des Maîtres des Ténèbres se trouvaient là il y a moins de deux heures.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(305, "inspecter les maisons"));
                        paragraph.addDecision(new MoveEvent(40, "éviter cette clairière"));
                        return paragraph;
                    }
                case 135:
                    {
                        paragraph = new StoryParagraph("Parvenu au bord de l'escarpement de la berge, vous jetez un coup d'œil en contrebas et vous apercevez un enchevêtrement de débris de bois portés là par le courant. Un gros tronc d'arbre, notamment, s'est échoué sur la rive, à côté d'un petit canoë. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(223, "utiliser le tronc d'arbre pour descendre le cours de la rivière"));
                        paragraph.addDecision(new MoveEvent(4, "vous servir du canoë"));
                        return paragraph;
                    }
                case 136:
                    {
                        paragraph = new StoryParagraph("Les Gloks se rapprochent puis s'accroupissent, prêts à bondir. Vous apercevez les pointes dentelées de leurs lances et vous entendez les sons gutturaux qu'ils produisent en parlant. « Rob Gaye Oring Ahrr oho key ! Pamark élbhûtt ! » s'écrie la plus grande des deux créatures qui vous attaque aussitôt. Il vous faut combattre les deux Gloks à tour de rôle. Vous ajouterez un point d'HABILETÉ à votre total en raison de l'avantage que vous donne votre position plus élevée sur le terrain. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok",13,10, EnnemyTypes.Orc)));
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok",12,10, EnnemyTypes.Orc)));
                        paragraph.addDecision(new MoveEvent(313, "Continuer"));
                        return paragraph;
                    }
                case 137:
                    {
                        paragraph = new StoryParagraph("Lorsque la dernière de ces répugnantes créatures meurt enfin, la lumière verdâtre commence à diminuer. Vous constatez alors que dans chacun des crânes fracassés se trouve une Pierre Précieuse. Vous ramassez ces vingt Pierres juste avant que la lueur s'éteigne, plongeant la chambre mortuaire dans une totale obscurité.\n Vous vous hâtez de quitter la Crypte et vous poursuivez votre chemin", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new SpecialItemUsage("20PierresPrecieuses")));
                        paragraph.addDecision(new MoveEvent(23, "Continuer"));
                        return paragraph;
                    }
                case 138:
                    {
                        paragraph = new StoryParagraph("Vous dégainez votre arme et vous vous portez à la rencontre de l'ennemi. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok", 13, 10, EnnemyTypes.Orc)));
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Glok", 12, 10, EnnemyTypes.Orc)));
                        paragraph.addDecision(new MoveEvent(291, "Continuer"));
                        return paragraph;
                    }
                case 139:
                    {
                        paragraph = new StoryParagraph("Il règne dans la cour une intense activité. Des éclaireurs de la cavalerie attendent à côté de leurs chevaux que leurs commandants d'unité, rassemblés au Quartier Général, leur confient des messages à porter. A chaque instant, l'un de ces hommes quitte la cour au galop, porteur d'une dépêche destinée aux officiers en poste dans le camp fortifié. A peine sont-ils partis que d'autres reviennent, à bout de souffle et souvent blessés. Vous avez fait une douzaine de pas dans la cour lorsqu'une voix retentit soudain : « Arrêtez cet homme ! » ordonne-t-elle. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(66, "Continuer"));
                        return paragraph;
                    }
                case 140:
                    {
                        paragraph = new StoryParagraph("Vous vous trouvez dans une clairière au centre de laquelle on a élevé une tour branlante à l'aide de troncs d'arbres grossièrement taillés. Au pied de la tour, trois sentiers partent dans différentes directions.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(14, "prendre le sentier qui mène au sud"));
                        paragraph.addDecision(new MoveEvent(252, "prendre celui qui mène à l'est"));
                        paragraph.addDecision(new MoveEvent(215, "prendre celui orienté au sud-ouest"));
                        paragraph.addDecision(new MoveEvent(36, "monter dans la tour"));
                        return paragraph;
                    }
                case 141:
                    {
                        paragraph = new StoryParagraph("Votre Sixième Sens vous avertit que quelques-unes des créatures qui ont attaqué le monastère sont restées dans les environs et inspectent les deux chemins, en quête d'éventuels survivants à massacrer. Vous pouvez cependant éviter ces deux sentiers en coupant par les sous-bois de la forêt. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(56, "aller vers le sud"));
                        paragraph.addDecision(new MoveEvent(333, "vous frayer un chemin dans le feuillage plus touffu au nord-est"));
                        return paragraph;
                    }
                case 142:
                    {
                        paragraph = new StoryParagraph("Vous apercevez les hautes murailles blanches et les tours scintillantes de Holmgard, dont les étendards flottent au vent frais du matin. S'étirant vers l'ouest, le fleuve Eledil jaillit des monts Durncrag et se jette dans le golfe de Holm. Or, soudain, vous distinguez au loin, à l'ombre des montagnes, une immense armée aux uniformes noirs qui marche sans répit vers la capitale. \nA votre droite, la grand - route mène à Holmgard à travers les plaines.En courant vite, vous pourriez atteindre en une heure le camp fortifié qui se dresse autour de la ville, mais vous seriez la plupart du temps à découvert, offrant aux Kraans une proie facile.A quelque distance devant vous, cependant, une large rivière aux eaux boueuses coule paresseusement en direction du fleuve Eledil dans lequel elle finit par se jeter.Vous pourriez profiter de l'escarpement de ses berges pour nager à couvert et rejoindre ainsi la capitale. A votre gauche, par ailleurs, s'étend le Cimetière des Anciens.En marchant parmi les tombes et les monuments funéraires en ruine, vous pourriez échapper aux regards et vous approcher de votre but, mais c'est là une zone interdite : des forces ténébreuses restent, en effet, tapies dans l'ombre de la nécropole, attendant qu'un passant téméraire s'offre à leurs maléfices.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(58, "tenter votre chance en empruntant la grand-route"));
                        paragraph.addDecision(new MoveEvent(135, "atteindre la capitale par la rivière"));
                        paragraph.addDecision(new MoveEvent(102, "vous risquer dans le Cimetière des Anciens"));
                        return paragraph;
                    }
                case 143:
                    {
                        paragraph = new StoryParagraph("Vous sortez bientôt de la forêt pour arriver sur une grande route : c'est celle qui relie le port de Toran à la capitale. Vous lancez votre cheval au galop : si tout va bien vous devriez avoir atteint Holmgard dans la matinée. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(149, "Continuer"));
                        return paragraph;
                    }
                case 144:
                    {
                        paragraph = new StoryParagraph("Vous vous frayez un chemin à coups de coude dans la foule qui se presse sur la grand-rue. Vous apercevez un peu plus loin la silhouette massive de la citadelle qui abrite le Palais du Roi. Les habitants de Holmgard, saisis de panique, courent en tous sens, tandis que retentissent les cris des Kraans qui tournoient dans le ciel de la ville. Dans la bousculade, quelqu'un vous vole l'un des objets contenus dans votre Sac à Dos. Si vous n'avez plus de Sac à Dos, c'est une arme qu'on vous dérobe. Rayez l'objet ou l'arme perdue de votre Feuille d'Aventure (c'est vous qui choisissez ce qu'on vous a volé). Un cheval emballé, qui tire une charrette, passe devant vous à toute allure et vous heurte en vous projetant contre une porte cochère. Vous êtes à moitié assommé et vous perdez 2 points D'ENDURANCE. Vous vous relevez en titubant, mais, au même moment, la porte s'ouvre à la volée et un vieil homme décrépit se précipite sur vous en brandissant un couteau à viande. Il est fou à lier et il vous faut le combattre ou tenter de fuir.", paragraphNumber);
                        paragraph.addMainEvent(new DammageEvent(2));
                        paragraph.addDecision(new MoveEvent(63, "le combattre"));
                        paragraph.addDecision(new MoveEvent(217, "éviter l'affrontement"));
                        return paragraph;
                    }
                case 145:
                    {
                        paragraph = new StoryParagraph("Vous avez l'impression d'avoir été renversé par un chariot. Vous tombez en avant et vous perdez connaissance en ressentant une terrible douleur dans le dos, et avec un goût désagréable dans la bouche : celui de la poussière qui recouvre la route.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(165, "Continuer"));
                        return paragraph;
                    }
                case 146:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru deux kilomètres à cheval lorsque vous êtes soudain jeté à bas de votre monture par une flèche qui vient de vous écorcher le front. Vous perdez 3 points d'ENDURANCE. Tandis que vous vous relevez, vous voyez surgir de la forêt, des deux côtés de la route, une bande de Drakkarims qui vous ont tendu une embuscade. Il vous faut prendre la fuite au plus vite en courant vous cacher parmi les arbres.", paragraphNumber);
                        paragraph.addMainEvent(new DammageEvent(3));
                        paragraph.addDecision(new MoveEvent(154, "Continuer"));
                        return paragraph;
                    }
                case 147:
                    {
                        paragraph = new StoryParagraph("Après avoir marché pendant quelques minutes, vous passez devant une petite hutte couverte de mousse qui a été bâtie à l'écart du chemin. Vous avez faim et il vous faut prendre un Repas, sinon, vous perdez 3 points d'ENDURANCE. Vous constatez bientôt que le chemin tourne vers l'est. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(42, "continuer à le suivre"));
                        paragraph.addDecision(new MoveEvent(28, "revenir sur vos pas"));
                        return paragraph;
                    }
                case 148:
                    {
                        paragraph = new StoryParagraph("Vous ouvrez la porte d'un coup de pied et vous vous ruez à l'intérieur de la ferme. Un Kraan s'élève dans les airs en poussant un cri de victoire : il tient une victime dans ses serres pointues. Vous reprenez votre équilibre et vous jetez un coup d'œil autour de vous : l'endroit est désert. En vous approchant de la cheminée, vous trouvez un Marteau de Guerre posé contre le mur. Vous pouvez le prendre si vous le désirez.", paragraphNumber);
                        paragraph.addDecision(new LootEvent(CreateLoot.CreateWeapon.MarteauDeGuerre()));
                        paragraph.addDecision(new MoveEvent(81, "rester dans cette ferme"));
                        paragraph.addDecision(new MoveEvent(320, "vous réfugier dans la forêt"));
                        paragraph.addDecision(new MoveEvent(199, "inspecter plus avant la pièce "));
                        return paragraph;
                    }
                case 149:
                    {
                        paragraph = new StoryParagraph("Tandis que vous parcourez la grand-route à cheval, la lumière du jour diminue de plus en plus ; bientôt, il fera complètement nuit et vous ne pourrez plus voir les ennerrus qui vous attendent dans l'ombre. Vous décidez donc de vous arrêter en lisière de la forêt et de vous cacher là jusqu'au matin. Vous pourrez par la même occasion prendre quelque repos. Vous vous aménagez une cachette sûre et vous vous y installez, emmitouflé dans votre cape verte de Seigneur Kaï. Quelques instants plus tard, vous avez sombré dans un sommeil sans rêves.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(256, "Continuer"));
                        return paragraph;
                    }
                case 150:
                    {
                        paragraph = new StoryParagraph("Bien qu'elle soit un peu trop cuite, cette nourriture a un goût délicieux (il n'y en a pas assez cependant pour constituer un repas complet) et l'eau claire étanche votre soif. Vous avez passé environ une demi-heure dans cette maison lorsque vous vous rendez soudain compte que vous êtes en train de prendre du retard. Vous ramassez vos affaires et reprenez votre chemin ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(83, "Continuer"));
                        return paragraph;
                    }
                case 151:
                    {
                        paragraph = new StoryParagraph("En vous concentrant sur le trou de la serrure, vous pourrez peutêtre actionner le mécanisme interne et repousser le pêne par votre seule force mentale. Vous ferez ensuite léviter la broche pour la libérer de ses attaches. En opérant ainsi à distance, vous resterez hors d'atteinte des pièges éventuels qui pourraient se déclencher lors de l'ouverture de la serrure. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(81, "Continuer"));
                        return paragraph;
                    }
                case 152:
                    {
                        paragraph = new StoryParagraph("L'herboriste vous offre tout un choix de potions : certaines d'entre elles accroissent votre force, d'autres vous rendent invisible, d'autres encore vous donnent la faculté de vous faufiler partout, et il en est même qui vous permettent de prendre une forme gazeuse. Ensuite, l'homme ouvre un tiroir au bas de son comptoir et vous montre une magnifique Baguette Magique. D'après lui, il s'agit là d'une arme puissante qui vous permettra de combattre efficacement toute créature malfaisante en vous rendant vous-même invulnérable aux coups de vos adversaires. Pour mieux vous en convaincre, il vous invite à lire une inscription magique gravée sur la baguette.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(49, "vous pencher par-dessus le comptoir pour lire l'étrange inscription"));
                        paragraph.addDecision(new MoveEvent(231, "vous intéressez davantage aux potions"));
                        return paragraph;
                    }
                case 153:
                    {
                        paragraph = new StoryParagraph("Au loin se dressent les hautes murailles blanches et les tours scintillantes de Holmgard dont les étendards flottent au vent frais du matin. S'étirant vers l'ouest, le fleuve Eledil jaillit des monts Durncrag et se jette dans le golfe de Holm. Or, soudain, vous distinguez au pied des montagnes une immense armée aux uniformes noirs qui s'avance inexorablement vers la capitale. A votre droite, la grand-route mène à Holmgard à travers les plaines. En vous lançant au galop, vous pourriez atteindre en moins d'une heure le camp fortifié qui entoure la ville, mais vous seriez la plupart du temps à découvert, offrant aux Kraans une proie facile. A quelque distance devant vous, cependant, une large rivière aux eaux boueuses coule paresseusement en direction du fleuve Eledil dans lequel elle finit par se jeter. Vous pourriez abandonner votre cheval et profiter de l'escarpement de ses berges pour nager à couvert jusqu'aux abords de la capitale. Il existe enfin une troisième voie : à votre gauche s'étend, en effet, le Cimetière des Anciens. Si vous marchiez parmi les tombes et les monuments funéraires en ruine, vous n'auriez aucun mal à vous approcher de votre but en échappant aux regards, mais c'est là une zone interdite car des forces ténébreuses restent tapies dans l'ombre de la nécropole et attendent qu'un passant téméraire s'offre à leurs maléfices.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(202, "tenter votre chance en empruntant la grand-route"));
                        paragraph.addDecision(new MoveEvent(135, "atteindre la capitale par la rivière"));
                        paragraph.addDecision(new MoveEvent(329, "affronter les terribles périls du Cimetière des Anciens"));
                        return paragraph;
                    }
                case 154:
                    {
                        paragraph = new StoryParagraph("Votre blessure vous donne le tournis et vous titubez parmi les arbres comme un aveugle. Soudain, vous tombez en avant comme si le sol s'était dérobé sous vos pieds ; c'est, d'ailleurs, ce qui s'est passé : vous venez d'être précipité tête la première dans un piège à ours. Vous levez alors les yeux et vous distinguez les silhouettes de quatre Drakkarims qui tendent leurs arcs en vous visant de leurs flèches. Ils tirent tous les quatre en même temps et vous entendez des grognements de triomphe s'échapper de leurs lèvres, tordues en un rictus répugnant. Les quatre flèches s'enfoncent profondément dans votre poitrine et toute lumière s'éteint. Votre mission a échoué. ", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("Continuer"));
                        return paragraph;
                    }
                case 155:
                    {
                        paragraph = new StoryParagraph("A votre approche, leur conversation s'interrompt. Vous constatez par l'expression de leurs visages que tous ces gens ont reconnu en vous un Seigneur Kaï. Alors, lentement, l'un des hommes tend la main vers vous en un geste amical. \n«Seigneur, dit - il, nous avons entendu dire que le Monastère Kaï avait été détruit et tous ceux qui l'occupaient impitoyablement massacrés. Heureusement, votre présence ici montre qu'il s'agissait là de fausses rumeurs. Nous avions peur que tout ne soit perdu. » Vous préférez ne pas leur révéler que le Monastère a bel et bien été anéanti : ce serait, en effet, enlever tout espoir à ces hommes et à ces femmes qui ont fui la ville de Toran dévastée par les armées ennemies. Ils ont dû abandonner tous leurs biens et les voilà qui errent sur les chemins pour tenter d'échapper à la guerre, en espérant que les Seigneurs Kaï conduiront à la victoire l'armée du Sommerlund. Vous apprenez par leurs récits que le port de Toran a été attaqué par mer et par air et que les armées des Maîtres des Ténèbres surpassaient largement en nombre la garnison de la ville. En dépit de la vaillance dont ils ont fait preuve, les soldats du Roi ont ainsi dû s'incliner.Vous essayez de rassurer de votre mieux ces malheureux réfugiés en affirmant que le Sommerlund ne tombera jamais aux mains des envahisseurs.Puis vous leur souhaitez bonne chance au long de leur exode et vous reprenez vous - même votre chemin.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(70, "Continuer"));
                        return paragraph;
                    }
                case 156:
                    {
                        paragraph = new StoryParagraph("Des flèches noires se fichent dans la boue tout autour de vous. D'autres Gloks ont fait leur apparition sur la berge escarpée de la rivière et vous tirent dessus. De ce côté du cours d'eau, il n'y a pas d'arbres pour vous mettre à l'abri.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(294, "plonger dans l'eau de la rivière et nager au fil du courant"));
                        paragraph.addDecision(new MoveEvent(245, "traverser le cours d'eau à la nage pour aller vous mettre à couvert des arbres"));
                        return paragraph;
                    }
                case 157:
                    {
                        paragraph = new StoryParagraph("La forêt s'éclaircit et vous apercevez bientôt une route un peu plus loin. Une véritable foule occupe toute la largeur de la chaussée et des hommes et des femmes tirent des carrioles remplies d'objets, de meubles ou de vêtements. Ce sont des réfugiés qui fuient le nord du royaume, ils pourront peut-être vous donner des informations sur ce qui se passe dans le nord. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(30, "vous joindre à ces réfugiés"));
                        paragraph.addDecision(new MoveEvent(167, "poursuivre votre route vers le sud, en restant à l'abri des arbres"));
                        return paragraph;
                    }
                case 158:
                    {
                        paragraph = new StoryParagraph("La clé s'adapte parfaitement à la serrure que vous n'avez aucun mal à ouvrir. Vous faites pivoter la porte sur ses gonds et vous vous retrouvez face à face avec un vieillard étrange qui porte un bâton à la main droite. Soudain, un éclair jaillit du bâton et vous frappe en pleine poitrine. Vous perdez 6 points d'ENDURANCE. Haletant de douleur, vous avez malgré tout (si vous n'êtes pas mort sur le coup) la force de bousculer le vieil homme d'un coup d'épaule et de monter quatre à quatre un escalier plutôt raide qui mène à la lumière du jour. Vous avez grimpé la moitié des marches lorsque le vieillard fait jaillir un nouvel éclair de son bâton.Si vous avez survécu, vous émergez à la lumière du jour en maudissant votre mauvaise fortune. Vous avez découvert, par malchance, le temple secret d'une secte de druides malfaisants et vous auriez pu tout aussi bien y laisser votre peau. Vous vous hâtez à présent de rejoindre le sentier qui redescend de l'autre côté de la colline.", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if(rand > 5)
                        {
                            paragraph.addMainEvent(new DammageEvent("", "l'éclair vous frappe dans le dos",4));
                        }
                        paragraph.addDecision(new MoveEvent(106, "Continuer"));
                        return paragraph;
                    }
                case 159:
                    {
                        paragraph = new StoryParagraph("Le marchand refuse votre offre : il ne vous laissera pas monter dans la roulotte. Et, soudain, il claque des doigts à l'adresse d'un de ses gardes du corps qui empoigne aussitôt le pommeau de son arme.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(191, "le combattre"));
                        paragraph.addDecision(new MoveEvent(234, "sauter de la roulotte"));
                        return paragraph;
                    }
                case 160:
                    {
                        int rand = DiceRoll.D10Roll0();
                        if(rand < 5)
                        {
                            paragraph = new StoryParagraph("vous avez été repéré", paragraphNumber);
                            paragraph.addDecision(new MoveEvent(286, "Continuer"));
                        }
                        else
                        {
                            paragraph = new StoryParagraph("ils ne vous ont pas vu ", paragraphNumber);
                            paragraph.addDecision(new MoveEvent(10, "Continuer"));
                        }
                       
                        
                        return paragraph;
                    }
                case 161:
                    {
                        paragraph = new StoryParagraph("Au moment où vous vous asseyez, le Serpent de Pierre se met à bouger. Une sueur froide perle à votre front et vous empoignez votre arme d'une main tremblante, prêt à vous défendre contre une attaque éventuelle. Une langue rouge et fourchue jaillit alors de la tête de cette étrange statue et vient plonger dans la coupe de lumière verte posée sur le dossier du trône, au-dessus de vous. Lentement, la langue fourchue ressort de la coupe en tenant une Clé d'Or qu'elle laisse tomber sur vos genoux. \n Un instant plus tard, un panneau glisse dans le mur est de la pièce, découvrant l'entrée d'un passage secret.Vous prenez la Clé et vous vous hâtez de quitter les lieux par cette sortie inattendue.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(209, "Continuer"));
                        return paragraph;
                    }
                case 162:
                    {
                        paragraph = new StoryParagraph("Vous vous approchez de ces hommes et vous les appelez. Mais lorsqu'ils se tournent vers vous, votre sang se glace et vous sentez votre cœur battre à tout rompre, car ce sont des Drakkarims déguisés. En vous voyant, ils se précipitent sur vous, vous ligotent pieds et poignets et vous traînent derrière eux le long d'un sentier. Ils vous prennent votre Sac à Dos et vos Armes, mais ils ne fouillent pas les poches de votre cape et ne trouvent pas vos Pièces d'Or. Vous les entendez jacasser d'un air menaçant tandis qu'ils vous emportent ainsi vers leur repaire : de toute évidence, ils sont en train de décider du sort qu'ils vous réservent, et vos perspectives d'avenir ne semblent pas des plus réjouissantes. ", paragraphNumber);
                        paragraph.addDecision(new CapacityEvent(258,CapacityType.MaitriseDeLaMatiere));
                        paragraph.addDecision(new MoveEvent(127, "Continuer"));
                        return paragraph;
                    }
                case 163:
                    {
                        paragraph = new StoryParagraph("Au bout d'une demi-heure environ, vous sentez que le courant devient plus fort. Un peu plus loin, le cours de la rivière forme un méandre et ses eaux s'agitent en un puissant tourbillon qui vous emportera au fond si vous vous laissez entraîner. Vous décidez donc de nager vers la rive droite et de poursuivre votre chemin à pied. Votre équipement est au complet, vous n'avez rien perdu dans les eaux de la rivière. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(321, "Continuer"));
                        return paragraph;
                    }
                case 164:
                    {
                        paragraph = new StoryParagraph("Vous débouchez prudemment chacune des bouteilles et vous reniflez son contenu. Il semble s'agir là de différentes sortes de vin. Mais soudain, une autre bouteille, plus petite, coincée parmi les autres, attire votre attention. Elle est remplie d'un liquide de couleur orange dont l'odeur vous est familière : c'est de l'Essence d'Alether, une puissante potion qui a la propriété d'accroître votre force. Vous pouvez conserver cette fiole et en boire le contenu au début d'un combat : votre total d'HABILETÉ augmentera alors de 2 points pendant toute la durée de l'affrontement. Cette quantité d'essence d'Alether ne représente qu'une seule dose, vous ne pourrez donc en faire usage qu'une fois. Vous décidez à présent d'inspecter l'écurie.", paragraphNumber);
                        paragraph.addMainEvent(new LootEvent(new SpecialItemUsage("EssenceDAlether")));
                        paragraph.addDecision(new MoveEvent(308, "Continuer"));
                        return paragraph;
                    }
                case 165:
                    {
                        paragraph = new StoryParagraph("Vous vous réveillez tremblant de fièvre. Des images floues défilent devant vos yeux puis s'effacent. Votre dos vous fait terriblement mal et vous hurlez de douleur. Quelques instants plus tard, vous sentez sur votre front le contact frais d'un linge humide et vous apercevez à travers la brume de votre cerveau le visage inquiet d'une jeune femme. Un vieillard lui murmure quelque chose à l'oreille, puis disparaît de votre champ de vision. La jeune fille s'agenouille alors près de vous et vous chuchote quelques mots de réconfort, mais bientôt, la lumière s'évanouit à nouveau et vous replongez dans les ténèbres. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(212, "Continuer"));
                        return paragraph;
                    }
                case 166:
                    {
                        paragraph = new StoryParagraph("Vous êtes en présence d'une force hautement maléfique. Un être puissant et invisible essaie de soumettre votre esprit, et il vous faut rassembler toute votre énergie pour vous défendre. Cette lutte intense vous met en grand danger de perdre la raison. Vous traversez une longue et pénible épreuve au cours de laquelle toutes sortes d'apparitions terrifiantes, surnaturelles, fantasmagoriques essaient de vous attirer dans leur monde de folie. La tentation et l'horreur se mélangent dans votre tête et ce n'est qu'à grand-peine que vous parvenez à sortir vainqueur de ce véritable calvaire. Vous perdez 4 points d'ENDURANCE et vous entrez dans le tunnel d'un pas chancelant.", paragraphNumber);
                        paragraph.addMainEvent(new DammageEvent(4));
                        paragraph.addDecision(new MoveEvent(104, "Continuer"));
                        return paragraph;
                    }
                case 167:
                    {
                        paragraph = new StoryParagraph("Vous avez parcouru environ deux kilomètres lorsque vous apercevez deux jambes qui dépassent de derrière un gros rocher.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(88, "vous approcher pour voir de quoi il retourne"));
                        paragraph.addDecision(new MoveEvent(264, "passer votre chemin et continuer droit devant"));
                        paragraph.addDecision(new CapacityEvent(178, CapacityType.SixiemeSens));
                        return paragraph;
                    }
                case 168:
                    {
                        paragraph = new StoryParagraph("Vous vous hissez au sommet de la luxueuse roulotte et vous vous installez au milieu des malles et des valises. La nuit bientôt tombera sur la grand-route. Un vent frais souffle de l'ouest, qui vous oblige à bien serrer votre cape autour de vous pour n'avoir pas trop froid. Au-dessous, à l'intérieur de la roulotte, vous entendez des gens parler et une délicieuse odeur de viande rôtie vous monte aux narines. Elle vient vous rappeler que vous avez très faim et qu'il vous faut prendre un Repas, sinon, vous perdrez 3 points d'ENDURANCE. La fatigue a tôt fait d'avoir raison de vous et vous finissez par sombrer dans un sommeil agité.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(64, "Continuer"));
                        return paragraph;
                    }
                case 169:
                    {
                        paragraph = new StoryParagraph("Lorsque vous passez devant les crânes, chacun d'eux pivote lentement sur lui-même comme pour suivre le moindre de vos mouvements. Vous vous trouvez à présent au milieu de cette chambre mortuaire et, soudain, vous entendez un bruit d'os qui se brise. Des formes monstrueuses éclosent alors des crânes en déployant des ailes semblables à celles des chauves-souris. Dix de ces créatures à la peau gluante vous attaquent aussitôt", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Monstres des cryptes", 16,16,EnnemyTypes.Beast)));
                        paragraph.addDecision(new MoveEvent(137, "Continuer"));
                        return paragraph;
                    }
                case 170:
                    {
                        paragraph = new StoryParagraph("Le tunnel est sombre et il y fait beaucoup plus froid qu'audehors. Vous avancez prudemment en tâtonnant la paroi et au bout de trois minutes passées dans une obscurité totale, vous sentez soudain une odeur répugnante de viande pourrie. Si vous disposez d'une Torche et d'un Briquet d'Amadou, vous pourrez vous en servir pour vous éclairer. Soudain, une lourde masse tombe du plafond du tunnel et atterrit sur votre dos. Sous le choc, vos jambes fléchissent et vous vous retrouvez à genoux. C'est un Gluâtre des Profondeurs qui vient de vous attaquer en essayant de vous étrangler de ses longs tentacules visqueux. Si vous n'avez pas de Torche pour vous éclairer, vous devrez réduire de 3 points votre total d'HABILETÉ pendant toute la durée du combat. Le Gluâtre est insensible aux Disciplines Kaï de la Puissance Psychique et de la Communication Animale. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Gluatre des profondeurs", 17,7, EnnemyTypes.Hero)));
                        paragraph.addDecision(new MoveEvent(319, "Continuer"));
                        return paragraph;
                    }
                case 171:
                    {
                        paragraph = new StoryParagraph("Vous avez atteint la lisière du bois lorsque votre cheval se cabre soudain en poussant un hennissement de douleur. Le Kraan a enfoncé ses serres pointues dans les pattes arrière de votre monture et tente de vous désarçonner à grands coups d'aile. Pendant ce temps, le Glok diabolique lance de petits cris triomphants en brandissant sa lance. Vous sautez à terre et vous courez vous mettre à l'abri parmi les arbres, laissant là votre malheureux cheval qui agonise entre les griffes du Kraan. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(303, "Continuer"));
                        return paragraph;
                    }
                case 172:
                    {
                        paragraph = new StoryParagraph("La nuit tombe et l'obscurité bientôt vous engloutit. Il serait vain de poursuivre votre route car vous vous perdriez à coup sûr. Vous attachez donc votre cheval à un arbre, vous vous étendez sur le sol en vous emmitouflant dans votre cape de Seigneur Kaï et vous sombrez dans un sommeil sans rêves. Au matin vous êtes réveillé par des bruits de galops lointains. De l'autre côté du lac, vous distinguez des silhouettes noires de Drakkarims et une meute de Loups Maudits. Un Kraan apparaît également au-dessus des arbres et se pose sur le toit de la petite cabane. Il est monté par une créature vêtue de rouge. Un instant plus tard, le monstre redoutable reprend son vol et traverse le lac en se dirigeant vers l'endroit où vous êtes caché.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(239, "vous enfoncer plus profondément dans la forêt afin d'échapper au Kraan"));
                        paragraph.addDecision(new MoveEvent(29, "vous préparer à combattre "));
                        paragraph.addDecision(new CapacityEvent(114, CapacityType.Camouflage));
                        return paragraph;
                    }
                case 173:
                    {
                        paragraph = new StoryParagraph("Lorsque vous atteignez la porte, un énorme bloc de pierre tombant du plafond s'écrase au sol, juste derrière vous. Vous faites volte-face et vous constatez que la sortie est à présent entièrement obstruée. Si vous possédez une Clé d'Argent, vous pouvez vous en servir pour essayer d'ouvrir la porte.", paragraphNumber);
                        paragraph.addDecision(new ItemRequieredEvent(158,"CleDArgent"));
                        paragraph.addDecision(new MoveEvent(259, "continuer"));
                        return paragraph;
                    }
                case 174:
                    {
                        paragraph = new StoryParagraph("Après vous être laissé dériver pendant environ une heure, vous remarquez que le courant devient plus fort. Vous apercevez alors à quelque distance un tourbillon que forment les eaux de la rivière à hauteur d'un méandre. Les flots vous entraînent vers ce puissant remous qui pourrait bien signifier pour vous la noyade pure et simple. Il ne vous reste plus qu'à plonger dans les eaux boueuses pour regagner la berge. Malheureusement, tandis que vous nagez en vous éloignant du courant, votre Sac à Dos se détache et tombe au fond de l'eau ainsi que vos Armes. C'est donc privé de votre équipement que vous atteignez la rive boisée sur laquelle vous parvenez à vous hisser tant bien que mal. ", paragraphNumber);
                        paragraph.addMainEvent(new LooseBackPack());
                        paragraph.addMainEvent(new LooseWeaponHolder());
                        paragraph.addDecision(new MoveEvent(190, "continuer"));
                        return paragraph;
                    }
                case 175:
                    {
                        paragraph = new StoryParagraph("De la main, vous faites signe aux cavaliers en qui vous reconnaissez des Gardes-Frontières de l'armée du Roi. Ils font partie du régiment chargé de surveiller les frontières occidentales du Royaume, souvent menacées. Mais le soulagement que vous éprouvez à rencontrer des alliés est de courte durée, car vous vous apercevez bientôt que ces soldats sont, en fait, poursuivis par des Gloks hurlants qui chevauchent des Loups Maudits. Des flèches noires tombent en pluie tout autour des GardesFrontières tandis que leurs terribles poursuivants gagnent du terrain. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(41, "essayer de vous cacher là où vous êtes"));
                        paragraph.addDecision(new MoveEvent(116, "traverser la rivière à la nage pour vous réfugier sur l'autre berge"));
                        paragraph.addDecision(new CapacityEvent(182, CapacityType.Camouflage));
                        return paragraph;
                    }
                case 176:
                    {
                        paragraph = new StoryParagraph("Vous vous cachez derrière d'épais buissons en espérant que le Loup Maudit et son cavalier ne verront pas votre cheval blanc. \nPar chance, votre ruse réussit et les malfaisantes créatures passent devant vous sans vous remarquer, puis s'éloignent le long du sentier que vous venez de quitter.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(253, "attaquer les autres Loups Maudits et leurs cavaliers"));
                        paragraph.addDecision(new MoveEvent(126, "poursuivre votre chemin en vous enfonçant plus avant dans la forêt"));
                        return paragraph;
                    }
                case 177:
                    {
                        paragraph = new StoryParagraph("Vous fouillez tous les placards de la maisonnette, mais vous ne trouvez rien qui puisse vous être de quelque utilité. Vous estimez alors que vous avez perdu suffisamment de temps et vous décidez de vous remettre en chemin au plus vite.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(83, "continuer"));
                        return paragraph;
                    }
                case 178:
                    {
                        paragraph = new StoryParagraph("Votre Sixième Sens vous permet de reconnaître à distance les bottes et les guêtres d'un soldat de l'armée royale. Vous sentez également que cet homme est blessé et qu'il a besoin d'aide. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(88, "lui porter secours"));
                        paragraph.addDecision(new MoveEvent(264, "l'abandonner à son sort et poursuivre votre chemin"));
                        return paragraph;
                    }
                case 179:
                    {
                        paragraph = new StoryParagraph("Vous avez été repéré par les gardes qui vous mettent en joue avec leurs arbalètes.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(318, "lever les mains et avancer vers eux"));
                        paragraph.addDecision(new MoveEvent(51, "prendre vos jambes à votre cou pour vous cacher parmi les arbres"));
                        return paragraph;
                    }
                case 180:
                    {
                        paragraph = new StoryParagraph("Ils vous voient lever votre arme et vous attaquent aussitôt.", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Chef des soldats",15,22, EnnemyTypes.Human)));
                        paragraph.addMainEvent(new FightEvent(new Ennemy("soldat",13,20, EnnemyTypes.Human)));
                        paragraph.addMainEvent(new FightEvent(new Ennemy("soldat", 13,20, EnnemyTypes.Human)));
                        paragraph.addDecision(new MoveEvent(62, "continuer"));
                        return paragraph;
                    }
                case 181:
                    {
                        paragraph = new StoryParagraph("Instinctivement, vous plongez en avant pour éviter le carreau de l'arbalète. Le brigand tire et vous sentez la manche de votre tunique se déchirer tandis que le projectile vous écorche le bras gauche. Vous remerciez les Dieux de vous avoir protégé et vous prenez vos jambes à votre cou. Les autres bandits n'ont pas d'arbalètes ni d'arcs et ils ont tôt fait d'abandonner la poursuite. Quelques instants plus tard, ils sont loin derrière vous et vous êtes sauf. Vous avez perdu votre Équipement, mais pas la vie. Vous faites une brève halte pour panser l'écorchure causée par le carreau d'arbalète puis vous vous remettez en route en direction de la capitale.", paragraphNumber);
                        paragraph.addMainEvent(new LooseBackPack());
                        paragraph.addDecision(new MoveEvent(288, "continuer"));
                        return paragraph;
                    }
                case 182:
                    {
                        paragraph = new StoryParagraph("Trois Gardes-Frontières de l'armée royale galopent le long de la rive, suivis de près par des Gloks chevauchant leurs terribles montures, des Loups Maudits. Votre science du Camouflage vous a cependant évité d'être vu et les Gloks diaboliques continuent leur poursuite sans même jeter un coup d'œil du côté de la rivière. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(174, "continuer"));
                        return paragraph;
                    }
                case 183:
                    {
                        paragraph = new StoryParagraph("L'officier ordonne à ses hommes de s'arrêter et vous demande ce que vous voulez. Vous lui expliquez qui vous êtes et vous lui faites le récit de la destruction du Monastère. Consterné par la nouvelle qu'il vient d'apprendre, il vous donne un cheval et vous demande de le suivre auprès du Prince Pellagayo, le fils du Roi.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(97, "accepter sa proposition"));
                        paragraph.addDecision(new MoveEvent(200, "refuser"));
                        return paragraph;
                    }
                case 184:
                    {
                        paragraph = new StoryParagraph("La roulotte a échappé à tout contrôle et cahote dangereusement sur le bas-côté de la route, parmi les pierres et les nids-de-poule. Vous parvenez cependant, au prix de bien des efforts, à ramener sur la chaussée les chevaux saisis de panique et à arrêter l'attelage. En fouillant rapidement le véhicule, vous découvrez 40 Pièces d'Or, une Epée et une quantité de nourriture équivalant à 4 Repas. Si vous pouvez conserver l'une ou l'autre de ces trouvailles. Les épreuves que vous avez subies vous ont épuisé, et il vous faut prendre un Repas. Vous plongerez ensuite dans un sommeil profond. ", paragraphNumber);
                        paragraph.addDecision(new LootEvent(new Gold(40), "Prendre l'or"));
                        paragraph.addDecision(new LootEvent(CreateLoot.CreateWeapon.sword(), "Prendre l'épée"));
                        paragraph.addDecision(new LootEvent(CreateLoot.CreateFood.ration(4), "Prendre les repas"));
                        paragraph.addDecision(new MoveEvent(64, "continuer"));

                        return paragraph;
                    }
                case 185:
                    {
                        paragraph = new StoryParagraph("Vous plissez les yeux et vous scrutez le feuillage des arbres pour voir s'il ne s'y cache pas un archer. Votre attente ne dure guère car, quelques instants plus tard, une douleur fulgurante vous déchire la poitrine et vous êtes projeté en arrière sous le choc de trois flèches qui vous transpercent le corps. Deux de ces flèches se sont enfoncées profondément dans votre thorax et la troisième s'est plantée dans votre cuisse. Avant de sombrer dans les ténèbres, vous contemplez dans une ultime vision le feuillage des arbres qui forme un dôme au-dessus de vous et une libellule qui vient se poser sur la boucle de votre ceinture. Votre mission s'achève ici", paragraphNumber);
                        paragraph.addDecision(new DeathEvent("continuer"));
                        return paragraph;
                    }
                case 186:
                    {
                        paragraph = new StoryParagraph("Les Kakarmis disparaissent bientôt dans l'épaisseur des sousbois et vous vous retrouvez seul, perdu de surcroît. Vous avez marché pendant près de deux heures lorsque vous entendez soudain le bruit d'une eau qui court. Vous décidez d'aller dans la direction d'où provient ce bruit.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(106, "continuer"));
                        return paragraph;
                    }
                case 187:
                    {
                        paragraph = new StoryParagraph("Deux têtes au pelage ras apparaissent derrière le tronc. Les deux créatures jettent un coup d'œil à votre arme et poussent un cri d'effroi. Elles bondissent alors loin du tronc et s'enfuient dans la forêt. ", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(186, "vous lancer à leur poursuite"));
                        paragraph.addDecision(new MoveEvent(228, "les laisser partir et continuer votre chemin"));
                        return paragraph;
                    }
                case 188:
                    {
                        paragraph = new StoryParagraph("L'ombre du Kraan grandit tout autour de vous et, soudain, le monstre vous frappe dans le dos en vous jetant à terre sous la force de son attaque. Ses serres s'accrochent à votre sac.", paragraphNumber);
                        int rand = DiceRoll.D10Roll0();
                        if(rand < 7)
                        {
                            paragraph.addMainEvent(new LooseBackPack());
                        }
                        else
                        {
                            paragraph.addMainEvent(new DammageEvent("","vous avez été blessé aux deux bras ", 3));
                        }
                        paragraph.addDecision(new MoveEvent(303, "continuer"));
                        return paragraph;
                    }
                case 189:
                    {
                        paragraph = new StoryParagraph("Grâce à votre entraînement de Seigneur Kaï et à la promptitude de vos réflexes, vous avez échappé à ce marécage qui aurait pu se révéler tout aussi meurtrier qu'un Kraan ou un Drakkarim. Vous êtes contrarié d'avoir perdu du temps et vous vous hâtez de poursuivre votre chemin parmi les arbres, en direction du sud. Un peu plus loin devant vous, un large chemin mène également vers le sud.", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(119, "continuer"));
                        return paragraph;
                    }
                case 190:
                    {
                        paragraph = new StoryParagraph("Vous parcourez cinq kilomètres le long de la rivière et vous découvrez alors une épave de péniche. Il semble que quelqu'un y ait élu domicile car vous apercevez, au travers d'un trou dans le pont, un lit et des ustensiles de cuisine", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(20, "fouiller cette péniche"));
                        paragraph.addDecision(new MoveEvent(273, "poursuivre votre chemin"));
                        return paragraph;
                    }
                case 191:
                    {
                        paragraph = new StoryParagraph("Le garde du corps dégaine un long cimeterre et s'apprête à vous attaquer. ", paragraphNumber);
                        paragraph.addMainEvent(new FightEvent(new Ennemy("Garde du corps",11,21,EnnemyTypes.Human)));
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 192:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 193:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 194:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 195:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 196:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 197:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 198:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                case 199:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
                default :
                    paragraph = new StoryParagraph("", paragraphNumber);
                    MoveEvent event1 = new MoveEvent(111, "Marcher");
                    paragraph.addDecision(event1);
                    return paragraph;
                case 6:
                    {
                        paragraph = new StoryParagraph("", paragraphNumber);
                        paragraph.addDecision(new MoveEvent(, ""));
                        return paragraph;
                    }
            }
        }
    }
}
