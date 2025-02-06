using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GN.Utilities;

namespace TP2_GN.Models
{
    public class ProfesorModel : INotifyPropertyChanged
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _domicilio;
        private string _localidad;
        private string _provincia;
        private string _nroCelular;
        private string _email;
        private string _categoria;
        private string _nivelEnsenanza;
        private List<MateriasEnum> _materias;
        private List<DiasSemanaEnum> _diasClase;
        private List<TurnosEnum> _turnos;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _apellido = value;
                OnPropertyChanged(nameof(Apellido));
            }
        }

        public string Domicilio
        {
            get => _domicilio;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _domicilio = value;
                else
                    _domicilio = string.Empty;
                OnPropertyChanged(nameof(Domicilio));
            }
        }

        public string Localidad
        {
            get => _localidad;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _localidad = value;
                else
                    _localidad = string.Empty;
                OnPropertyChanged(nameof(Localidad));
            }
        }

        public string Provincia
        {
            get => _provincia;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _provincia = value;
                else
                    _provincia = string.Empty;
                OnPropertyChanged(nameof(Provincia));
            }
        }

        public string NroCelular
        {
            get => _nroCelular;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _nroCelular = value;
                else
                    _nroCelular = string.Empty;
                OnPropertyChanged(nameof(NroCelular));
            }
        }
        public string Email
        {
            get => _email;
            set {
                if (!string.IsNullOrWhiteSpace(value))
                    _email = value;
                else
                    _email = string.Empty;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Categoria
        {
            get => _categoria;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _categoria = value;
                else
                    _categoria = string.Empty;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        public string NivelEnsenanza
        {
            get => _nivelEnsenanza;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _nivelEnsenanza = value;
                else
                    _nivelEnsenanza = string.Empty;
                OnPropertyChanged(nameof(NivelEnsenanza));
            }
        }
        public List<MateriasEnum> Materias
        {
            get => _materias;
            set
            {
                _materias = value; // Asigna directamente, permitiendo que pueda ser nulo o vacío
                OnPropertyChanged(nameof(Materias)); // Notifica el cambio siempre que se establezca un nuevo valor
            }
        }
        public List<DiasSemanaEnum> DiasClase
        {
            get => _diasClase;
            set
            {
                _diasClase = value; // Asigna directamente, permitiendo que pueda ser nulo o vacío
                OnPropertyChanged(nameof(DiasClase)); // Notifica el cambio siempre que se establezca un nuevo valor
            }

        }
        public List<TurnosEnum> Turnos
        {
            get => _turnos;
            set
            {
                _turnos = value;
                OnPropertyChanged(nameof(Turnos));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Constructor opcional
        public ProfesorModel()
        {
            DiasClase = new List<DiasSemanaEnum>(); // Inicializa la lista
            Turnos = new List<TurnosEnum>();
            Materias = new List<MateriasEnum>();
        }

        public ProfesorModel(int id, string nombre, string apellido, string domicilio, string localidad, string provincia,
                        string nroCelular, string email, string categoria, string nivelEnsenanza,
                        List<MateriasEnum> materias, List<DiasSemanaEnum> diasClase, List<TurnosEnum> turnos) : this()
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Domicilio = domicilio;
            Localidad = localidad;
            Provincia = provincia;
            NroCelular = nroCelular;
            Email = email;
            Categoria = categoria;
            NivelEnsenanza = nivelEnsenanza;
            Materias = materias;
            DiasClase = diasClase;
            Turnos = turnos;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Materia/s: {Materias} - {NivelEnsenanza}";
        }
    }
}