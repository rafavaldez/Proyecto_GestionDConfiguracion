namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PROYECTO")]
    public partial class PROYECTO
    {
        [Key]
        public int ID_PROYECYO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCRIPCION { get; set; }

        public int ID_CLIENTE { get; set; }

        public int ID_METODOLOGIA { get; set; }

        public bool? ESTADO { get; set; }

        public int ID_JEFEPROYECTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        public virtual METODOLOGIA METODOLOGIA { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        public virtual USUARIO USUARIO1 { get; set; }
        public List<PROYECTO> ListarTodo()
        {
            var proyecto = new List<PROYECTO>();

            try
            {
                using (var db = new Model1())
                {
                    proyecto = db.PROYECTO.Include("METODOLOGIA")
                        .Include("USUARIO")
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return proyecto;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_PROYECYO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public PROYECTO ObtenerProyecto(int id)
        {
            var proyecto = new PROYECTO();

            try
            {
                using (var db = new Model1())
                {
                    proyecto = db.PROYECTO
                        .Where(x => x.ID_PROYECYO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return proyecto;
        }

        public void Eliminar()
        {
            var proyecto = ObtenerProyecto(ID_PROYECYO);
            this.ID_PROYECYO = proyecto.ID_PROYECYO;
            this.NOMBRE = proyecto.NOMBRE;
            this.DESCRIPCION = proyecto.DESCRIPCION;
            this.ID_CLIENTE = proyecto.ID_CLIENTE;
            this.ID_METODOLOGIA = proyecto.ID_METODOLOGIA;
            this.ESTADO = proyecto.ESTADO;
            this.ID_JEFEPROYECTO = proyecto.ID_JEFEPROYECTO;
            this.FECHA_INICIO = proyecto.FECHA_INICIO;
            this.FECHA_FIN = proyecto.FECHA_FIN;
            this.ESTADO = false;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_METODOLOGIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Habilitar()
        {
            var proyecto = ObtenerProyecto(ID_PROYECYO);
            this.ID_PROYECYO = proyecto.ID_PROYECYO;
            this.NOMBRE = proyecto.NOMBRE;
            this.DESCRIPCION = proyecto.DESCRIPCION;
            this.ID_CLIENTE = proyecto.ID_CLIENTE;
            this.ID_METODOLOGIA = proyecto.ID_METODOLOGIA;
            this.ESTADO = proyecto.ESTADO;
            this.ID_JEFEPROYECTO = proyecto.ID_JEFEPROYECTO;
            this.FECHA_INICIO = proyecto.FECHA_INICIO;
            this.FECHA_FIN = proyecto.FECHA_FIN;
            this.ESTADO = true;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_METODOLOGIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Revision()
        {
            var proyecto = ObtenerProyecto(ID_PROYECYO);
            this.ID_PROYECYO = proyecto.ID_PROYECYO;
            this.NOMBRE = proyecto.NOMBRE;
            this.DESCRIPCION = proyecto.DESCRIPCION;
            this.ID_CLIENTE = proyecto.ID_CLIENTE;
            this.ID_METODOLOGIA = proyecto.ID_METODOLOGIA;
            this.ESTADO = proyecto.ESTADO;
            this.ID_JEFEPROYECTO = proyecto.ID_JEFEPROYECTO;
            this.FECHA_INICIO = proyecto.FECHA_INICIO;
            this.FECHA_FIN = proyecto.FECHA_FIN;
            this.ESTADO = null;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_METODOLOGIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
