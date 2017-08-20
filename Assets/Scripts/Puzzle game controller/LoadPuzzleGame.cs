using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour
{
   [SerializeField]
   private GameObject puzzleLevelSelectPanel;

   [SerializeField]
   private Animator puzzleLevelSelectAnim;

   [SerializeField]
   private GameObject puzzleGamePanel01, puzzleGamePanel02, puzzleGamePanel03, puzzleGamePanel04, puzzleGamePanel05;

   [SerializeField]
   private Animator puzzleGamePanelAnim01, puzzleGamePanelAnim02, puzzleGamePanelAnim03, puzzleGamePanelAnim04, puzzleGamePanelAnim05;

   public void LoadPuzzle(int level, string puzzle)
   {

   }
}