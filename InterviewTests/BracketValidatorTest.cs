using Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteviewTests
{
    [TestClass]
    public class BracketValidatorTest
    {
        [TestMethod]
        public void Validate_Valid()
        {
            bool result = BracketValidator.Validate("(a + b)[{!c}()]");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_Unbalanced()
        {
            bool result = BracketValidator.Validate("()[{()]");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_Incomplete()
        {
            bool result = BracketValidator.Validate("((((");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_Mixed()
        {
            bool result = BracketValidator.Validate("()[{(})]");
            Assert.IsFalse(result);
        }
    }
}
