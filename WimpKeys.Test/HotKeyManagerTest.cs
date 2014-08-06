using System;
using System.Windows.Forms.VisualStyles;
using NUnit.Framework;

namespace WimpKeys.Test
{
    [TestFixture]
    public class HotKeyManagerTest
    {
        [Test]
        public void AddHotKey_AddingOneHotKeyCombination_ShouldCallInternalRegisterHotKeyOnce()
        {
            var hotKeyManager = new TestableHotKeyManager();
            HotKeyColletion hotKeyColletion = new HotKeyColletion();
            hotKeyColletion.AddHotKey(0,0,null);

            hotKeyManager.Bind(hotKeyColletion.KeyCommands);
                
            Assert.AreEqual(1,hotKeyManager.InternalRegisterHotKey_NumberOfCalls);
        }

        [Test]
        public void AddHotKey_AddingOneHotKeyCombination_ShouldCallInternalRegisterHotKeyTwice()
        {
            var hotKeyManager = new TestableHotKeyManager();
            HotKeyColletion hotKeyColletion = new HotKeyColletion();
            hotKeyColletion.AddHotKey(0, 0, null);
            hotKeyColletion.AddHotKey(0, 0, null);
            
            hotKeyManager.Bind(hotKeyColletion.KeyCommands);

            Assert.AreEqual(2, hotKeyManager.InternalRegisterHotKey_NumberOfCalls);
        }
    }

    public class TestableHotKeyManager : HotKeyManager
    {

        public int InternalRegisterHotKey_NumberOfCalls { get; set; }
        protected override void InternalRegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc)
        {
            InternalRegisterHotKey_NumberOfCalls++;
        }
    }
}
