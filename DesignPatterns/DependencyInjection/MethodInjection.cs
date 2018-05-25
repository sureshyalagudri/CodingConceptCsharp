using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Method injection
// 1. Inject the dependency into a single method, for use by that method.
// 2. Could be useful where the whole class does not need the dependency, just the one method.
// 3. Generally uncommon, usually used for edge cases.

namespace MethodInjection
{
    public interface IService
    {
        void start();
    }

    class service1 : IService
    {
        public void start()
        {
            Console.WriteLine("Starting setvice1");
        }
    }

    public class service2 : IService
    {
        public void start()
        {
            Console.WriteLine("Starting setvice2");
        }
    }

    public class Client
    {
        IService m_Service;

        public void startService(IService service)
        {
            m_Service = service;
            m_Service.start();
        }

    }
}
