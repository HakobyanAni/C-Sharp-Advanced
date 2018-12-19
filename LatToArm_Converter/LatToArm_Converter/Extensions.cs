using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProf1
{
    public static class Extensions
    {
        public static string LatToArm(this string englisText)
        {
            string armenianText = "";
            string alph = "qwertyuiopasdfghjklzxcvbnm@&QWERTYUIOPASDFGHJKLZXCVBNM";

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a", "ա");
            dictionary.Add("b", "բ");
            dictionary.Add("c", "ց");
            dictionary.Add("d", "դ");
            dictionary.Add("e", "ե");
            dictionary.Add("f", "ֆ");
            dictionary.Add("g", "գ");
            dictionary.Add("h", "հ");
            dictionary.Add("i", "ի");
            dictionary.Add("j", "ժ");
            dictionary.Add("k", "կ");
            dictionary.Add("l", "լ");
            dictionary.Add("m", "մ");
            dictionary.Add("n", "ն");
            dictionary.Add("o", "ո");
            dictionary.Add("p", "պ");
            dictionary.Add("q", "ք");
            dictionary.Add("r", "ր");
            dictionary.Add("s", "ս");
            dictionary.Add("t", "տ");
            dictionary.Add("u", "ու");
            dictionary.Add("v", "վ");
            dictionary.Add("x", "խ");
            dictionary.Add("y", "յ");
            dictionary.Add("z", "զ");
            dictionary.Add(" ", " ");
            dictionary.Add(".", ":");
            dictionary.Add("?", "?");
            dictionary.Add("@", "ը");
            dictionary.Add("A", "Ա");
            dictionary.Add("B", "Բ");
            dictionary.Add("C", "Ց");
            dictionary.Add("D", "Դ");
            dictionary.Add("E", "Ե");
            dictionary.Add("F", "Ֆ");
            dictionary.Add("G", "Գ");
            dictionary.Add("H", "Հ");
            dictionary.Add("I", "Ի");
            dictionary.Add("J", "Ժ");
            dictionary.Add("K", "Կ");
            dictionary.Add("L", "Լ");
            dictionary.Add("M", "Մ");
            dictionary.Add("N", "Ն");
            dictionary.Add("O", "Ո");
            dictionary.Add("P", "Պ");
            dictionary.Add("Q", "Ք");
            dictionary.Add("R", "Ր");
            dictionary.Add("S", "Ս");
            dictionary.Add("T", "Տ");
            dictionary.Add("U", "Ու");
            dictionary.Add("V", "Վ");
            dictionary.Add("X", "Խ");
            dictionary.Add("Y", "Յ");
            dictionary.Add("Z", "Զ");

            for (int i = 0; i < englisText.Length; i++)
            {
                if (i != englisText.Length - 1)
                {
                    switch (englisText.Substring(i, 2))
                    {
                        case "ev":
                            armenianText += "և";
                            ++i;
                            break;
                        case "sh":
                            armenianText += "շ";
                            ++i;
                            break;
                        case "ch":
                            armenianText += "չ";
                            ++i;
                            break;
                        case "kh":
                            armenianText += "խ";
                            ++i;
                            break;
                        case "dj":
                            armenianText += "ջ";
                            ++i;
                            break;
                        case "ts":
                            armenianText += "ծ";
                            ++i;
                            break;
                        case "dz":
                            armenianText += "ձ";
                            ++i;
                            break;
                        case "gh":
                            armenianText += "ղ";
                            ++i;
                            break;
                        default:
                            if (englisText.Substring(i, 2) == "vo" && i == 0)
                            {
                                armenianText += "ո";
                                i++;
                                break;
                            }
                            if (englisText.Substring(i, 2) == "vo" && i != 0 && (englisText[i - 1].ToString() == "\n" || englisText[i - 1].ToString() == " "))
                            {
                                armenianText += "ո";
                                i++;
                                break;
                            }
                            if (englisText.Substring(i, 1) == "o" && i == 0)
                            {
                                armenianText += "օ";
                                break;
                            }
                            if (englisText.Substring(i, 1) == "o" && i != 0 && (englisText[i - 1].ToString() == "\n" || englisText[i - 1].ToString() == " "))
                            {
                                armenianText += "օ";
                                break;
                            }

                            if (englisText.Substring(i, 1) == "e" && i != 0 && (englisText[i - 1].ToString() == " " && englisText[i + 1].ToString() == " "))
                            {
                                armenianText += "Է";
                                break;
                            }
                            if (alph.Contains(englisText[i]))
                            {
                                armenianText += dictionary[englisText[i].ToString()];
                            }
                            else
                            {
                                armenianText += englisText[i].ToString();
                            }
                            break;
                    }
                }
                else
                {
                    if (alph.Contains(englisText[i]))
                    {
                        armenianText += dictionary[englisText[i].ToString()];
                    }
                    else
                    {
                        armenianText += englisText[i].ToString();
                    }
                }
            }
            return armenianText;
        }


    }
}
