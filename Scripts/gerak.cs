using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class gerak : MonoBehaviour
{
    public int speed, powerJump;
    Rigidbody2D lompat;

    public int pindah;
    public bool balik, tanah;
    public LayerMask targetLayer;
    public Transform cekTanah;
    public float jangkauan;
    Animator animPlayer;
    public int koin, nyawa;

    Vector2 mulai;
    public bool ulang;

    TextMeshProUGUI infoKoin, infoNyawa;
    public GameObject menang, kalah;

    public bool tombolKiri, tombolKanan;

    // Start is called before the first frame update
    void Start()
    {
        infoKoin = GameObject.Find("UIKoin").GetComponent<TextMeshProUGUI>();
        infoNyawa= GameObject.Find("UINyawa").GetComponent<TextMeshProUGUI>();
        lompat = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        mulai = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        infoKoin.text = "Koin: " + koin.ToString();
        infoNyawa.text = "Nyawa: " + nyawa.ToString();

        if (ulang)
        {
            transform.position = mulai;
            ulang = false;
        }
        if (nyawa <= 0)
        {
            Destroy(gameObject);
            kalah.SetActive(true);
            Application.LoadLevel(0);
        }
        if (koin >= 2)
        {
            menang.SetActive(true);
        }

        tanah = Physics2D.OverlapCircle(cekTanah.position, jangkauan, targetLayer);
        if (tanah)
        {
            animPlayer.SetBool("lompat", false);
        } else
        {
            animPlayer.SetBool("lompat", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") || tombolKanan)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            pindah = 1;
            animPlayer.SetBool("lari", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey("left") || tombolKiri)
        {
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
            pindah = -1;
            animPlayer.SetBool("lari", true);
        } else
        {
            animPlayer.SetBool("lari", false);
        }

        /*if ((tanah) && (Input.GetKey(KeyCode.Mouse0) || Input.GetKey("up")))
        {
            lompat.AddForce(new Vector2(0, powerJump));
        }*/

        if (pindah > 0 && !balik)
        {
            balikBadan();
        }
        else if (pindah < 0 && balik)
        {
            balikBadan();
        }
    }

    void balikBadan()
    {
        balik = !balik;
        Vector3 player = transform.localScale;
        player.x *= -1;
        transform.localScale = player;
    }

    public void TekanKiri()
    {
        tombolKiri = true;
    }

    public void LepasKiri()
    {
        tombolKiri = false;
    }

    public void TekanKanan()
    {
        tombolKanan = true;
    }

    public void LepasKanan()
    {
        tombolKanan = false;
    }

    public void TekanLompat()
    {
        if (tanah)
        {
            lompat.AddForce(new Vector2(0, powerJump));
        }
    }
}
