using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CTCI
{
    public class CTCIModerate
    {
        public void AllModerate()
        {
            //12 XML Endcoding 
            //string str = EncodeXML();

            //13 and 14 are line problems --- TO DO

            //15 Master Mind 
            //GetHitAndPseudoHit(); ----To Excute

            //16 Sub sort
            //FindSubArray(); ----To Excute

            //17 Continuous Sequence
            //MaxSquenceSum(); ----To Excute

            //18 Pattern Matching 
            bool isMatch = IsMatch( "aabab","catcatgocatgo");  //////////////To complex 
        }

        //12
        /// <summary>
        /// we use sb as string is immutable. String's content cann't be chanhe 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        Hashtable ht = new Hashtable();
        public string EncodeXML()
        {
            
            ht.Add("family", 1);//considering all lower case 
            ht.Add("person", 2);//considering all lower case 
            ht.Add("FirstName", 3);//considering all lower case 
            ht.Add("lastName", 4);//considering all lower case 
            ht.Add("state", 5);//considering all lower case 
            
            StringBuilder sb = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<family lastName='Minal' state='CA'>All members</family>");
            
            EncodeXML(doc.DocumentElement, sb);
            return sb.ToString();
        }

        private void EncodeXML(XmlElement root, StringBuilder sb)
        {
            if (root == null) return;

            sb.Append(GetMapping(root.Name));
            foreach (XmlAttribute attr in root.Attributes)
            {
                Append(GetMapping(attr.Name), sb);
                Append(attr.Value, sb);
            }

            Append("0", sb);
            if(root.Value != null)
            {
                Append(root.Value, sb);
            }

            foreach(XmlElement c in root.ChildNodes)
            {
                EncodeXML(c, sb);
            }
            Append("0", sb);
        }

        private void Append(string str, StringBuilder sb)
        {
            sb.Append(str);
            sb.Append(" ");
        }

        private string GetMapping(string key)
        {
           if(ht.Contains(key))
            {
                return ht[key].ToString();
            }
            return null;
        }

        //18 Pattern Matching 
        public bool IsMatch(string pattern, string value)
        {
            if (pattern.Length == 0) return value.Length == 0;

            char mainChar = pattern[0];
            char altChar = mainChar == 'a' ? 'b' : 'a';
            int size = value.Length;

            int countofMain = CountOf(pattern, mainChar);
            int countofAlt = CountOf(pattern, altChar);
            int firstAlt = pattern.IndexOf(altChar);
            int maxMainSize = size / countofMain;

            for (int mainSize =0; mainSize<=maxMainSize;mainSize++)
            {
                int remainingLength = size - mainSize * countofMain;
                if (countofAlt ==0 || remainingLength % countofAlt ==0)
                {
                    int altIndex = firstAlt * mainSize;
                    int altSize = countofAlt == 0 ? 0 : remainingLength / countofAlt;

                    if (Matches(pattern, value, mainSize, altSize, altIndex))
                    {
                        return true;
                    }
                }
            }
            return false; 
        }

        private bool Matches(string pattern, string value, int mainSize, int altSize, int fitstAlt)
        {
            int stringIndex = mainSize;
            for (int i=1; i<pattern.Length;i++)
            {
                int size = pattern[i] == pattern[0] ? mainSize : altSize;
                int offset = pattern[i] == pattern[0] ? 0 : fitstAlt;
                if (!IsEqual(value, offset, stringIndex, size))
                {
                    return false;
                }
                stringIndex += size;
            }

            return true;
        }

        private bool IsEqual(string s1, int offset1, int offset2, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if(s1[offset1+1] != s1[offset2+1])
                {
                    return false;
                }
            }
            return true;
        }
        private int CountOf(string pattern, char c)
        {
            int count = 0;
            for (int i=0;i<pattern.Length;i++)
            {
                if(pattern[i]==c)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
