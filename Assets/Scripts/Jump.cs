using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public string prefabTag = "Enemy";
    private Animator animator;
    // Start is called before the first frame update

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

    public void JumpButton()
    {
        animator.Play("Jump");
    }
}
