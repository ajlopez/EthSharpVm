namespace EthSharp.Vm.Core.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Integer256Tests
    {
        [TestMethod]
        public void ZeroToBytes()
        {
            Integer256 value = new Integer256();

            var result = value.ToBytes();

            AreEqual(result, new byte[] {});
        }

        [TestMethod]
        public void OneToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(1);
            var result = newvalue.ToBytes();

            AreEqual(result, new byte[] { 0x01 });
        }

        [TestMethod]
        public void MaxUInt32ToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(UInt32.MaxValue);
            var result = newvalue.ToBytes();

            AreEqual(result, new byte[] { 0xff, 0xff, 0xff, 0xff });
        }

        [TestMethod]
        public void MaxUInt32PlusOneToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(UInt32.MaxValue).Add(1);
            var result = newvalue.ToBytes();

            AreEqual(result, new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 });
        }

        [TestMethod]
        public void MaxUInt32TwiceToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(UInt32.MaxValue).Add(UInt32.MaxValue);
            var result = newvalue.ToBytes();

            AreEqual(result, new byte[] { 0x01, 0xff, 0xff, 0xff, 0xfe });
        }

        [TestMethod]
        public void NegateOne()
        {
            Integer256 value = new Integer256().Add(1).Negate();

            var result = value.ToBytes();

            AreEqual(result, new byte[] { }, true);
        }

        [TestMethod]
        public void NegateTwo()
        {
            Integer256 value = new Integer256().Add(1).Add(1).Negate();

            var result = value.ToBytes();

            AreEqual(result, new byte[] { 0xfe }, true);
        }

        [TestMethod]
        public void AddOneToOne()
        {
            var one = new Integer256().Add(1);
            var value = one.Add(one);

            var result = value.ToBytes();

            AreEqual(result, new byte[] { 0x02 });
        }

        [TestMethod]
        public void SubtractOneFromOne()
        {
            var one = new Integer256().Add(1);
            var value = one.Subtract(one);

            var result = value.ToBytes();

            AreEqual(result, new byte[] { });
        }

        [TestMethod]
        public void SubtractOneFromZero()
        {
            var zero = new Integer256();
            var value = zero.Subtract(new Integer256().Add(1));

            var result = value.ToBytes();

            AreEqual(result, new byte[] { }, true);
        }

        [TestMethod]
        public void EqualsAndHash()
        {
            var zero = new Integer256();
            var one1 = new Integer256().Add(1);
            var one2 = new Integer256().Add(1);
            var minusone = one1.Negate();

            Assert.IsFalse(zero.Equals(null));
            Assert.IsFalse(zero.Equals("Foo"));
            Assert.IsFalse(zero.Equals(0));
            Assert.IsFalse(zero.Equals(one1));
            Assert.IsFalse(zero.Equals(minusone));
            Assert.IsFalse(one1.Equals(minusone));

            Assert.IsTrue(zero.Equals(zero));
            Assert.IsTrue(one1.Equals(one2));
            Assert.IsTrue(one2.Equals(one1));

            Assert.AreEqual(one1.GetHashCode(), one2.GetHashCode());
        }

        private static void AreEqual(byte[] values, byte[] expected, bool onefilled = false)
        {
            Assert.IsNotNull(values);

            var vl = values.Length;

            Assert.AreEqual(32, vl);

            var el = expected.Length;

            if (onefilled)
                for (int k = 0; k < vl - el; k++)
                    Assert.AreEqual(0xff, values[k]);
            else
                for (int k = 0; k < vl - el; k++)
                    Assert.AreEqual(0x00, values[k]);

            for (int k = 0; k < el; k++)
                Assert.AreEqual(values[vl - el + k], expected[k]);
        }
    }
}
