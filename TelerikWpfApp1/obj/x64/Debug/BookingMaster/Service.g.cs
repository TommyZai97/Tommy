﻿#pragma checksum "..\..\..\..\BookingMaster\Service.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73A8AFED1A64B5BC5C0A78E2311C9949D74555CC"
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
using TBike.BookingMaster;


namespace TBike.BookingMaster {
    
    
    /// <summary>
    /// Service
    /// </summary>
    public partial class Service : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBBicycle;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LBBicycleName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LBStatus;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBCondition;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.DateTimePicker PickStart;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.DateTimePicker PickEnd;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LBDuration;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\BookingMaster\Service.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TLRankDesc;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\BookingMaster\Service.xaml"
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
            System.Uri resourceLocater = new System.Uri("/T-Bike;component/bookingmaster/service.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\BookingMaster\Service.xaml"
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
            this.CBBicycle = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\..\BookingMaster\Service.xaml"
            this.CBBicycle.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LBBicycleName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.LBStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TBCondition = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PickStart = ((MahApps.Metro.Controls.DateTimePicker)(target));
            
            #line 33 "..\..\..\..\BookingMaster\Service.xaml"
            this.PickStart.SelectedDateChanged += new System.EventHandler<MahApps.Metro.Controls.TimePickerBaseSelectionChangedEventArgs<System.Nullable<System.DateTime>>>(this.PickStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PickEnd = ((MahApps.Metro.Controls.DateTimePicker)(target));
            
            #line 37 "..\..\..\..\BookingMaster\Service.xaml"
            this.PickEnd.SelectedDateChanged += new System.EventHandler<MahApps.Metro.Controls.TimePickerBaseSelectionChangedEventArgs<System.Nullable<System.DateTime>>>(this.PickEnd_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LBDuration = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TLRankDesc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TLUsername = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 51 "..\..\..\..\BookingMaster\Service.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 52 "..\..\..\..\BookingMaster\Service.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

