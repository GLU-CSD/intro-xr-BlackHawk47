using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public string prefabTag = "Enemy";
    private Animator animator;
    // Start is called before the first frame update

    //zorgt er voor dat de animatie werkt
    void Update()
    {
        if (animator == null)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);
            if (spawnedPrefab != null)
            {
                animator = spawnedPrefab.GetComponent<Animator>();
            }
        }
    }
    //laat de speel animatie afspelen
    public void JumpButton()
    {
        animator.Play("Jump");
    }
}
