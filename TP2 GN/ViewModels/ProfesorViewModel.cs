using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using TP2_GN.Commands;
using TP2_GN.DataBase;
using TP2_GN.Models;
using TP2_GN.Utilities;

namespace TP2_GN.ViewModels
{
    internal class ProfesorViewModel : ViewModelBase
    {

        private readonly DB dataBase;
        private ProfesorModel _profesor;
        private ObservableCollection<ProfesorModel> _profesores;
        private ObservableCollection<string> _provincias;
        private ObservableCollection<string> _categorias;
        private ObservableCollection<string> _nivelesEnsenanza;
        public List<DiasSemanaEnum> DiasSemanaList { get; } = Enum.GetValues(typeof(DiasSemanaEnum)).Cast<DiasSemanaEnum>().ToList();
        public List<TurnosEnum> TurnosList { get; } = Enum.GetValues(typeof(TurnosEnum)).Cast<TurnosEnum>().ToList();

        public List<MateriasEnum> MateriasList { get; } = Enum.GetValues(typeof(MateriasEnum)).Cast<MateriasEnum>().ToList();


        // Comandos para agregar, listar, eliminar y actualizar profesores
        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand ActualizarCommand { get; }
        public ICommand ToggleSeleccionCommand { get; }

        public ProfesorViewModel()
        {
            // Instancias necesarias
            dataBase = new DB();
            AgregarCommand = new RelayCommand(Agregar);
            EliminarCommand = new RelayCommand(Eliminar);
            _profesor = new ProfesorModel();
            _profesores = dataBase.Get();

            // Cargo mis métodos para bindings
            CargarProvincias();
            CargarCategorias();
            CargarNivelesEnsenanza();
        }

        public ProfesorModel Profesor
        {
            get => _profesor;
            set
            {
                _profesor = value;
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

        // Método para agregar un nuevo profesor
        private void Agregar(object profesor)
        {
            if (IsValidProfesor(Profesor))
            {
                try
                {

                    dataBase.Add(Profesor); // Agrega el objeto a la base de datos
                    Profesores.Add(Profesor); // Agrega a la lista en memoria

                    MessageBox.Show("Profesor guardado correctamente");

                    Profesor = new ProfesorModel(); // Resetea el profesor seleccionado

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

        private bool IsValidProfesor(ProfesorModel profesor)
        {
            if (string.IsNullOrWhiteSpace(profesor.Nombre) || profesor == null)
            {
                MessageBox.Show("Debes llenar los campos obligatorios.");
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

        public List<MateriasEnum> Materias
        {
            get => Profesor.Materias;
            set
            {
                if (Profesor?.Materias != value)
                {
                    Profesor.Materias = value;
                    OnPropertyChanged(nameof(Materias));
                }
            }
        }

        // Métodos para añadir o eliminar un item cuando se selecciona o deselecciona
        public void ToggleMateriaSeleccionada(MateriasEnum materia, bool isSelected)
        {
            if(isSelected)
            {
                if (!Materias.Contains(materia))
                {
                    Materias.Add(materia);
                    OnPropertyChanged(nameof(Materias));
                }
                else
                {
                    if (Materias.Contains(materia))
                    {
                        Materias.Remove(materia);
                        OnPropertyChanged(nameof(Materias));
                    }
                }
            }
        }

        public List<DiasSemanaEnum> DiasClase
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

        public void ToggleDiaSeleccionado(DiasSemanaEnum dia, bool isSelected)
        {
            if (isSelected)
            {
                if (!DiasClase.Contains(dia))
                {
                    DiasClase.Add(dia);
                    OnPropertyChanged(nameof(DiasClase));
                }
            }
            else
            {
                if (DiasClase.Contains(dia))
                {
                    DiasClase.Remove(dia);
                    OnPropertyChanged(nameof(DiasClase));
                }
            }
        }

        public void ToggleTurnoSeleccionado(TurnosEnum turno, bool isSelected)
        {
            if (isSelected)
            {
                if (!Turnos.Contains(turno))
                {
                    Turnos.Add(turno);
                    OnPropertyChanged(nameof(Turnos));
                }
            }
            else
            {
                if (Turnos.Contains(turno))
                {
                    Turnos.Remove(turno);
                    OnPropertyChanged(nameof(Turnos));
                }
            }
        }

        public List<TurnosEnum> Turnos
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
                    "Tucumán"
                };
        }

        public ObservableCollection<string> Categorias
        {
            get => _categorias;
            set
            {
                _categorias = value;
                OnPropertyChanged(nameof(Categorias));
            }
        }

        private void CargarCategorias()
        {
            Categorias = new ObservableCollection<string>
                {
                    "Profesor",
                    "Ayudante",
                    "Jefe de Trabajos Prácticos",
                    "Investigador",
                    "Invitado",
                    "Asistente de Cátedra",
                    "Tutor",
                    "Coordinador Académico"
                };
        }

        public ObservableCollection<string> NivelesEnsenanza
        {
            get => _nivelesEnsenanza;
            set
            {
                _nivelesEnsenanza = value;
                OnPropertyChanged(nameof(NivelesEnsenanza));
            }
        }

        private void CargarNivelesEnsenanza()
        {
            NivelesEnsenanza = new ObservableCollection<string>
                {
                    "Universitario",
                    "Secundario",
                    "Primario",
                    "Inicial"
                };
        } 

        // Método para eliminar el profesor seleccionado
        private void Eliminar(object profesor)
        {
            if (Profesor != null)
            {
                // Elimina el profesor de la base de datos
                dataBase.Delete(Profesor);

                // Elimina el profesor de la colección en la vista
                Profesores.Remove(Profesor);

                // Limpia la selección
                Profesor = null;
            }
        }


    }
}
