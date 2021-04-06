using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObjectsRandomizer : MonoBehaviour
{
    public GameObject Wine_bottle;
    public GameObject Burger;
    public GameObject Fries;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public int CollectedBottles = 0;
    public int CollectedBurgers = 0;
    public int CollectedFries = 0;
    public int Score = 0;
    public int Health = 20;
    public Text ScoreTxt;
    public Text BurgerTxt;
    public Text BottlesTxt;
    public Text FriesTxt;
    public Text HealthText;
    public Collision B;
    public GameObject[] Items;
    Animator carAnim;
    public Button Restart;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);
        ScoreTxt.text = "Score:" + Score;
        BottlesTxt.text = CollectedBottles.ToString();
        BurgerTxt.text = CollectedBurgers.ToString();
        FriesTxt.text = CollectedFries.ToString();
        HealthText.text = "Heath:" + Health.ToString();
        carAnim = GetComponent<Animator>();
        Instantiate(Items[Random.Range(0,3)], new Vector3(Random.Range(-4.5f, 4.5f), 0.2f, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(30,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        if (Health < 5)
        {
            Health = 0;
            carAnim.SetBool("Destroy", true);
            GameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*if (Score >= 30)
        {
            WinPanel.SetActive(true);
        }*/

    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider A)
    {
        if (A.gameObject.tag == "Bottle")
        {
            CollectedBottles += 1;
            Score += 5;
            Destroy(A.gameObject);
            Instantiate(Items[Random.Range(0,3)], new Vector3(Random.Range(-4.5f, 4.5f), 0.2f, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(30,0,0));
            ScoreTxt.text = "Score:" + Score;
            BottlesTxt.text = CollectedBottles.ToString();
            if (Health < 20)
            {
                Health += 1;
                HealthText.text = "Heath:" + Health;
            }
        }
        if (A.gameObject.tag == "Burger")
        {
            CollectedBurgers += 1;
            Score += 3;
            Destroy(A.gameObject);
            Instantiate(Items[Random.Range(0,3)], new Vector3(Random.Range(-4.5f, 4.5f), 0.2f, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(30,0,0));
            ScoreTxt.text = "Score:" + Score;
            BurgerTxt.text = CollectedBurgers.ToString();
        }
        if (A.gameObject.tag == "Fries")
        {
            CollectedFries += 1;
            Score += 3;
            Destroy(A.gameObject);
            Instantiate(Items[Random.Range(0,3)], new Vector3(Random.Range(-4.5f, 4.5f), 0.2f, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(30,0,0));
            ScoreTxt.text = "Score:" + Score;
            FriesTxt.text = CollectedFries.ToString();
        }
    }

    void OnCollisionEnter(Collision A)
        {
            if (A.gameObject.tag == "Barrier" && A.impulse.magnitude > 1)
            {
                //Debug.Log(A.impulse.magnitude);
                Health -= 5;
                HealthText.text = "Heath:" + Health;
            }
        }
    

    void DisplayHealth()
    {
        HealthText.text = "Heath:" + Health.ToString();
    }
}
