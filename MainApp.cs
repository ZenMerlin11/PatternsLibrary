using System;
using AF = Patterns.Creational.AbstractFactory;
using B = Patterns.Creational.Builder;
using FM = Patterns.Creational.Factory;
using FMB = Patterns.Creational.FactoryB;
using P = Patterns.Creational.Prototype;
using S = Patterns.Creational.Singleton;
using AD = Patterns.Structural.Adapter;
using BR = Patterns.Structural.Bridge;
using C = Patterns.Structural.Composite;
using D = Patterns.Structural.Decorator;
using FA = Patterns.Structural.Facade;
using FW = Patterns.Structural.Flyweight;
using PR = Patterns.Structural.Proxy;
using CR = Patterns.Behavioral.ChainOfResponsibility;
using CO = Patterns.Behavioral.Command;
using I = Patterns.Behavioral.Interpreter;
using IT = Patterns.Behavioral.Iterator;
using M = Patterns.Behavioral.Mediator;
using ME = Patterns.Behavioral.Memento;
using O = Patterns.Behavioral.Observer;
using ST = Patterns.Behavioral.State;
using SY = Patterns.Behavioral.Strategy;
using TM = Patterns.Behavioral.TemplateMethod;
using V = Patterns.Behavioral.Visitor;


namespace Patterns
{
    /// <summary>
    /// MainApp startup class
    /// </summary>
    class MainApp
    {
        static void Main()
        {
            bool executeLoop = true;
            
            while (executeLoop)
            {
                string progHeader = stringMultiple("*", 39) + "\n" +
                    stringMultiple("*", 5) + " Design Patterns Example App " + stringMultiple("*", 5) + "\n" +
                    stringMultiple("*", 39) + "\n\n\n";

                string selectOpt = "Choose Pattern to Run:\n" +
                    "\n---Creational Patterns---\n" +
                    "[AF] Abstract Factory\n" +
                    "[B]  Builder\n" +
                    "[F]  Factory Method\n" +
                    "[FB] Factory Method (Real World Ex)\n" +
                    "[P]  Prototype\n" +
                    "[S]  Singleton\n" +
                    "\n---Structural Patterns---\n" +
                    "[AD] Adapter\n" +
                    "[BR] Bridge\n" +
                    "[C]  Composite\n" +
                    "[D]  Decorator\n" +
                    "[FA] Facade\n" +
                    "[FW] Flyweight\n" +
                    "[PR] Proxy\n" +
                    "\n---Behavorial Patterns---\n" +
                    "[CR] Chain of Responsibility\n" +
                    "[CO] Command\n" +
                    "[I]  Interpreter\n" +
                    "[IT] Iterator\n" +
                    "[M]  Mediator\n" +
                    "[ME] Memento\n" +
                    "[O]  Observer\n" +
                    "[ST] State\n" +
                    "[SY] Strategy\n" +
                    "[TM] Template Method\n" +
                    "[V]  Visitor\n" +
                    "\nType [Q] to quit\n" +
                    "\nSelection:";

                Console.Clear();
                Console.Write(progHeader + selectOpt);                
                string selection = Console.ReadLine();
                Console.Beep();
                selection = selection.ToUpper().Trim();

                switch (selection)
                {
                    case "AF":
                        RunAbstractFactory();
                        break;

                    case "B":
                        RunBuilder();
                        break;

                    case "F":
                        RunFactoryMethod();
                        break;
                    
                    case "FB":
                        RunFactoryMethodRealWorld();
                        break;

                    case "P":
                        RunPrototype();
                        break;
                    
                    case "S":
                        RunSingleton();
                        break;

                    case "AD":
                        RunAdapter();
                        break;

                    case "BR":
                        RunBridge();
                        break;

                    case "C":
                        RunComposite();
                        break;

                    case "D":
                        RunDecorator();
                        break;

                    case "FA":
                        RunFacade();
                        break;

                    case "FW":
                        RunFlyweight();
                        break;
                    
                    case "PR":
                        RunProxy();
                        break;

                    case "CR":
                        RunChainOfResp();
                        break;

                    case "CO":
                        RunCommand();
                        break;

                    case "I":
                        RunInterpreter();
                        break;

                    case "IT":
                        RunIterator();
                        break;

                    case "M":
                        RunMediator();
                        break;
                    
                    case "ME":
                        RunMemento();
                        break;
                    
                    case "O":
                        RunObserver();
                        break;

                    case "ST":
                        RunState();
                        break;

                    case "SY":
                        RunStategy();
                        break;

                    case "TM":
                        RunTemplateMethod();
                        break;

                    case "V":
                        RunVisitor();
                        break;
                    
                    case "Q":
                        Console.Clear();
                        Console.WriteLine("Over and done with....");
                        PressAnyKeyToCont();
                        executeLoop = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid Selection - Try Again");
                        PressAnyKeyToCont();
                        break;
                } 
            }
        }

