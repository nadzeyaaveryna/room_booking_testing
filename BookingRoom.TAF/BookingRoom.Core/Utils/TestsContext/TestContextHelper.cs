using NUnit.Framework;
using static NUnit.Framework.Internal.TestExecutionContext;

namespace BookingRoom.Core.Utils.TestsContext
{

    /// <summary>
    /// Represent helper for test context manipulation
    /// </summary>
    public static class TestContextHelper
    {
        public static void SetIfNotExist<T>(this TestContextVariable scenarioContext, T value)
        {
            if (!scenarioContext.IsExist())
                scenarioContext.Set(value);
        }

        public static bool IsExist(this TestContextVariable scenarioVariable)
        {
            return TestContext.CurrentContext.Test.Properties.ContainsKey(
                $"{TestContext.CurrentContext.Test.Name}{scenarioVariable.Name}");

        }

        public static void Set<T>(this TestContextVariable scenarioVariable, T value)
        {
            CurrentContext.CurrentTest.Properties.Set($"{TestContext.CurrentContext.Test.Name}{scenarioVariable.Name}",
                value);
        }

        public static T Get<T>(this TestContextVariable scenarioVariable)
        {
            return (T)TestContext.CurrentContext.Test.Properties.Get($"{TestContext.CurrentContext.Test.Name}{scenarioVariable.Name}");
        }
    }
}
