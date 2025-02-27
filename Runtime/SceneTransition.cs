using System.Collections;
using JD.Extensions;
using JD.Tween;
using JD.Waiting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JD.SceneTransitions
{
    public class SceneTransition : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatic()
        {
            _initialized = false;
            Instance = null;
        }
        
        public static SceneTransition Instance;
        private static bool _initialized = false;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnBeforeSceneLoadRuntimeMethod()
        {
            Load();
        }
        
        public static void Load()
        {
            if (_initialized) return;
            _initialized = true;

            Debug.Log($"Scene Transition Initialized!");
            
            var obj = Instantiate(Resources.Load<GameObject>("Prefabs/Scene Transition"));
            obj.name = "Scene Transition";
            Instance = obj.GetComponent<SceneTransition>();
            obj.SetActive(false);
            
            DontDestroyOnLoad(obj);
        }

        public Image Blocker;
        public Image[] Images;

        public void Load(string scene)
        {
            foreach (var image in Images)
            {
                image.SetAlpha(0f);
                image.rectTransform.SetScaleX(0f);
            }

            Blocker.raycastTarget = true;
            gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(PlayRoutine(scene));
        }
        
        private IEnumerator PlayRoutine(string scene)
        {
            const float duration = 0.25f;
            const float delay = 0.15f;
            
            for (var i = 0; i < Images.Length; i++)
            {
                var image = Images[i];
                image.TweenFade(1f, duration / 2f).SetDelay(delay * i);
                image.rectTransform.TweenScaleX(1f, duration).SetDelay(delay * i);
            }

            yield return Wait.Seconds(delay * (Images.Length - 1) + duration);

            SceneManager.LoadScene(scene);
            
            yield return null;
            yield return null;
            yield return null;
            
            //Blocker.raycastTarget = false;
            
            for (var i = 0; i < Images.Length; i++)
            {
                var image = Images[i];
                image.TweenFade(0f, duration / 2f).SetDelay(delay * i + duration / 2f);
                image.rectTransform.TweenScaleX(0f, duration).SetDelay(delay * i);
            }
            
            yield return Wait.Seconds(delay * (Images.Length - 1) + duration);
            
            gameObject.SetActive(false);
        }
    }
}