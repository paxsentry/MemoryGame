using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData : MonoBehaviour
{
   private bool[] _candyPuzzleLevels;
   private bool[] _transportPuzzleLevels;
   private bool[] _fruitPuzzleLevels;

   private int[] _candyPuzzleLevelStars;
   private int[] _transportPuzzleLevelStars;
   private int[] _fruitPuzzleLevelStars;

   private bool _isGameStartedFirstTime;

   private float _musicVolume;

   public void SetCandyPuzzleLevels(bool[] levels) { _candyPuzzleLevels = levels; }
   public bool[] GetCandyPuzzleLevels() { return _candyPuzzleLevels; }

   public void SetTransportPuzzleLevels(bool[] levels) { _transportPuzzleLevels = levels; }
   public bool[] GetTransportPuzzleLevels() { return _transportPuzzleLevels; }

   public void SetFruitPuzzleLevels(bool[] levels) { _fruitPuzzleLevels = levels; }
   public bool[] GetFruitPuzzleLevels() { return _fruitPuzzleLevels; }

   public void SetCandyPuzzleLevelStars(int[] stars) { _candyPuzzleLevelStars = stars; }
   public int[] GetCandyPuzzleLevelStars() { return _candyPuzzleLevelStars; }

   public void SetTransportLevelStars(int[] stars) { _transportPuzzleLevelStars = stars; }
   public int[] GetTransportPuzzleLevelStars() { return _transportPuzzleLevelStars; }

   public void SetFruitPuzzleLevelStars(int[] stars) { _fruitPuzzleLevelStars = stars; }
   public int[] GetFruitPuzzleLevelStars() { return _fruitPuzzleLevelStars; }

   public void SetIsTheGameStartedFirstTime(bool firstTime) { _isGameStartedFirstTime = firstTime; }
   public bool GetIsTheGameStartedFirstTime() { return _isGameStartedFirstTime; }

   public void SetMusicVolume(float volume) { _musicVolume = volume; }
   public float GetMusicVolume() { return _musicVolume; }
}