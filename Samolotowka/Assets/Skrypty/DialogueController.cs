using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    public bool ready=false;
    public int lang;
    public Text t;
    public Image im;
    public string loaded;
    public float textdelay;
    public float texttime;
    public string calosc;
    public string dialogpath;
    public string dialog;
    private int letternumber = 0;
    public string currentspeaker;
    private StringReader SR;
    public int expression;
    private string imgpath;
    void Start()
    {
        Zaladuj();
    }
    void Update ()
    {
        if(ready)
        {
            if (loaded == "" || loaded == null)
            {
                ready = false;
                t.text = "";
                currentspeaker = "";
                im.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
            }
            else if (loaded[0] == '[')
            {
                currentspeaker = loaded.Substring(1, loaded.Length - 3);
                expression = Int32.Parse(loaded.Substring(loaded.Length - 1, 1));
                imgpath = "" + currentspeaker + expression.ToString();
                im.sprite = (Sprite)Resources.Load(imgpath, typeof(Sprite));
                loaded = SR.ReadLine();

            }
            else if (letternumber < loaded.Length)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    textdelay = 0.0f;
                    texttime = 0.0f;
                }
                if (texttime <= 0.0f)
                {
                    t.text += loaded[letternumber];
                    texttime = textdelay;
                    letternumber += 1;
                }
                texttime -= Time.deltaTime;
            }
            else
            {
                textdelay = 0.1f;
                if (Input.GetButtonDown("Fire1"))
                {
                    t.text = "";
                    loaded = SR.ReadLine();
                    letternumber = 0;
                }
            }
        }
        else
        {

        }
        
	}
    public void Zaladuj()
    {
        TextAsset txt = (TextAsset)Resources.Load(dialogpath, typeof(TextAsset));
        dialog = txt.text;

        SR = new StringReader(dialog);
    }
    public void Czytaj()
    {
        ready = true;
        loaded = SR.ReadLine();
        Debug.Log(loaded);
        im.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    }
}
