using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreStuffs.CoreForm.DataInterfaces
{
    public interface IFormDefinitionProvider
    {
        IEnumerable<DataEntities.FormDefinition> GetFormDefinitions();
    }
}
