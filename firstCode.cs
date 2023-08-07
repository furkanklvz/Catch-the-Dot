using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstCode : MonoBehaviour
{

    /* public int a;
     public int b =15;
     public float c = 3.45f;
     public string str = "Furkan"; */
    public float sense;
    
    
    
    
    
    void Start()
    {

    }
    void Update()
    {

            float vertical = Input.GetAxis("Vertical") * sense;
            transform.Translate(0f,vertical * Time.deltaTime,0f);

            float yPozition = Mathf.Clamp(transform.position.y,-3.722f,3.722f);
            transform.position = new Vector2(transform.position.x, yPozition);
    }


}
