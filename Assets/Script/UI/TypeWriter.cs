using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip TypeSound;
    [Multiline]
    public string yazi;

    AudioSource audSrc;
    Text thisText;
    public GameObject play;
    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<Text>();

        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in yazi)
        {
            thisText.text += i.ToString();

            audSrc.pitch = Random.Range(0.8f, 1.2f);
            audSrc.PlayOneShot(TypeSound);
            
            if (i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }
          
        }
        play.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
