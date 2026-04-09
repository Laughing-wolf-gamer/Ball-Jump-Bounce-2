using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenarate : MonoBehaviour
{
    [SerializeField]private GameObject[] Platfoms;
    [SerializeField]private Transform PlatformContainer;
    float firstStep;
    float middleStep;
    int continuousPlatform;
    [SerializeField]private Material bae;
    [SerializeField]private Material platorm;
    [SerializeField]private Material obstacle;
    [SerializeField]private Color Bae;
    [SerializeField]private Color PlatformColor;
    [SerializeField]private Color ObstacleColor;
    [SerializeField]private Transform MainCylinder;
    [SerializeField]private Transform cylinder;
    [SerializeField]private GameData gameData;

    private void Awake() {
        bae.color = Bae;
        platorm.color = PlatformColor;
        obstacle.color = ObstacleColor;
    }
    private void Start() {
        firstStep = Random.Range(5,10);
        middleStep = Random.Range(2,6);
        continuousPlatform = Random.Range(0,11);

        int platformCount = gameData != null ? gameData.GetPlatformCount() : 24;
        float y = 23.5f - 3.0f;

        if(gameData != null && gameData.level < 7)
        {
            MainCylinder.position = new Vector3(0,25,0);
            cylinder.position = new Vector3(cylinder.transform.position.x,-23,cylinder.transform.position.z);
        }

        for(int i = 0; i < platformCount; i++){
            int prefabIndex = 0;
            if(gameData == null || gameData.level < 7){
                prefabIndex = Random.Range(0,Mathf.Min(2,Platfoms.Length));
                Instantiate(Platfoms[prefabIndex],new Vector3(0,y,0),Quaternion.Euler(0,i + 5,0),PlatformContainer);
            }else if(gameData.level < 20){
                prefabIndex = Random.Range(0,Mathf.Min(7,Platfoms.Length));
                Instantiate(Platfoms[prefabIndex],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
            }else if(gameData.level < 50){
                prefabIndex = Random.Range(0,Mathf.Min(9,Platfoms.Length));
                Instantiate(Platfoms[prefabIndex],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
            }else{
                prefabIndex = Random.Range(0,Platfoms.Length);
                Instantiate(Platfoms[prefabIndex],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
            }

            y -= 3.0f;
        }
                

    }
}
