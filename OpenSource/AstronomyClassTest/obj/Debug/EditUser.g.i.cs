﻿#pragma checksum "..\..\EditUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "619F618D5925D6B5AFD2E8F6A54223233A50237301B1DE02C1DC4D762B72EE6F"
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
    /// EditUser
    /// </summary>
    public partial class EditUser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBackBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox OldPasswordInput;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPasswordInput;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameInput;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameInput;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameInput;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberPhone;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EducationalInput;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectedClassForUser;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadAvatarUser;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\EditUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveUserProfileBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/AstronomyClassTest;component/edituser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditUser.xaml"
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
            this.GoBackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EditUser.xaml"
            this.GoBackBtn.Click += new System.Windows.RoutedEventHandler(this.GoBackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OldPasswordInput = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.NewPasswordInput = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.LastNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.FirstNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SurnameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.NumberPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.EducationalInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.SelectedClassForUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.UploadAvatarUser = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\EditUser.xaml"
            this.UploadAvatarUser.Click += new System.Windows.RoutedEventHandler(this.UploadAvatarUser_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SaveUserProfileBtn = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\EditUser.xaml"
            this.SaveUserProfileBtn.Click += new System.Windows.RoutedEventHandler(this.SaveUserProfileBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
