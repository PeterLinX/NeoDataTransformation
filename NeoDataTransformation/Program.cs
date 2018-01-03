using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

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

            //大端序地址转换： AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb = 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9
            string str5 = "AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb";
            UInt160 address = Helper.ToScriptHash(str5);
            Console.WriteLine(address);

            //大端序地址转换： 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 = AeV59NyZtgj5AMQ7vY6yhr2MRvcfFeLWSb
            string str6 = "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9";
            string strFromScriptHash = Helper.ToAddress(UInt160.Parse(str6));
            Console.WriteLine(strFromScriptHash);


            //小端序地址转换： Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU = d336d7eb9975a29b2404fdb28185e277a4b299bc
            //d336d7eb9975a29b2404fdb28185e277a4b299bc = 0xbc99b2a477e28581b2fd04249ba27599ebd736d3
            string str7 = "Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU";
            UInt160 addr = Helper.ToScriptHash(str7);
            Console.WriteLine(addr);

            //小端序地址转换： d336d7eb9975a29b2404fdb28185e277a4b299bc = Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU
            string str8 = "d336d7eb9975a29b2404fdb28185e277a4b299bc";
            string strFromByteArray = Helper.ToAddress(UInt160.Parse(str8.HexToBytes().Reverse().ToHexString()));
            Console.WriteLine(strFromByteArray);

            Console.ReadLine();
        }
    }
}
