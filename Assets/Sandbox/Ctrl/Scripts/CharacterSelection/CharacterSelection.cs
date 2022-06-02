using UnityEngine;
using UnityEngine.UI;
public class CharacterSelection : MonoBehaviour
{
    public Image[] images;
    private PlayerImg[] playersImages;
    private GlobalParameters glob;
    private int amount;
    private int acc;
    void Start(){
        glob = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>();
        amount = glob.allTemplates.Length;
        playersImages = new PlayerImg[4];
        int i = 0;
        for (i = 0; i < 4; i++){
            playersImages[i] = new PlayerImg(amount,images[i]);
            playersImages[i].ChangeSprite();
        }
        
    }
    public void ChangeRight(int playerID){
        playersImages[playerID].Next();
        playersImages[playerID].ChangeSprite();
        
    }
    public void ChangeLeft(int playerID){
        playersImages[playerID].Previous();
        playersImages[playerID].ChangeSprite();
    }

    public class PlayerImg : MonoBehaviour{
        private Image playerimg;
        private int amount;
        int acc;
        public PlayerImg(int amnt, Image img){
            acc = 0;
            amount = amnt;
            playerimg = img;
        }
        public void Next(){
            acc++;
            acc = acc%amount;
        }
        public void Previous(){
            acc--;
            if (acc < 0) acc = amount + acc;
        }
        public void ChangeSprite(){
            //Por enquanto deixa assim. Dps a gnt da aquela melhorada
            playerimg.sprite = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>().allTemplates[acc];
        }
    }
}
