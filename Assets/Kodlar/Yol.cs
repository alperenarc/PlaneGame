using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yol : MonoBehaviour
{
    public bool aktif;
    public GameObject[] Objeler;

    void Start()
    {
        float altsayi = Random.Range(0, 2);
        float ustsayi = Random.Range(0, 2);

        if (altsayi == 1)
        {
            Objeler[1].SetActive(false);
        }
        else
        {
            Objeler[1].SetActive(true);
        }

        if (ustsayi == 1)
        {
            Objeler[2].SetActive(false);
        }
        else
        {
            Objeler[2].SetActive(true);
        }
        if (altsayi == 1 && ustsayi == 1)
        {
            
            Objeler[3].transform.localPosition = new Vector2(0, Random.Range(-2.5f, 2.5f));
        }
        Objeler[0].transform.localPosition = new Vector2(Random.Range(-3.5f, 3.5f), 0);
        Objeler[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (aktif)
        {
            Objeler[3].SetActive(false);
            Invoke("YoluTasi", 4);
            aktif = false;
        }
    }
    void YoluTasi()
    {
        float altsayi = Random.Range(0, 2);
        float ustsayi = Random.Range(0, 2);

        if (altsayi == 1)
        {
            Objeler[1].SetActive(false);
        }
        else
        {
            Objeler[1].SetActive(true);
        }

        if (ustsayi == 1)
        {
            Objeler[2].SetActive(false);
        }
        else
        {
            Objeler[2].SetActive(true);
        }
        if (altsayi == 1 && ustsayi==1)
        {
            Objeler[3].SetActive(true);
            Objeler[3].transform.localPosition = new Vector2(0, Random.Range(-2.5f, 2.5f));
        }
        else if(altsayi==1 && ustsayi !=1)
        {
            Objeler[3].transform.localPosition = new Vector2(0, Random.Range(-2.5f, 0));
        }
        else if (altsayi != 1 && ustsayi == 1)
        {
            Objeler[3].transform.localPosition = new Vector2(0, Random.Range(0, 2.5f));
        }
        else if (altsayi != 1 && ustsayi != 1)
        {
            Objeler[3].transform.localPosition = new Vector2(0, Random.Range(0, 0));
        }
        Objeler[0].transform.localPosition = new Vector2(Random.Range(-3.5f,3.5f),0);
        transform.position = transform.position + new Vector3(40.252f, 0, 0);
        Objeler[3].SetActive(true);
    }

}
