using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace miniTodo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Todos { get; } = new ObservableCollection<string>();

        private string newTodoText;
        public string NewTodoText
        {
            get => newTodoText;
            set
            {
                newTodoText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewTodoText)));
            }
        }

        public ICommand AddTodoCommand { get; }
        public ICommand RemoveTodoCommand { get; }  // новая команда

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            AddTodoCommand = new RelayCommand(AddTodo);
            RemoveTodoCommand = new RelayCommand<string>(RemoveTodo); // команда с параметром
        }

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoText)) {
                Todos.Add(NewTodoText);
                NewTodoText = "";
            }
        }

        private void RemoveTodo(string item)
        {
            if (Todos.Contains(item))
                Todos.Remove(item);
        }
    }
}
