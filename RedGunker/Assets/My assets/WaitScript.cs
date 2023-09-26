using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitScript : MonoBehaviour
{
    public GameObject DialogueObj;
    public float time;

    void Start()
    {
        PopDialogue();
    }
    private void Update()
    {
        
    }
    public void PopDialogue()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        DialogueObj.SetActive(true);
    }

}
