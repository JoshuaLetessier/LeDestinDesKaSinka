using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Projectil;
    public Rigidbody2D playerrb;
    public SpriteRenderer spriteRenderer;
    public int Force;
    public static Tir instance;

    public AudioClip fireSound;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flip(Controller.instance.rb.velocity.x);
            GameObject BouleDeFeu = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;
            AudioManager.instance.PlayClipAt(fireSound, transform.position);
            //BouleDeFeu.GetComponent<Rigidbody2D>().velocity = Vector2.right * Force * Time.deltaTime;
            BouleDeFeu.GetComponent<Rigidbody2D>().velocity = Controller.instance.TirDirection * Force * Time.deltaTime;
            Destroy(BouleDeFeu, 2f);
        }

    }
    void Flip(float _velocity)
    {
        //print("1");
        if (_velocity > 0.3f)
        {
            //print("2");
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.3f)
        {
            //print("3");
            spriteRenderer.flipX = true;
        }
    }


}
