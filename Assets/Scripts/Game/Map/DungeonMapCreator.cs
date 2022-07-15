using Game.Manager;
using DungeonArchitect;
using DungeonArchitect.Builders.Grid;
using DungeonArchitect.Builders.GridFlow;
using Game.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonRPG.Game.Map {
    public class DungeonMapCreator : MonoBehaviour {
        [SerializeField] private Dungeon dungeon;
        [SerializeField] private Button button;

        private void Awake() {
            button.onClick.AddListener(OnClickButton);
        }

        private void OnClickButton() {
            var dungeonConfig = dungeon.GetComponent<GridFlowDungeonConfig>();
            dungeonConfig.Seed = (uint) Random.Range(0, 10000);

            dungeon.Build();

            GameManager.Instance.PutPlayerSpawnPoint();
        }

        public void SetNewDungeon() {
            var dungeonConfig = dungeon.GetComponent<GridFlowDungeonConfig>();
            dungeonConfig.Seed = (uint) Random.Range(0, 10000);

            dungeon.Build();
        }

#if UNITY_EDITOR
        private void Update() {
            if (UnityEditor.EditorApplication.isPlaying == false) {
                dungeon.DestroyDungeon();
            }
        } 
#endif
    }
}
