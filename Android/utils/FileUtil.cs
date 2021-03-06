﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndroidSmallTools.utils
{
    class FileUtil
    {
        public static String DESKTOP_DIR = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static String CURRENT_DIR = Application.StartupPath;

        public static String ADB_FOLDER_PATH = FileUtil.CURRENT_DIR + "/" + "path";

        //删除目录
        public static void deleteDirectory(String path)
        {
            try
            {

                //去除文件夹和子文件的只读属性
                //去除文件夹的只读属性
                System.IO.DirectoryInfo fileInfo = new DirectoryInfo(path);
                fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;

                //去除文件的只读属性
                System.IO.File.SetAttributes(path, System.IO.FileAttributes.Normal);

                //判断文件夹是否还存在
                if (Directory.Exists(path))
                {
                    foreach (string f in Directory.GetFileSystemEntries(path))
                    {
                        if (File.Exists(f))
                        {
                            //如果有子文件删除文件
                            File.Delete(f);
                            Console.WriteLine(f);
                        }
                        else
                        {
                            //循环递归删除子文件夹
                            deleteDirectory(f);
                        }
                    }
                    //删除空文件夹
                    Directory.Delete(path);
                }
            }
            catch (Exception ex) // 异常处理
            {
                Console.WriteLine(ex.Message.ToString());// 异常信息
            }
        }

        public static void writeFile(String path, String text)
        {
            //防止写文件乱码，使用GB2312编码
            StreamWriter sw1 = new StreamWriter(path, false, Encoding.GetEncoding("GB2312"));
            sw1.WriteLine(text);
            sw1.Close();
        }

        public static String readFile(String path)
        {
            if (File.Exists(path))
            {
                String value = File.ReadAllText(path);
                //File.Delete(path);
                return value;
            }
            return "";
        }
    }
}
