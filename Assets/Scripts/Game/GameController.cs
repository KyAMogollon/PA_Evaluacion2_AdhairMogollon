using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos;
    [SerializeField] private List<Transform> puntosDeSpawn;

    [SerializeField] TMP_Text tmp_textP1;
    TMP_Text tmpP1;
    public float contadorP1 = 0;
    public int scoreP1 = 0;
    [SerializeField] TMP_Text tmp_textP2;
    TMP_Text tmpP2;
    public float contadorP2 = 0;
    public int scoreP2 = 0;
    [SerializeField] UnityEvent onPlayerDie;
    public float tiempoEntreEnemigos = 1.5f;
    [SerializeField] PlayerMovement player;
    [SerializeField] AudioSource lose;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemigo", tiempoEntreEnemigos, tiempoEntreEnemigos);
    }

    // Update is called once per frame
    void Update()
    {
        PuntajeP1();
        PuntajeP2();
    }
    void PuntajeP1()
    {
        contadorP1 = contadorP1 + 1 * Time.deltaTime;
        scoreP1 = (int)contadorP1;
        tmp_textP1.text = "Score: " + scoreP1;
        if (player.player_lives <= 0)
        {
            tmpP1.text = "Life: " + 0;
            lose.Play();
            onPlayerDie.Invoke();
        }
    }
    void PuntajeP2()
    {
        contadorP2 = contadorP2 + 1 * Time.deltaTime;
        scoreP2 = (int)contadorP2;
        tmp_textP2.text = "Score: " + scoreP2;
        if (player.player2_lives <= 0)
        {
            tmpP2.text = "Life: " + 0;
            lose.Play();
            onPlayerDie.Invoke();
        }
    }
    public void SpawnEnemigo()
    {
        int randomEnemigo = Random.Range(0, enemigos.Count);
        int randomSpawn = Random.Range(0, puntosDeSpawn.Count);
        Instantiate(enemigos[randomEnemigo], puntosDeSpawn[randomSpawn].position, Quaternion.identity);
    }
}
