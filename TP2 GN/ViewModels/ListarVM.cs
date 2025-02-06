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
using TP2_GN.Views;

namespace TP2_GN.ViewModels
{
    internal class ListarVM : ViewModelBase
    {

        private readonly DB dataBase;
        private ProfesorModel _profesor;
        private ObservableCollection<ProfesorModel> _profesores;

        public ListarVM()
        {
            dataBase = new DB();
            _profesor = new ProfesorModel();
            _profesores = dataBase.Get();
        }

        public ProfesorModel Profesor
        {
            get => _profesor;
            set
            {
                if (_profesor != value)
                {
                    _profesor = value;
                    OnPropertyChanged(nameof(Profesor));
                }
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

        public IEnumerable<ProfesorModel> FiltrarPorId(int id)
        {
            return Profesores.Where(p => p.Id == id);   
        }

        public IEnumerable<ProfesorModel> FiltrarPorNombre(string nombre)
        {
            return Profesores.Where(p => p.Nombre == nombre);
        }

        public IEnumerable<ProfesorModel> FiltrarPorApellido(string apellido)
        {
            return Profesores.Where(p => p.Apellido == apellido);
        }

        public IEnumerable<string> ObtenerNombresOrdenados()
        {
            return Profesores
                .OrderBy(p => p.Nombre)
                .Select(p => p.Nombre);
        }

    }
}
