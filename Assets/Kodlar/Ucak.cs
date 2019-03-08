using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ucak : MonoBehaviour
{
    public float Hiz, YukselisHizi,Mesafe,SkorMesafe;
    public Transform baslangicnoktasi;
    public Text mesafeYazi,mesafeoyunsonuyazi,skormesafeyazi;
    public GameObject oyunSonuPanel,oyunPanel,baslangicPanel;
    public int j = 1;

    void Start()
    {
        oyunSonuPanel.SetActive(false);
        oyunPanel.SetActive(false);
        baslangicPanel.SetActive(true);
        Hiz = 0;
        YukselisHizi = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        j = 1;

        GetComponent<Rigidbody2D>().transform.localPosition = new Vector2(0, 0);

    }
    void Update()
    {
        Mesafe = Vector2.Distance(baslangicnoktasi.position, transform.position);
        mesafeYazi.text = (int)Mesafe + "M";
        transform.Translate(Hiz*Time.deltaTime,0,0);
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * YukselisHizi);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * YukselisHizi);
        }
    }
    void OnTriggerEnter2D(Collider2D nesne)
    {
        if (nesne.gameObject.tag == "Gecis")
        {
            nesne.gameObject.transform.root.gameObject.GetComponent<Yol>().aktif = true;
        }
    }
    void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "Engel")
        {
            Time.timeScale = 0;
            OyunSonu();

        }
    }
    public void Butonlar(int i)
    {
        if (i==0)
        {
            Hiz = 5;
            YukselisHizi = 200;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            oyunPanel.SetActive(false);
            baslangicPanel.SetActive(false);
            oyunPanel.SetActive(true);

        }
    }
    public void Yeniden(int j)
    {
        if (j == 0)
        {
            Start();
        }
    }
    void OyunSonu()
    {
        oyunPanel.SetActive(false);
        oyunSonuPanel.SetActive(true);
        mesafeoyunsonuyazi.text ="Mesafe : " +(int)Mesafe + "M";
        SkorMesafe = PlayerPrefs.GetFloat("SkorMesafemiz");
        j = 0;
        if (SkorMesafe>Mesafe)
        {
            skormesafeyazi.text = "Skor Mesafe : "+(int)SkorMesafe+"M";
        }
        else
        {
            SkorMesafe = Mesafe;
            PlayerPrefs.SetFloat("SkorMesafemiz", SkorMesafe);
            skormesafeyazi.text = "Skor Mesafe : " + (int)SkorMesafe + "M";

        }
    }
}
