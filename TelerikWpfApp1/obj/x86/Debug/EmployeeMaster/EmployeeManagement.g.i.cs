﻿#pragma checksum "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB16C8CB7EF5AC163DE320D9A4A23B46C91BD492"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using TelerikWpfApp1;


namespace TBike {
    
    
    /// <summary>
    /// EmployeeManagement
    /// </summary>
    public partial class EmployeeManagement : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTNnew;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTNSetRank;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTNPromote;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TLRankDesc;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TLUsername;
        
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
            System.Uri resourceLocater = new System.Uri("/T-Bike;component/employeemaster/employeemanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
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
            this.dataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            this.dataGrid1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTNnew = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            this.BTNnew.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTNSetRank = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            this.BTNSetRank.Click += new System.Windows.RoutedEventHandler(this.BTNSetRank_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BTNPromote = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\EmployeeMaster\EmployeeManagement.xaml"
            this.BTNPromote.Click += new System.Windows.RoutedEventHandler(this.BTNPromote_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TLRankDesc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TLUsername = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
