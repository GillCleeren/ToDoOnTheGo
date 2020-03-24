using System.Reflection;
using Xamarin.Forms;

namespace ToDoOnTheGo.Tests.Helper
{
    public static class DataBindingExtensions
    {
        private static MethodInfo _bindablePropertyGetContextMethodInfo = typeof(BindableObject).GetMethod("GetContext", BindingFlags.NonPublic | BindingFlags.Instance);
        private static FieldInfo _bindablePropertyContextBindingFieldInfo;

        public static Binding GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
        {
            object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });

            if (bindablePropertyContext != null)
            {
                FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo ??=
                        bindablePropertyContext.GetType().GetField("Binding");

                return (Binding)propertyInfo.GetValue(bindablePropertyContext);
            }
            return null;
        }
    }
}
