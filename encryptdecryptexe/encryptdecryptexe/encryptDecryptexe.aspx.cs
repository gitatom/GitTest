using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace encryptdecryptexe
{
    public partial class encryptDecryptexe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string encryptedText = "td1EPNRmDL/ktnD3niAEexlztcUVPh6e";//
            string str = "4667040916002142";
            EencyptData(str);
            string data=DecryptData(encryptedText);



        }

        public string DecryptData(string encryptedText)
        {

            DES des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.UTF8.GetBytes("61220121".Substring(0, 8));
            des.IV = System.Text.Encoding.UTF8.GetBytes("61220121".Substring(0, 8));

            byte[] bytes = Convert.FromBase64String(encryptedText);
            byte[] resultBytes = des.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);

            return Encoding.UTF8.GetString(resultBytes);


        }
        public string EencyptData(string str)
        {
            UTF8Encoding UTF8 = new UTF8Encoding();
            // .new.DesManaged se=new DesManaged();
            DES des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.UTF8.GetBytes("61220121".Substring(0, 8));
            ICryptoTransform crypt = des.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] cipher = crypt.TransformFinalBlock(bytes, 0, bytes.Length);
            string encdata = Convert.ToBase64String(cipher);
            // des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            return encdata;
        }
    }
}