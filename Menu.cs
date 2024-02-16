using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUi, loreMenuUi;
    public static bool gamePaused = false;
    public FirstPersonController fps;
    public GameObject hope, despair, punishment, rise, remembrance, beauty, adam, note;
    [SerializeField] RawImage hope1, despair1, punishment1, rise1, remembrance1, beauty1, adam1, note1;
    public Orb orb1;
    public Orb2 orb2;
    public Orb3 orb3;
    public Orb4 orb4;
    public Orb5 orb5;
    public finalScript fsh;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        hope.SetActive(orb1.collected);
        punishment.SetActive(orb2.collected2);
        despair.SetActive(orb3.collected3);
        rise.SetActive(orb4.collected4);
        remembrance.SetActive(orb5.collected5);
        beauty.SetActive(fsh.collected6);
        adam.SetActive(fsh.collected6);
        note.SetActive(fsh.collected6);
    }

    public void onHopeClicked()
    {
        hope1.enabled = true;
    }

    public void onBeautyClicked()
    {
        beauty1.enabled = true;
    }

    public void onPunishmentClicked()
    {
        punishment1.enabled = true;
    }

    public void onDespairClicked()
    {
        despair1.enabled = true;
    }

    public void onRiseClicked()
    {
        rise1.enabled = true;
    }

    public void onRemembranceClicked()
    {
        remembrance1.enabled = true;
    }

    public void onAdamClicked()
    {
        adam1.enabled = true;
    }

    public void onNoteClicked()
    {
        note1.enabled = true;
    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);
        loreMenuUi.SetActive(false); 
        Time.timeScale = 1f;
        gamePaused = false;
        fps.lockCursor = true;
        fps.cameraCanMove = true;

    }

    void pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        fps.lockCursor = false;
        fps.cameraCanMove = false;
    }


    public void onNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
    }

    public void onExitClicked()
    {
        Application.Quit();
    }
}
