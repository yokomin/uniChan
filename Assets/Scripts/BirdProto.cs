using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdProto : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float up = 3f;

    [SerializeField] Transform cam;

    bool ground = true;
    float realSp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A・Dキー、←→キーで横移動
        if(!ground)
        {
            realSp = speed * 6;
        }
        else
        {
            realSp = speed;
        }

        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * realSp;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * realSp;

        float u = Input.GetAxisRaw("Jump") * Time.deltaTime * up;
        float d = Input.GetAxisRaw("Fire3") * Time.deltaTime * -up;

        if (z != 0 || x != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        transform.position += transform.forward * z + transform.right * x + transform.up * u + transform.up * d;
    }

    void OnCollisionStay(Collision col){
        ground = true;
    }

    void OnCollisionExit(Collision col){
        ground = false;
    }
}
