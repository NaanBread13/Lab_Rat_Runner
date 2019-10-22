using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreTest
    {
        // A Test behaves as an ordinary method

        public GameObject newObj;
        [Test]
        public void ScoreTestSimplePasses()
        {
            newObj = new GameObject("gamenewObject");
            newObj.AddComponent<Score>();
            newObj.AddComponent<PlayerMotor>();
            Score score = newObj.GetComponent<Score>();

            Debug.Log(score.GetLevel()); //shows current level
            Assert.AreEqual(1, score.GetLevel()); // except get level 1 as current level

            score.NextLevel(); // test levelup method
            Assert.AreEqual(2, score.GetLevel()); // except get level 2 as current level

            Debug.Log(score.GetLevel()); //shows current level

            score.LastLevel();// test lastlevel method
            Assert.AreEqual(1, score.GetLevel()); // except get level 1 as current level
            Debug.Log(score.GetLevel()); //shows current level

        }
    }
}
