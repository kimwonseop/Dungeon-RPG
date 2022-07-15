using DungeonRPG.Game.Map;
using Game.Manager;
using UnityEngine;

namespace Game.Manager {
    public class GameManager : Singleton<GameManager> {
        private Player player;
        public Player Player {
            get {
                lock (lockObject) {
                    if (player == null) {
                        player = GameObject.FindWithTag("Player").GetComponent<Player>();
                    }
                }

                return player;
            }
        }

        private Vector3 spawnPoint;
        public Vector3 SpawnPoint {
            get {
                if (spawanPointObject == null) {
                    spawanPointObject = GameObject.FindWithTag("SpawnPoint");
                }

                return spawanPointObject.transform.position;
            }
        }

        private object lockObject = new object();
        private GameObject spawanPointObject;
        private DungeonMapCreator dungeonMapCreator;

        private void Start() {
            dungeonMapCreator = GameObject.Find("DungeonMapCreator").GetComponent<DungeonMapCreator>();
        }

        public void PutPlayerSpawnPoint() {
            Player.transform.position = SpawnPoint;
        }

        public void ResetGame() {
            dungeonMapCreator.SetNewDungeon();
            PutPlayerSpawnPoint();
        }
    }
}
