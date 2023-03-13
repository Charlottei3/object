using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SCN.Common
{
    public class startGame : MonoBehaviour
    {

        [SerializeField] string sceneName;

       

       /* public void LoadScene(string sceneName)
        {
            LoadSceneManager.Instance.LoadScene(sceneName);
        }*/
        public void LoadGame(string scenename)
        {
            Debug.Log("sceneName to load: " + scenename);
            SceneManager.LoadScene(scenename);
        }

    }
}
