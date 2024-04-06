using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSprites : MonoBehaviour
{
    [SerializeField] private Sprite[] Dialogues;
    [SerializeField] private Image spriteRender;
    [SerializeField] private GameObject Highlight;
    private GameObject clone;
    private int number = 1;
    private bool canClick = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchSprite();
        }
    }
    public void SwitchSprite()
    {
        if (canClick)
        {
            SetSprite(number);
            number += 1;
        }
    }

    private void SetSprite(int spriteIndex)
    {
        canClick = false;
        StartCoroutine(Cooldown(0.5f));
        if (spriteIndex >= 0 && spriteIndex < Dialogues.Length)
        {
            if (spriteIndex == 3)
                Highlight.SetActive(true);
            if (spriteIndex == 5)
                Highlight.SetActive(false);

            spriteRender.enabled = true;
            spriteRender.sprite = Dialogues[spriteIndex];
        }
        else
            SceneManager.LoadScene(0);
    }

    private IEnumerator Cooldown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canClick = true;
    }
}
