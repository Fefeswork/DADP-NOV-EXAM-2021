using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pnlDialogue;

    public GameObject btnPhone, btnBack;
    public GameObject cnvPhone, cnvLocation;
    public bool bPhoneicon = false;
    public bool bCnvsPhone = false;
    public bool bCnvsLocation = true;
    // Start is called before the first frame update
    void Start()
    {
        pnlDialogue = GameObject.Find("pnlUI");
        cnvPhone = GameObject.Find("CnvPhone");
        cnvLocation = GameObject.Find("CnvLocation");
        btnPhone = GameObject.Find("btnPhone");

        cnvPhone.active = bCnvsPhone;
        btnPhone.active = bPhoneicon;
        
    }

    // Update is called once per frame
    void Update()
    {
        btnPhone.active = bPhoneicon;

        cnvPhone.active = bCnvsPhone;
        
    }

    public void OnClickPhoneIcon()
    {
        bCnvsPhone = true;
       

    }
}
