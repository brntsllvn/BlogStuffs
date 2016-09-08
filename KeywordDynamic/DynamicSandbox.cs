using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace KeywordDynamic
{
    public class DynamicSandbox
    {
    }

    [TestFixture]
    public class KeywordDynamicTests
    {
        [Test]
        public void Dynamic_With_String()
        {
            dynamic item = "First";
            dynamic value = "!";

            string result = item + value;

            result.ShouldBe("First!");
        }

        [Test]
        public void Dynamic_BinderException()
        {
            dynamic item = 1;
            dynamic value = 2;

            Should.Throw<RuntimeBinderException>(() => { string result = item + value; });
        }

        [Test]
        public void Dynamic_NoException()
        {
            dynamic item = 1;
            dynamic value = 2;

            dynamic result = item + value;

            // note: extension methods not available on dynamic types
            Assert.That(result, Is.EqualTo(3));
        }


    }
}
