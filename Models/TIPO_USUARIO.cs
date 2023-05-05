namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TIPO_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_USUARIO()
        {
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int ID_TIPOUSUARIO { get; set; }

        [StringLength(20)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<TIPO_USUARIO> Listar()
        {
            var tipo_usuario = new List<TIPO_USUARIO>();

            try
            {
                using (var db = new Model1())
                {
                    tipo_usuario = db.TIPO_USUARIO.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return tipo_usuario;
        }
    }
}
