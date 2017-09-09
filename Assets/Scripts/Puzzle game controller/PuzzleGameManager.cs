using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
   [SerializeField]
   private GameFinished gameFinished;

   [SerializeField]
   private PuzzleGameSaver puzzleGameSaver;

   [SerializeField]
   private List<Sprite> _gamePuzzles = new List<Sprite>();

   private List<Button> _puzzleButtons = new List<Button>();

   private List<Animator> _puzzleButtonAnimators = new List<Animator>();

   private int _level;
   private string _selectedPuzzle;

   private Sprite _puzzleBackgroundImage;

   private bool firstGuess, secondGuess;
   private int firstGuessIndex, secondGuessIndex;
   private string firstGuessPuzzle, secondGuessPuzzle;

   private int _countGuesses;
   private int _countCorrectGuesses;
   private int _gameGuesses;

   public void PickAPuzzle()
   {
      if (!firstGuess)
      {
         firstGuess = true;
         firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
         firstGuessPuzzle = _gamePuzzles[firstGuessIndex].name;

         StartCoroutine(TurnPuzzleButtonUp(_puzzleButtonAnimators[firstGuessIndex], _puzzleButtons[firstGuessIndex], _gamePuzzles[firstGuessIndex]));
      }
      else if (!secondGuess)
      {
         secondGuess = true;
         secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
         secondGuessPuzzle = _gamePuzzles[secondGuessIndex].name;

         StartCoroutine(TurnPuzzleButtonUp(_puzzleButtonAnimators[secondGuessIndex], _puzzleButtons[secondGuessIndex], _gamePuzzles[secondGuessIndex]));
         StartCoroutine(CheckPuzzleMatch(_puzzleBackgroundImage));

         _countGuesses++;
      }
   }

   IEnumerator CheckPuzzleMatch(Sprite background)
   {
      yield return new WaitForSeconds(1.7f);

      if (firstGuessPuzzle == secondGuessPuzzle)
      {
         _puzzleButtonAnimators[firstGuessIndex].Play("FadeOut");
         _puzzleButtonAnimators[secondGuessIndex].Play("FadeOut");

         CheckGameCompleted();
      }
      else
      {
         StartCoroutine(TurnPuzzleButtonDown(_puzzleButtonAnimators[firstGuessIndex], _puzzleButtons[firstGuessIndex], _puzzleBackgroundImage));
         StartCoroutine(TurnPuzzleButtonDown(_puzzleButtonAnimators[secondGuessIndex], _puzzleButtons[secondGuessIndex], _puzzleBackgroundImage));
      }

      yield return new WaitForSeconds(.7f);

      firstGuess = secondGuess = false;
   }

   IEnumerator TurnPuzzleButtonUp(Animator anim, Button btn, Sprite puzzle)
   {
      anim.Play("TurnUp");
      yield return new WaitForSeconds(.4f);
      btn.image.sprite = puzzle;
   }

   IEnumerator TurnPuzzleButtonDown(Animator anim, Button btn, Sprite puzzle)
   {
      anim.Play("TurnBack");
      yield return new WaitForSeconds(.4f);
      btn.image.sprite = puzzle;
   }

   void CheckGameCompleted()
   {
      _countCorrectGuesses++;

      if (_countCorrectGuesses == _gameGuesses)
      {
         CheckHowManyGuesses();
      }
   }

   void CheckHowManyGuesses()
   {
      int howManyGuesses = 0;

      switch (_level)
      {
         case 0:
            howManyGuesses = 5;
            break;

         case 1:
            howManyGuesses = 10;
            break;

         case 2:
            howManyGuesses = 15;
            break;

         case 3:
            howManyGuesses = 20;
            break;

         case 4:
            howManyGuesses = 25;
            break;

         default:
            break;
      }

      if (_countGuesses < howManyGuesses)
      {
         gameFinished.ShowGameFinishedPanel(3);
         puzzleGameSaver.Save(_level, _selectedPuzzle, 3);
      }
      else if (_countGuesses < (howManyGuesses + 5))
      {
         gameFinished.ShowGameFinishedPanel(2);
         puzzleGameSaver.Save(_level, _selectedPuzzle, 2);
      }
      else
      {
         gameFinished.ShowGameFinishedPanel(1);
         puzzleGameSaver.Save(_level, _selectedPuzzle, 1);
      }
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

      _gameGuesses = _puzzleButtons.Count / 2;

      _puzzleBackgroundImage = _puzzleButtons[0].image.sprite;

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

   public List<Animator> ResetGameplay()
   {
      firstGuess = secondGuess = false;
      _countCorrectGuesses = _countGuesses = 0;

      gameFinished.HideGameFinishedPanel();

      return _puzzleButtonAnimators;
   }
}