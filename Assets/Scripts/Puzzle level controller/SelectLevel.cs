﻿using System.Collections;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameManager puzzleGameManager;

   [SerializeField]
   private GameObject selectPuzzlePanel, puzzleLevelPanel;

   [SerializeField]
   private Animator selectPuzzleAnim, puzzleLevelAnim;

   [SerializeField]
   private LoadPuzzleGame loadPuzzleGame;

   private string _selectedPuzzle;

   public void BackToPuzzleSelectMenu()
   {
      StartCoroutine(ShowPuzzleSelectMenu());
   }

   public void SelectPuzzleLevel()
   {
      int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

      puzzleGameManager.SetLevel(level);

      loadPuzzleGame.LoadPuzzle(level, _selectedPuzzle);
   }

   public void SetSelectPuzzle(string selectedPuzzle)
   {
      _selectedPuzzle = selectedPuzzle;
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