﻿#pragma checksum "..\..\..\Articles and Tests\AddEditArticlePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E24397AC3191E2A5042AF99E890F15D8D037799B92B06B59922A86DFFE3CD60"
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
    /// AddEditArticlePage
    /// </summary>
    public partial class AddEditArticlePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameArticle;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectedType;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionObjectArticle;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextObjectArticle;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadImage;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveArticleBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/AstronomyClassTest;component/articles%20and%20tests/addeditarticlepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
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
            
            #line 7 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
            ((AstronomyClassTest.AddEditArticlePage)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Page_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameArticle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SelectedType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DescriptionObjectArticle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextObjectArticle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UploadImage = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
            this.UploadImage.Click += new System.Windows.RoutedEventHandler(this.UploadImage_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SaveArticleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\Articles and Tests\AddEditArticlePage.xaml"
            this.SaveArticleBtn.Click += new System.Windows.RoutedEventHandler(this.SaveArticleBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

