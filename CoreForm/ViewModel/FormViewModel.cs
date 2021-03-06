﻿using DotNetify;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CoreForm.ViewModel
{
    public class FormViewModel:BaseVM
    {
        private CoreForm.DataInterfaces.IFormDefinitionProvider formDefinitionProvider;

        public ObservableCollection<String> FormList { get => Get<ObservableCollection<String>>(); set => Set(value); }

        public FormViewModel(CoreForm.DataInterfaces.IFormDefinitionProvider formDefinitionProvider)
        {
            this.formDefinitionProvider = formDefinitionProvider;
            FormList = new ObservableCollection<string>() { "Form 1", "Form 2" };
            formDefinitionProvider.GetFormDefinitions().ToList().ForEach(o => { FormList.Add(o.Title); });
            FormList.CollectionChanged += (o, e) =>
            {
                Changed("FormList");
                PushUpdates();
            };
        }

        public void Save(String formName)
        {
            FormList.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF"));
        }
    }
}
