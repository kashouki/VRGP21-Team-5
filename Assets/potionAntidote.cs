using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionAntidote : MonoBehaviour
{
    public cauidron c;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (c.status == 2)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
