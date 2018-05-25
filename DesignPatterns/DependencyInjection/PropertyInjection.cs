using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Property injection
// 1. Also called Setter injection.
// 2. Used when a class has optional dependencies, or where the implementations may need to be swapped.Different logger implementations could be used this way.
// 3. May require checking for a provided implementation throughout the class(need to check for null before using it).
// 4. Does not require adding or modifying constructors.

namespace PropertyInjection
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

        public IService propService
        {
            set
            {
                m_Service = value;
            }
        }

        public void startService()
        {
            m_Service.start();
        }
    }

}
