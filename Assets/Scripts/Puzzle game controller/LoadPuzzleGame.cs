using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameManager puzzleGameManager;

   [SerializeField]
   private LevelLocker levelLocker;

   [SerializeField]
   private LayoutPuzzleButtons layoutPuzzleButtons;

   [SerializeField]
   private GameObject puzzleLevelSelectPanel;

   [SerializeField]
   private Animator puzzleLevelSelectAnim;

   [SerializeField]
   private GameObject puzzleGamePanel01, puzzleGamePanel02, puzzleGamePanel03, puzzleGamePanel04, puzzleGamePanel05;

   [SerializeField]
   private Animator puzzleGamePanelAnim01, puzzleGamePanelAnim02, puzzleGamePanelAnim03, puzzleGamePanelAnim04, puzzleGamePanelAnim05;

   private int _puzzleLevel;

   private string _selectedPuzzle;

   private List<Animator> anims;

   public void LoadPuzzle(int level, string puzzle)
   {
      _puzzleLevel = level;
      _selectedPuzzle = puzzle;

      layoutPuzzleButtons.LayoutButtons(level, puzzle);

      switch (_puzzleLevel)
      {
         case 0:
            StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel01, puzzleGamePanelAnim01));
            break;
         case 1:
            StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel02, puzzleGamePanelAnim02));
            break;
         case 2:
            StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel03, puzzleGamePanelAnim03));
            break;
         case 3:
            StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel04, puzzleGamePanelAnim04));
            break;
         case 4:
            StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel05, puzzleGamePanelAnim05));
            break;
      }
   }

   public void BackToPuzzleLevelSelection()
   {
      anims = puzzleGameManager.ResetGameplay();

      levelLocker.CheckWhichLevelsAreUnlocked(_selectedPuzzle);

      switch (_puzzleLevel)
      {
         case 0:
            StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel01, puzzleGamePanelAnim01));
            break;
         case 1:
            StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel02, puzzleGamePanelAnim02));
            break;
         case 2:
            StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel03, puzzleGamePanelAnim03));
            break;
         case 3:
            StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel04, puzzleGamePanelAnim04));
            break;
         case 4:
            StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel05, puzzleGamePanelAnim05));
            break;
      }
   }

   IEnumerator LoadPuzzleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGameAnim)
   {
      puzzleLevelSelectPanel.SetActive(true);
      puzzleLevelSelectAnim.Play("LevelSelectorSlideIn");
      puzzleGameAnim.Play("SlideOut");
      yield return new WaitForSeconds(1f);

      foreach (Animator anim in anims)
      {
         anim.Play("Idle");
      }

      yield return new WaitForSeconds(.5f);

      puzzleGamePanel.SetActive(false);
   }

   IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGameAnim)
   {
      puzzleGamePanel.SetActive(true);
      puzzleGameAnim.Play("SlideIn");
      puzzleLevelSelectAnim.Play("LevelSelectorSlideOut");
      yield return new WaitForSeconds(1f);
      puzzleLevelSelectPanel.SetActive(false);
   }
}