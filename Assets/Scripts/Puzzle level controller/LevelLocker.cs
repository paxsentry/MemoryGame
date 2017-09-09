using UnityEngine;

public class LevelLocker : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameSaver puzzleGameSaver;

   [SerializeField]
   private StarsLocker starsLocker;

   [SerializeField]
   private GameObject[] levelStarHolders;

   [SerializeField]
   private GameObject[] levelPadlocks;

   private bool[] candyPuzzleLevels;
   private bool[] transportPuzzleLevels;
   private bool[] fruitPuzzleLevels;

   private void Awake()
   {
      DeactivatePadlocksAndStarHolders();
   }

   private void Start()
   {
      GetLevels();
   }

   public void CheckWhichLevelsAreUnlocked(string selectedPuzzle)
   {
      DeactivatePadlocksAndStarHolders();
      GetLevels();

      switch (selectedPuzzle)
      {
         case "Candy puzzle":
            for (int i = 0; i < candyPuzzleLevels.Length; i++)
            {
               if (candyPuzzleLevels[i])
               {
                  levelStarHolders[i].SetActive(true);
                  starsLocker.ActivateStars(i, selectedPuzzle);
               }
               else
               {
                  levelPadlocks[i].SetActive(true);
               }
            }
            break;

         case "Transport puzzle":
            for (int i = 0; i < transportPuzzleLevels.Length; i++)
            {
               if (transportPuzzleLevels[i])
               {
                  levelStarHolders[i].SetActive(true);
                  starsLocker.ActivateStars(i, selectedPuzzle);
               }
               else
               {
                  levelPadlocks[i].SetActive(true);
               }
            }
            break;

         case "Fruit puzzle":
            for (int i = 0; i < fruitPuzzleLevels.Length; i++)
            {
               if (fruitPuzzleLevels[i])
               {
                  levelStarHolders[i].SetActive(true);
                  starsLocker.ActivateStars(i, selectedPuzzle);
               }
               else
               {
                  levelPadlocks[i].SetActive(true);
               }
            }
            break;

         default:
            break;
      }
   }

   void DeactivatePadlocksAndStarHolders()
   {
      for (int i = 0; i < levelStarHolders.Length; i++)
      {
         levelStarHolders[i].SetActive(false);
         levelPadlocks[i].SetActive(false);
      }
   }

   void GetLevels()
   {
      candyPuzzleLevels = puzzleGameSaver.candyPuzzleLevels;
      transportPuzzleLevels = puzzleGameSaver.transportPuzzleLevels;
      fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
   }

   public bool[] GetPuzzleLevels(string selectedPuzzle)
   {
      switch (selectedPuzzle)
      {
         case "Candy puzzle":
            return candyPuzzleLevels;
            break;

         case "Transport puzzle":
            return transportPuzzleLevels;
            break;

         case "Fruit puzzle":
            return fruitPuzzleLevels;
            break;

         default:
            return null;
            break;
      }
   }
}