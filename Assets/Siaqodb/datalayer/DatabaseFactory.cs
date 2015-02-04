using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sqo;

namespace SiaqodbDemo
{
    public class DatabaseFactory
    {
        public static string siaoqodbPath;
        private static Siaqodb instance;


        public static Siaqodb GetInstance()
        {
            if (instance == null)
            {
               //put here your License Key
				SiaqodbConfigurator.SetLicense(@"QB89ZFVPOc4vXeNEBR5mLxnR0NlnEZfmLDNj3a+Wa6A=");
               
                //if ANDROID:
				if (Application.platform == RuntimePlatform.Android)
                	siaoqodbPath = Application.persistentDataPath;

                //if Windows or MAC
				else if (Application.platform == RuntimePlatform.OSXEditor || 
				         Application.platform == RuntimePlatform.WindowsEditor)
                	siaoqodbPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"database";

                //if iOS (iPhone /iPad)
				else if (Application.platform == RuntimePlatform.OSXPlayer ||
				         Application.platform == RuntimePlatform.IPhonePlayer)
                	siaoqodbPath = Application.dataPath;

                if (!Directory.Exists(siaoqodbPath))
                {
                    Directory.CreateDirectory(siaoqodbPath);
                }
                instance = new Siaqodb(siaoqodbPath);
            }
            return instance;
        }
        public static void CloseDatabase()
        {
            if (instance != null)
            {
                instance.Close();
                instance = null;
            }
        }
    }
}
