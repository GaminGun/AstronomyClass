﻿#pragma checksum "..\..\FullViewArticlePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3F16B6E2111B47046724391473F182A4247254A2C410EE2B0055909A50E3DBE8"
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
    /// FullViewArticlePage
    /// </summary>
    public partial class FullViewArticlePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBackBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RunTestBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateTest;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeForTestInput;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditTest;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewMarkThisTest;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteTest;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\FullViewArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OutputFullInfoArticle;
        
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
            System.Uri resourceLocater = new System.Uri("/AstronomyClassTest;component/fullviewarticlepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FullViewArticlePage.xaml"
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
            
            #line 17 "..\..\FullViewArticlePage.xaml"
            this.GoBackBtn.Click += new System.Windows.RoutedEventHandler(this.GoBackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RunTestBtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\FullViewArticlePage.xaml"
            this.RunTestBtn.Click += new System.Windows.RoutedEventHandler(this.RunTestBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CreateTest = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\FullViewArticlePage.xaml"
            this.CreateTest.Click += new System.Windows.RoutedEventHandler(this.CreateTest_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TimeForTestInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\FullViewArticlePage.xaml"
            this.TimeForTestInput.GotFocus += new System.Windows.RoutedEventHandler(this.TimeForTestInput_GotFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\FullViewArticlePage.xaml"
            this.TimeForTestInput.LostFocus += new System.Windows.RoutedEventHandler(this.TimeForTestInput_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditTest = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\FullViewArticlePage.xaml"
            this.EditTest.Click += new System.Windows.RoutedEventHandler(this.EditTest_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ViewMarkThisTest = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\FullViewArticlePage.xaml"
            this.ViewMarkThisTest.Click += new System.Windows.RoutedEventHandler(this.ViewMarkThisTest_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DeleteTest = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\FullViewArticlePage.xaml"
            this.DeleteTest.Click += new System.Windows.RoutedEventHandler(this.DeleteTest_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OutputFullInfoArticle = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

