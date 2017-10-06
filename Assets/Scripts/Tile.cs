namespace ToVRs.Assets.Scripts
{
 
public interface ITile {
	int tileId();
	string type();
	int nextId();
	int prevId();
	int TopId();
	int LeftId();
	int BottomId();
	int RightId();
}

    public class Tile {
        public int tileId;
        public string type;
        public int nextId;
        public int prevId;
    
        Tile(int tileId, string type, int nextTileId, int prevTileId){
            this.tileId = tileId;
            this.type = type;
            this.nextId = nextTileId;
            this.prevId = nextTileId;
        }

    }
}