using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePuzzleButtonsAndAnimators : MonoBehaviour
{
   [SerializeField]
   private Button puzzleButton;

   [SerializeField]
   private LayoutPuzzleButtons layoutPuzzleButtons;

   private int puzzleGame01 = 6;
   private int puzzleGame02 = 12;
   private int puzzleGame03 = 18;
   private int puzzleGame04 = 24;
   private int puzzleGame05 = 30;

   private List<Button> _level01Buttons = new List<Button>();
   private List<Button> _level02Buttons = new List<Button>();
   private List<Button> _level03Buttons = new List<Button>();
   private List<Button> _level04Buttons = new List<Button>();
   private List<Button> _level05Buttons = new List<Button>();

   private List<Animator> _level01Anims = new List<Animator>();
   private List<Animator> _level02Anims = new List<Animator>();
   private List<Animator> _level03Anims = new List<Animator>();
   private List<Animator> _level04Anims = new List<Animator>();
   private List<Animator> _level05Anims = new List<Animator>();

   private void Awake()
   {
      CreateButtons();
      GetAnimators();
   }

   void Start()
   {
      AssignButtonsAndAnims();
   }

   void CreateButtons()
   {
      for (int i = 0; i < puzzleGame01; i++)
      {
         Button btn = Instantiate(puzzleButton);
         btn.gameObject.name = "" + i;

         _level01Buttons.Add(btn);
      }

      for (int i = 0; i < puzzleGame02; i++)
      {
         Button btn = Instantiate(puzzleButton);
         btn.gameObject.name = "" + i;

         _level02Buttons.Add(btn);
      }

      for (int i = 0; i < puzzleGame03; i++)
      {
         Button btn = Instantiate(puzzleButton);
         btn.gameObject.name = "" + i;

         _level03Buttons.Add(btn);
      }

      for (int i = 0; i < puzzleGame04; i++)
      {
         Button btn = Instantiate(puzzleButton);
         btn.gameObject.name = "" + i;

         _level04Buttons.Add(btn);
      }

      for (int i = 0; i < puzzleGame05; i++)
      {
         Button btn = Instantiate(puzzleButton);
         btn.gameObject.name = "" + i;

         _level05Buttons.Add(btn);
      }
   }

   void GetAnimators()
   {
      for (int i = 0; i < _level01Buttons.Count; i++)
      {
         _level01Anims.Add(_level01Buttons[i].gameObject.GetComponent<Animator>());
         _level01Buttons[i].gameObject.SetActive(false);
      }

      for (int i = 0; i < _level02Buttons.Count; i++)
      {
         _level02Anims.Add(_level02Buttons[i].gameObject.GetComponent<Animator>());
         _level02Buttons[i].gameObject.SetActive(false);
      }

      for (int i = 0; i < _level03Buttons.Count; i++)
      {
         _level03Anims.Add(_level03Buttons[i].gameObject.GetComponent<Animator>());
         _level03Buttons[i].gameObject.SetActive(false);
      }

      for (int i = 0; i < _level04Buttons.Count; i++)
      {
         _level04Anims.Add(_level04Buttons[i].gameObject.GetComponent<Animator>());
         _level04Buttons[i].gameObject.SetActive(false);
      }

      for (int i = 0; i < _level05Buttons.Count; i++)
      {
         _level05Anims.Add(_level05Buttons[i].gameObject.GetComponent<Animator>());
         _level05Buttons[i].gameObject.SetActive(false);
      }
   }

   void AssignButtonsAndAnims()
   {
      layoutPuzzleButtons.level01Buttons = _level01Buttons;
      layoutPuzzleButtons.level02Buttons = _level02Buttons;
      layoutPuzzleButtons.level03Buttons = _level03Buttons;
      layoutPuzzleButtons.level04Buttons = _level04Buttons;
      layoutPuzzleButtons.level05Buttons = _level05Buttons;

      layoutPuzzleButtons.level01Anims = _level01Anims;
      layoutPuzzleButtons.level02Anims = _level02Anims;
      layoutPuzzleButtons.level03Anims = _level03Anims;
      layoutPuzzleButtons.level04Anims = _level04Anims;
      layoutPuzzleButtons.level05Anims = _level05Anims;
   }
}