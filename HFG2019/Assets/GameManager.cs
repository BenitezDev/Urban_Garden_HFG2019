using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;

    void Awake()
    {

        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    #endregion
    
    [Space(20)]
    [SerializeField]
    GameObject Calendar,
     TypesOfGround,
     TypesOfClimate,
     Crops,
     Pests,
     Profile,
     Tomato_info,
     General_info;

    [Space(20)]
    [SerializeField]
    Animator anim;
    [SerializeField]
    GameObject Transition;

     
    public enum Windows { Calendar, Ground, Climate, Crops, Pests, Profile, Tomato_info, General_info };
    public Windows currentWindows = Windows.Calendar;

    private void Start()
    {
        currentWindows = Windows.Calendar;
    }
    public void ChangeWindow(int indexwindow)
    {
        /*
         *      0 -> Calendar
         *      1 -> TypeOfGround
         *      2 -> TypesOfClimate
         *      3 -> Crops
         *      4 -> Pests
         *      5 -> Profile
         *      6 -> Tomato_info
         *      7 -> General_info
         */

        //  { }
        print("Disable: "+(Windows)currentWindows+" Abre: "+ (Windows)indexwindow);
        
        // Hide current windows
        ToggleWindows(false);

        if(currentWindows == Windows.Calendar)
        {
            // play transition
            Transition.SetActive(true);
            anim.SetTrigger("Transition");
        }
        // Set new current windows
        currentWindows = (Windows)indexwindow;

        // Set Active new windows
        ToggleWindows(true);
    }

    private void ToggleWindows(bool activation)
    {
        switch (currentWindows)
        {
            case Windows.Calendar:
                Calendar.SetActive(activation);
                break;
            case Windows.Ground:
                TypesOfGround.SetActive(activation);
                break;
            case Windows.Climate:
                TypesOfClimate.SetActive(activation);
                break;
            case Windows.Crops:
                Crops.SetActive(activation);
                break;
            case Windows.Pests:
                Pests.SetActive(activation);
                break;
            case Windows.Profile:
                Profile.SetActive(activation);
                break;
            case Windows.Tomato_info:
                Tomato_info.SetActive(activation);
                break;
            case Windows.General_info:
                General_info.SetActive(activation);
                break;
                
        }

    }

    

}
