﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3_4
{
    /// <summary>
    /// Interaction logic for Platitelj.xaml
    /// </summary>
    public partial class Platitelj : Page
    {
        public Platitelj()
        {
            InitializeComponent();
        }

        private void ReceiverTypeFizickaInput_Click(object sender, RoutedEventArgs e)
        {
            ReceiverTypePrivnaInput.IsEnabled = false;
        }

        private void ReceiverTypePrivnaInput_Click(object sender, RoutedEventArgs e)
        {
            ReceiverTypeFizickaInput.IsEnabled = false;
        }
    }
}