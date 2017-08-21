using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
   [SerializeField]
   private List<Sprite> _gamePuzzles = new List<Sprite>();

   private List<Button> _puzzleButtons = new List<Button>();

   private List<Animator> _puzzleButtonAnimators = new List<Animator>();

   private int _level;

   private string _selectedPuzzle;

   public void PickAPuzzle()
   {
      Debug.Log("Selected button is " + UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
   }

   void AddListener()
   {
      foreach (Button btn in _puzzleButtons)
      {
         btn.onClick.RemoveAllListeners();
         btn.onClick.AddListener(() => PickAPuzzle());
      }
   }

   public void SetupButtonsAndAnimators(List<Button> buttons, List<Animator> animators)
   {
      _puzzleButtons = buttons;
      _puzzleButtonAnimators = animators;

      AddListener();
   }

   public void SetGamePuzzleSprites(List<Sprite> puzzleSprites)
   {
      _gamePuzzles = puzzleSprites;
   }

   public void SetLevel(int level)
   {
      _level = level;
   }

   public void SetSelectedPuzzle(string selectedPuzzle)
   {
      _selectedPuzzle = selectedPuzzle;
   }
}