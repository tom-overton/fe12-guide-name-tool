// Copyright (c) 2016 Tom Overton

using System;
using System.Windows.Forms;

namespace FE12GuideNameTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NameFileMapper.InitializeNameFileMapper();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FE12GuideNameForm());
        }
    }
}
