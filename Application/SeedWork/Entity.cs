using System;

namespace ApplicationCore.SeedWork
{
    /// <summary>
    /// Entity
    /// </summary>
    public abstract class Entity
    {
        private int? _requestedHashCode;
        private int? _Id;

        /// <summary>
        /// Id 
        /// </summary>
        public virtual int? Id
        {
            get => _Id;
            set => _Id = value;
        }

        /// <summary>
        /// est transitoire
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return this.Id == default;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Entity item = (Entity)obj;

            return item.IsTransient() || this.IsTransient() ? false : item.Id == this.Id;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = this.Id.GetHashCode();
                }

                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Operateur de comparaison
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity left, Entity right)
        {
            return Object.Equals(left, null) ? (Object.Equals(right, null)) ? true : false : left.Equals(right);
        }

        /// <summary>
        /// Operateur de difference
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
