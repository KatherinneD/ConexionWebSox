using ConexionWeb.Bussiness;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;

namespace ConexionWeb.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ConexionSOXService : IConexionSOXService
    {
        public string CrearActualizarActividadControl(ActividadControl aplicacion)
        {
            var actividadControlBL = new ActividadControlBL();
            return actividadControlBL.CrearActualizarActividadControl(aplicacion);
        }

        public string CrearActualizarAplicacion(Aplicaciones aplicacion)
        {
            var aplicacionesBL = new AplicacionesBL();
            return aplicacionesBL.CrearActualizarAplicacion(aplicacion);
        }

        public string CrearActualizarCampo(CampoMatriz campo)
        {
            var camposBL = new CampoMatrizBL();
            return camposBL.CrearActualizarCampos(campo);
        }

        public string CrearActualizarJefatura(Jefatura Jefatura)
        {
            var jefaturaBL = new JefaturaBL();
            return jefaturaBL.CrearActualizarJefatura(Jefatura);
        }

        public string CrearActualizarMatrizControl(MatrizControles matriz)
        {
            var matrizBL = new MatrizControlesBL();
            return matrizBL.CrearActualizarMatrizControles(matriz);
        }

        public string CrearActualizarMatrizControlPorAprobar(MatrizControlesPorAprobar matriz)
        {
            var matrizBL = new MatrizControlesPorAprobarBL();
            return matrizBL.CrearActualizarMatrizControlesPorAprobar(matriz);
        }

        public string CrearActualizarObjetivosControl(ObjetivoControl objetivoControl)
        {
            var objetivoControlBL = new ObjetivoControlBL();
            return objetivoControlBL.CrearActualizarObjetivoControl(objetivoControl);
        }

        public string CrearActualizarOpcionCampo(OpcionCampoMatriz opcion)
        {
            var camposBL = new OpcionCampoBL();
            return camposBL.CrearActualizarOpciones(opcion);
        }

        public string CrearActualizarPuntosControl(PuntoControl puntoControl)
        {
            var puntoControlBL = new PuntoControlBL();
            return puntoControlBL.CrearActualizarPuntoControl(puntoControl);
        }

        public string CrearActualizarRegistroGobierno(Gobierno gobierno)
        {
            var gobiernoBL = new GobiernoBL();
            return gobiernoBL.CrearActualizarRegistroGobierno(gobierno);
        }

        public string CrearActualizarRiesgoSOX(RiesgoSOX riesgo)
        {
            var riesgoSOXBL = new RiesgoSOXBL();
            return riesgoSOXBL.CrearActualizarRiesgoSOX(riesgo);
        }

        public string CrearActualizarRol(Roles rol)
        {
            var rolesBL = new RolesBL();
            return rolesBL.CrearActualizarRoles(rol);
        }

        public ActividadControl ObtenerActividadControl(string codigo)
        {
            var actividadControlBL = new ActividadControlBL();
            return actividadControlBL.ObtenerActividadControl(codigo);
        }

        public IList<ActividadControl> ObtenerActividadesControl()
        {
            var actividadControlBL = new ActividadControlBL();
            return actividadControlBL.ObtenerActividadControles().ToList();
        }

        public Aplicaciones ObtenerAplicacion(string codigo)
        {
            var aplicacionesBL = new AplicacionesBL();
            return aplicacionesBL.ObtenerAplicacion(codigo);
        }

        public IList<Aplicaciones> ObtenerAplicaciones()
        {
            var aplicacionesBL = new AplicacionesBL();
            return aplicacionesBL.ObtenerAplicaciones().ToList();
        }

        public CampoMatriz ObtenerCampo(string codigo)
        {
            var camposBL = new CampoMatrizBL();
            return camposBL.ObtenerCampos(codigo);
        }

        public IList<CampoMatriz> ObtenerCampos()
        {
            var camposBL = new CampoMatrizBL();
            return camposBL.ObtenerCampoMatriz().ToList();
        }

        public Jefatura ObtenerJefatura(string codigoArea)
        {
            var jefaturaBL = new JefaturaBL();
            return jefaturaBL.ObtenerJefatura(codigoArea);
        }

        public IList<Jefatura> ObtenerJefaturas()
        {
            var jefaturaBL = new JefaturaBL();
            return jefaturaBL.ObtenerJefaturas().ToList();
        }

        public IList<MatrizControles> ObtenerMatricesControl()
        {
            var matrizBL = new MatrizControlesBL();
            return matrizBL.ObtenerTodosMatrizControles().ToList();
        }

        public MatrizControles ObtenerMatrizControl(string codigo)
        {
            var matrizBL = new MatrizControlesBL();
            return matrizBL.ObtenerMatrizControles(codigo);
        }

        public MatrizControlesPorAprobar ObtenerMatrizControlPorAprobar(string codigo)
        {
            var matrizBL = new MatrizControlesPorAprobarBL();
            return matrizBL.ObtenerMatrizControlesPorAprobar(codigo);
        }

        public ObjetivoControl ObtenerObjetivoControl(int codigo)
        {
            var objetivoControlBL = new ObjetivoControlBL();
            return objetivoControlBL.ObtenerObjetivoControl(codigo);
        }

        public int ObtenerConsecutivoObjetivoControl()
        {
            var objetivoControlBL = new ObjetivoControlBL();
            return objetivoControlBL.ObtenerNuevoCodigoObjetivoControl();
        }

        public IList<ObjetivoControl> ObtenerObjetivosControl()
        {
            var objetivoControlBL = new ObjetivoControlBL();
            return objetivoControlBL.ObtenerObjetivoControls().ToList();
        }

        public IList<OpcionCampoMatriz> ObtenerOpcionesCampo()
        {
            var opcionBL = new OpcionCampoBL();
            return opcionBL.ObtenerOpcionCampoMatriz().ToList();
        }

        public OpcionCampoMatriz ObtenerOpcionCampo(string codigo)
        {
            var opcionBL = new OpcionCampoBL();
            return opcionBL.ObtenerOpciones(codigo);
        }

        public int ObtenerConsecutivoPuntoControl()
        {
            var puntoControlBL = new PuntoControlBL();
            return puntoControlBL.ObtenerNuevoCodigoPuntoControl();
        }

        public PuntoControl ObtenerPuntoControl(int codigo)
        {
            var puntoControlBL = new PuntoControlBL();
            return puntoControlBL.ObtenerPuntoControl(codigo);
        }

        public IList<PuntoControl> ObtenerPuntosControl()
        {
            var puntoControlBL = new PuntoControlBL();
            return puntoControlBL.ObtenerPuntosControl().ToList();
        }

        public Gobierno ObtenerRegistroGobierno(string codigo)
        {
            var gobiernoBL = new GobiernoBL();
            return gobiernoBL.ObtenerRegistroGobierno(codigo);
        }

        public IList<Gobierno> ObtenerRegistrosGobierno()
        {
            var gobiernoBL = new GobiernoBL();
            return gobiernoBL.ObtenerListadoGobierno().ToList();
        }

        public IList<RiesgoCorporativo> ObtenerRiesgosCorporativos()
        {
            var riesgoBL = new RiesgoCorporativoBL();
            return riesgoBL.ObtenerRiesgos().ToList();
        }

        public RiesgoSOX ObtenerRiesgoSOX(string codigoRiesgo)
        {
            var riesgoSOXBL = new RiesgoSOXBL();
            return riesgoSOXBL.ObtenerRiesgoSOX(codigoRiesgo);
        }

        public IList<RiesgoSOX> ObtenerRiesgosSOX()
        {
            var riesgoSOXBL = new RiesgoSOXBL();
            return riesgoSOXBL.ObtenerRiesgosSOX().ToList();
        }

        public Roles ObtenerRol(string idRol)
        {
            var rolesBL = new RolesBL();
            return rolesBL.ObtenerRol(idRol);
        }

        public IList<Roles> ObtenerRoles()
        {
            var rolesBL = new RolesBL();
            return rolesBL.ObtenerRoles().ToList();
        }

        public string ProcesarArchivoActividadControl(string nombreArchivo, byte[] bytes)
        {
            var procesarActividadesControl = new ProcesarCSV();
            return procesarActividadesControl.ProcesarArchivoActividadControl(nombreArchivo, bytes);
        }

        public string ProcesarArchivoAplicaciones(string nombreArchivo, byte[] bytes)
        {
            var procesarAplicaciones  = new ProcesarCSV();
            return procesarAplicaciones.ProcesarAplicaciones(nombreArchivo, bytes);
        }

        public string ProcesarArchivoGobierno(string nombreArchivo, byte[] bytes)
        {
            var procesarRiesgos = new ProcesarCSV();
            return procesarRiesgos.ProcesarGobierno(nombreArchivo, bytes);
        }

        public string ProcesarArchivoJefaturas(string nombreArchivo, byte[] bytes)
        {
            var procesarRiesgos = new ProcesarCSV();
            return procesarRiesgos.ProcesarJefaturas(nombreArchivo, bytes);
        }

        public string ProcesarArchivoObjetivosControl(string nombreArchivo, byte[] bytes)
        {
            var procesarRiesgos = new ProcesarCSV();
            return procesarRiesgos.ProcesarObjetivosControl(nombreArchivo, bytes);
        }

        public string ProcesarArchivPuntosControl(string nombreArchivo, byte[] bytes)
        {
            var procesarRiesgos = new ProcesarCSV();
            return procesarRiesgos.ProcesarPuntosControl(nombreArchivo, bytes);
        }

        public string ProcesarRiesgosCorporativos(string nombreArchivo, byte[] bytes)
        {
            var procesarRiesgos = new ProcesarCSV();
            return procesarRiesgos.ProcesarRiesgosCorporativos(nombreArchivo, bytes);
        }

        public Control ObtenerControl(string codigo)
        {
            var controlBL = new ControlBL();
            return controlBL.ObtenerControl(codigo);
        }

        public IList<Control> ObtenerControles()
        {
            var controlBL = new ControlBL();
            return controlBL.ObtenerControles().ToList();
        }

        public string CrearActualizarControl(Control aplicacion)
        {
            var controlBL = new ControlBL();
            return controlBL.CrearActualizarControl(aplicacion);
        }

        public string ProcesarArchivoControl(string nombreArchivo, byte[] bytes)
        {
            var procesarControl = new ProcesarCSV();
            return procesarControl.ProcesarArchivoControl(nombreArchivo, bytes);
        }

        public Servidores ObtenerServidor(string codigo)
        {
            var servidoresBL = new ServidoresBL();
            return servidoresBL.ObtenerServidor(codigo);
        }

        public IList<Servidores> ObtenerServidores()
        {
            var servidoresBL = new ServidoresBL();
            return servidoresBL.ObtenerServidores().ToList();
        }

        public string CrearActualizarServidor(Servidores servidor)
        {
            var servidoresBL = new ServidoresBL();
            return servidoresBL.CrearActualizarServidor(servidor);
        }

    }
}
