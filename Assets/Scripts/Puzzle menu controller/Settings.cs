using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

   [SerializeField]
   private GameObject settingsPanel;

   [SerializeField]
   private Animator settingsAnim;

   [SerializeField]
   private MusicController musicController;

   [SerializeField]
   private Slider slider;

   public void OpenSettingsPanel()
   {
      slider.value = musicController.GetMusicVolume();
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

   public void GetVolume(float volume)
   {
      musicController.SetMusicVolume(volume);
   }
}