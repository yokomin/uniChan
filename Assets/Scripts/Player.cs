using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CapsuleColliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour {

    //移動スピード
        [SerializeField] float speed = 2f;

        [SerializeField] float thrust = 100;

    //Animatorを入れる
        private Animator animator;

    //Main Cameraを入れる
        [SerializeField] Transform cam;

    //Rigidbodyを入れる
        Rigidbody rb;
    //Capsule Colliderを入れる
        CapsuleCollider caps;

        bool ground = true;
    
    void Start()
    {
        //Animatorコンポーネントを取得
            animator = GetComponent<Animator>();

        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        //RigidbodyのConstraintsを3つともチェック入れて
        //勝手に回転しないようにする
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }
    
    void Update()
    {
        if(ground)
        {
        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //AnimatorControllerのParametersに数値を送って
        //アニメーションを出す
        animator.SetFloat("X", x * 50);
        animator.SetFloat("Y", z * 50);

        if (z != 0 || x != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        transform.position += transform.forward * z + transform.right * x;

        if (Input.GetButton("Jump"))
            {
                //thrustの分だけ上方に力がかかる
                rb.AddForce(transform.up * thrust);
                //速度が出ていたら前方と上方に力がかかる
                if (rb.velocity.magnitude > 0)
                    rb.AddForce(transform.forward * thrust + transform.up * thrust);
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        ground = true;
        //ジャンプのアニメーションをオフにする
        animator.SetBool("Jumping", false);
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;
        //ジャンプのアニメーションをオンにする
        animator.SetBool("Jumping", true);
    }

}