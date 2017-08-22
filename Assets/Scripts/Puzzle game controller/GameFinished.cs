﻿using System.Collections;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
   [SerializeField]
   private GameObject gameFinishedPanel;

   [SerializeField]
   private Animator gamepanelAnim, star1Anim, star2Anim, star3Anim, textAnim;

   private void Start()
   {
      ShowGameFinishedPanel(3);
   }

   public void ShowGameFinishedPanel(int stars)
   {
      StartCoroutine(ShowPanel(stars));
   }

   public void HideGameFinishedPanel()
   {
      if (gameFinishedPanel.activeInHierarchy)
      {
         StartCoroutine(HidePanel());
      }
   }

   IEnumerator ShowPanel(int stars)
   {
      gameFinishedPanel.SetActive(true);

      gamepanelAnim.Play("FadeIn");

      yield return new WaitForSeconds(1.7f);

      switch (stars)
      {
         case 1:
            star1Anim.Play("FadeIn");
            yield return new WaitForSeconds(.1f);
            textAnim.Play("FadeIn");
            break;

         case 2:
            star1Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star2Anim.Play("FadeIn");
            yield return new WaitForSeconds(.1f);
            textAnim.Play("FadeIn");
            break;

         case 3:
            star1Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star2Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star3Anim.Play("FadeIn");
            yield return new WaitForSeconds(.1f);
            textAnim.Play("FadeIn");
            break;

         default:
            break;
      }
   }

   IEnumerator HidePanel()
   {
      gamepanelAnim.Play("FadeOut");

      star1Anim.Play("FadeOut");
      star2Anim.Play("FadeOut");
      star3Anim.Play("FadeOut");

      textAnim.Play("FadeOut");

      yield return new WaitForSeconds(1.5f);

      gameFinishedPanel.SetActive(false);
   }
}