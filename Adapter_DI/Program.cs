using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Features.Metadata;

namespace Adapter_DI
{
    public interface ICommand
    {
        void Execute();
    }
    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("save file");
        }
    }
    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("open file");
        }
    }
    public class Button
    {
        private ICommand command;
        public string name;
        public Button(ICommand command, string name)
        {
            this.command = command;
            this.name = name;
        }
        public void click()
        {
            command.Execute();
        }
        public void printme()
        {
            Console.WriteLine($"print button called {name}");
        }
    }
    public class Editor
    {
        private IEnumerable<Button> buttons;
        public IEnumerable<Button> Buttons => buttons;
        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons;
        }
        public void ClickAll()
        {
            foreach (var btn in buttons)
            {
                btn.click();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
            b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            //b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();
            
            using(var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();
                foreach (var btn in editor.Buttons)
                {
                    btn.printme();
                }
            }
        }
    }
}
