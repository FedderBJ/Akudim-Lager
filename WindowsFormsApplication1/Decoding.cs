using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    static class Decoding
    {
        private static string code00 = "";
        private static string code01 = "";
        private static string code02 = "";
        private static string code10 = "";
        private static string code15 = "";
        private static string code37 = "";

        public static string theCode00
        {
            get { return code00; }
            set { code00 = value; }
        }
        public static string theCode01
        {
            get { return code01; }
            set { code01 = value; }
        }
        public static string theCode02
        {
            get { return code02; }
            set { code02 = value; }
        }
        public static string theCode10
        {
            get { return code10; }
            set { code10 = value; }
        }
        public static string theCode15
        {
            get { return code15; }
            set { code15 = value; }
        }
        public static string theCode37
        {
            get { return code37; }
            set { code37 = value; }
        }
    }
}
