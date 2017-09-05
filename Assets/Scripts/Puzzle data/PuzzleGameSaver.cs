using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PuzzleGameSaver : MonoBehaviour
{
   private GameData gameData;

   public bool[] candyPuzzleLevels;
   public bool[] transportPuzzleLevels;
   public bool[] fruitPuzzleLevels;

   public int[] candyPuzzleLevelStars;
   public int[] transportPuzzleLevelStars;
   public int[] fruitPuzzleLevelStars;

   private bool _isGameStartedFirstTime;

   public float musicVolume;

   void InitialiseGame()
   {

   }

   void SaveGameData()
   {
      FileStream file = null;

      try
      {
         BinaryFormatter bf = new BinaryFormatter();

         file = File.Create(Application.persistentDataPath + "gameData.dat");

         if (gameData != null)
         {
            gameData.SetCandyPuzzleLevels(candyPuzzleLevels);
            gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
            gameData.SetFruitPuzzleLevels(fruitPuzzleLevels);

            gameData.SetCandyPuzzleLevelStars(candyPuzzleLevelStars);
            gameData.SetTransportLevelStars(transportPuzzleLevelStars);
            gameData.SetFruitPuzzleLevelStars(fruitPuzzleLevelStars);

            gameData.SetIsTheGameStartedFirstTime(_isGameStartedFirstTime);
            gameData.SetMusicVolume(musicVolume);

            bf.Serialize(file, gameData);
         }
      }
      catch (Exception e)
      {
         throw;
      }
      finally
      {
         if (file != null)
         {
            file.Close();
         }
      }
   }

   void LoadGameData()
   {
      FileStream file = null;

      try
      {
         BinaryFormatter bf = new BinaryFormatter();

         file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

         gameData = (GameData)bf.Deserialize(file);

         if (gameData != null)
         {
            candyPuzzleLevels = gameData.GetCandyPuzzleLevels();
            transportPuzzleLevels = gameData.GetTransportPuzzleLevels();
            fruitPuzzleLevels = gameData.GetFruitPuzzleLevels();

            candyPuzzleLevelStars = gameData.GetCandyPuzzleLevelStars();
            transportPuzzleLevelStars = gameData.GetTransportPuzzleLevelStars();
            fruitPuzzleLevelStars = gameData.GetFruitPuzzleLevelStars();

            musicVolume = gameData.GetMusicVolume();
         }
      }
      catch (Exception e)
      {
         throw;
      }
      finally
      {
         if (file != null)
         {
            file.Close();
         }
      }
   }

   public void Save(int level, string selectedPuzzel, int stars)
   {

   }
}