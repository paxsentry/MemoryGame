using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
   [SerializeField]
   private GameObject selectPuzzlePanel, puzzleLevelPanel;

   [SerializeField]
   private Animator selectPuzzleAnim, puzzleLevelAnim;

   private string selectedPuzzle;

   public void BackToPuzzleSelectMenu()
   {
      StartCoroutine(ShowPuzzleSelectMenu());
   }

   IEnumerator ShowPuzzleSelectMenu()
   {
      selectPuzzlePanel.SetActive(true);
      selectPuzzleAnim.Play("SelectSlideIn");
      puzzleLevelAnim.Play("LevelSelectorSlideOut");
      yield return new WaitForSeconds(1f);
      puzzleLevelPanel.SetActive(false);
   }
}