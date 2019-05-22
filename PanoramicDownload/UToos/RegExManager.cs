using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PanoramicDownload.UToos
{
    /// <summary>
    /// 正则判断
    /// </summary>
    public class RegExManager
    {
        /// <summary>
        /// 正则判断720yun
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public List<String> GetRegex(string txt)
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
        public string MatchYun(string str)
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
                string w1 = m.Groups[1].ToString();
                string c1 = m.Groups[2].ToString();
                string w2 = m.Groups[3].ToString();
                string d1 = m.Groups[4].ToString();
                string c2 = m.Groups[5].ToString();
                string int1 = m.Groups[6].ToString();
                string c3 = m.Groups[7].ToString();
                string w3 = m.Groups[8].ToString();
                string int2 = m.Groups[9].ToString();
                string c4 = m.Groups[10].ToString();
                string w4 = m.Groups[11].ToString();
                string c5 = m.Groups[12].ToString();
                string int3 = m.Groups[13].ToString();
                string c6 = m.Groups[14].ToString();
                string int4 = m.Groups[15].ToString();
                string c7 = m.Groups[16].ToString();
                string word1 = m.Groups[17].ToString();
                //MessageBox.Show(w1.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + d1.ToString() + "" + "" + c2.ToString() + "" + "" + int1.ToString() + "" + "" + c3.ToString() + "" + "" + w3.ToString() + "" + "" + int2.ToString() + "" + "" + c4.ToString() + "" + "" + w4.ToString() + "" + "" + c5.ToString() + "" + "" + int3.ToString() + "" + "" + c6.ToString() + "" + "" + int4.ToString() + "" + "" + c7.ToString() + "" + "" + word1.ToString() + "" + "\n");
                return w1 + c1 + w2 + d1 + c2 + int1 + c3 + w3 + int2 + c4 + w4 + c5 + int3 + c6 + int4 + c7 + word1 + "\n";
            }
            return "";
        }

        /// <summary>
        /// 酷家乐
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string MatchKJL(string str)
        {
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "(kujiale)";   // Word 1
            string re3 = "(.)"; // Any Single Character 1
            string re4 = "((?:[a-z][a-z]+))";   // Word 2
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "(\\.)";   // Any Single Character 2
            string re7 = "(jpg)";   // Word 3
            string re8 = "(_)"; // Any Single Character 3
            string re9 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re10 = "(@)";    // Any Single Character 4

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(str);
            if (m.Success)
            {
                string word1 = m.Groups[1].ToString();
                string c1 = m.Groups[2].ToString();
                string word2 = m.Groups[3].ToString();
                string c2 = m.Groups[4].ToString();
                string word3 = m.Groups[5].ToString();
                string c3 = m.Groups[6].ToString();
                string w1 = m.Groups[7].ToString();
                string c4 = m.Groups[8].ToString();
                return word1 + c1 + word2 + c2 + word3 + c3 + w1 + c4;
            }
            return "";
        }

        /// <summary>
        /// 网展
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string MatchWZ(string str)
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
                string w1 = m.Groups[1].ToString();
                string c1 = m.Groups[2].ToString();
                string w2 = m.Groups[3].ToString();
                string d1 = m.Groups[4].ToString();
                string c2 = m.Groups[5].ToString();
                string d2 = m.Groups[6].ToString();
                string c3 = m.Groups[7].ToString();
                string w3 = m.Groups[8].ToString();
                string c4 = m.Groups[9].ToString();
                string d3 = m.Groups[10].ToString();
                string c5 = m.Groups[11].ToString();
                string d4 = m.Groups[12].ToString();
                string c6 = m.Groups[13].ToString();
                string var1 = m.Groups[14].ToString();
                return w1 + c1 + w2 + d1 + c2 + d2 + c3 + w3 + c4 + d3 + c5 + d4 + c6 + var1;
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
        public List<string> GetRegexWZ(string txt)
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
                string w1 = m.Groups[1].ToString();
                string d1 = m.Groups[2].ToString();
                string int1 = m.Groups[3].ToString();
                string int2 = m.Groups[4].ToString();
                string int3 = m.Groups[5].ToString();
                keyStr.Add(w1 + d1);
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
        public string MatchYJ(string str)
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
                string c1 = m.Groups[1].ToString();
                string w1 = m.Groups[2].ToString();
                string c2 = m.Groups[3].ToString();
                string w2 = m.Groups[4].ToString();
                string d1 = m.Groups[5].ToString();
                string c3 = m.Groups[6].ToString();
                string w3 = m.Groups[7].ToString();
                string c4 = m.Groups[8].ToString();
                string int1 = m.Groups[9].ToString();
                string c5 = m.Groups[10].ToString();
                string int2 = m.Groups[11].ToString();
                string c6 = m.Groups[12].ToString();
                string w4 = m.Groups[13].ToString();
                string w5 = m.Groups[14].ToString();
                string w6 = m.Groups[15].ToString();
                return c1 + w1 + c2 + w2 + d1 + c3 + w3 + c4 + int1 + c5 + int2 + c6 + w4 + w5 + w6;
            }
            return "";
        }

        /// <summary>
        /// E建网
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public List<string> GetRegexYJ(string txt)
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
                string w1 = m.Groups[1].ToString();
                string int1 = m.Groups[2].ToString();
                string int2 = m.Groups[3].ToString();
                string int3 = m.Groups[4].ToString();
                keyStr.Add(w1 + int1);
                keyStr.Add(int2);
                keyStr.Add(int3);
                return keyStr;
                //Console.Write("(" + w1.ToString() + ")" + "(" + int1.ToString() + ")" + "(" + int2.ToString() + ")" + "(" + int3.ToString() + ")" + "\n");
            }
            return keyStr;
        }

        /// <summary>
        /// 鱼模网 
        /// </summary>
        public string MatchYMW(string txt)
        {
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "\\/"; // Uninteresting: c
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "\\/"; // Uninteresting: c
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "\\/"; // Uninteresting: c
            string re7 = ".*?"; // Non-greedy match on filler
            string re8 = "\\/"; // Uninteresting: c
            string re9 = ".*?"; // Non-greedy match on filler
            string re10 = "\\/";    // Uninteresting: c
            string re11 = ".*?";    // Non-greedy match on filler
            string re12 = "(\\/)";  // Any Single Character 1
            string re13 = "((?:[a-z][a-z]+))";  // Word 1
            string re14 = "(_)";    // Any Single Character 2
            string re15 = "(.)";    // Any Single Character 3
            string re16 = "(.)";    // Any Single Character 4
            string re17 = "(.)";    // Any Single Character 5
            string re18 = "(.)";    // Any Single Character 6
            string re19 = "(.)";    // Any Single Character 7

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17 + re18 + re19, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string c1 = m.Groups[1].ToString();
                string word1 = m.Groups[2].ToString();
                string c2 = m.Groups[3].ToString();
                string c3 = m.Groups[4].ToString();
                string c4 = m.Groups[5].ToString();
                string c5 = m.Groups[6].ToString();
                string c6 = m.Groups[7].ToString();
                string c7 = m.Groups[8].ToString();
                return c1 + word1 + c2 + c3 + c4 + c5 + c6 + c7;
                // Console.Write("(" + c1.ToString() + ")" + "(" + word1.ToString() + ")" + "(" + c2.ToString() + ")" + "(" + c3.ToString() + ")" + "(" + c4.ToString() + ")" + "(" + c5.ToString() + ")" + "(" + c6.ToString() + ")" + "(" + c7.ToString() + ")" + "\n");
            }
            return "";
        }

        /// <summary>
        /// 全景客
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string MatchQJK(string txt)
        {
            // txt = "http://www.quanjingke.com/attachment/2015/08/07578600.tiles/l2_f_01_02.jpg";

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "\\/"; // Uninteresting: c
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "\\/"; // Uninteresting: c
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "\\/"; // Uninteresting: c
            string re7 = ".*?"; // Non-greedy match on filler
            string re8 = "\\/"; // Uninteresting: c
            string re9 = ".*?"; // Non-greedy match on filler
            string re10 = "\\/";    // Uninteresting: c
            string re11 = ".*?";    // Non-greedy match on filler
            string re12 = "\\/";    // Uninteresting: c
            string re13 = ".*?";    // Non-greedy match on filler
            string re14 = "(\\/)";  // Any Single Character 1
            string re15 = "([a-z])";    // Any Single Word Character (Not Whitespace) 1
            string re16 = "(\\d+)"; // Integer Number 1
            string re17 = "(.)";    // Any Single Character 2
            string re18 = "([a-z])";    // Any Single Word Character (Not Whitespace) 2
            string re19 = "(.)";    // Any Single Character 3
            string re20 = "(\\d+)"; // Integer Number 2
            string re21 = "(.)";    // Any Single Character 4
            string re22 = "(\\d+)"; // Integer Number 3
            string re23 = "(\\.)";  // Any Single Character 5
            string re24 = "((?:[a-z][a-z]+))";  // Word 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17 + re18 + re19 + re20 + re21 + re22 + re23 + re24, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string c1 = m.Groups[1].ToString();
                string w1 = m.Groups[2].ToString();
                string int1 = m.Groups[3].ToString();
                string c2 = m.Groups[4].ToString();
                string w2 = m.Groups[5].ToString();
                string c3 = m.Groups[6].ToString();
                string int2 = m.Groups[7].ToString();
                string c4 = m.Groups[8].ToString();
                string int3 = m.Groups[9].ToString();
                string c5 = m.Groups[10].ToString();
                string word1 = m.Groups[11].ToString();
                return c1 + w1 + int1 + c2 + w2 + c3 + int2 + c4 + int3 + c5 + word1;
                // Console.Write("(" + c1.ToString() + ")" + "(" + w1.ToString() + ")" + "(" + int1.ToString() + ")" + "(" + c2.ToString() + ")" + "(" + w2.ToString() + ")" + "(" + c3.ToString() + ")" + "(" + int2.ToString() + ")" + "(" + c4.ToString() + ")" + "(" + int3.ToString() + ")" + "(" + c5.ToString() + ")" + "(" + word1.ToString() + ")" + "\n");
            }
            return "";
        }

        public List<string> GetRegexQJK(string txt)
        {
            //string txt = "l3_f_02_01.jpg";
            List<string> liststr = new List<string>();
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "(\\d+)";  // Integer Number 1
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "(\\d+)";  // Integer Number 2
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "(\\d+)";  // Integer Number 3

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string int1 = m.Groups[1].ToString();
                string int2 = m.Groups[2].ToString();
                string int3 = m.Groups[3].ToString();
                liststr.Add(int1);
                liststr.Add(int2);
                liststr.Add(int3);
                return liststr;
            }
            return liststr;
        }

        /// <summary>
        /// 视维
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string MatchSW(string txt)
        {
            //string txt = "01/l2_b_1_1.jpg";

            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "(\\/)";   // Any Single Character 1
            string re3 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re4 = "(\\d+)";  // Integer Number 1
            string re5 = "(_)"; // Any Single Character 2
            string re6 = "([a-z])"; // Any Single Word Character (Not Whitespace) 2
            string re7 = "(.)"; // Any Single Character 3
            string re8 = "(\\d+)";  // Integer Number 2
            string re9 = "(.)"; // Any Single Character 4
            string re10 = "(\\d+)"; // Integer Number 3
            string re11 = "(.)";    // Any Single Character 5
            string re12 = "((?:[a-z][a-z]+))";  // Word 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string c1 = m.Groups[1].ToString();
                string w1 = m.Groups[2].ToString();
                string int1 = m.Groups[3].ToString();
                string c2 = m.Groups[4].ToString();
                string w2 = m.Groups[5].ToString();
                string c3 = m.Groups[6].ToString();
                string int2 = m.Groups[7].ToString();
                string c4 = m.Groups[8].ToString();
                string int3 = m.Groups[9].ToString();
                string c5 = m.Groups[10].ToString();
                string word1 = m.Groups[11].ToString();
                return c1 + w1 + int1 + c2 + w2 + c3 + int2 + c4 + int3 + c5 + word1;
            }
            return "";
        }

        public List<string> GetRegexSW(string txt)
        {
            //string txt = "l2_b_1_1.jpg";
            List<string> liststr = new List<string>();
            string re1 = "(l)"; // Any Single Word Character (Not Whitespace) 1
            string re2 = "(\\d+)";  // Integer Number 1
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = "_";   // Uninteresting: c
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = "(_)"; // Any Single Character 1
            string re7 = "(\\d+)";  // Integer Number 2
            string re8 = "(_)"; // Any Single Character 2
            string re9 = "(\\d+)";  // Integer Number 3

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string w1 = m.Groups[1].ToString();
                string int1 = m.Groups[2].ToString();
                liststr.Add(w1 + int1);
                string c1 = m.Groups[3].ToString();
                string int2 = m.Groups[4].ToString();
                liststr.Add(c1 + int2);
                string c2 = m.Groups[5].ToString();
                string int3 = m.Groups[6].ToString();
                liststr.Add(c2 + int3);
                return liststr;
            }
            return null;
        }

        /// <summary>
        /// 六面图
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string MatchLMT(string txt)
        {
            //string txt = "c5/pano_l.jpg";
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = ".";   // Uninteresting: c
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = ".";   // Uninteresting: c
            string re5 = "(.)"; // Any Single Character 1
            string re6 = "(pano)";  // Word 1
            string re7 = "(.)"; // Any Single Character 2
            string re8 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re9 = "(.)"; // Any Single Character 3
            string re10 = "(jpg)";  // Variable Name 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String c1 = m.Groups[1].ToString();
                String word1 = m.Groups[2].ToString();
                String c2 = m.Groups[3].ToString();
                String w1 = m.Groups[4].ToString();
                String c3 = m.Groups[5].ToString();
                String var1 = m.Groups[6].ToString();
                return c1 + word1 + c2 + w1 + c3 + var1;
            }
            return "";
        }

        public string MatchQJK_1(string txt)
        {
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = ".";   // Uninteresting: c
            string re3 = ".*?"; // Non-greedy match on filler
            string re4 = ".";   // Uninteresting: c
            string re5 = ".*?"; // Non-greedy match on filler
            string re6 = ".";   // Uninteresting: c
            string re7 = ".*?"; // Non-greedy match on filler
            string re8 = ".";   // Uninteresting: c
            string re9 = ".*?"; // Non-greedy match on filler
            string re10 = ".";  // Uninteresting: c
            string re11 = "(.)";    // Any Single Character 1
            string re12 = "([a-z])";    // Any Single Word Character (Not Whitespace) 1
            string re13 = "(\\d+)"; // Integer Number 1
            string re14 = "(.)";    // Any Single Character 2
            string re15 = "([a-z])";    // Any Single Word Character (Not Whitespace) 2
            string re16 = "(.)";    // Any Single Character 3
            string re17 = "(\\d+)"; // Integer Number 2
            string re18 = "(.)";    // Any Single Character 4
            string re19 = "((?:[a-z][a-z]+))";  // Word 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17 + re18 + re19, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                string c1 = m.Groups[1].ToString();
                string w1 = m.Groups[2].ToString();
                string int1 = m.Groups[3].ToString();
                string c2 = m.Groups[4].ToString();
                string w2 = m.Groups[5].ToString();
                string c3 = m.Groups[6].ToString();
                string int2 = m.Groups[7].ToString();
                string c4 = m.Groups[8].ToString();
                string word1 = m.Groups[9].ToString();
                return c1 + w1 + int1+ c2+ w2 + c3 + int2 + c4 + word1;
            }
            return "";
        }

        public List<string> GetRegexQJL_1(string txt)
        {
            List<string> liststr = new List<string>();
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re3 = "(\\d+)";  // Integer Number 1
            string re4 = ".*?"; // Non-greedy match on filler
            string re5 = ".";   // Uninteresting: c
            string re6 = ".*?"; // Non-greedy match on filler
            string re7 = ".";   // Uninteresting: c
            string re8 = ".*?"; // Non-greedy match on filler
            string re9 = "(.)"; // Any Single Character 1
            string re10 = "(\\d)";  // Any Single Digit 1
            string re11 = "(\\d)";  // Any Single Digit 2
            string re12 = "(\\d)";  // Any Single Digit 3
            string re13 = "(\\d)";  // Any Single Digit 4
            string re14 = "(.)";    // Any Single Character 2

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String int1 = m.Groups[2].ToString();
                String c1 = m.Groups[3].ToString();
                String d1 = m.Groups[4].ToString();
                String d2 = m.Groups[5].ToString();
                String d3 = m.Groups[6].ToString();
                String d4 = m.Groups[7].ToString();
                String c2 = m.Groups[8].ToString();
                liststr.Add(w1 + int1);
                liststr.Add(c1 + d1+ d2);
                liststr.Add(d3 + d4 + c2);
                return liststr;
            }
            return null;
        }
    }
}
