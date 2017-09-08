using System;
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

   private void Awake()
   {
      InitialiseGame();
   }

   void InitialiseGame()
   {
      LoadGameData();

      if (gameData != null)
      {
         _isGameStartedFirstTime = gameData.GetIsTheGameStartedFirstTime();
      }
      else
      {
         _isGameStartedFirstTime = true;
      }

      if (_isGameStartedFirstTime)
      {
         _isGameStartedFirstTime = false;

         musicVolume = 0;

         candyPuzzleLevels = new bool[5];
         transportPuzzleLevels = new bool[5];
         fruitPuzzleLevels = new bool[5];

         candyPuzzleLevels[0] = true;
         transportPuzzleLevels[0] = true;
         fruitPuzzleLevels[0] = true;

         for (int i = 1; i < candyPuzzleLevels.Length; i++)
         {
            candyPuzzleLevels[i] = false;
            transportPuzzleLevels[i] = false;
            fruitPuzzleLevels[i] = false;
         }

         candyPuzzleLevelStars = new int[5];
         transportPuzzleLevelStars = new int[5];
         fruitPuzzleLevelStars = new int[5];

         for (int i = 0; i < candyPuzzleLevelStars.Length; i++)
         {
            candyPuzzleLevelStars[i] = 0;
            transportPuzzleLevelStars[i] = 0;
            fruitPuzzleLevelStars[i] = 0;
         }

         gameData = new GameData();

         gameData.SetCandyPuzzleLevels(candyPuzzleLevels);
         gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
         gameData.SetFruitPuzzleLevels(fruitPuzzleLevels);

         gameData.SetCandyPuzzleLevelStars(candyPuzzleLevelStars);
         gameData.SetTransportPuzzleLevelStars(transportPuzzleLevelStars);
         gameData.SetFruitPuzzleLevelStars(fruitPuzzleLevelStars);

         gameData.SetIsTheGameStartedFirstTime(_isGameStartedFirstTime);
         gameData.SetMusicVolume(musicVolume);

         SaveGameData();
         LoadGameData();
      }
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
            gameData.SetTransportPuzzleLevelStars(transportPuzzleLevelStars);
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
        // throw;
      }
      finally
      {
         if (file != null)
         {
            file.Close();
         }
      }
   }

   public void Save(int level, string selectedPuzzle, int stars)
   {
      int unlockNextLevel = -1;

      switch (selectedPuzzle)
      {
         case "Candy Puzzle":
            unlockNextLevel = level++;
            candyPuzzleLevelStars[level] = stars;

            if (unlockNextLevel < candyPuzzleLevels.Length)
            {
               candyPuzzleLevels[unlockNextLevel] = true;
            }
            break;

         case "Transport Puzzle":
            unlockNextLevel = level++;
            transportPuzzleLevelStars[level] = stars;

            if (unlockNextLevel < transportPuzzleLevels.Length)
            {
               transportPuzzleLevels[unlockNextLevel] = true;
            }
            break;

         case "Fruit Puzzle":
            unlockNextLevel = level++;
            fruitPuzzleLevelStars[level] = stars;

            if (unlockNextLevel < fruitPuzzleLevels.Length)
            {
               fruitPuzzleLevels[unlockNextLevel] = true;
            }
            break;

         default:
            break;
      }
   }
}