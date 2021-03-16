using Ninject;
using System;
using System.Reflection;

namespace VeterinariaMVC.Windows.Ninject
{
    public class DI
    {
        private static StandardKernel _kernel;

        public static void Inicialize()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        public static T Create<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
