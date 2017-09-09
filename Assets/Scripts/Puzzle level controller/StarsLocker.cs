using System.Collections.Generic;
using UnityEngine;

public class StarsLocker : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameSaver puzzleGameSaver;

   [SerializeField]
   private GameObject[] level01Stars, level02Stars, level03Stars, level04Stars, level05Stars;

   public int[] candyPuzzleLevelStars;
   public int[] transportPuzzleLevelStars;
   public int[] fruitPuzzleLevelStars;

   private void Awake() { }

   private void Start() { }

   public void ActivateStars(int level, string selectedPuzzle)
   {
      GetStars();

      int stars;

      switch (selectedPuzzle)
      {
         case "Candy puzzle":
            stars = candyPuzzleLevelStars[level];
            ActivateLevelStars(level, stars);
            break;

         case "Transport puzzle":
            stars = transportPuzzleLevelStars[level];
            ActivateLevelStars(level, stars);
            break;

         case "Fruit puzzle":
            stars = fruitPuzzleLevelStars[level];
            ActivateLevelStars(level, stars);
            break;

         default:
            break;
      }
   }

   void ActivateLevelStars(int level, int looper)
   {
      switch (level)
      {
         case 0:
            if (looper != 0)
            {
               for (int i = 0; i < looper; i++)
               {
                  level01Stars[i].SetActive(true);
               }
            }
            break;

         case 1:
            if (looper != 0)
            {
               for (int i = 0; i < looper; i++)
               {
                  level02Stars[i].SetActive(true);
               }
            }
            break;

         case 2:
            if (looper != 0)
            {
               for (int i = 0; i < looper; i++)
               {
                  level03Stars[i].SetActive(true);
               }
            }
            break;

         case 3:
            if (looper != 0)
            {
               for (int i = 0; i < looper; i++)
               {
                  level04Stars[i].SetActive(true);
               }
            }
            break;

         case 4:
            if (looper != 0)
            {
               for (int i = 0; i < looper; i++)
               {
                  level05Stars[i].SetActive(true);
               }
            }
            break;

         default:
            break;
      }
   }

   public void DeactivateStars()
   {
      for (int i = 0; i < level01Stars.Length; i++)
      {
         level01Stars[i].SetActive(false);
         level02Stars[i].SetActive(false);
         level03Stars[i].SetActive(false);
         level04Stars[i].SetActive(false);
         level05Stars[i].SetActive(false);
      }
   }

   void GetStars()
   {
      candyPuzzleLevelStars = puzzleGameSaver.candyPuzzleLevelStars;
      transportPuzzleLevelStars = puzzleGameSaver.transportPuzzleLevelStars;
      fruitPuzzleLevelStars = puzzleGameSaver.fruitPuzzleLevelStars;
   }
}