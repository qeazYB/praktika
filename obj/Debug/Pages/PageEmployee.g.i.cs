﻿#pragma checksum "..\..\..\Pages\PageEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C130E0759D0E1ABFB4C3B4BB831B758A2530E9C0D1DC1A90E4D61DEFDD57FAFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
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
using WpfApplProject;
using WpfApplProject.Commands;


namespace WpfApplProject {
    
    
    /// <summary>
    /// PageEmployee
    /// </summary>
    public partial class PageEmployee : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar ToolBar1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Undo;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\PageEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplProject;component/pages/pageemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageEmployee.xaml"
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
            
            #line 24 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar1 = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 3:
            this.Undo = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Add = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Edit = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Save = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.Delete = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.DataGridEmployee = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 78 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Undo_Executed);
            
            #line default
            #line hidden
            
            #line 78 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Undo_CanExecute);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 79 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.New_Executed);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.New_CanExecute);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 80 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Edit_Executed);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Edit_CanExecute);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 81 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Save_Executed);
            
            #line default
            #line hidden
            
            #line 81 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Save_CanExecute);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 83 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Delete_Executed);
            
            #line default
            #line hidden
            
            #line 83 "..\..\..\Pages\PageEmployee.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Delete_CanExecute);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

