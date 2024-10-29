using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TP2_GN.Commands;
using TP2_GN.DataBase;
using TP2_GN.Models;

namespace TP2_GN.ViewModels
{
    internal class ProfesorViewModel : ViewModelBase
    {

        private readonly DB dataBase;
        private ObservableCollection<ProfesorModel> _profesores;
        private ObservableCollection<string> _provincias;
        private ProfesorModel _profesor;

        // Comandos para agregar, eliminar y actualizar profesores
        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand ActualizarCommand { get; }


        public ProfesorViewModel()
        {
            dataBase = new DB();
            AgregarCommand = new RelayCommand(Agregar);
            _profesor = new ProfesorModel();
            _profesores = dataBase.Get();
            CargarProvincias();
            
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

        // Método para agregar un nuevo profesor
        private void Agregar(object profesor)
        {
            if (IsValidProfesor(Profesor))
            {
                try
                {
                    dataBase.Add(Profesor); // Agrega el objeto a la base de datos
                    Profesores.Add(Profesor); // Agrega a la lista en memoria
                    Profesor = new ProfesorModel(); // Resetea el profesor seleccionado
                    MessageBox.Show("Profesor guardado correctamente");
                }
                catch (Exception ex) // Manejo de excepciones
                {
                    MessageBox.Show($"Error al agregar el profesor: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Error: No se pudo guardar");
            }
        }

        // Método de validación personalizado
        private bool IsValidProfesor(ProfesorModel profesor)
        {
            // Primero verifica que el objeto profesor no sea null
            if (profesor == null) return false;

            // Despues verifica que las propiedades obligatorias no sean nulas o vacías
            if (string.IsNullOrWhiteSpace(profesor.Nombre))
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(profesor.Apellido))
            {
                MessageBox.Show("El campo 'Apellido' es obligatorio.");
                return false;
            }

            return true;
        }


        public string Nombre
        {
            get => Profesor.Nombre;
            set
            {
                if (Profesor.Nombre != value)
                {
                    Profesor.Nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }


        public string Apellido
        {
            get => Profesor.Apellido;
            set
            {
                if (Profesor.Apellido != value)
                {
                    Profesor.Apellido = value;
                    OnPropertyChanged(nameof(Apellido));
                }
            }
        }

        public string Domicilio
        {
            get => Profesor.Domicilio;
            set
            {
                if (Profesor.Domicilio != value)
                {
                    Profesor.Domicilio = value;
                    OnPropertyChanged(nameof(Domicilio));
                }
            }
        }


        public string Localidad
        {
            get => Profesor.Localidad;
            set
            {
                if (Profesor.Localidad != value)
                {
                    Profesor.Localidad = value;
                    OnPropertyChanged(nameof(Localidad));
                }
            }
        }

        public string Provincia
        {
            get => Profesor.Provincia;
            set
            {
                if (Profesor.Provincia != value)
                {
                    Profesor.Provincia = value;
                    OnPropertyChanged(nameof(Provincia));
                }
            }
        }

        public string NroCelular
        {
            get => Profesor.NroCelular;
            set
            {
                if (Profesor.NroCelular != value)
                {
                    Profesor.NroCelular = value;
                    OnPropertyChanged(nameof(NroCelular));
                }
            }
        }

        public string Email
        {
            get => Profesor.Email;
            set
            {
                if (Profesor.Email != value)
                {
                    Profesor.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Categoria
        {
            get => Profesor.Categoria;
            set
            {
                if (Profesor.Categoria != value)
                {
                    Profesor.Categoria = value;
                    OnPropertyChanged(nameof(Categoria));
                }
            }
        }

        public string Posicion
        {
            get => Profesor.Posicion;
            set
            {
                if (Profesor.Posicion != value)
                {
                    Profesor.Posicion = value;
                    OnPropertyChanged(nameof(Posicion));
                }
            }
        }
        public string NivelEnsenanza
        {
            get => Profesor.NivelEnsenanza;
            set
            {
                if (Profesor.NivelEnsenanza != value)
                {
                    Profesor.NivelEnsenanza = value;
                    OnPropertyChanged(nameof(NivelEnsenanza));
                }
            }
        }

        public string Materia
        {
            get => Profesor.Materia;
            set
            {
                if (Profesor.Materia != value)
                {
                    Profesor.Materia = value;
                    OnPropertyChanged(nameof(Materia));
                }
            }
        }

        public List<string> DiasClase
        {
            get => Profesor.DiasClase;
            set
            {
                if (Profesor.DiasClase != value)
                {
                    Profesor.DiasClase = value;
                    OnPropertyChanged(nameof(DiasClase));
                }
            }
        }

        public List<string> Turnos
        {
            get => Profesor.Turnos;
            set
            {
                if (Profesor.Turnos != value)
                {
                    Profesor.Turnos = value;
                    OnPropertyChanged(nameof(Turnos));
                }
            }
        }
        public ObservableCollection<string> Provincias
        {
            get => _provincias;
            set
            {
                _provincias = value;
                OnPropertyChanged(nameof(Provincias));
            }
        }

        private void CargarProvincias()
        {
            Provincias = new ObservableCollection<string>
            {
                "Buenos Aires",
                "Catamarca",
                "Chaco",
                "Chubut",
                "Córdoba",
                "Corrientes",
                "Entre Ríos",
                "Formosa",
                "Jujuy",
                "La Pampa",
                "La Rioja",
                "Mendoza",
                "Misiones",
                "Neuquén",
                "Río Negro",
                "Salta",
                "San Juan",
                "San Luis",
                "Santa Cruz",
                "Santa Fe",
                "Santiago Del Estero",
                "Tierra Del Fuego",
                "Tucumán",
            };
        }

        // Propiedades booleanas para el checkbox de días laborales
        private bool _diasClaseLunes;
        public bool DiasClaseLunes
        {
            get { return _diasClaseLunes; }
            set
            {
                _diasClaseLunes = value;
                OnPropertyChanged(nameof(DiasClaseLunes));
            }
        }

        private bool _diasClaseMartes;
        public bool DiasClaseMartes
        {
            get { return _diasClaseMartes; }
            set
            {
                _diasClaseMartes = value;
                OnPropertyChanged(nameof(DiasClaseMartes));
            }
        }

        private bool _diasClaseMiercoles;
        public bool DiasClaseMiercoles
        {
            get { return _diasClaseMiercoles; }
            set
            {
                _diasClaseMiercoles = value;
                OnPropertyChanged(nameof(DiasClaseMiercoles));
            }
        }

        private bool _diasClaseJueves;
        public bool DiasClaseJueves
        {
            get { return _diasClaseJueves; }
            set
            {
                _diasClaseJueves = value;
                OnPropertyChanged(nameof(DiasClaseJueves));
            }
        }

        private bool _diasClaseViernes;
        public bool DiasClaseViernes
        {
            get { return _diasClaseViernes; }
            set
            {
                _diasClaseViernes = value;
                OnPropertyChanged(nameof(DiasClaseViernes));
            }
        }

        private bool _diasClaseSabado;
        public bool DiasClaseSabado
        {
            get { return _diasClaseSabado; }
            set
            {
                _diasClaseSabado = value;
                OnPropertyChanged(nameof(DiasClaseSabado));
            }
        }

        // Propiedades booleanas para el checkbox de turnos
        private bool _turnoManana;
        public bool TurnoManana
        {
            get { return _turnoManana; }
            set
            {
                _turnoManana = value;
                OnPropertyChanged(nameof(TurnoManana));
            }
        }

        private bool _turnoTarde;
        public bool TurnoTarde
        {
            get { return _turnoTarde; }
            set
            {
                _turnoTarde = value;
                OnPropertyChanged(nameof(TurnoTarde));
            }
        }

        private bool _turnoNoche;
        public bool TurnoNoche
        {
            get { return _turnoNoche; }
            set
            {
                _turnoNoche = value;
                OnPropertyChanged(nameof(TurnoNoche));
            }
        }


        // Método para eliminar el profesor seleccionado
        private void Eliminar()
        {
            dataBase.Delete(Profesor);
            Profesores.Remove(Profesor); // Remueve de la colección
            Profesor = new ProfesorModel(); // Resetea la selección
        }

        // Método para actualizar la información de un profesor
        private void Actualizar()
        {
            dataBase.Edit(Profesor);
            Profesores = dataBase.Get(); // Refresca la lista
            OnPropertyChanged(nameof(Profesores)); // Notifica el cambio
        }

        // Validación de eliminación y actualización
        private bool CanEliminarProfesor() => Profesor != null && Profesor.Id > 0;
        private bool CanActualizarProfesor() => Profesor != null && Profesor.Id > 0;


    }
}
