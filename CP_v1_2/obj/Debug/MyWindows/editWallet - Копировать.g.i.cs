﻿#pragma checksum "..\..\..\MyWindows\editWallet - Копировать.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "11F0574482D094425105CF22D09BE218B3F37829530D2F5B171C392B8D05F37F"
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
    /// editWallet
    /// </summary>
    public partial class editWallet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\MyWindows\editWallet - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblWalletName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MyWindows\editWallet - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxCurrensies;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\MyWindows\editWallet - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblSum;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MyWindows\editWallet - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Edit;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\MyWindows\editWallet - Копировать.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CP_v1_2;component/mywindows/editwallet%20-%20%d0%9a%d0%be%d0%bf%d0%b8%d1%80%d0%b" +
                    "e%d0%b2%d0%b0%d1%82%d1%8c.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MyWindows\editWallet - Копировать.xaml"
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
            
            #line 12 "..\..\..\MyWindows\editWallet - Копировать.xaml"
            ((CP_v1_2.MyWindows.editWallet)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tblWalletName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbxCurrensies = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.tblSum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this._Edit = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\MyWindows\editWallet - Копировать.xaml"
            this._Edit.Click += new System.Windows.RoutedEventHandler(this._Edit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this._Close = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\MyWindows\editWallet - Копировать.xaml"
            this._Close.Click += new System.Windows.RoutedEventHandler(this._Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

