﻿#pragma checksum "..\..\..\MyWindows\editPlanning.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A9086C3C7C0E87D3E75E0A3554B10CD3E81A52E1FB32A69769781A9662B75EC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CP_v1_2.MyWindows;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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


namespace CP_v1_2.MyWindows {
    
    
    /// <summary>
    /// editPlanning
    /// </summary>
    public partial class editPlanning : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxYears;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxMonth;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxCategory;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblSum;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxCurrency;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Edit;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MyWindows\editPlanning.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Close;
        
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
            System.Uri resourceLocater = new System.Uri("/CP_v1_2;component/mywindows/editplanning.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MyWindows\editPlanning.xaml"
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
            
            #line 11 "..\..\..\MyWindows\editPlanning.xaml"
            ((CP_v1_2.MyWindows.editPlanning)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbxYears = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cbxMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbxCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.tblSum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbxCurrency = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this._Edit = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\MyWindows\editPlanning.xaml"
            this._Edit.Click += new System.Windows.RoutedEventHandler(this._Edit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this._Close = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\MyWindows\editPlanning.xaml"
            this._Close.Click += new System.Windows.RoutedEventHandler(this._Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

