using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightMove : MonoBehaviour
{
    public float sens;

    void Start()
    {
        
    }

    void Update()
    {
        
        float vertical = Input.GetAxis("Vertical2") * sens;
        transform.Translate(0f,vertical * Time.deltaTime,0f);

        float yPozition = Mathf.Clamp(transform.position.y,-3.722f,3.722f);
        transform.position = new Vector2(transform.position.x, yPozition);
    
    }
}
