﻿#pragma checksum "..\..\..\MyWindows\editUsersSettings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "544CD35DA38D2B417BDD560F84CDC479DA15C76FCA763CE8D95CFF9FB3DB1AAE"
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
    /// editUsersSettings
    /// </summary>
    public partial class editUsersSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\MyWindows\editUsersSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse userPhoto;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MyWindows\editUsersSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChangePhoto;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MyWindows\editUsersSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxUserRole;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MyWindows\editUsersSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _UserEdit;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\MyWindows\editUsersSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _UserClose;
        
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
            System.Uri resourceLocater = new System.Uri("/CP_v1_2;component/mywindows/edituserssettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MyWindows\editUsersSettings.xaml"
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
            
            #line 12 "..\..\..\MyWindows\editUsersSettings.xaml"
            ((CP_v1_2.MyWindows.editUsersSettings)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userPhoto = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.btnChangePhoto = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\MyWindows\editUsersSettings.xaml"
            this.btnChangePhoto.Click += new System.Windows.RoutedEventHandler(this.btnChangePhoto_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbxUserRole = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this._UserEdit = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\MyWindows\editUsersSettings.xaml"
            this._UserEdit.Click += new System.Windows.RoutedEventHandler(this._UserEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this._UserClose = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\MyWindows\editUsersSettings.xaml"
            this._UserClose.Click += new System.Windows.RoutedEventHandler(this._Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

