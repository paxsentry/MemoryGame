using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupPuzzleGame : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameManager puzzleGameManager;

   private Sprite[] _candyPuzzleSprites, _transportPuzzleSprites, _fruitPuzzleSprites;

   private List<Sprite> _gamePuzzles = new List<Sprite>();

   private List<Button> _puzzleButtons = new List<Button>();

   private List<Animator> _puzzleButtonAnimators = new List<Animator>();

   private int _level;

   private string _selectedPuzzle;

   private int _looper;

   private void Awake()
   {
      _candyPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Candy");
      _transportPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Transport");
      _fruitPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Fruits");
   }

   void Shuffle(List<Sprite> sprites)
   {
      for (int i = 0; i < sprites.Count; i++)
      {
         Sprite temp = sprites[i];

         int randomIndex = Random.Range(i, sprites.Count);
         sprites[i] = sprites[randomIndex];
         sprites[randomIndex] = temp;
      }
   }

   public void SetLevelAndPuzzle(int level, string puzzle)
   {
      _level = level;
      _selectedPuzzle = puzzle;

      PrepareGameSprites();

      puzzleGameManager.SetGamePuzzleSprites(_gamePuzzles);
   }

   private void PrepareGameSprites()
   {
      _gamePuzzles.Clear();
      _gamePuzzles = new List<Sprite>();

      int index = 0;

      switch (_level)
      {
         case 0:
            _looper = 6;
            break;
         case 1:
            _looper = 12;
            break;
         case 2:
            _looper = 18;
            break;
         case 3:
            _looper = 24;
            break;
         case 4:
            _looper = 30;
            break;
      }

      switch (_selectedPuzzle)
      {
         case "Candy puzzle":
            for (int i = 0; i < _looper; i++)
            {
               if (index == _looper / 2) { index = 0; }

               _gamePuzzles.Add(_candyPuzzleSprites[index]);

               index++;
            }
            break;

         case "Tranport puzzle":
            for (int i = 0; i < _looper; i++)
            {
               if (index == _looper / 2) { index = 0; }

               _gamePuzzles.Add(_transportPuzzleSprites[index]);

               index++;
            }
            break;

         case "Fruits puzzle":
            for (int i = 0; i < _looper; i++)
            {
               if (index == _looper / 2) { index = 0; }

               _gamePuzzles.Add(_fruitPuzzleSprites[index]);

               index++;
            }
            break;
      }

      Shuffle(_gamePuzzles);
   }

   public void SetPuzzleButtonsAndAnimators(List<Button> buttons, List<Animator> animators)
   {
      _puzzleButtons = buttons;
      _puzzleButtonAnimators = animators;

      puzzleGameManager.SetupButtonsAndAnimators(buttons, animators);
   }
}