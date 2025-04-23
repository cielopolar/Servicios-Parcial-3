using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AppsParcial3.Models;

namespace AppsParcial3.Clases
{
    public class clsEvento
    {

        private bdNatilleraEntities bdNatillera = new bdNatilleraEntities();
        public Evento eventos { get; set; }

        public string Insertar()
        {
            try
            {
                bdNatillera.Eventos.Add(eventos);
                bdNatillera.SaveChanges();
                return "Evento guardado con exito";

            }
            catch (Exception ex)
            {
                return "Error al insertar el evento " + ex.Message;
            }
        }
        public Evento ConsultarXID(int Id)
        {
            Evento even = bdNatillera.Eventos.FirstOrDefault(e => e.idEventos == Id);
            return even;
        }
        public Evento ConsultarXNombre(string Nombre)
        {
            Evento evenNombre = bdNatillera.Eventos.FirstOrDefault(e => e.NombreEvento == Nombre);
            return evenNombre;
        }
        public Evento ConsultarXTipo(string Tipo)
        {
            Evento evenTipo = bdNatillera.Eventos.FirstOrDefault(e => e.TipoEvento == Tipo);
            return evenTipo;
        }
        public Evento ConsultarXFecha(DateTime Fecha)
        {
            Evento evenFecha = bdNatillera.Eventos.FirstOrDefault(e => e.FechaEvento == Fecha);
            return evenFecha;
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar se debe consultar si el dato ya existe 
                Evento even = ConsultarXID(eventos.idEventos);
                if (even == null)
                {
                    return "El evento no existe";
                }
                bdNatillera.Eventos.AddOrUpdate(eventos);
                bdNatillera.SaveChanges();
                return "Evento actualizado con exito";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el evento" + ex.Message;
            }
        }

        public string Eliminar()
        {
            //Primero se debe consultar 
            try
            {
                Evento eve = ConsultarXID(eventos.idEventos);
                if (eve == null)
                {
                    return "El evento no existe";
                }
                bdNatillera.Eventos.Remove(eventos);
                bdNatillera.SaveChanges();
                return "El evento se elimino correctamente";
            }
            catch (Exception ex)
            {
                return "No se ha podido eliminar el evento" + ex.Message;
            }
        }


    }
}