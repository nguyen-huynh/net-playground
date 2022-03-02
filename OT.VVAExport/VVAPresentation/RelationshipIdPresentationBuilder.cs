namespace OT.VVAExport.VVAPresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using IO = System.IO;

    /// <summary>
    /// Follow the OpenXml Docs
    /// <para>Refs: 
    ///     <see href="https://docs.microsoft.com/en-us/office/open-xml/working-with-presentationml-documents">Working with PresentationML documents (Open XML SDK)</see>
    /// </para>
    /// </summary>
    public partial class PresentationBuilder
    {
        public static Func<UInt32Value> GetNewId { get; set; } = null;

        private IDictionary<string, OpenXmlPart> RelationshipIds = new Dictionary<string, OpenXmlPart>();
        private IDictionary<Type, List<int>> RelationshipIdHolders = new Dictionary<Type, List<int>>();
        private void CleanRelationshipId()
        {
            RelationshipIds.Clear();
            RelationshipIdHolders.Clear();
            _newId = 0U;

            PresentationBuilder.GetNewId = () => this.NewId;
        }

        private UInt32Value _newId = 0U;
        private UInt32Value NewId
        {
            get
            {
                return _newId ++;
            }
        }

        private string GenerateRelationshipId<T>() where T : OpenXmlCompositeElement
        {
            string value = null;
            try
            {
                var type = typeof(T);
                if (RelationshipIdHolders.ContainsKey(type))
                {
                    var ids = RelationshipIdHolders[type];
                    ids.Add(ids.Max<int>() + 1);
                    value = $"{type.Name}{ids.Last()}";
                }
                else
                {
                    var ids = new List<int>() { 1 };
                    RelationshipIdHolders.Add(type, ids);
                    value = $"{type.Name}{ids.Last()}";
                }
            }
            finally
            {
                Console.WriteLine($"Generated rId for {typeof(T).Name} : {value}");
            }
            return value;
        }

        private string GeneratePartRelationshipId<T>() where T : OpenXmlPart
        {
            string value = null;
            try
            {
                var type = typeof(T);
                if (RelationshipIdHolders.ContainsKey(type))
                {
                    var ids = RelationshipIdHolders[type];
                    ids.Add(ids.Max<int>() + 1);
                    value = $"{type.Name}{ids.Last()}";
                }
                else
                {
                    var ids = new List<int>() { 1 };
                    RelationshipIdHolders.Add(type, ids);
                    value = $"{type.Name}{ids.Last()}";
                }
            }
            finally
            {
                Console.WriteLine($"Generated rId for {typeof(T).Name} : {value}");
            }
            return value;
        }

        private string LastRelationshipIdOf<T>() where T : OpenXmlCompositeElement
        {
            var type = typeof(T);
            if (RelationshipIdHolders.ContainsKey(type))
            {
                var ids = RelationshipIdHolders[type];
                return $"{type.Name}{ids.Last()}";
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        private string LastPartRelationshipIdOf<T>() where T : OpenXmlPart
        {
            var type = typeof(T);
            if (RelationshipIdHolders.ContainsKey(type))
            {
                var ids = RelationshipIdHolders[type];
                return $"{type.Name}{ids.Last()}";
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        private OpenXmlElement GetIdList<T>() where T : OpenXmlCompositeElement
        {
            var type = typeof(T);
            if (type == typeof(SlideMasterId))
            {
                var slideMasterIds = RelationshipIdHolders[type].Where(x => x > 0)
                    .Select((id, idx) => new SlideMasterId { Id = (2147483648U - UInt32Value.FromUInt32((uint)idx)), RelationshipId = $"{type.Name}{id}" });
                return new SlideMasterIdList(slideMasterIds);
            }
            else if (type == typeof(SlideId))
            {
                var slideIds = RelationshipIdHolders[type].Where(x => x > 0)
                    .Select((id, idx) => new SlideId { Id = (256U + UInt32Value.FromUInt32((uint)idx)), RelationshipId = $"{type.Name}{id}" });
                return new SlideIdList(slideIds);
            }

            return null;
        }
    }
}