using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PcBuilder;

public class Main : MonoBehaviour
{
    PcDirector director = new PcDirector();
    PcBuilderBase builderBaja = new BajaPCBuilder();
    

    void Start()
    {
        PC pcBaja = director.BuildPC(builderBaja);
        
    }

    
    
}
