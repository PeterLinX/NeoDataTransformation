using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NeoDataTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //字符："transfer" = "7472616e73666572"
            string str1 = "transfer";
            byte[] byteArray = Encoding.UTF8.GetBytes(str1);
            string hexStr = byteArray.ToHexString();
            Console.WriteLine("hexStr: " + hexStr);

            //字符："7472616e73666572" = "transfer"
            string str2 = "7472616e73666572";
            byte[] tmp2 = str2.HexToBytes();
            string keyStr = Encoding.ASCII.GetString(tmp2);
            Console.WriteLine("normalStr: " + keyStr);

            //数字：100000000 = 00e1f505
            string str3 = "100000000";
            BigInteger bigInteger = BigInteger.Parse(str3);
            string hexNumber = bigInteger.ToByteArray().ToHexString();
            Console.WriteLine("hexStr: " + hexNumber);

            //数字：00e1f505 = 100000000
            string str4 = "00e1f505";
            byte[] tmp1 = str4.HexToBytes();
            BigInteger biResult = new BigInteger(tmp1);
            Console.WriteLine("normalStr: " + biResult);

            //地址： AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb = ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9
            string str5 = "AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb";
            UInt160 address = Helper.ToScriptHash(str5);
            Console.WriteLine(address);

            //地址： ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 = AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb
            string str6 = "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9";
            string strFromScriptHash = Helper.ToAddress(UInt160.Parse(str6));
            Console.WriteLine(strFromScriptHash);


            Console.ReadLine();
        }
    }
}
