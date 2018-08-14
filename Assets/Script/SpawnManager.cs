using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

    public GeoData ballData;

    public Transform cube;
    public Transform ball;
    public Transform capsule;
    public bool isBallSpawned = false;


    public Text BallSpawnCostText;
    public Text SpeedUpradeCostText;
    public Text VisionUpradeCostText;

    private GameObject BallSpawnButton;
    private GameObject BallSpeedUpgradeButton;
    private GameObject BallVisionUpgradeButton;
    private GameObject mainCam;
    private int ballSpawnCost = 10;
    private int ballSpeedLevel;
    private int ballVisionLevel;
    private Transform ballObj;
    

    private void Awake()
    {
        BallSpawnButton = GameObject.Find("BallSpawnButton");
        BallSpeedUpgradeButton = GameObject.Find("BallSpeedUpgradeButton");
        BallVisionUpgradeButton = GameObject.Find("BallVisionUpgradeButton");
        mainCam = GameObject.Find("Main Camera");
    }
    // Use this for initialization
    void Start () {
        BallSpawnButton.SetActive(false);
        BallSpeedUpgradeButton.SetActive(false);
        BallVisionUpgradeButton.SetActive(false);
        ballSpeedLevel = 0;
        ballVisionLevel = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isBallSpawned)
        {
            if (EntropyManager.entropy > 10)
            {
                BallSpawnButton.SetActive(true);
                BallSpawnCostText.text = "Make BAll \n" + ballSpawnCost.ToString();
            }
        }
        if (isBallSpawned)
        {
            BallSpeedUpgradeButton.SetActive(true);
            BallVisionUpgradeButton.SetActive(true);
            SpeedUpradeCostText.text = "SPEED \n" + ballData.SpeedUPCost[ballSpeedLevel - 1];
            VisionUpradeCostText.text = "VISION \n" + ballData.VisionUPCost[ballVisionLevel - 1];
            if (EntropyManager.entropy > ballData.SpeedUPCost[ballSpeedLevel- 1])
            {
                BallSpeedUpgradeButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                BallSpeedUpgradeButton.GetComponent<Button>().interactable = false;
            }
            if (EntropyManager.entropy > ballData.VisionUPCost[ballVisionLevel - 1])
            {
                BallVisionUpgradeButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                BallVisionUpgradeButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void BallSpawn()
    {
        if (EntropyManager.entropy > ballSpawnCost)
        {
            ballObj = Instantiate(ball, new Vector3(0f, 1.2f, 0f), Quaternion.identity);
            EntropyManager.entropy -= ballSpawnCost;
            isBallSpawned = true;
            BallSpawnButton.SetActive(false);
            ballSpeedLevel = 1;
            ballVisionLevel = 1;
            mainCam.GetComponent<CameraFollowCharacter>().target = ballObj;
        }
    }

    public void BallSpeedUpgrade()
    {
        if (EntropyManager.entropy > ballData.SpeedUPCost[ballSpeedLevel - 1])
        {
            EntropyManager.entropy -= ballData.SpeedUPCost[ballSpeedLevel - 1];
            ballSpeedLevel++;
            SphereWantToRoll.rollSpeed = ballData.SpeedUPEffect[ballSpeedLevel-1];
            ballObj.GetComponent<SphereWantToRoll>().Break();
            if (ballSpeedLevel >= ballData.SpeedUPCost.Length)
            {
                SpeedUpradeCostText.text = "Max Speed";
                BallSpeedUpgradeButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void BallVisionUpgrade()
    {
        if (EntropyManager.entropy > ballData.VisionUPCost[ballVisionLevel - 1])
        {
            EntropyManager.entropy -= ballData.VisionUPCost[ballVisionLevel - 1];
            ballVisionLevel++;
            SphereWantToRoll.ballVision = ballData.VisionUPEffect[ballVisionLevel - 1];
            ballObj.GetComponent<SphereWantToRoll>().LightUP();
            if (ballVisionLevel >= ballData.VisionUPCost.Length)
            {
                VisionUpradeCostText.text = "Max Vision";
                BallVisionUpgradeButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}
