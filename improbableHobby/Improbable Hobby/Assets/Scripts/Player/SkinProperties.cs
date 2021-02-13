using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinProperties : MonoBehaviour
{
    private List<string> skinNames = new List<string>();
    private List<string> skinDescriptions = new List<string>();
    private List<string> skinUnlockConditions = new List<string>();
    private List<int> skinPrice = new List<int>();

    public void Awake() //initializes before Start
    {
                                            //Skin ID's
        skinNames.Add("Regular M'Eme");     //0
        skinNames.Add("Caped M'Eme");       //1
        skinNames.Add("Filthy M'Eme");      //2
        skinNames.Add("Nuclear M'Eme");     //3
        skinNames.Add("Medic M'Eme");       //4



        //******************************DESCRIPTIONS******************************

        //Skin ID's
        /*0*/
        skinDescriptions.Add("M'Eme in his regular clothing. While he has no particular special talents, he is still determined!");
        /*1*/
        skinDescriptions.Add("After finding this long lost magic cape, M'Eme now has the ability to jump twice before hitting the ground!");
        /*2*/
        skinDescriptions.Add("Filthy cheaters never prosper, except sometimes M'Eme! Your device will not rotate when turned!");
        /*3*/
        skinDescriptions.Add("It's pronounced NEW-CUE-LUR! M'Eme is now easily visible in the dark!");
        /*4*/
        skinDescriptions.Add("Being the youngest ever fully licensed doctor at age 6, M'Eme can come back to life once after dying!");


        //******************************Unlock Conditions******************************
                                                                            
                                                                                                                //Skin ID's                                                                                                
        skinUnlockConditions.Add("Should be Unlocked ERROR");                                                   //0                
        skinUnlockConditions.Add("Should be Unlocked ERROR");                                                   //1
        skinUnlockConditions.Add("Unlock Achievement \"Cheater\" or unlock now for 500 coins");                 //2
        skinUnlockConditions.Add("Unlock Achievement \"maybe nothing\" or unlock now for 2000 coins");          //3
        skinUnlockConditions.Add("Unlock Achievement \"Playing it Safe\" or unlock now for 4000 coins");        //4


        //******************************Unlock Conditions******************************

                                        //Skin IDs
        skinPrice.Add(0);               //0  
        skinPrice.Add(0);               //1
        skinPrice.Add(500);             //2
        skinPrice.Add(2000);            //3
        skinPrice.Add(4000);            //4




    }

    public string GetSkinName(int skinID)
    {
        if(skinID >= 0 && skinID < skinNames.Count)
            return skinNames[skinID];
        else
            return "ERROR: INVALID NAME";
    }

    public string GetSkinDescription(int skinID)
    {
        if (skinID >= 0 && skinID < skinDescriptions.Count)
            return skinDescriptions[skinID];
        else
            return "ERROR: INVALID DESCRIPTION";
    }

    public string GetSkinConditions(int skinID)
    {
        if (skinID >= 0 && skinID < skinUnlockConditions.Count)
            return skinUnlockConditions[skinID];
        else
            return "ERROR: INVALID DESCRIPTION";
    }

    public int GetSkinPrice(int skinID)
    {
        if (skinID >= 0 && skinID < skinUnlockConditions.Count)
            return skinPrice[skinID];
        else
            return 999999;
    }
}

