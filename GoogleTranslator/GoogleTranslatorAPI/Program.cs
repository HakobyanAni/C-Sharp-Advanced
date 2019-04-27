using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System;

namespace GoogleTranslatorAPI
{
    // This little project is an example how to deal with Google Translator API

    public class TranslateSapmle
    {
        public string TranslateText(string wordToTranslate, string targetLang, string sourceLang)
        {
            var credential = GoogleCredential.FromJson(System.IO.File.ReadAllText(@"D:\Annie\Programming\GoogleTranslator\GoogleTranslatorAPI\Google\GT_credentials.json"));
            TranslationClient client = TranslationClient.Create(credential);
            var response = client.TranslateText(
                text: $"{wordToTranslate}",
                targetLanguage: "arm",  // Armenian
                sourceLanguage: "en");  // English
            return response.TranslatedText;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TranslateSapmle tr = new TranslateSapmle();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to google translator.");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Choose and write the target language code. For example: ru, arm, en and etc.. ");
            string targetLang = Console.ReadLine();

            Console.WriteLine("And now choose and write the source language code. For example: ru, arm, en and etc.. ");
            string sourceLang = Console.ReadLine();

            Console.WriteLine("Write the word or the sentence you want to translate: ");
            string wordToTranslate = Console.ReadLine();

            string translatedWord = tr.TranslateText(wordToTranslate, targetLang, sourceLang);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n Translation");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{wordToTranslate} - {translatedWord}");

            Console.ReadKey();
        }
    }
}
