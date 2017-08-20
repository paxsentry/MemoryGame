using System.Collections;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour
{
   [SerializeField]
   private GameObject selectPuzzlePanel, puzzleLevelSelector;

   [SerializeField]
   private Animator selectPuzzleAnim, puzzleLevelAnim;

   private string selectPuzzle;

   public void SelectedPuzzle()
   {
     // selectPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

      StartCoroutine(ShowPuzzleLevelSeletor());
   }

   IEnumerator ShowPuzzleLevelSeletor()
   {
      puzzleLevelSelector.SetActive(true);
      selectPuzzleAnim.Play("SelectSlideOut");
      puzzleLevelAnim.Play("LevelSelectorSlideIn");
      yield return new WaitForSeconds(1f);
      selectPuzzlePanel.SetActive(false);
   }
}