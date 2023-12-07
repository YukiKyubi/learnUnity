using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : HiroMonoBehavior
{
    protected string sceneName = "GalaxyDemo";

    protected virtual void OnMouseDown() {
        LoadGalaxy();
    }

    protected virtual void LoadGalaxy() {
        SceneManager.LoadScene(sceneName);
    }
}
