using ConexionWeb.Bussiness.CSVEntities;
using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class ProcesarCSV
    {
        private ConexionSOXDBContext _context = new ConexionSOXDBContext();

        private string GuardarArchivoLocal(string nombreArchivo, byte[] bytes)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["RutaArchivosLocales"], nombreArchivo);
            File.WriteAllBytes(path, bytes);
            return path;
        }

        public string ProcesarArchivoActividadControl(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<ActividadControlCSV>(Encoding.UTF8);
                engine.BeforeReadRecord += (sender, args) =>
                {
                    args.RecordLine = args.RecordLine;
                };
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var actividadControlBL = new ActividadControlBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            ActividadControl actividadControl = new ActividadControl
                            {
                                Codigo = record.Codigo.Length > 100 ? record.Codigo.Substring(0, 100) : record.Codigo,
                                NombreActividad = record.NombreActividad,
                                Estado = record.Estado
                            };
                            actividadControlBL.CrearActualizarActividadControl(actividadControl);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }

        public string ProcesarArchivoControl(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<ControlCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var controlBL = new ControlBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            Control control = new Control();
                            control.Codigo = record.Codigo;
                            control.sControl = record.NombreControl;
                            control.InicialesControl = record.InicialesControl;
                            control.Estado = record.Estado;
                            controlBL.CrearActualizarControl(control);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }
        public string ProcesarAplicaciones(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<AplicacionesCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var aplicacionesBL = new AplicacionesBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            Aplicaciones aplicacion = aplicacionesBL.ObtenerAplicacion(record.Codigo);
                            //Si la aplicacion no existe crea una nueva
                            if (aplicacion == null)
                                aplicacion = new Aplicaciones();
                            var servidoresBL = new ServidoresBL();
                            aplicacion.Codigo = record.Codigo;
                            aplicacion.NombreAplicacion = record.NombreAplicacion;
                            aplicacion.Estado = "Activo";
                            if (string.IsNullOrEmpty(aplicacion.Servidores))
                            {
                                aplicacion.Servidores = record.Servidor;
                            }
                            else
                            {
                                if (!aplicacion.Servidores.Contains(record.Servidor))
                                    aplicacion.Servidores = aplicacion.Servidores + "," + record.Servidor;
                            }
                            aplicacionesBL.CrearActualizarAplicacion(aplicacion);

                            foreach (var item in record.Servidor.Split(','))
                            {
                                Servidores servidor = new Servidores()
                                {
                                    Nombre = item.Trim(),
                                    Ip = record.IPServidor,
                                    Tipo = record.TipoServidor,
                                    Estado = "Activo"
                                };
                                servidoresBL.CrearActualizarServidor(servidor);
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }

        public string ProcesarPuntosControl(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<PuntoControlCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var puntoControlBL = new PuntoControlBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            PuntoControl nuevoPuntoControl = new PuntoControl
                            {
                                Codigo = record.Codigo,
                                PuntoDeControl = record.PuntoControl
                            };
                            puntoControlBL.CrearActualizarPuntoControl(nuevoPuntoControl);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }

        public string ProcesarObjetivosControl(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<ObjetivoControlCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var objetivoControlBL = new ObjetivoControlBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            ObjetivoControl nuevoObjetivo = new ObjetivoControl();
                            nuevoObjetivo.Codigo = record.Codigo;
                            nuevoObjetivo.ObjetivoDeControl = record.ObjetivoControl;
                            objetivoControlBL.CrearActualizarObjetivoControl(nuevoObjetivo);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }

        public string ProcesarJefaturas(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<JefaturaCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var jefaturaBL = new JefaturaBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            Jefatura nuevaJefatura = new Jefatura();
                            nuevaJefatura.CodigoArea = record.Area;
                            nuevaJefatura.Direccion = record.Jefe;
                            jefaturaBL.CrearActualizarJefatura(nuevaJefatura);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }

        public string ProcesarGobierno(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<GobiernoCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var gobiernoBL = new GobiernoBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            Gobierno nuevoGobierno = new Gobierno();
                            nuevoGobierno.Codigo = record.Codigo;
                            nuevoGobierno.NombreProceso = record.NombreProceso;
                            nuevoGobierno.URL = record.URL;
                            gobiernoBL.CrearActualizarRegistroGobierno(nuevoGobierno);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }
        public string ProcesarRiesgosCorporativos(string nombreArchivo, byte[] bytes)
        {
            try
            {
                var engine = new FileHelperEngine<RiesgoCorporativoCSV>(Encoding.UTF8);
                var path = GuardarArchivoLocal(nombreArchivo, bytes);
                var records = engine.ReadFile(path);
                var riesgoCorporativoBL = new RiesgoCorporativoBL();
                int contador = 0;
                foreach (var record in records)
                {
                    contador++;

                    try
                    {
                        if (contador > 1)
                        {
                            RiesgoCorporativo nuevoRiesgo = new RiesgoCorporativo();
                            nuevoRiesgo.Codigo = record.Codigo;
                            nuevoRiesgo.Descripcion = record.Descripcion;
                            nuevoRiesgo.Nivel = record.Nivel;
                            nuevoRiesgo.Tipo = record.Tipo;
                            riesgoCorporativoBL.CrearRiesgo(nuevoRiesgo);
                        }
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Registros insertados correctamente.";
        }
    }
}
