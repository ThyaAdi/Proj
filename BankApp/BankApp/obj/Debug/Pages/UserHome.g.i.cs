﻿#pragma checksum "..\..\..\Pages\UserHome.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F214E200499DDB32385F857E9C8F8C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BankApp {
    
    
    /// <summary>
    /// UserHome
    /// </summary>
    public partial class UserHome : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BankDetails;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button4;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button5;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\UserHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BankApp;component/pages/userhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\UserHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.frame1 = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.BankDetails = ((System.Windows.Controls.DataGrid)(target));
            
            #line 9 "..\..\..\Pages\UserHome.xaml"
            this.BankDetails.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.bank_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button4 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Pages\UserHome.xaml"
            this.button4.Click += new System.Windows.RoutedEventHandler(this.button4_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Pages\UserHome.xaml"
            this.button3.Click += new System.Windows.RoutedEventHandler(this.button3_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button5 = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\UserHome.xaml"
            this.button5.Click += new System.Windows.RoutedEventHandler(this.button5_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\UserHome.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.AddAccount_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\UserHome.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

