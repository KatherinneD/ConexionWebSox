using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ConexionWeb.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IConexionSOXService
    {
        [OperationContract]
        IList<OpcionCampoMatriz> ObtenerOpcionesCampo();

        [OperationContract]
        OpcionCampoMatriz ObtenerOpcionCampo(string codigo);

        [OperationContract]
        string CrearActualizarOpcionCampo(OpcionCampoMatriz opcion);

        [OperationContract]
        IList<CampoMatriz> ObtenerCampos();

        [OperationContract]
        CampoMatriz ObtenerCampo(string codigo);

        [OperationContract]
        string CrearActualizarCampo(CampoMatriz campo);


        [OperationContract]
        IList<Roles> ObtenerRoles();

        [OperationContract]
        Roles ObtenerRol(string idRol);

        [OperationContract]
        string CrearActualizarRol(Roles rol);

        [OperationContract]
        MatrizControlesPorAprobar ObtenerMatrizControlPorAprobar(string codigo);

        [OperationContract]
        string CrearActualizarMatrizControlPorAprobar(MatrizControlesPorAprobar matriz);

        [OperationContract]
        IList<MatrizControles> ObtenerMatricesControl();

        [OperationContract]
        MatrizControles ObtenerMatrizControl(string codigo);

        [OperationContract]
        string CrearActualizarMatrizControl(MatrizControles matriz);


        [OperationContract]
        IList<ActividadControl> ObtenerActividadesControl();

        [OperationContract]
        ActividadControl ObtenerActividadControl(string codigo);

        [OperationContract]
        string CrearActualizarActividadControl(ActividadControl aplicacion);

        [OperationContract]
        string ProcesarArchivoActividadControl(string nombreArchivo, byte[] bytes);

        [OperationContract]
        string ProcesarArchivoControl(string nombreArchivo, byte[] bytes);

        [OperationContract]
        IList<Aplicaciones> ObtenerAplicaciones();

        [OperationContract]
        Aplicaciones ObtenerAplicacion(string codigo);

        [OperationContract]
        string CrearActualizarAplicacion(Aplicaciones aplicacion);

        [OperationContract]
        string ProcesarArchivoAplicaciones(string nombreArchivo, byte[] bytes);


        [OperationContract]
        IList<PuntoControl> ObtenerPuntosControl();

        [OperationContract]
        int ObtenerConsecutivoPuntoControl();

        [OperationContract]
        PuntoControl ObtenerPuntoControl(int codigo);

        [OperationContract]
        string CrearActualizarPuntosControl(PuntoControl puntoControl);

        [OperationContract]
        string ProcesarArchivPuntosControl(string nombreArchivo, byte[] bytes);


        [OperationContract]
        IList<ObjetivoControl> ObtenerObjetivosControl();

        [OperationContract]
        int ObtenerConsecutivoObjetivoControl();

        [OperationContract]
        ObjetivoControl ObtenerObjetivoControl(int codigo);

        [OperationContract]
        string CrearActualizarObjetivosControl(ObjetivoControl objetivoControl);

        [OperationContract]
        string ProcesarArchivoObjetivosControl(string nombreArchivo, byte[] bytes);


        [OperationContract]
        IList<Jefatura> ObtenerJefaturas();

        [OperationContract]
        Jefatura ObtenerJefatura(string codigoArea);

        [OperationContract]
        string CrearActualizarJefatura(Jefatura Jefatura);

        [OperationContract]
        string ProcesarArchivoJefaturas(string nombreArchivo, byte[] bytes);

        [OperationContract]
        IList<RiesgoCorporativo> ObtenerRiesgosCorporativos();

        [OperationContract]
        IList<RiesgoSOX> ObtenerRiesgosSOX();

        [OperationContract]
        IList<Gobierno> ObtenerRegistrosGobierno();

        [OperationContract]
        string ProcesarRiesgosCorporativos(string nombreArchivo, byte[] bytes);

        [OperationContract]
        string ProcesarArchivoGobierno(string nombreArchivo, byte[] bytes);

        [OperationContract]
        RiesgoSOX ObtenerRiesgoSOX(string codigoRiesgo);


        [OperationContract]
        Gobierno ObtenerRegistroGobierno(string codigo);

        [OperationContract]
        string CrearActualizarRegistroGobierno(Gobierno gobierno);

        [OperationContract]
        string CrearActualizarRiesgoSOX(RiesgoSOX riesgo);
        [OperationContract]
        IList<Control> ObtenerControles();

        [OperationContract]
        Control ObtenerControl(string codigo);

        [OperationContract]
        string CrearActualizarControl(Control aplicacion);

        [OperationContract]
        IList<Servidores> ObtenerServidores();

        [OperationContract]
        Servidores ObtenerServidor(string codigo);

        [OperationContract]
        string CrearActualizarServidor(Servidores servidor);
    }
}
