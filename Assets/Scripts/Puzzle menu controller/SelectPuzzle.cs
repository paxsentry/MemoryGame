using UnityEngine;

public class SelectPuzzle : MonoBehaviour
{
   [SerializeField]
   private GameObject selectPuzzlePanel;

   [SerializeField]
   private Animator selectPuzzleAnim;

   private string selectPuzzle;

   public void SelectedPuzzle()
   {
      selectPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

      Debug.Log(selectPuzzle);
   }
}