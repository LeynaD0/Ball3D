using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;

    Vector3 posicion;

    [SerializeField]
    float impulso = 10f;

    [SerializeField]
    TextMeshProUGUI diamondsText;

    int diamonds;

    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    float timer;

    [SerializeField]
    GameObject lostScreen;

    [SerializeField]
    GameObject doors;

    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    GameObject musicBackground;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Tiempo: " + timer.ToString("00.00");
        posicion.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulso;
        posicion.z = Input.GetAxis("Vertical") * Time.deltaTime * impulso;

        diamondsText.text = "Diamonds: " + diamonds.ToString() + " / 10";

        if(timer <= 0)
        {
            timer = 0;
            this.enabled = false;
            lostScreen.SetActive(true);
            musicBackground.SetActive(false);
        }

        if(diamonds == 9)
        {
            doors.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            diamonds++;
            timer += 10f;
        }
        Instantiate(prefabParticles, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);

    }
    private void FixedUpdate()
    {
        body.AddForce(posicion, ForceMode.Impulse);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
