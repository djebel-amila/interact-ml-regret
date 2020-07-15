﻿using UnityEngine;


namespace InteractML
{
    /// <summary>
    /// Contains info regarding a monobehaviour to use with our IML System
    /// </summary>
    [System.Serializable]
    public class IMLMonoBehaviourContainer 
    {
        /// <summary>
        /// Monobehaviour contained
        /// </summary>
        public MonoBehaviour GameComponent;
        /// <summary>
        /// Do we want our IML System to control any clones from this monobehaviour?
        /// </summary>
        public bool ControlClones;

        /// <summary>
        /// Creates a new monobehaviour container. Default clone control is false
        /// </summary>
        /// <param name="gameComponent"></param>
        public IMLMonoBehaviourContainer(MonoBehaviour gameComponent)
        {
            GameComponent = gameComponent;
            ControlClones = false;
        }

        /// <summary>
        /// Creates a new monobehaviour container
        /// </summary>
        /// <param name="gameComponent"></param>
        /// <param name="controlClones"></param>
        public IMLMonoBehaviourContainer(MonoBehaviour gameComponent, bool controlClones)
        {
            GameComponent = gameComponent;
            ControlClones = controlClones;
        }

        /// <summary>
        /// Override of Equals for the List.Contains method work properly
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((IMLMonoBehaviourContainer)obj);
        }

        /// <summary>
        /// Overriding Equals functionality
        /// </summary>
        /// <param name="otherContainer"></param>
        /// <returns></returns>
        private bool Equals(IMLMonoBehaviourContainer otherContainer)
        {
            if (otherContainer.GameComponent == null || this.GameComponent == null) return false;
            // If we are checking whether or not is a clone, just check for type
            if (this.ControlClones == true)
                return this.GameComponent.GetType() == otherContainer.GameComponent.GetType();
            // If we are not controlling clones, check if it is the same script instance
            else
                return this.GameComponent.Equals(otherContainer.GameComponent);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            if (GameComponent == null) return default(int);
            return this.GameComponent.GetHashCode();
        }
    }

}
