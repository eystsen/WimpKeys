using System;
using System.Windows.Forms;
using FakeItEasy;
using NUnit.Framework;
using WimpTray;

namespace WimpKeys.Test
{
    [TestFixture]
    public class HotKeyCollectionTest
    {
        int DOESNTMATTER_INT = 0;
        Action DOESNTMATTER_ACTION = null;

        [Test]
        public void AddHotKey_CallingExecuteOnKeyCommand_ShouldExecuteAction()
        {
            IWimpControl fakeWimpControl = A.Fake<IWimpControl>();
            HotKeyColletion hotKeyCollection = new HotKeyColletion();

            hotKeyCollection.AddHotKey(DOESNTMATTER_INT, DOESNTMATTER_INT, () => fakeWimpControl.Next());
            hotKeyCollection.KeyCommands[0].Execute();

            A.CallTo(() => fakeWimpControl.Next()).MustHaveHappened();
        }

        [Test]
        public void AddHotKey_AddingTwoCommand_BothShouldHAveUniqueIds()
        {
            HotKeyColletion hotKeyCollection = new HotKeyColletion();

            hotKeyCollection.AddHotKey(DOESNTMATTER_INT, DOESNTMATTER_INT, DOESNTMATTER_ACTION);
            hotKeyCollection.AddHotKey(DOESNTMATTER_INT, DOESNTMATTER_INT, DOESNTMATTER_ACTION);

            Assert.AreNotEqual(hotKeyCollection.KeyCommands[0].Id, hotKeyCollection.KeyCommands[1].Id);
        }

        [Test]
        public void AddHotKey_AddHotKeyOnNewCollection_ShouldBeSetOnTheFirstHotKeyInList()
        {
            var hotKeyCollection = new HotKeyColletion();

            hotKeyCollection.AddHotKey(DOESNTMATTER_INT, Keys.A.GetHashCode(), DOESNTMATTER_ACTION);

            Assert.AreEqual(Keys.A.GetHashCode(), hotKeyCollection.KeyCommands[0].Keys);
        }

        [Test]
        public void AddHotKey_AddModifiersToAHotKeyOnNewCollection_ShouldBeSetOnTheFirstHotKeyInList()
        {
            var hotKeyCollection = new HotKeyColletion();

            hotKeyCollection.AddHotKey(ModifierKeys.CONTROL, DOESNTMATTER_INT, DOESNTMATTER_ACTION);

            Assert.AreEqual(ModifierKeys.CONTROL, hotKeyCollection.KeyCommands[0].Modifiers);
        }
    }
}
