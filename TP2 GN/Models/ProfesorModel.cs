using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string _posicion;
        private string _nivelEnsenanza;
        private string _materia;
        private List<string> _diasClase;
        private List<string> _turnos;
        private int _cantidadHoras;
        private decimal _valorHoraCatedra;

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
                else
                    throw new ArgumentException("El nombre no puede estar vacío.");
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
                else
                    throw new ArgumentException("El apellido no puede estar vacío.");
                OnPropertyChanged(nameof(Apellido));
            }
        }

        public string Materia
        {
            get => _materia;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _materia = value;
                else
                    throw new ArgumentException("La materia no puede estar vacía.");
                OnPropertyChanged(nameof(Materia));
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
                    throw new ArgumentException("El domicilio no puede estar vacío.");
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
                    throw new ArgumentException("La localidad no puede estar vacía.");
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
                    throw new ArgumentException("La provincia no puede estar vacía.");
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
                    throw new ArgumentException("El número de celular no puede estar vacío.");
                OnPropertyChanged(nameof(NroCelular));
            }
        }
        public string Email
        {
            get => _email;
            set {
                if (!string.IsNullOrWhiteSpace(value))
                    _email = value;
                else throw new ArgumentException("Esnecesario indicar un correo electrónico.");
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
                    throw new ArgumentException("La categoría no puede estar vacía.");
                OnPropertyChanged(nameof(Categoria));
            }
        }

        public string Posicion
        {
            get => _posicion;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _posicion = value;
                else
                    throw new ArgumentException("La posición no puede estar vacía.");
                OnPropertyChanged(nameof(Posicion));
            }
        }

        public List<string> DiasClase
        {
            get => _diasClase;
            set
            {
                _diasClase = value; // Asigna directamente, permitiendo que pueda ser nulo o vacío
                OnPropertyChanged(nameof(DiasClase)); // Notifica el cambio siempre que se establezca un nuevo valor
            }
        }

        public int CantidadHoras
        {
            get => _cantidadHoras;
            set
            {
                if (value >= 0)
                    _cantidadHoras = value;
                else
                    throw new ArgumentException("La cantidad de horas debe ser positiva.");
                OnPropertyChanged(nameof(CantidadHoras));
            }
        }

        public decimal ValorHoraCatedra
        {
            get => _valorHoraCatedra;
            set
            {
                if (value >= 0)
                    _valorHoraCatedra = value;
                else
                    throw new ArgumentException("El valor por hora cátedra debe ser positivo.");
                OnPropertyChanged(nameof(ValorHoraCatedra));
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
                    throw new ArgumentException("El nivel de enseñanza no puede estar vacío.");
                OnPropertyChanged(nameof(NivelEnsenanza));
            }
        }

        public List<string> Turnos
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
            DiasClase = new List<string>(); // Inicializa la lista
        }

        public ProfesorModel(int id, string nombre, string apellido, string domicilio, string localidad, string provincia,
                        string nroCelular, string email, string categoria, string posicion, string nivelEnsenanza, 
                        string materia, List<string> diasClase, List<string> turnos, 
                        int cantidadHoras, decimal valorHoraCatedra) : this()
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
            Posicion = posicion;
            NivelEnsenanza = nivelEnsenanza;
            Materia = materia;
            DiasClase = diasClase;
            Turnos = turnos;
            CantidadHoras = cantidadHoras;
            ValorHoraCatedra = valorHoraCatedra;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Materia: {Materia} - {NivelEnsenanza}";
        }
    }
}