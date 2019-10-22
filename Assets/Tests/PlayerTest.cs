using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {
        public GameObject newObj;
        [Test]
        public void PlayerTestSimplePasses()
        {
            newObj = new GameObject("gamenewObject");
            newObj.AddComponent<PlayerMotor>();
            PlayerMotor player = newObj.GetComponent<PlayerMotor>();

            Debug.Log(player.getSpeed()); //shows current speed
            Assert.AreEqual(5.0f, player.getSpeed()); // except 5.0f

            player.setSpeed(5.0f); // test setSpeed method
            Assert.AreEqual(10.0f, player.getSpeed()); // except 10.0f
            Debug.Log(player.getSpeed()); //shows current speed



            Debug.Log(player.life); //shows current life

            player.setLife(1);// test increasing life method
            Assert.AreEqual(4, player.life); // except get 4
            Debug.Log(player.life); //shows current life

            player.setLife(0);// test decreasing life method
            Assert.AreEqual(3, player.life); // except get 4
            Debug.Log(player.life); //shows current life
        }

    }
}
