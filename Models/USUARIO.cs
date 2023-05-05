namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            PROYECTO = new HashSet<PROYECTO>();
            PROYECTO1 = new HashSet<PROYECTO>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string CODIGO { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(80)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO1 { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }


        public List<USUARIO> ListarTodo()
        {
            var usuarios = new List<USUARIO>();

            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO").ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return usuarios;
        }

        public void Guardar()
        {
            this.ESTADO = true;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        this.FECHA_CREACION = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
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

        public ResponseModel ValidarLogin(string Codigo, string Contraseña)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new Model1())
                {
                    var usuario = db.USUARIO.Where(x => x.CODIGO == Codigo)
                        .Where(x => x.PASSWORD == Contraseña)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.ID_USUARIO.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }

        public USUARIO ObtenerUsuario(int id)
        {
            var usuario = new USUARIO();

            try
            {
                using (var db = new Model1())
                {
                    usuario = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_USUARIO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public void Eliminar()
        {
            var usuario = ObtenerUsuario(ID_USUARIO);
            this.ID_USUARIO = usuario.ID_USUARIO;
            this.NOMBRE = usuario.NOMBRE;
            this.APELLIDO = usuario.APELLIDO;
            this.FECHA_CREACION = usuario.FECHA_CREACION;
            this.CODIGO = usuario.CODIGO;
            this.TELEFONO = usuario.TELEFONO;
            this.EMAIL = usuario.EMAIL;
            this.PASSWORD = usuario.PASSWORD;
            this.ID_TIPOUSUARIO = usuario.ID_TIPOUSUARIO;
            this.ESTADO = false;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_USUARIO > 0)
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
            var usuario = ObtenerUsuario(ID_USUARIO);
            this.ID_USUARIO = usuario.ID_USUARIO;
            this.NOMBRE = usuario.NOMBRE;
            this.APELLIDO = usuario.APELLIDO;
            this.FECHA_CREACION = usuario.FECHA_CREACION;
            this.CODIGO = usuario.CODIGO;
            this.TELEFONO = usuario.TELEFONO;
            this.EMAIL = usuario.EMAIL;
            this.PASSWORD = usuario.PASSWORD;
            this.ID_TIPOUSUARIO = usuario.ID_TIPOUSUARIO;
            this.ESTADO = true;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_USUARIO > 0)
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
