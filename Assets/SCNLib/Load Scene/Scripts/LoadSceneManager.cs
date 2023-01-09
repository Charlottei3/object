using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SCN.Common
{
    public class LoadSceneManager : MonoBehaviour
    {
        static LoadSceneManager _instance;
        public static LoadSceneManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Setup();
                }

                return _instance;
            }
        }

        LoadSceneSettings setting;

        public static void Setup()
        {
            _instance = Instantiate(LoadSource.LoadObject<GameObject>("Load scene canvas")
                , DDOL.Instance.transform).GetComponent<LoadSceneManager>();

            _instance.setting = LoadSource.LoadObject<LoadSceneSettings>("Load scene settings");

            var canvas = _instance.GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            canvas.sortingLayerName = _instance.setting.Layer;
            canvas.sortingOrder = _instance.setting.OrderInLayer;

            _instance.animDefault = 
                _instance.SpawnAnim(_instance.setting.LoadSceneAnimDefault);
        }

        public static System.Action<string> OnLoadSceneDone;
        public static System.Action<string> OnSceneReady;

        public static System.Action BeforeExitScene;
        public static System.Action OnLoadingScene;

        public string CurrentScene => SceneManager.GetActiveScene().name;
        public string LastScene = "";

        public bool IsLoading { get; private set; }

        [SerializeField] AnimLoadSceneBase animDefault;
        [SerializeField] List<AnimLoadSceneBase> listAnim = new List<AnimLoadSceneBase>();

        public void LoadScene(string sceneName, AnimLoadSceneBase animPrefab = null, System.Action onDone = null)
        {
            FreeRAM();
            IsLoading = true;

            if (animPrefab == null)
            {
                animDefault.BeforeLoad(sceneName, () =>
                {
                    _ = Instance.StartCoroutine(LoadSceneIE(sceneName, animDefault, onDone));
                });
            }
            else
            {
                var _anim = GetAnim(animPrefab);
                _anim.BeforeLoad(sceneName, () =>
                {
                    _ = Instance.StartCoroutine(LoadSceneIE(sceneName, _anim, onDone));
                });
            }
        }

        public void RemoveAllAnimObj()
		{
            while (listAnim.Count > 0)
            {
                Destroy(listAnim[0].gameObject);
                listAnim.RemoveAt(0);
            }
		}

        /// <summary>
        /// Check trong list truoc
        /// </summary>
        AnimLoadSceneBase GetAnim(AnimLoadSceneBase prefab)
        {
            var _anim = listAnim.Find(anim => anim.GetType() == prefab.GetType());

            if (_anim == null)
            {
                _anim = SpawnAnim(prefab);
                listAnim.Add(_anim);
            }

            return _anim;
        }

        /// <summary>
        /// Spawn 1 anim obj moi hoan toan
        /// </summary>
		AnimLoadSceneBase SpawnAnim(AnimLoadSceneBase prefab)
		{
            var anim = Instantiate(prefab.gameObject
                , _instance.transform).GetComponent<AnimLoadSceneBase>();

            if (anim == null)
            {
                Debug.LogError($"Cannot spawn anim {anim}");
            }
            anim.SetupDefault();

            return anim;
        }

        IEnumerator LoadSceneIE(string sceneName, AnimLoadSceneBase anim
            , System.Action onDone = null)
        {
            anim.StartLoad(sceneName);

            var _lastScene = CurrentScene;

            BeforeExitScene?.Invoke();
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName.ToString());

            LastScene = _lastScene;

            bool check = true;
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                if (progress > 0.5f && check)
                {
                    OnLoadingScene?.Invoke();
                    check = false;
                }
                yield return null;
            }

            _instance.GetComponent<Canvas>().worldCamera = Camera.main;
            OnLoadSceneDone?.Invoke(sceneName);
            onDone?.Invoke();

            anim.EndLoad(sceneName, () =>
            {
                OnSceneReady?.Invoke(sceneName);
            });
        }

        void FreeRAM()
        {
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }
    }
}
