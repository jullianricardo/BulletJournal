namespace BulletJournal.Models.Domain
{
    public abstract class Entity : IEntity
    {
        public string? Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsTransient()
        {
            return Id == null;
        }

        #region Overrides 

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null)
                return false;

            if (GetRealObjectType(this) != GetRealObjectType(obj))
                return false;

            return obj is Entity other && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                //For entities without Id we want to use object GetHashCode
                return IsTransient() ? base.GetHashCode() : Id.GetHashCode();
            }
        }

        private Type GetRealObjectType(object obj)
        {
            var retVal = obj.GetType();

            //Because can be compared two objects with same id and 'types' but one of it if EF dynamic proxy type
            if (retVal.BaseType != null && retVal.Namespace == "System.Data.Entity.DynamicProxies")
                retVal = retVal.BaseType;

            return retVal;
        }


        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
