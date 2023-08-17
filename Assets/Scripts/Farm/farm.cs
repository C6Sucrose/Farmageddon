using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;




public class farm : MonoBehaviour
{
    public static int index; 
    // Start is called before the first frame update
    public int totalHealth = 100;
    public int currentHealth;
   // public int hogdamage = 50;
    private Rigidbody2D rb;
    public corn Bar;

   //public losescreen index;

    public HealthBar healthBar;

    public float damageRate = 1f;                                      // Rate at which the farm should take damage
    private float nextDamage;
  


    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        currentHealth = totalHealth;
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(totalHealth);

    }

    void Update()
    {



    }



    //damage logic
    public void TakeDamage(int damageAmount)
    {

        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
       // GameObject.FindGameObjectsWithTag("bar");
       
        //transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
        //bar Bar = other.GetComponent<bar>();
       //  Bar.decreasescale();
    }

    // Handle enemy death logic here
    void Die()
    {

        Destroy(gameObject);

        //int ind = SceneManager.GetActiveScene().buildIndex;
        //index.GoToPreviousScene(ind);
      //  SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("losescreen");
        Debug.Log("losescreen loaded");

        SceneManager.LoadScene("Lose");


    }


    //check if the hog is hit
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the hog is hit by a bullet
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            // Get the bullet component from the other object
            Hog hog = other.GetComponent<Hog>();
            if (nextDamage < Time.time)
            {
                // Damage the hog based on the bullet's damage value
                TakeDamage(hog.hogdamage);
                nextDamage = Time.time + damageRate;
            }
            

            hog.transform.position = hog.transform.position - new Vector3(-0.25f, 0, 0);

        }
        //else if (other.CompareTag("Aoe"))                           // Check if collider is triggered by an area of effect attack
        //{
        //    Debug.Log("Explosive Hit");
        //    Bullet aoe = other.GetComponent<Bullet>();
        //    TakeDamage(aoe.damage);                              // Do not destroy aoe objects as their function depends on their
        //                                                         // lifetime.
        //}
        else
        {
            Debug.Log("Miss");

        }
    }

}
