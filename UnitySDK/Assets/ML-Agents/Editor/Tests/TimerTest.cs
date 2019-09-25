using NUnit.Framework;
using UnityEngine;

namespace MLAgents.Tests
{
    public class TimerTests
    {

        [Test]
        public void TestNested()
        {
            TimerStack myTimer = new TimerStack();
            using (myTimer.Scoped("foo"))
            {
                for (int i = 0; i < 5; i++)
                {
                    using (myTimer.Scoped("bar"))
                    {
                    }
                }
            }

            var rootChildren = myTimer.m_RootNode.m_Children;
            Assert.That(rootChildren, Contains.Key("foo"));
            Assert.AreEqual(rootChildren["foo"].m_NumCalls, 1);

            var fooChildren = rootChildren["foo"].m_Children;
            Assert.That(fooChildren, Contains.Key("bar"));
            Assert.AreEqual(fooChildren["bar"].m_NumCalls, 5);
        }


    }
}
