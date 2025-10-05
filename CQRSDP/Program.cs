
// Amir Moeini Rad
// October 2025

// Main Concept: CQRS Design Pattern
// With help from ChatGPT

// CQRS stands for Command Query Responsibility Segregation.
// In this pattern, we separate the read (Query) and write (Command) operations of a system into different models.
// This allows us to optimize each model for its specific purpose, improving performance and scalability.


namespace CQRSDP
{
    // Command: changes data
    class CreateUserCommand
    {
        public string Name { get; }

        public CreateUserCommand(string name) => Name = name;
    }


    // Command Handler
    class UserCommandHandler
    {
        private readonly List<string> _users;

        public UserCommandHandler(List<string> users) => _users = users;

        public void Handle(CreateUserCommand command)
        {
            _users.Add(command.Name);
            Console.WriteLine($"User '{command.Name}' created.");
        }
    }


    //------------------------------------------------------


    // Query: reads data
    class GetAllUsersQuery { }


    // Query Handler
    class UserQueryHandler
    {
        private readonly List<string> _users;

        public UserQueryHandler(List<string> users) => _users = users;

        public List<string> Handle(GetAllUsersQuery query)
        {
            return _users;
        }
    }


    //------------------------------------------------------


    // Client (Main Program)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("The CQRS Design Pattern in C#.NET.");
            Console.WriteLine("----------------------------------\n");

            
            var users = new List<string>();

            var commandHandler = new UserCommandHandler(users);
            var queryHandler = new UserQueryHandler(users);

            // Execute commands (write operations)
            commandHandler.Handle(new CreateUserCommand("Amir"));
            commandHandler.Handle(new CreateUserCommand("Arman"));

            Console.WriteLine();
            
            // Execute query (read operation)
            var result = queryHandler.Handle(new GetAllUsersQuery());
            Console.WriteLine("All Users: " + string.Join(", ", result));


            Console.WriteLine("\nDone.");
        }
    }
}
