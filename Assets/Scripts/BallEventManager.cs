using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallEventManager : MonoBehaviour
{
    [Header("Text References")]
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("GameObjects Spowner")]
    [SerializeField] ParticleSystem enemyHitParticle;
    [SerializeField] GameObject pfHeartAnimaton;
    [SerializeField] GameObject pfYellowCoinAnimaton;
    [SerializeField] GameObject pfBlueCoinAnimaton;
    [SerializeField] GameObject pfGreenCoinAnimaton;
    [SerializeField] Transform animationSpowner;

    [Header("Health & Score")]
    [HideInInspector] public int coin = 0;
    [HideInInspector] public float score = 0;
    [SerializeField] Image[] images;
    [SerializeField] Sprite redHeart;
    [SerializeField] Sprite whiteHeart;
    [SerializeField] bool isCheat = false;

    [Header("Music & Audio")]
    [SerializeField] AudioClip coinAudio;
    [SerializeField] AudioClip heartAudio;
    [SerializeField] AudioClip enemyAudio;


    Vector2 spawnPos;
    int health = 5;
    float scorePerSec = 20f;
    float delayToLoadScene = 1.0f;

    AudioSource audioSource;
    CircleCollider2D ballCollider;
    BallMovement ballMovement;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ballCollider = GetComponent<CircleCollider2D>();
        ballMovement = GetComponentInParent<BallMovement>();

        enemyHitParticle.Stop();
        spawnPos = new Vector2(animationSpowner.transform.position.x, animationSpowner.transform.position.y);
    }


    void Update() 
    {
        coinText.text = coin.ToString();
        HeartIconManager();
        ScoreCount();
        //SetSoundVolume(PlayerPrefs.GetFloat("soundValue"));
    }

    
     void OnTriggerEnter2D(Collider2D other) 
    {
        switch (other.gameObject.tag)
        {
            case "YCoin":
                HitYellowCoins(other);
                break;

            case "BCoin":
                HitBlueCoins(other);
                break;

            case "GCoin":
                HitGreenCoins(other);
                break;

            case "Enemy":
                HitEnemy(other);
                break;
            
            case "Heart":
                HitHeart(other);
                break;

            default:
                break;
            
        }
    }


    //public void SetSoundVolume(float volume) { soundAudioSource.volume = volume; }
    //public void SetMusicVolume(float volume) { musicAudioSource.volume = volume; }

    void ScoreCount()
    {
        score += scorePerSec * Time.deltaTime;
        scoreText.text = Mathf.Round(score).ToString();
    }

    void HitYellowCoins(Collider2D other)
    {
        CoinAudio();
        Instantiate(pfYellowCoinAnimaton, spawnPos, Quaternion.identity);
        coin++;
        Destroy(other.gameObject);
    }
    
    void HitBlueCoins(Collider2D other)
    {
        CoinAudio();
        Instantiate(pfBlueCoinAnimaton, spawnPos, Quaternion.identity);
        coin += 2;
        Destroy(other.gameObject);
    }
    
    void HitGreenCoins(Collider2D other)
    {
        CoinAudio();
        Instantiate(pfGreenCoinAnimaton, spawnPos, Quaternion.identity);
        coin += 3;
        Destroy(other.gameObject);
    }

    void HitEnemy(Collider2D other)
    {
        EnemyAudio();
        enemyHitParticle.Play();
        Destroy(other.gameObject);
        if (isCheat) return;
        health--;
        if (health == 0)
        {
            DisableOnGameOver();
            Invoke("GameOver", delayToLoadScene);
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("score", (int)score);
        }
    }

    void HitHeart(Collider2D other)
    {
        Destroy(other.gameObject);
        if (health < 5)
        {
            HeartAudio();
            health++;
            Instantiate(pfHeartAnimaton, spawnPos, Quaternion.identity);
        }
    }


    void CoinAudio()
    {
        audioSource.PlayOneShot(coinAudio);
    }

    void HeartAudio()
    {
        audioSource.PlayOneShot(heartAudio);
    }

    void EnemyAudio()
    {
        audioSource.PlayOneShot(enemyAudio);
    }
    void HeartIconManager()
    {
        foreach(Image img in images)
        {
            img.sprite = whiteHeart;
        }

        for (int i = 0; i < health; i++)
        {
            images[i].sprite = redHeart;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    void DisableOnGameOver()
    {
        ballMovement.enabled = false;
        ballCollider.enabled = false;
    }
    public void TauggleCheat()
    {
        isCheat = !isCheat;
    }
}

