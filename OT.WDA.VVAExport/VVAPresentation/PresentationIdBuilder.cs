using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OT.WDA.VVAExport.VVAPresentation
{
    public partial class PresentationBuilder
    {
        private IDictionary<Type, List<int>> RelationshipIds = new Dictionary<Type, List<int>>();
        private UInt32Value _newId = 0U;
        public UInt32Value NewId
        {
            get
            {
                return _newId++;
            }
        }

        private void CleanRelationshipId()
        {
            RelationshipIds.Clear();
            _newId = 0U;
        }

        public string GenerateRelationshipId<T>() where T : class
        {
            var type = typeof(T);
            if (RelationshipIds.ContainsKey(type))
            {
                var ids = RelationshipIds[type];
                ids.Add(ids.Max<int>() + 1);
                return $"{type.Name}{ids.Last()}";
            }
            else
            {
                var ids = new List<int>() { 1 };
                RelationshipIds.Add(type, ids);
                return $"{type.Name}{ids.Last()}";
            }
        }
        public string LastRelationshipIdOf<T>() where T : class
        {
            var type = typeof(T);
            if (RelationshipIds.ContainsKey(type))
            {
                var ids = RelationshipIds[type];
                return $"{type.Name}{ids.Last()}";
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}