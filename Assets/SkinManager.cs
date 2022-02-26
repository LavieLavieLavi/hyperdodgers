using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{

    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;

    public void NextSkin()
    {
        selectedSkin = selectedSkin + 1;

        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }

        sr.sprite = skins[selectedSkin];
    }

    public void BackSkin()
    {
        selectedSkin = selectedSkin -1;

        if (selectedSkin == skins.Count)
        {
            selectedSkin = skins.Count - 1;
        }

        sr.sprite = skins[selectedSkin];
    }

    public void Confirm()
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Prefabs/Playables/dodger.prefab");
        SceneManager.LoadScene("Main Menu");
    }
}
