using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_GN.Utilities
{
    public enum MateriasEnum
    {

        [Description("Arquitectura y sistemas operativos")]
        ArquitecturaYSO,
        [Description("Base de datos I")]
        BaseDeDatosI,
        [Description("Base de datos II")]
        BaseDeDatosII,
        [Description("Formalización de algoritmos")]
        FormalizacionDeAlgoritmos,
        [Description("Gestión de desarrollo de software")]
        GestionDeDesarrolloDeSO,
        [Description("Inglés I")]
        InglesI,
        [Description("Inglés II")]
        InglesII,
        [Description("Introducción al análisis de datos")]
        IntroduccionAlAnalisisDeDatos,
        [Description("Lectura comprensiva")]
        LecturaComprensiva,
        [Description("Legislación")]
        Legislacion,
        [Description("Matemática inicial")]
        MatematicaInicial,
        [Description("Matemática")]
        Matematica,
        [Description("Metodología de sistemas I")]
        MetodologiaDeSistemasI,
        [Description("Metodología de sistemas II")]
        MetodologiaDeSistemasII,
        [Description("Organización empresarial")]
        OrganizacionEmpresarial,
        [Description("Probabilidad y estadística")]
        ProbabilidadYEstadistica,
        [Description("Programación I")]
        ProgramacionI,
        [Description("Programación II")]
        ProgramacionII,
        [Description("Programación III")]
        ProgramacionIII,
        [Description("Programación IV")]
        ProgramacionIV,
        [Description("Trabajo final integrador")]
        TrabajoFinalIntegrador
       
    }
}
