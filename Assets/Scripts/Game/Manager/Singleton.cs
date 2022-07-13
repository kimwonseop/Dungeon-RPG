using UnityEngine;

namespace Game.Manager {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static T instance;
        private static object lockObject = new object();
        public static T Instance {
            get {
                if (instance == null) {
                    lock (lockObject) {
                        instance = FindObjectOfType(typeof(T)) as T;

                        if (instance == null) {
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();

                            singletonObject.name = typeof(T).Name;
                            DontDestroyOnLoad(singletonObject);
                        }
                    }
                }

                return instance;
            }
        }
    }
}
