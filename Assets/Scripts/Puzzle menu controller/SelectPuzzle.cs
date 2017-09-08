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

   [SerializeField]
   private LevelLocker levelLocker;

   private string _selectedPuzzle;

   public void SelectedPuzzle()
   {
      _selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

      puzzleGameManager.SetSelectedPuzzle(_selectedPuzzle);

      levelLocker.CheckWhichLevelsAreUnlocked(_selectedPuzzle);

      selectLevel.SetSelectPuzzle(_selectedPuzzle);

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