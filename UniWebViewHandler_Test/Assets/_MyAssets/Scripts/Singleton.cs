using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance = null;

    //gameObject existent in the scene -> the gameObject is active -> 
    //a singleton script is a component on the gameObject -> Awake() is executed ->
    //Singelton Pattern -> instance != null
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //!!!!!!!!!!!
                //TODO: read this
                //what happen if FindObjectsOfType<T>().Length >= 1 ?
                //the intention is that script B call Singleton.Instance after script B Awake()(meaning in Start()), 
                //so the Awake() in the manager(or script A) is executed forst thus the Singleton Pattern will work properly.
                //but what if, for some stupid reason, script B call Singleton.Instance in it's Awake(), 
                //and script B Awake() is executed before script A Awake() ?
                //probably is -> FindObjectsOfType<T>().Length >= 1!!! the quetion is how I deal with it ?
                //!!!!!!!!!
                GameObject obj = new GameObject(typeof(T).Name);
                obj.AddComponent<T>();
                //!!!!!!!!!
                //ToDo: Do I need to buy time between "obj.AddComponent<T>();" to "return instance;"
                //to make sure Awake() actived and instance != null ?
                //in my STRONGE computer the code work, but will it work on weaker computers? 
                //!!!!!!!!!!!
                Debug.LogWarning("A new " + typeof(T).Name + " as been created!!!!");
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        #region Singelton Pattern
        //Check if instance already exists
        if (instance == null)
        {
            //Set instance to this as T
            instance = this as T;
            //Set this gameObject to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Make sure this GameObject is out from the life cycle of Unity Engine.
            gameObject.SetActive(false);
            //And destroy this gameObject to enforces the singleton pattern.             
            Destroy(gameObject);
        }
        #endregion

    }


}
