using System;
using System.Collections;
using System.Dynamic;
using System.Xml.Linq;
using NUnit.Framework;

namespace CodeSnippets.DynamicExpandoObject
{
    [TestFixture]
    public class XmlDeserializableWithDynamicObject
    {
        [Test]
        public void XmlDeserializableTest()
        {
            dynamic doc = new DynamicXml(@"..\Debug\DynamicExpandoObject\Employees.xml");

            foreach (var employee in doc.employees)
            {
                Console.WriteLine(employee.firstName);
            }
        }

        internal class DynamicXml : DynamicObject, IEnumerable
        {
            private readonly dynamic _xml;

            public DynamicXml(string fileName)
            {
                _xml = XDocument.Load(fileName);

            }

            public DynamicXml(dynamic xml)
            {
                _xml = xml;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var xml = _xml.Element(binder.Name);

                if (xml != null)
                {
                    result = new DynamicXml(xml);
                    return true;
                }

                result = null;
                return false;
                
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var child in _xml.Elements())
                {
                    yield return new DynamicXml(child);
                } 
            }

            public static implicit operator string(DynamicXml xml)
            {
                return xml._xml.Value;
            }
        }
    }
}
