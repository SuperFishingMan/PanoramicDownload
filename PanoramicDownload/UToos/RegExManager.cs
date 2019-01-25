using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PanoramicDownload.UToos
{
    public class RegExManager
    {
        /// <summary>
        /// 正则判断720yun
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public  List<String> GetRegex(string txt)
        {

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "[a-z]";   // Uninteresting: w
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re5 = "(\\d)";   // Any Single Digit 1
            string re6 = ".*?"; // Non-greedy match on filler
            string re7 = "(\\d+)";  // Integer Number 1
            string re8 = ".*?"; // Non-greedy match on filler
            string re9 = "\\d+";    // Uninteresting: int
            string re10 = ".*?";    // Non-greedy match on filler
            string re11 = "(\\d+)"; // Integer Number 2
            string re12 = ".*?";    // Non-greedy match on filler
            string re13 = "(\\d+)"; // Integer Number 3
            List<string> keyStr = new List<string>();
            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String d1 = m.Groups[2].ToString();
                String int1 = m.Groups[3].ToString();
                String int2 = m.Groups[4].ToString();
                String int3 = m.Groups[5].ToString();

                keyStr.Add(w1 + d1);
                keyStr.Add(int1);
                keyStr.Add(int2);
                keyStr.Add(int3);
                return keyStr;
            }
            return null;
        }

        /// <summary>
        /// /获得url中的关键字符     b/l1/01/l1_b_01_01.jpg         720yun
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public  string MatchYun(string str)
        {
            string txt = str;
            string re1 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re2 = "(.)"; // Any Single Character 1
            string re3 = "([a-z])"; // Any Single Word Character (Not Whitespace) 2
            string re4 = "(\\d)";   // Any Single Digit 1
            string re5 = "(\\/)";   // Any Single Character 2
            string re6 = "(\\d+)";  // Integer Number 1
            string re7 = "(\\/)";   // Any Single Character 3
            string re8 = "([a-z])"; // Any Single Word Character (Not Whitespace) 3
            string re9 = "(\\d+)";  // Integer Number 2
            string re10 = "(.)";    // Any Single Character 4
            string re11 = "([a-z])";    // Any Single Word Character (Not Whitespace) 4
            string re12 = "(.)";    // Any Single Character 5
            string re13 = "(\\d+)"; // Integer Number 3
            string re14 = "(.)";    // Any Single Character 6
            string re15 = "(\\d+)"; // Integer Number 4
            string re16 = "(\\.)";  // Any Single Character 7
            string re17 = "((?:[a-z][a-z]+))";  // Word 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String w2 = m.Groups[3].ToString();
                String d1 = m.Groups[4].ToString();
                String c2 = m.Groups[5].ToString();
                String int1 = m.Groups[6].ToString();
                String c3 = m.Groups[7].ToString();
                String w3 = m.Groups[8].ToString();
                String int2 = m.Groups[9].ToString();
                String c4 = m.Groups[10].ToString();
                String w4 = m.Groups[11].ToString();
                String c5 = m.Groups[12].ToString();
                String int3 = m.Groups[13].ToString();
                String c6 = m.Groups[14].ToString();
                String int4 = m.Groups[15].ToString();
                String c7 = m.Groups[16].ToString();
                String word1 = m.Groups[17].ToString();
                //MessageBox.Show(w1.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + d1.ToString() + "" + "" + c2.ToString() + "" + "" + int1.ToString() + "" + "" + c3.ToString() + "" + "" + w3.ToString() + "" + "" + int2.ToString() + "" + "" + c4.ToString() + "" + "" + w4.ToString() + "" + "" + c5.ToString() + "" + "" + int3.ToString() + "" + "" + c6.ToString() + "" + "" + int4.ToString() + "" + "" + c7.ToString() + "" + "" + word1.ToString() + "" + "\n");
                return w1.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + d1.ToString() + "" + "" + c2.ToString() + "" + "" + int1.ToString() + "" + "" + c3.ToString() + "" + "" + w3.ToString() + "" + "" + int2.ToString() + "" + "" + c4.ToString() + "" + "" + w4.ToString() + "" + "" + c5.ToString() + "" + "" + int3.ToString() + "" + "" + c6.ToString() + "" + "" + int4.ToString() + "" + "" + c7.ToString() + "" + "" + word1.ToString() + "" + "\n";
            }
            return "";
        }

        /// <summary>
        /// 酷家乐
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public  string MatchKJL(string str)
        {           
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "\\d"; // Uninteresting: d
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "\\d"; // Uninteresting: d
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "\\d"; // Uninteresting: d
            string re7 = ".*?"; // Non-greedy match on filler
            string re8 = "(\\d)";   // Any Single Digit 1
            string re9 = "(\\d)";   // Any Single Digit 2
            string re10 = "(\\d)";  // Any Single Digit 3
            string re11 = "(\\d)";  // Any Single Digit 4
            string re12 = "(x)";    // Any Single Word Character (Not Whitespace) 1
            string re13 = "(\\d)";  // Any Single Digit 5
            string re14 = "(\\d)";  // Any Single Digit 6
            string re15 = "(\\d)";  // Any Single Digit 7
            string re16 = "(\\d)";  // Any Single Digit 8
            string re17 = "(\\.)";  // Any Single Character 1
            string re18 = "(j)";    // Any Single Word Character (Not Whitespace) 2
            string re19 = "(p)";    // Any Single Word Character (Not Whitespace) 3
            string re20 = "(g)";    // Any Single Word Character (Not Whitespace) 4
            string re21 = "(_)";    // Any Single Character 2
            string re22 = "([a-z])";    // Any Single Word Character (Not Whitespace) 5

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17 + re18 + re19 + re20 + re21 + re22, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(str);
            if (m.Success)
            {
                String d1 = m.Groups[1].ToString();
                String d2 = m.Groups[2].ToString();
                String d3 = m.Groups[3].ToString();
                String d4 = m.Groups[4].ToString();
                String w1 = m.Groups[5].ToString();
                String d5 = m.Groups[6].ToString();
                String d6 = m.Groups[7].ToString();
                String d7 = m.Groups[8].ToString();
                String d8 = m.Groups[9].ToString();
                String c1 = m.Groups[10].ToString();
                String w2 = m.Groups[11].ToString();
                String w3 = m.Groups[12].ToString();
                String w4 = m.Groups[13].ToString();
                String c2 = m.Groups[14].ToString();
                String w5 = m.Groups[15].ToString();
              
                return d1.ToString() + "" + "" + d2.ToString() + "" + "" + d3.ToString() + "" + "" + d4.ToString() + "" + "" + w1.ToString() + "" + "" + d5.ToString() + "" + "" + d6.ToString() + "" + "" + d7.ToString() + "" + "" + d8.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + w3.ToString() + "" + "" + w4.ToString() + "" + "" + c2.ToString() + "" + "" + w5.ToString() + "" + "";
            }
            return "";
        }

        /// <summary>
        /// 网展
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public  string MatchWZ(string str)
        {
            //string txt = "/u/n3/5/u_5_2.jpg";

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re3 = "(.)"; // Any Single Character 1
            string re4 = "([a-z])"; // Any Single Word Character (Not Whitespace) 2
            string re5 = "(\\d)";   // Any Single Digit 1
            string re6 = "(.)"; // Any Single Character 2
            string re7 = "(\\d)";   // Any Single Digit 2
            string re8 = "(.)"; // Any Single Character 3
            string re9 = "([a-z])"; // Any Single Word Character (Not Whitespace) 3
            string re10 = "(.)";    // Any Single Character 4
            string re11 = "(\\d)";  // Any Single Digit 3
            string re12 = "(.)";    // Any Single Character 5
            string re13 = "(\\d)";  // Any Single Digit 4
            string re14 = "(.)";    // Any Single Character 6
            string re15 = "((?:[a-z][a-z0-9_]*))";  // Variable Name 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(str);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String w2 = m.Groups[3].ToString();
                String d1 = m.Groups[4].ToString();
                String c2 = m.Groups[5].ToString();
                String d2 = m.Groups[6].ToString();
                String c3 = m.Groups[7].ToString();
                String w3 = m.Groups[8].ToString();
                String c4 = m.Groups[9].ToString();
                String d3 = m.Groups[10].ToString();
                String c5 = m.Groups[11].ToString();
                String d4 = m.Groups[12].ToString();
                String c6 = m.Groups[13].ToString();
                String var1 = m.Groups[14].ToString();
                return w1.ToString() + "" + c1.ToString() + "" + w2.ToString()  + "" + d1.ToString() + "" + c2.ToString()  + "" + d2.ToString() + "" + c3.ToString()  + "" + w3.ToString()  + "" + c4.ToString()  + "" + d3.ToString()  + "" + c5.ToString()  + "" + d4.ToString() + ""+ c6.ToString()  + "" + var1.ToString();
                //Console.Write("(" + w1.ToString() + ")" + "(" + c1.ToString() + ")" + "(" + w2.ToString() + ")" + "(" + d1.ToString() + ")" + "(" + c2.ToString() + ")" + "(" + d2.ToString() + ")" + "(" + c3.ToString() + ")" + "(" + w3.ToString() + ")" + "(" + c4.ToString() + ")" + "(" + d3.ToString() + ")" + "(" + c5.ToString() + ")" + "(" + d4.ToString() + ")" + "(" + c6.ToString() + ")" + "(" + var1.ToString() + ")" + "\n");
            }
            return "";
           // Console.ReadLine();
        }

        /// <summary>
        /// 网展
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public  List<string> GetRegexWZ(string txt)
        {
            //string txt = "u/n3/5/u_5_2.jpg";

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "[a-z]";   // Uninteresting: w
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re5 = "(\\d)";   // Any Single Digit 1
            string re6 = ".*?"; // Non-greedy match on filler
            string re7 = "(\\d+)";  // Integer Number 1
            string re8 = ".*?"; // Non-greedy match on filler
            string re9 = "(\\d+)";  // Integer Number 2
            string re10 = ".*?";    // Non-greedy match on filler
            string re11 = "(\\d+)"; // Integer Number 3
            List<string> keyStr = new List<string>();
            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String d1 = m.Groups[2].ToString();
                String int1 = m.Groups[3].ToString();
                String int2 = m.Groups[4].ToString();
                String int3 = m.Groups[5].ToString();
                keyStr.Add(w1+ d1);
                keyStr.Add(int1);
                keyStr.Add(int2);
                keyStr.Add(int3);
                return keyStr;
                //return w1.ToString()  + d1.ToString() + ""+ int1.ToString() + "" + int2.ToString() + "" + int3.ToString());
               // Console.Write("(" + w1.ToString() + ")" + "(" + d1.ToString() + ")" + "(" + int1.ToString() + ")" + "(" + int2.ToString() + ")" + "(" + int3.ToString() + ")" + "\n");
            }
            return keyStr;
        }


        /// <summary>
        /// E建网
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public  string MatchYJ(string str)
        {
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "(\\/)";   // Any Single Character 1
            string re3 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re4 = "(.)"; // Any Single Character 2
            string re5 = "([a-z])"; // Any Single Word Character (Not Whitespace) 2
            string re6 = "(\\d)";   // Any Single Digit 1
            string re7 = "(.)"; // Any Single Character 3
            string re8 = "([a-z])"; // Any Single Word Character (Not Whitespace) 3
            string re9 = "(.)"; // Any Single Character 4
            string re10 = "(\\d+)"; // Integer Number 1
            string re11 = "(.)";    // Any Single Character 5
            string re12 = "(\\d+)"; // Integer Number 2
            string re13 = "(.)";    // Any Single Character 6
            string re14 = "([a-z])";    // Any Single Word Character (Not Whitespace) 4
            string re15 = "([a-z])";    // Any Single Word Character (Not Whitespace) 5
            string re16 = "([a-z])";    // Any Single Word Character (Not Whitespace) 6

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(str);
            if (m.Success)
            {
                String c1 = m.Groups[1].ToString();
                String w1 = m.Groups[2].ToString();
                String c2 = m.Groups[3].ToString();
                String w2 = m.Groups[4].ToString();
                String d1 = m.Groups[5].ToString();
                String c3 = m.Groups[6].ToString();
                String w3 = m.Groups[7].ToString();
                String c4 = m.Groups[8].ToString();
                String int1 = m.Groups[9].ToString();
                String c5 = m.Groups[10].ToString();
                String int2 = m.Groups[11].ToString();
                String c6 = m.Groups[12].ToString();
                String w4 = m.Groups[13].ToString();
                String w5 = m.Groups[14].ToString();
                String w6 = m.Groups[15].ToString();
                return c1 + w1 + c2 + w2 + d1 + c3 + w3 + c4 + int1 + c5 + int2 + c6 + w4 + w5 + w6;
            }
            return "";
        }

        /// <summary>
        /// E建网
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public  List<string> GetRegexYJ(string txt)
        {
            //string txt = "u/l2_u_1_2.jpg";

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "[a-z]";   // Uninteresting: w
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re5 = "(\\d+)";  // Integer Number 1
            string re6 = ".*?"; // Non-greedy match on filler
            string re7 = "(\\d+)";  // Integer Number 2
            string re8 = ".*?"; // Non-greedy match on filler
            string re9 = "(\\d+)";  // Integer Number 3
            List<string> keyStr = new List<string>();
            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String int1 = m.Groups[2].ToString();
                String int2 = m.Groups[3].ToString();
                String int3 = m.Groups[4].ToString();
                keyStr.Add(w1 + int1);
                keyStr.Add(int2);
                keyStr.Add(int3);
                return keyStr;
                //Console.Write("(" + w1.ToString() + ")" + "(" + int1.ToString() + ")" + "(" + int2.ToString() + ")" + "(" + int3.ToString() + ")" + "\n");
            }
            return keyStr;
        }
    }
}
