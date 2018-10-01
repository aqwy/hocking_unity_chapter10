using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
[RequireComponent(typeof(playerManager))]
[RequireComponent(typeof(weatherManager))]
[RequireComponent(typeof(imagesManager))]*/
[RequireComponent(typeof(audioManager))]
public class Managers : MonoBehaviour
{
    /*public static playerManager player { get; private set; }
    public static inventoryManager inventory { get; private set; }*/
    /*public static weatherManager weatherm { get; private set; }
    public static imagesManager imgManeg { get; private set; }*/
    public static audioManager theaudio { get; private set; }
    private List<IGameManager> startSequnce;
    void Awake()
    {
        theaudio = GetComponent<audioManager>();
        /*weatherm = GetComponent<weatherManager>();
        imgManeg = GetComponent<imagesManager>();*/
        /*player = GetComponent<playerManager>();
        inventory = GetComponent<inventoryManager>();*/
        startSequnce = new List<IGameManager>();
        /*startSequnce.Add(player);
        startSequnce.Add(inventory);*/
        /*startSequnce.Add(weatherm);
        startSequnce.Add(imgManeg);*/
        startSequnce.Add(theaudio);
        StartCoroutine(startupManagers());
    }
    private IEnumerator startupManagers()
    {
        NetworkService network = new NetworkService();
        foreach (IGameManager mang in startSequnce)
        {
            mang.Startup(network);
        }
        yield return null;

        int numModuls = startSequnce.Count;
        int numReady = 0;

        while (numReady < numModuls)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager managers in startSequnce)
            {
                if (managers.status == managerStatus.Started)
                    numReady++;
            }
            if (numReady > lastReady)
            {
                Debug.Log("progers " + numReady + "/" + numModuls);
            }
            yield return null;
        }
        Debug.Log("All managers started up");
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
