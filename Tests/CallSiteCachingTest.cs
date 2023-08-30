using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExposedObject;
using TestSubjects;
using Xunit;

namespace Tests
{
    public class CallSiteCachingTest
    {
        [Fact]
        public void OverriddenMethodTest()
        {
            dynamic child = Exposed.From(new ChildClass());
            Assert.Equal(nameof(ChildClass), child.OverriddenMethod());
        }

        [Fact]
        public void OverriddenPropertyTest()
        {
            dynamic child = Exposed.From(new ChildClass());
            Assert.Equal(nameof(ChildClass), child.OverriddenProperty);
        }

        [Fact]
        public void HiddenMethodTest()
        {
            dynamic child = Exposed.From(new ChildClass());
            Assert.Equal(nameof(ChildClass), child.HiddenMethod());
        }

        [Fact]
        public void HiddenPropertyTest()
        {
            dynamic child = Exposed.From(new ChildClass());
            Assert.Equal(nameof(ChildClass), child.HiddenProperty);
        }

        [Fact]
        public void HiddenFieldTest()
        {
            dynamic child = Exposed.From(new ChildClass());
            Assert.Equal(nameof(ChildClass), child._hiddenField);
        }

        [Fact]
        public void CallSiteTypeCachingInheritedMethodTest()
        {
            CallHiddenMethod(new ChildClass());
            CallHiddenMethod(new BaseClass());

            static string CallHiddenMethod(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.Method();
            }
        }

        [Fact]
        public void CallSiteTypeCachingInheritedPropertyTest()
        {
            var childValue = GetHiddenPropertyValue(new ChildClass());
            var parentValue = GetHiddenPropertyValue(new BaseClass());

            Assert.Equal(nameof(ChildClass), childValue);
            Assert.Equal(nameof(BaseClass), parentValue);

            static string GetHiddenPropertyValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.Property;
            }
        }

        [Fact]
        public void CallSiteTypeCachingInheritedFieldTest()
        {
            var childValue = GetHiddenFieldValue(new ChildClass());
            var parentValue = GetHiddenFieldValue(new BaseClass());

            Assert.Equal(nameof(ChildClass), childValue);
            Assert.Equal(nameof(BaseClass), parentValue);

            static string GetHiddenFieldValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed._field;
            }
        }

        // FIXME: The below show advanced situations where the call site type caching isn't as easily worked around
        [Fact(Skip = "Not yet working")]
        public void CallSiteTypeCachingHiddenMethodTest()
        {
            Assert.Equal(nameof(ChildClass), GetHiddenMethodValue(new ChildClass()));
            Assert.Equal(nameof(BaseClass), GetHiddenMethodValue(new BaseClass()));

            static string GetHiddenMethodValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.HiddenMethod();
            }
        }

        [Fact(Skip = "Not yet working")]
        public void CallSiteTypeCachingHiddenPropertyTest()
        {
            Assert.Equal(nameof(ChildClass), GetHiddenPropertyValue(new ChildClass()));
            Assert.Equal(nameof(BaseClass), GetHiddenPropertyValue(new BaseClass()));

            static string GetHiddenPropertyValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.HiddenProperty;
            }
        }

        [Fact(Skip = "Not yet working")]
        public void CallSiteTypeCachingHiddenFieldTest()
        {
            Assert.Equal(nameof(ChildClass), GetHiddenFieldValue(new ChildClass()));

            // If this test fails, will throw an InvalidCastException
            Assert.Equal(nameof(BaseClass), GetHiddenFieldValue(new BaseClass()));

            static string GetHiddenFieldValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed._hiddenField;
            }
        }

        [Fact(Skip = "Not yet working")]
        public void CallSiteTypeCachingOverriddenMethodTest()
        {
            Assert.Equal(nameof(ChildClass), GetOverriddenMethodValue(new ChildClass()));

            // If this test fails, will throw an InvalidCastException
            Assert.Equal(nameof(BaseClass), GetOverriddenMethodValue(new BaseClass()));

            static string GetOverriddenMethodValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.OverriddenMethod();
            }
        }

        [Fact(Skip = "Not yet working")]
        public void CallSiteTypeCachingOverriddenPropertyTest()
        {
            Assert.Equal(nameof(ChildClass), GetOverriddenPropertyValue(new ChildClass()));

            // If this test fails, will throw an InvalidCastException
            Assert.Equal(nameof(BaseClass), GetOverriddenPropertyValue(new BaseClass()));

            static string GetOverriddenPropertyValue(Object o)
            {
                dynamic exposed = Exposed.From(o);
                return exposed.OverriddenProperty;
            }
        }
    }
}