        static string stringMultiple(string stringToWrite, int numberOfTimes)
        {
            string retVal = "";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                retVal = retVal + stringToWrite;
            }

            return retVal;
        }

        static void PressAnyKeyToCont()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        static void RunAbstractFactory()
        {
            Console.Clear();
            Console.WriteLine("Abstract Factory\n\n");
            
            // Abstract factory #1
            AF::AbstractFactory factory1 = new AF::ConcreteFactory1();
            AF::Client client1 = new AF::Client(factory1);
            client1.Run();

            // Abstract factory #2
            AF::AbstractFactory factory2 = new AF::ConcreteFactory2();
            AF::Client client2 = new AF::Client(factory2);
            client2.Run();

            // Wait for user input
            PressAnyKeyToCont();
        }

        static void RunBuilder()
        {
            Console.Clear();
            Console.WriteLine("Builder\n\n");
            
            // Create director and builders
            B::Director director = new B::Director();

            B::Builder b1 = new B::ConcreteBuilder1();
            B::Builder b2 = new B::ConcreteBuilder2();

            // Construct two products
            director.Construct(b1);            
            B::Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            B::Product p2 = b2.GetResult();
            p2.Show();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunFactoryMethod()
        {
            Console.Clear();
            Console.WriteLine("Factory Method\n\n");
                        
            // An array of creators
            FM::Creator[] creators = new FM::Creator[2];
            
            creators[0] = new FM::ConcreteCreatorA();
            creators[1] = new FM::ConcreteCreatorB();
            
            // Iterate over creators and create products
            foreach (FM::Creator creator in creators)
            {
                FM::Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }
            
            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunFactoryMethodRealWorld()
        {
            Console.Clear();
            Console.WriteLine("Factory Method - Real World Example\n\n");
            
            // Note:  Constructors call factory method
            FMB::Document[] documents = new FMB::Document[2];

            documents[0] = new FMB::Resume();
            documents[1] = new FMB::Report();

            // Display document pages
            foreach (FMB::Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (FMB::Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            // Wait for user input
            PressAnyKeyToCont();
        }

        static void RunPrototype()
        {
            Console.Clear();
            Console.WriteLine("Prototype\n\n");
                        
            // Create two instances and clone each
            P::ConcretePrototype1 p1 = new P::ConcretePrototype1("I");
            P::ConcretePrototype1 c1 = (P::ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            P::ConcretePrototype2 p2 = new P::ConcretePrototype2("II");
            P::ConcretePrototype2 c2 = (P::ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunSingleton()
        {
            Console.Clear();
            Console.WriteLine("Singleton\n\n");
              
            // Constructor is protected -- cannot use new
            S::Singleton s1 = S::Singleton.Instance();
            S::Singleton s2 = S::Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunAdapter()
        {
            Console.Clear();
            Console.WriteLine("Adapter\n\n");
            
            // Create adapter and place a request
            AD::Target target = new AD::Adapter();
            target.Request();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunBridge()
        {
            Console.Clear();
            Console.WriteLine("Bridge\n\n");

            BR::Abstraction ab = new BR::RefinedAbstraction();

            // Set implementation and call
            ab.Implementor = new BR::ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call
            ab.Implementor = new BR::ConcreteImplementorB();
            ab.Operation();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunComposite()
        {
            Console.Clear();
            Console.WriteLine("Composite\n\n");

            // Create a tree structure
            C::Composite root = new C::Composite("root");
            root.Add(new C::Leaf("Leaf A"));
            root.Add(new C::Leaf("Leaf B"));

            C::Composite comp = new C::Composite("Composite X");
            comp.Add(new C::Leaf("Leaf XA"));
            comp.Add(new C::Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new C::Leaf("Leaf C"));

            // Add and remove a leaf
            C::Leaf leaf = new C::Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunDecorator()
        {
            Console.Clear();
            Console.WriteLine("Decorator\n\n");

            // Create ConcreteComponent and two Decorators
            D::ConcreteComponent c = new D::ConcreteComponent();
            D::ConcreteDecoratorA d1 = new D::ConcreteDecoratorA();
            D::ConcreteDecoratorB d2 = new D::ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunFacade()
        {
            Console.Clear();
            Console.WriteLine("Facade\n\n");

            // Create Facade class and run its two methods
            FA::Facade facade = new FA::Facade();
            facade.MethodA();
            facade.MethodB();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunFlyweight()
        {
            Console.Clear();
            Console.WriteLine("Flyweight\n\n");

            // Arbitrary extrinsic state
            int extrinsicState = 22;

            FW::FlyweightFactory factory = new FW::FlyweightFactory();

            // Work with different flyweight instances
            FW::Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicState);

            FW::Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicState);
                        
            FW::Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicState);

            FW::UnsharedConcreteFlyweight fu = new FW::UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicState);

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunProxy()
        {
            Console.Clear();
            Console.WriteLine("Proxy\n\n");

            PR::Proxy proxy = new PR::Proxy();
            proxy.Request();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunChainOfResp()
        {
            Console.Clear();
            Console.WriteLine("Chain of Responsibility\n\n");

            CR::Handler h1 = new CR::ConcreteHandler1();
            CR::Handler h2 = new CR::ConcreteHandler2();
            CR::Handler h3 = new CR::ConcreteHandler3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 2, 5, 12, 16, 22, 25 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
            
            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunCommand()
        {
            Console.Clear();
            Console.WriteLine("Command\n\n");

            CO::Receiver receiver = new CO::Receiver();
            CO::Command command = new CO::ConcreteCommand(receiver);
            CO::Invoker invoker = new CO::Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunInterpreter()
        {
            Console.Clear();
            Console.WriteLine("Interpreter\n\n");

            I::Context context = new I::Context();
            I::AbstractExpression e1 = new I::NonterminalExpression();
            I::AbstractExpression e2 = new I::TerminalExpression();

            e1.Interpret(context);
            e2.Interpret(context);

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunIterator()
        {
            Console.Clear();
            Console.WriteLine("Iterator\n\n");
            
            IT::ConcreteAggregate a = new IT::ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";
            
            // Create Iterator and provide aggregate
            IT::Iterator i = a.CreateIterator();


            Console.WriteLine("Iterating over collection:");

            object item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunMediator()
        {
            Console.Clear();
            Console.WriteLine("Mediator\n\n");

            M::ConcreteMediator mediator = new M::ConcreteMediator();
            M::ConcreteColleague1 c1 = new M::ConcreteColleague1(mediator);
            M::ConcreteColleague2 c2 = new M::ConcreteColleague2(mediator);
            mediator.Colleague1 = c1;
            mediator.Colleague2 = c2;

            c1.Send("Sup?");
            c2.Send(@"What's crappenin'?");

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunMemento()
        {
            Console.Clear();
            Console.WriteLine("Memento\n\n");

            ME::Originator o = new ME::Originator();
            o.State = "ON";

            ME::Caretaker c = new ME::Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "OFF";

            o.SetMemento(c.Memento);

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunObserver()
        {
            Console.Clear();
            Console.WriteLine("Observer\n\n");
            
            // Configure observer pattern
            O::ConcreteSubject s = new O::ConcreteSubject();

            s.Attach(new O::ConcreteObserver(s, "X"));
            s.Attach(new O::ConcreteObserver(s, "Y"));
            s.Attach(new O::ConcreteObserver(s, "Z"));

            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunState()
        {
            Console.Clear();
            Console.WriteLine("State\n\n");

            // Setup context in a state
            ST::Context c = new ST::Context(new ST::ConcreteStateA());

            // Issue requests which toggle state
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunStategy()
        {
            Console.Clear();
            Console.WriteLine("Strategy\n\n");

            SY::Context context;

            // Three new contexts implementing different strategies
            context = new SY::Context(new SY::ConcreteStrategyA());
            context.ContextInterface();

            context = new SY::Context(new SY::ConcreteStrategyB());
            context.ContextInterface();

            context = new SY::Context(new SY::ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunTemplateMethod()
        {
            Console.Clear();
            Console.WriteLine("Template Method\n\n");

            TM::AbstractClass tmA = new TM::ConcreteClassA();
            TM::AbstractClass tmB = new TM::ConcreteClassB();

            tmA.TemplateMethod();
            tmB.TemplateMethod();

            // Wait for user
            PressAnyKeyToCont();
        }

        static void RunVisitor()
        {
            Console.Clear();
            Console.WriteLine("Visitor\n\n");

            V::ObjectStructure os = new V::ObjectStructure();
            os.Attach(new V::ConcreteElementA());
            os.Attach(new V::ConcreteElementB());
            os.Accept(new V::ConcreteVisitor1());
            os.Accept(new V::ConcreteVisitor2());

            // Wait for user
            PressAnyKeyToCont();
        }        
    }
}