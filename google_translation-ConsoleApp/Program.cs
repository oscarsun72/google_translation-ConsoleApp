using System;
using System.Collections.Generic;
using System.Linq;
using STRExp = System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Clipboard;
using SD = System.Diagnostics;
using static System.Environment;
using C_sharp_MSEdge_Chromium_Browser_automating;

namespace google_translation_ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string word = GetText();
            if (String.IsNullOrWhiteSpace(word)) return;
            STRExp::Regex reg = new STRExp.Regex("[0-9]");
            if (reg.IsMatch(word)) return;
            string[] address = new string[2];
            if (word.Length > 30)
            {//所查者太長，則翻譯之
                address[0] = @"https://translate.google.com/?source=gtx#auto/zh-TW/";
                address[1] = @"https://www.deepl.com/translator#en/zh/";
            }
            else
            {
                address = new string[4];
                address[2] = @"https://translate.google.com/?source=gtx#auto/zh-TW/";
                address[0] = @"https://www.deepl.com/translator#en/zh/";
                address[1] = @"https://zh.forvo.com/search/";
                address[3] = @"https://dictionary.cambridge.org/zht/%E8%A9%9E%E5%85%B8/%E8%8B%B1%E8%AA%9E-%E6%BC%A2%E8%AA%9E-%E7%B9%81%E9%AB%94/";
            }
            //判斷是否有換行 http://bit.ly/2uu2Y6V  http://bit.ly/2twgwue
            if (word.IndexOf(NewLine) > -1) word = word.Replace(NewLine, " ").Replace("  ", " ").Replace(@"/", "");
            while (word.IndexOf("  ") > -1) word = word.Replace("  ", " ");
            foreach (var item in address)
            {
                //SD::Process.Start(item + word.Trim());
                BrowserChrome.OpenLinkChrome(item + word.Trim());
            }
            //SD::Process.Start(address+ word.Trim());


        }
    }
}
