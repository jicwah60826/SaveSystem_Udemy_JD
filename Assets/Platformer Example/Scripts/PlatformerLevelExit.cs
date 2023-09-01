using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerLevelExit : MonoBehaviour
{
    private bool hasExited;

    public float coverGrowSpeed;
    private bool growCover;
    public Transform cover;
    public float growScaleTarget;

    private void Update()
    {
        if(growCover)
        {
            cover.transform.localScale = Vector3.MoveTowards(cover.transform.localScale, Vector3.one * growScaleTarget, coverGrowSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasExited && other.tag == "Player")
        {
            hasExited = true;
            PlatformerLevelManager.instance.ExitLevel();

            growCover = true;
        }
    }


}
