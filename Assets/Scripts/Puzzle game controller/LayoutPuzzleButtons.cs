using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutPuzzleButtons : MonoBehaviour
{
   [SerializeField]
   private Transform puzzleLevel01, puzzleLevel02, puzzleLevel03, puzzleLevel04, puzzleLevel05;

   public List<Button> level01Buttons, level02Buttons, level03Buttons, level04Buttons, level05Buttons;

   public List<Animator> level01Anims, level02Anims, level03Anims, level04Anims, level05Anims;

   [SerializeField]
   private Sprite[] puzzleButtonsBacksideImage;

   private int _puzzleLevel;

   private string _selectedPuzzle;

   public void LayoutButtons(int level, string puzzle)
   {
      _puzzleLevel = level;
      _selectedPuzzle = puzzle;

      LayoutPuzzle();
   }

   void LayoutPuzzle()
   {
      switch (_puzzleLevel)
      {
         case 0:
            foreach (Button btn in level01Buttons)
            {
               if (!btn.gameObject.activeInHierarchy)
               {
                  btn.gameObject.SetActive(true);
                  btn.gameObject.transform.SetParent(puzzleLevel01, false);

                  SetBackgroundImage(btn);
               }
            }
            break;

         case 1:
            foreach (Button btn in level02Buttons)
            {
               if (!btn.gameObject.activeInHierarchy)
               {
                  btn.gameObject.SetActive(true);
                  btn.gameObject.transform.SetParent(puzzleLevel02, false);

                  SetBackgroundImage(btn);
               }
            }
            break;

         case 2:
            foreach (Button btn in level03Buttons)
            {
               if (!btn.gameObject.activeInHierarchy)
               {
                  btn.gameObject.SetActive(true);
                  btn.gameObject.transform.SetParent(puzzleLevel03, false);

                  SetBackgroundImage(btn);
               }
            }
            break;

         case 3:
            foreach (Button btn in level04Buttons)
            {
               if (!btn.gameObject.activeInHierarchy)
               {
                  btn.gameObject.SetActive(true);
                  btn.gameObject.transform.SetParent(puzzleLevel04, false);

                  SetBackgroundImage(btn);
               }
            }
            break;

         case 4:
            foreach (Button btn in level05Buttons)
            {
               if (!btn.gameObject.activeInHierarchy)
               {
                  btn.gameObject.SetActive(true);
                  btn.gameObject.transform.SetParent(puzzleLevel05, false);

                  SetBackgroundImage(btn);
               }
            }
            break;

         default:
            break;
      }
   }

   private void SetBackgroundImage(Button btn)
   {
      if (_selectedPuzzle == "Candy puzzle")
      {
         btn.image.sprite = puzzleButtonsBacksideImage[0];
      }
      else if (_selectedPuzzle == "Transport puzzle")
      {
         btn.image.sprite = puzzleButtonsBacksideImage[1];
      }
      else if (_selectedPuzzle == "Fruit puzzle")
      {
         btn.image.sprite = puzzleButtonsBacksideImage[2];
      }
   }
}