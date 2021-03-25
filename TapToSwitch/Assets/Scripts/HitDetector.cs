using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public SkinnedMeshRenderer playerCurrentMatCheck;
    public TapToChange playerInstance;
    public GameObject Block;
    public MeshRenderer mesh;
    public GameObject BreakObject;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<TapToChange>();
        playerCurrentMatCheck = GameObject.FindGameObjectWithTag("PlayerMat").GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            if (playerCurrentMatCheck.material.name == mesh.material.name)
            {
                int FallInt = Random.RandomRange(1, 2);
                playerInstance.animator.SetInteger("Hit", FallInt);
                Invoke("Remover", 1f);
            }
            else
            {
                int FallInt = Random.RandomRange(1, 2);
                playerInstance.animator.SetInteger("Fall", FallInt);
                Invoke("Over",2f);
            }
        }

    }

    void Remover()
    {
        BreakObject.SetActive(true);
        playerInstance.animator.SetInteger("Hit", 0);

        Block.GetComponent<MeshRenderer>().enabled = false;
        Block.GetComponent<BoxCollider>().enabled = false;
        Invoke("RemoveAndDestroy", 2f);
    }
    void Over()
    {
        GameManager.gameOver = true;
    }

    void RemoveAndDestroy()
    {
        Destroy(BreakObject);
    }
}
