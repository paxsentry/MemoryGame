using UnityEngine;

public class MusicController : MonoBehaviour
{
   [SerializeField]
   private PuzzleGameSaver puzzleGameSaver;

   private AudioSource bgMusic;

   private float _musicVolume;

   private void Awake()
   {
      GetAudioSource();
   }

   private void Start()
   {
      _musicVolume = puzzleGameSaver.musicVolume;
      MusicOnOff(_musicVolume);
   }

   void GetAudioSource()
   {
      bgMusic = GetComponent<AudioSource>();
   }

   public void SetMusicVolume(float volume)
   {
      MusicOnOff(volume);
   }

   void MusicOnOff(float volume)
   {
      _musicVolume = volume;
      bgMusic.volume = _musicVolume;

      if (bgMusic.volume > 0)
      {
         if (!bgMusic.isPlaying)
         {
            bgMusic.Play();
         }

         puzzleGameSaver.musicVolume = _musicVolume;
         puzzleGameSaver.SaveGameData();
      }
      else if (bgMusic.volume == 0)
      {
         if (bgMusic.isPlaying)
         {
            bgMusic.Stop();
         }

         puzzleGameSaver.musicVolume = _musicVolume;
         puzzleGameSaver.SaveGameData();
      }
   }

   public float GetMusicVolume()
   {
      return _musicVolume;
   }
}