using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera, character;
    public GameObject playerCamObj, finishCamObj;
    public TMP_Text welcomeText;

    CinemachineBrain cinemachineBrain;
    bool isGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        welcomeText.SetText("Ready");
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
        character.GetComponent<Move_character>().enabled = false;
        finishCamObj.SetActive(true);
        playerCamObj.SetActive(false);
        StartCoroutine(FinishToPlayerCam());
    }
    IEnumerator FinishToPlayerCam()
    {
        yield return new WaitForSeconds(2);
        finishCamObj.SetActive(false);
        playerCamObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cinemachineBrain.IsBlending)
        {
            ICinemachineCamera finishCam = finishCamObj.GetComponent<ICinemachineCamera>();
            bool finishCamlive = CinemachineCore.Instance.IsLive(finishCam);
            if (!finishCamlive && !isGameStarted)
            {                
                character.GetComponent<Move_character>().enabled = true;
                StartCoroutine(DisplayTextWithDelay(welcomeText, "Go!!!", 2.0f));
            }
        }
    }
    IEnumerator DisplayTextWithDelay(TMP_Text textObj, string text, float delay)
    {
        textObj.SetText(text);
        yield return new WaitForSeconds(delay);
        textObj.gameObject.SetActive(false);
    }
}
