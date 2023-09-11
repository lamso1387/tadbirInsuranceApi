using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tadbirInsuranceApi.Models;

namespace tadbirInsuranceApi.Domain
{
    public abstract class GenericEntity
    {
        [Key]
        public long id { get; set; }
        public long creator_id { get; set; }
        public long? modifier_id { get; set; }
        public DateTime create_date { get; set; } = DateTime.Now;
        public DateTime? modify_date { get; set; }
        [Required]
        public string status { get; set; } = EntityStatus.active.ToString();
        [NotMapped]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Func<GenericEntity, object> Selector => x => new
        {
            x.id,
            x.create_date,
            x.creator_id,
            x.modifier_id,
            x.modify_date
        };
        [NotMapped]
        public virtual EntityStatus status_enum
        {
            get => Tools.ConvertorTools.StringToEnum<EntityStatus>(status);
            set { status = value.ToString(); }
        }
        [NotMapped]
        public virtual DateTime? update_date => modify_date == null ? create_date : modify_date;

        public void Modify(long modifier_user_id)
        {
            modifier_id = modifier_user_id;
            modify_date = DateTime.Now;
        }

    }
}
