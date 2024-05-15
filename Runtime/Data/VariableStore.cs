using System;
using System.Collections.Generic;
using System.Linq;
using SODD.Variables;

namespace SODD.Data
{
    [Serializable]
    internal class VariableStore
    {
        private Dictionary<string, object> _data = new();

        public void Store(IEnumerable<IVariable> variables)
        {
            _data = variables.ToDictionary(variable => variable.Id, variable => variable.Value);
        }

        public void Restore(IEnumerable<IVariable> variables)
        {
            var dictionary = variables.ToDictionary(variable => variable.Id, variable => variable);
            foreach (var pair in _data) dictionary[pair.Key].Value = pair.Value;
        }
    }
}