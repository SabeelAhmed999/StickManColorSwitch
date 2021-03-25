using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToChange : MonoBehaviour
{
    public SkinnedMeshRenderer playerMat;
    public Material[] changeMat;
    int currentMat=0;
    public float movementSpeed = 5f;
    public Animator animator;
    private bool Runing;
    private CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.startGame)
        {
            character.Move((Vector3.forward * movementSpeed) * Time.deltaTime);
            Runing = true;
            animator.SetBool("Run", Runing);
        }
    }

    public void ChangeMaterial()
    {
        if(currentMat<changeMat.Length)
        {
            playerMat.material = changeMat[currentMat];
            currentMat += 1;
        }
        if(currentMat==changeMat.Length)
        {
            currentMat = 0;
        }
    }

}
