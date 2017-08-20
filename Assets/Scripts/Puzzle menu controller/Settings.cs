using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

   [SerializeField]
   private GameObject settingsPanel;

   [SerializeField]
   private Animator settingsAnim;

   public void OpenSettingsPanel()
   {
      settingsPanel.SetActive(true);
      settingsAnim.Play("SettingsSlideIn");
   }

   public void CloseSettingsPanel()
   {
      StartCoroutine(CloseSettings());
   }

   IEnumerator CloseSettings()
   {
      settingsAnim.Play("SettingsSlideOut");
      yield return new WaitForSeconds(1f);
      settingsPanel.SetActive(false);
   }
}