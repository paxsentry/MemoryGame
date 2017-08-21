using System.Collections;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameManager puzzleGameManager;

   [SerializeField]
   private GameObject selectPuzzlePanel, puzzleLevelSelector;

   [SerializeField]
   private Animator selectPuzzleAnim, puzzleLevelAnim;

   [SerializeField]
   private SelectLevel selectLevel;

   private string _selectPuzzle;

   public void SelectedPuzzle()
   {
      _selectPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

      puzzleGameManager.SetSelectedPuzzle(_selectPuzzle);

      selectLevel.SetSelectPuzzle(_selectPuzzle);

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