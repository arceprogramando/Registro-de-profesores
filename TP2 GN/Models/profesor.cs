using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace TP2_GN.Models
{
    public class Profesor
    {

        // Atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _materia;
        private string _domicilio;
        private string _localidad;
        private string _provincia;
        private string _nroCelular;
        private string _categoria;
        private string _posicion;
        private string _diasClase;
        private int _cantidadHoras;
        private decimal _valorHoraCatedra;
        private string _nivelEnsenanza;
        private DateTime _horario;

        // Propiedades públicas con encapsulamiento
        public int Id
        {
            get => _id;
            set => _id = value;
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
            }
        }

        public string DiasClase
        {
            get => _diasClase;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _diasClase = value;
                else
                    throw new ArgumentException("Los días de clase no pueden estar vacíos.");
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
            }
        }

        public DateTime Horario
        {
            get => _horario;
            set => _horario = value;
        }

        // Constructor opcional
        public Profesor() { }

        public Profesor(int id, string nombre, string apellido, string materia, string domicilio, string localidad, string provincia,
                        string nroCelular, string categoria, string posicion, string diasClase, int cantidadHoras,
                        decimal valorHoraCatedra, string nivelEnsenanza, DateTime horario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Materia = materia;
            Domicilio = domicilio;
            Localidad = localidad;
            Provincia = provincia;
            NroCelular = nroCelular;
            Categoria = categoria;
            Posicion = posicion;
            DiasClase = diasClase;
            CantidadHoras = cantidadHoras;
            ValorHoraCatedra = valorHoraCatedra;
            NivelEnsenanza = nivelEnsenanza;
            Horario = horario;
        }

        // Método sobrescrito (opcional)
        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Materia: {Materia} - {NivelEnsenanza}";
        }

    }
}