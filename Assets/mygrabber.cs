using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class mygrabber : OVRGrabber
{
    public GameObject potionPoisonHand;
    public GameObject potionPoison;
    public GameObject knifeHand;
    public GameObject knife;
    //
    
    //
    //public GameObject normalHand;
    //private Renderer renderer;
    private OVRHand hand;
    public float pinchThreshold = 0.6f;
    public float holdThreshold = 0.1f;
    bool hold;
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
        //renderer = GetComponent<Renderer>();
        hold = false;
    }
    public override void Update()
    {
        base.Update();
        float pinchStrehgth = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        if (!hold &&!m_grabbedObj && pinchStrehgth >= pinchThreshold && m_grabCandidates.Count > 0)
        {
           if (holdThreshold > Vector3.Distance(potionPoison.transform.position, transform.position))
            {
                hold = true;
                potionPoisonHand.SetActive(true);
                potionPoison.SetActive(false);
                GetComponent<OVRMeshRenderer>().enabled = false;
                GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else if (holdThreshold > Vector3.Distance(knife.transform.position, transform.position))
            {
                hold = true;
                knifeHand.SetActive(true);
                knife.SetActive(false);
                GetComponent<OVRMeshRenderer>().enabled = false;
                GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
        }
        else if (hold && pinchStrehgth < pinchThreshold)
        {
            hold = false;
            potionPoisonHand.SetActive(false);
            potionPoison.SetActive(true);
            knifeHand.SetActive(false);
            knife.SetActive(true);
            GetComponent<OVRMeshRenderer>().enabled = true;
            GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
    }
}
