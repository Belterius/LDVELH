using System;
using System.Windows;
using System.Resources;
using HtmlAgilityPack;
namespace LDVELH_WPF
{
    /*********************************************************************************************************\
   
        This class is only here to do most of the work from generating the resource string file of the Lone Wolf Books from a corresponding PDF or text file.
        It should NOT be used randomly.

        As it will replace the resource file, make sur to back it up before trying anything.

    /*********************************************************************************************************/
    public partial class HackResx : Window
    {
        private string frenchBook1 = @"C:\Users\lbailleul\Source\Repos\LDVELH\LDVELH_WPF\Resources\StringBook1.resx";
        private string englishBook1 = @"C:\Users\lbailleul\Source\Repos\LDVELH\LDVELH_WPF\Resources\StringBook1.en.resx";
        private string projectAOEBook1 = @"C:\Users\lbailleul\Desktop\t1\en\xhtml-simple\lw\01fftd.htm";

        public HackResx()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(frenchBook1))
            {
                for (int k = 0; k <= 49; k++)
                {

                    for (int paragraph = 1; paragraph <= 350; paragraph++)
                    {
                        StoryParagraph newParag = CreateParagraphTranslated.CreateAParagraph(paragraph);

                        resx.AddResource("Paragraph" + paragraph, newParag.ContentText);
                        int j = 0;
                        foreach (Event Decision in newParag.GetListDecision)
                        {
                            if ((Decision is MoveEvent || Decision is CapacityEvent || Decision is RunEvent || Decision is MealEvent || Decision is ItemRequieredEvent || Decision is LinkedEvent || Decision is LoseBackPack || Decision is LoseWeaponHolder) && Decision.DestinationNumber.ToString() != null)
                            {
                                resx.AddResource("Paragraph" + paragraph + "To" + Decision.DestinationNumber.ToString(), Decision.TriggerMessage);

                            }
                            else
                            {
                                j++;
                                resx.AddResource("Paragraph" + paragraph + Decision.GetType().Name + j, Decision.TriggerMessage);
                            }
                        }

                    }
                }
                
                System.Diagnostics.Debug.WriteLine("done");
            }

                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int paragraph = 1; paragraph <= 350; paragraph++)
                {
                    StoryParagraph newParag = CreateParagraph.CreateAParagraph(paragraph);
                }
            }
            System.Diagnostics.Debug.WriteLine("Finished");
                
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*
             * WARNING REMEMBER TO MANUALLY ADD THE STRINGS FROM SAVEOFMANUALENGLISH.RESX TO STRINGBOOK1.EN.RESX
             * ELSE IT WILL TAKE THE FRENCH PART !
             */
            string filePath = projectAOEBook1;
            string resxPath = englishBook1;
            HtmlDocument doc = getHTMLDoc(filePath);
            HtmlNodeCollection paragraphs = getAllParagraphTitleNode(doc);
            GenerateResxFile(resxPath, paragraphs);
            
        }


        private HtmlNodeCollection getAllParagraphTitleNode(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//h3[a[starts-with(@name, 'sect')]]");
        }
        private HtmlDocument getHTMLDoc(String filePath)
        {
            HtmlWeb web = new HtmlWeb();
            return web.Load(filePath);
        }
        private HtmlNodeCollection getParagraphContentByIndex(int index, HtmlNodeCollection paragraphsNode)
        {
            var isLast = (index == paragraphsNode.Count - 1);
            var xpath = ".//following-sibling::p";
            if (!isLast)
                xpath += string.Format("[following-sibling::h3[1][a/@name = '{0}']]", paragraphsNode[index + 1].SelectSingleNode("./a").Attributes["name"].Value);
            return paragraphsNode[index].SelectNodes(xpath);
        }
        private bool isMainContent(HtmlNode smallParagraph)
        {
            if (!smallParagraph.InnerHtml.Contains("<a href="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isDecision(HtmlNode smallParagraph)
        {
            if (smallParagraph.Attributes["Class"] != null && smallParagraph.Attributes["Class"].Value == "choice")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string getAncre(String innerHTML)
        {
            int startAncre = innerHTML.IndexOf("<a href=", StringComparison.Ordinal);
            int endAncre = innerHTML.IndexOf("</a>", StringComparison.Ordinal) + 4;
            return innerHTML.Substring(startAncre, endAncre - startAncre);
        }
        private string getAncreContent(string ancre)
        {
            int startContent = ancre.IndexOf("\">", StringComparison.Ordinal) + 2;
            int endContent = ancre.IndexOf("</a>", StringComparison.Ordinal);
            return ancre.Substring(startContent, endContent - startContent);
        }
        private string getNumberDestinationFromAncreContent(string ancreContent)
        {
            string numberDestination = ancreContent.ToLower().Replace("turn to", "").Trim();
            numberDestination = numberDestination.Replace("turning to", "").Trim();
            numberDestination = numberDestination.Replace("go to", "").Trim();
            return numberDestination;
        }
        private string GetParagraphDestination(string innerHtml)
        {
            string ancreContent = getAncreContent(getAncre(innerHtml));
            string destinationNumber = getNumberDestinationFromAncreContent(ancreContent);
            return destinationNumber;
        }
        private static string DeleteAncre(string innerHtml)
        {
            int startAncre = innerHtml.IndexOf("<a href=", StringComparison.Ordinal);
            int endAncre = innerHtml.IndexOf("</a>", StringComparison.Ordinal) + 4;
            return innerHtml.Remove(startAncre, endAncre - startAncre);
        }
        private static string CleanDecision(string decisionContent)
        {
            string decision = decisionContent;
            if (decision.Contains("If you have picked a number"))
            {
                decision = "Try your luck";
            }
            else
            {
                decision = decision.Replace("If you wish to", "").Trim();
                decision = decision.Replace("If you would rather", "").Trim();
                decision = decision.Replace(", .", ".").Trim();
                decision = decision.Replace("by .", ".").Trim();
                decision = decision.Replace("by ?", ".").Trim();
                decision = decision.Trim();
                if (decision.ToLower().StartsWith("if you win the"))
                {
                    decision = "continue";
                }
                if (decision.ToLower().StartsWith("if you"))
                {
                    decision = decision.ToLower().Replace("if you", "").Trim();
                }
                if (decision.ToLower().StartsWith("or if you would rather"))
                {
                    decision = decision.ToLower().Replace("or if you would rather", "").Trim();
                }
                if (decision.ToLower().StartsWith("or if you wish to"))
                {
                    decision = decision.ToLower().Replace("or if you wish to", "").Trim();
                }
                if (decision.ToLower().StartsWith("would prefer to"))
                {
                    decision = decision.ToLower().Replace("would prefer to", "").Trim();
                }
                if (decision.ToLower().StartsWith("decide to"))
                {
                    decision = decision.ToLower().Replace("decide to", "").Trim();
                }
                if (decision.ToLower().StartsWith("you may"))
                {
                    decision = decision.ToLower().Replace("you may", "").Trim();
                }
                if (decision.ToLower().StartsWith("or you may"))
                {
                    decision = decision.ToLower().Replace("or you may", "").Trim();
                }
                if (decision.ToLower().StartsWith("if the number"))
                {
                    decision = "Try your luck";
                }
                if (decision == ".")
                {
                    decision = "continue";
                }
            }
            return decision;
        }
        private string getDecisionContent(String innerHTML)
        {
            string myContent = DeleteAncre(innerHTML);
            return CleanDecision(myContent);

        }
        private string GenerateResxName(HtmlNode paragraph, int index)
        {

            string myDestination = GetParagraphDestination(paragraph.InnerHtml);
            string myDecisionContent = getDecisionContent(paragraph.InnerHtml);
            return "Paragraph" + (index + 1) + "To" + myDestination;
        }
        private string GenerateResxValue(HtmlNode paragraph)
        {
            return getDecisionContent(paragraph.InnerHtml);
        }
        private void GenerateResxFromParagraph(ResXResourceWriter resx, HtmlNodeCollection paragraphContent, int index)
        {
            string myMainContent = "";

            foreach (HtmlNode smallParagraph in paragraphContent)
            {
                if (isMainContent(smallParagraph))
                {
                    myMainContent += smallParagraph.InnerHtml + "\n";
                    //System.Diagnostics.Debug.WriteLine("This is the main text :" + par.InnerText);
                }
                else
                {
                    if (isDecision(smallParagraph))
                    {
                        string resxName = GenerateResxName(smallParagraph, index);
                        string resxValue = GenerateResxValue(smallParagraph);

                        resx.AddResource(resxName, resxValue);
                    }
                }
            }
            resx.AddResource("Paragraph" + (index + 1), myMainContent);
        }
        private void GenerateResxFile(string resxPath, HtmlNodeCollection paragraphsNode)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(resxPath))
            {
                for (var index = 0; index < paragraphsNode.Count; index++)
                {
                    HtmlNodeCollection paragraphContent = getParagraphContentByIndex(index, paragraphsNode);
                    GenerateResxFromParagraph(resx, paragraphContent, index);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MenuLoad mnLoad = new MenuLoad();
            mnLoad.Show();
        }
    }
}
