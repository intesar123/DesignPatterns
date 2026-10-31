using System.Net.Security;
// Singleton with lazy initialization and thread safety
public class LazySingleton
{
    private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());
    private LazySingleton()
    {
        // Private constructor to prevent instantiation from outside
        Console.WriteLine("LazySingleton instance created.");
    }
    public static LazySingleton Instance => _instance.Value;
    public void DoSomething()
    {
        Console.WriteLine("LazySingleton instance is doing something.");
    }
}
// This is a simple implementation of the Singleton design pattern in C#.
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();
    private Singleton()
    {
        // Private constructor to prevent instantiation from outside
        Console.WriteLine("Singleton instance created.");
    }
    public static Singleton Instance
    {
        get
        {
            // Double-checked locking to ensure thread safety
            // How is thread safety ensured in this implementation of the Singleton pattern?
            // Answer: Thread safety is ensured by using a lock on a private static object
            // (_lock) to synchronize access to the instance creation.
            // The double-checked locking pattern checks if the instance is null before and after
            // acquiring the lock, ensuring that only one instance is created even in a multithreaded environment.
            if (_instance == null)
            {
                // What does the lock statement do in this context?
                // Answer: The lock statement ensures that only one thread can enter the critical section
                // of code that creates the Singleton instance at a time. This prevents multiple threads
                // from creating multiple instances of the Singleton class simultaneously.
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
    public void DoSomething()
    {
        Console.WriteLine("Singleton instance is doing something.");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Singleton.Instance.DoSomething();
        // destroy the singleton instance
        // How can the Singleton instance be destroyed in this implementation?
        // Answer: In this implementation, the Singleton instance cannot be destroyed
        // because the constructor is private and there is no method provided to reset or nullify the instance.

        // However, if you want to allow the Singleton instance to be destroyed, you could add a method
        // to reset the instance, like this:
        // public static void ResetInstance()
        // {
        //     lock (_lock)
        //     {
        //         _instance = null;
        //     }
        // }

        LazySingleton.Instance.DoSomething();
        // destroy the lazy singleton instance
        // How can the LazySingleton instance be destroyed in this implementation?
        // Answer: Similar to the Singleton implementation, the LazySingleton instance cannot be destroyed
        // because the constructor is private and there is no method provided to reset or nullify the instance.
        // If you want to allow the LazySingleton instance to be destroyed, you could add a method
        // to reset the instance, like this:
        // public static void ResetInstance()
        // {
        //     _instance = new Lazy<LazySingleton>(() => new LazySingleton());
        // }

        //Count the number of instances created for both Singleton and LazySingleton
        // How can we count the number of instances created for both Singleton and LazySingleton?
        // Answer: We can add a static counter variable in both Singleton and LazySingleton classes
        // and increment it in the constructor. For example:
        // In Singleton class:
        // private static int _instanceCount = 0;
        // In the constructor:
        // _instanceCount++;
        // In LazySingleton class:
        // private static int _instanceCount = 0;
        // In the constructor:
        // _instanceCount++;
        // Then we can add a public static method to get the instance count:
        // public static int GetInstanceCount()
        // {
        //     return _instanceCount;
        // }
    }
}