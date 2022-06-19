using DungeonArchitect;
using DungeonArchitect.Builders.Grid;
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
            var dungeonConfig = dungeon.GetComponent<GridDungeonConfig>();
            dungeonConfig.Seed = (uint)Random.Range(0, 10000);
            
            dungeon.Build();
        }
    }
}
