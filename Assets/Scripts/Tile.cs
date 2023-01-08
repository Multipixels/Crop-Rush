using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class TileInfo {
    public int id;
    public string name;
    public string description;
    public Sprite sprite;
    public Color color;
}

public class Tile : MonoBehaviour {
    [SerializeField]
    public TileInfo[] tiles;

    private int tileId;


    public void Initialize(int id) {

        tileId = id;

        if (id == 0) {
            Destroy(gameObject);
        }

        if (tiles[id].sprite != null) {
            gameObject.GetComponent<SpriteRenderer>().sprite = tiles[id].sprite;
        } else {
            gameObject.GetComponent<SpriteRenderer>().color = tiles[id].color;
        }

    }

    public int GetId() {
        return tileId;
    }
    public void Progress() {
        if(tileId == 2 || tileId == 6 || tileId == 7) {
            tileId = 4;
        }
        if (tileId == 5 || tileId == 8) {
            tileId = 2;
        }
        Initialize(tileId);
    }
}
