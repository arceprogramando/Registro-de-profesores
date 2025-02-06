using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GN.DataBase;
using TP2_GN.Models;

namespace TP2_GN.ViewModels
{
    internal class EliminarVM : ViewModelBase
    {

        private readonly DB database;
        private ObservableCollection<ProfesorModel> _profesores;

        public EliminarVM()
        {
            database = new DB();
            _profesores = database.Get();
        }

        public ObservableCollection<ProfesorModel> Profesores
        {
            get => _profesores;
            set
            {
                if (_profesores != null)
                {
                    _profesores = value;
                    OnPropertyChanged(nameof(Profesores));
                }
            }
        }




    }
}
