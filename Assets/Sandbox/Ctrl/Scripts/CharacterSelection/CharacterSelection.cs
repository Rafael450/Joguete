using UnityEngine;
using UnityEngine.UI;
public class CharacterSelection : MonoBehaviour
{
    public Image[] images;
    private PlayerImg[] playersImages;
    private GlobalParameters glob;
    private int amount;
    private int acc;
    [Space]
    [Header("Owners")]
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;
    void Start(){
        glob = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>();
        amount = glob.allTemplates.Length;
        playersImages = new PlayerImg[4];
        int i = 0;
        for (i = 0; i < 4; i++){
            playersImages[i] = new PlayerImg(amount,images[i]);
            playersImages[i].ChangeSprite(i);
        }
        
    }
    public void ChangeRight(int playerID){
        playersImages[playerID].Next();
        playersImages[playerID].ChangeSprite(playerID);
        
    }
    public void ChangeLeft(int playerID){
        playersImages[playerID].Previous();
        playersImages[playerID].ChangeSprite(playerID);
    }

    public class PlayerImg : MonoBehaviour{
        private Image playerimg;
        private int amount;
        int acc;
        public bool isBot;
        public PlayerImg(int amnt, Image img){
            acc = 0;
            amount = amnt;
            playerimg = img;
            isBot = true;
        }
        public void Next(){
            acc++;
            acc = acc%amount;
        }
        public void Previous(){
            acc--;
            if (acc < 0) acc = amount + acc;
        }
        public void ChangeSprite(int colorID){
            //Por enquanto deixa assim. Dps a gnt da aquela melhorada
            playerimg.sprite = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>().allTemplates[acc];
            if (isBot) {
                playerimg.color = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>().mainColors[4];
            }
            else playerimg.color = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>().mainColors[colorID];
        }
    }

    void Update(){
        UpdateOwnerData();
    }

    private void UpdateOwnerData(){
        o1.GetComponent<Dados>().avatar = images[0].sprite;
        o2.GetComponent<Dados>().avatar = images[1].sprite;
        o3.GetComponent<Dados>().avatar = images[2].sprite;
        o4.GetComponent<Dados>().avatar = images[3].sprite;

        o1.GetComponent<Dados>().isPlayer = !playersImages[0].isBot;
        o2.GetComponent<Dados>().isPlayer = !playersImages[1].isBot;
        o3.GetComponent<Dados>().isPlayer = !playersImages[2].isBot;
        o4.GetComponent<Dados>().isPlayer = !playersImages[3].isBot;
    }

    public void ToggleBot(int playerID){
        if (!playersImages[playerID].isBot){
            playersImages[playerID].isBot = true;
            playersImages[playerID].ChangeSprite(4);
        }
        else{
            playersImages[playerID].isBot = false;
            playersImages[playerID].ChangeSprite(playerID);
        }
    }
}
