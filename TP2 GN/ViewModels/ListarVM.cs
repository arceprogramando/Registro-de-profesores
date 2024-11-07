using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP2_GN.Commands;
using TP2_GN.DataBase;
using TP2_GN.Models;

namespace TP2_GN.ViewModels
{
    internal class ListarVM : ViewModelBase
    {

        private ProfesorModel _profesorSeleccionado;

        private readonly DB dataBase;
        private ObservableCollection<ProfesorModel> _profesores;

        public ICommand ListarCommand { get; }

        public ListarVM()
        {
            dataBase = new DB();
            ListarCommand = new RelayCommand(ListarProfesores);
        }

        public ProfesorModel Profesor
        {
            get => _profesorSeleccionado;
            set
            {
                _profesorSeleccionado = value;
                OnPropertyChanged(nameof(Profesor));
            }
        }

        public ObservableCollection<ProfesorModel> Profesores
        {
            get => _profesores;
            set
            {
                if (_profesores != value)
                {
                    _profesores = value;
                    OnPropertyChanged(nameof(Profesores));
                }
            }

        }

        private void ListarProfesores(object parameter = null)
        {
            // Supongamos que tienes un método en dataBase que obtiene la lista de profesores
            Profesores = new ObservableCollection<ProfesorModel>(dataBase.Get());
        }

    }
}
