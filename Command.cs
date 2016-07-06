﻿using System;

namespace Patterns.Behavioral.Command
{
    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }
                
        public override void Execute()
        {
            receiver.Action();
        }
    }
        
    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }
    
    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }


}
