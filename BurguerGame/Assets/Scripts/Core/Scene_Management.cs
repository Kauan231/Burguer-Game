using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Management : MonoBehaviour
{
    [SerializeField] private string scene_name;
    public void Change_Scene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
