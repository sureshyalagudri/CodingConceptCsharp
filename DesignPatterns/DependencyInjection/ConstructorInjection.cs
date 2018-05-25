using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Constructor Injection
// 1. This is the most common DI.
// 2. Dependency Injection is done by supplying the DEPENDENCY through the class’s constructor when instantiating that class.
// 3. Injected component can be used anywhere within the class.
// 4. Should be used when the injected dependency is required for the class to function.
// 5. It addresses the most common scenario where a class requires one or more dependencies.

namespace ConstructorInjection
{
    // Interface 
    interface IService
    {
        void start();
        void GetStatus();
    }

    // Implimentation of interface
    public class service1 : IService
    {
        public void start()
        {
            Console.WriteLine("Service1 is started!!!");
        }

        public void GetStatus() { }
    }

    // Implimentation of interface
    public class service2 : IService
    {
        public void start()
        {
            Console.WriteLine("Service2 is started!!!");
        }

        public void GetStatus() { }
    }

    class Client
    {
        IService m_Service;
        public Client(IService service)
        {
            m_Service = service;

        }

        public void startService()
        {
            m_Service.start();
        }
    }
}
