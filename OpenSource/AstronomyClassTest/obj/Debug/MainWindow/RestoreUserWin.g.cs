﻿#pragma checksum "..\..\..\MainWindow\RestoreUserWin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F0C3F02795849B4BE7C826650C22064A1BCB6F16A13BBE8796A8A37940DD9A14"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AstronomyClassTest;
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


namespace AstronomyClassTest {
    
    
    /// <summary>
    /// RestoreUserWin
    /// </summary>
    public partial class RestoreUserWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\MainWindow\RestoreUserWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginInputForRestore;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\MainWindow\RestoreUserWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CodeInputForRestore;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow\RestoreUserWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPassInputForRestore;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow\RestoreUserWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EndRestorePassBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/AstronomyClassTest;component/mainwindow/restoreuserwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow\RestoreUserWin.xaml"
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
            this.LoginInputForRestore = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\MainWindow\RestoreUserWin.xaml"
            this.LoginInputForRestore.KeyDown += new System.Windows.Input.KeyEventHandler(this.LoginInputForRestore_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CodeInputForRestore = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\MainWindow\RestoreUserWin.xaml"
            this.CodeInputForRestore.KeyDown += new System.Windows.Input.KeyEventHandler(this.CodeInputForRestore_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NewPassInputForRestore = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.EndRestorePassBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\MainWindow\RestoreUserWin.xaml"
            this.EndRestorePassBtn.Click += new System.Windows.RoutedEventHandler(this.EndRestorePassBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

