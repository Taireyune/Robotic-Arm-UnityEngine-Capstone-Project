using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    Timer gameTime;
    GameObject target;
    private Dictionary<string, GameObject> subjects = new Dictionary<string, GameObject>();

    void Awake() 
    {
        // gameTime = gameObject.AddComponent<Timer>();
        // gameTime.Duration = 3600;
        EventManager.Initialize();
        ConfigData.initialize();  

    }
    void Start()
    {
        Vector3 target_position = Vector3.zero;
        float target_radius = 0;
        SetupTarget(ref target_position, ref target_radius);
        SpawnSubjects(target_position, target_radius);

        // /// test subject
        // GameObject subject = Instantiate<GameObject>(
        //     Resources.Load(@"Prefab\Cube") as GameObject,
        //     new Vector3(-2.5f, 0.3f, -7.5f),
        //     Quaternion.identity
        // );
        // subject.GetComponent<Subject>().SetTargetRegion(target_position, target_radius);                
        // subject.name = "test_subject";
        
        // subjects.Add(subject.name, subject);      
        
        // foreach (string key in subjects.Keys)
        // {
        //     Debug.Log(key);
        // }
    }
    void Update()
    {
        // pause command
        if (Input.GetButtonDown("Pause"))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }        
    }

    ///
    /// Level building methods
    ///
    void SetupTarget(ref Vector3 target_position, ref float target_radius)
    {
        /// set position
        float x_min = float.Parse(ConfigData.GetValue("Target", "x_min"));
        float x_max = float.Parse(ConfigData.GetValue("Target", "x_max"));
        float z_min = float.Parse(ConfigData.GetValue("Target", "z_min"));
        float z_max = float.Parse(ConfigData.GetValue("Target", "z_max"));

        target_position = new Vector3(
            UnityEngine.Random.Range(x_min, x_max),
            0.01f,
            UnityEngine.Random.Range(z_min, z_max)
        );

        target = Instantiate<GameObject>(
                Resources.Load(@"Prefab\Target") as GameObject, 
                target_position,
                Quaternion.identity
            );
        
        /// set scale/size based on difficulty
        float scale = float.Parse(ConfigData.GetValue("Target", ConfigData.GetDifficulty()));
        target.transform.localScale = new Vector3(scale, 0.001f, scale);

        /// update radius
        target_radius = scale/2;
    }
    void SpawnSubjects(Vector3 target_position, float target_radius)
    {
        string[] subject_names = ConfigData.GetValue("Subject", "subjects").Split('|');
        foreach (string subject_name in subject_names)
        {
            GameObject subject_prefab = Resources.Load(@"Prefab\" + subject_name) as GameObject;

            int count = int.Parse(ConfigData.GetValue(subject_name, ConfigData.GetDifficulty()));
            while (count > 0 )
            {
                GameObject subject = Instantiate<GameObject>(
                    subject_prefab,
                    GetValidSpawnLocation(target_radius),
                    Quaternion.identity
                );
                subject.GetComponent<Subject>().SetTargetRegion(target_position, target_radius);                
                subject.name = subject_name + "_" + count.ToString();
                
                subjects.Add(subject.name, subject);
                count --;
            }
        }
    }
    Vector3 GetValidSpawnLocation(float radius)
    {
        Vector3 position = Vector3.zero;
        float x_min = float.Parse(ConfigData.GetValue("Subject", "x_min"));
        float x_max = float.Parse(ConfigData.GetValue("Subject", "x_max"));
        float z_min = float.Parse(ConfigData.GetValue("Subject", "z_min"));
        float z_max = float.Parse(ConfigData.GetValue("Subject", "z_max"));

        bool valid_position = false;
        int tries = 0;
        while (!valid_position)
        {
            
            position = new Vector3(
                UnityEngine.Random.Range(x_min, x_max),
                0.5f,
                UnityEngine.Random.Range(z_min, z_max)
            );
            valid_position = true;
            Collider[] colliders = Physics.OverlapSphere(position, radius);

            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Subject")
                {
                    valid_position = false;
                    break;
                }
            }

            tries ++;
            if (tries > 20)
            {
                throw new Exception("[GamePlay.GetValidSpawnLocation] \n\tUnable to find valid spawn location.");
            }
        }
        return position;
    }

    ///
    /// Event listening methods
    ///
    /// When subject reach target, remove subject from dictionary and destroy subject
    void SubjectCleanup(EventParam eventParam)
    {
        string subject_name = eventParam.eventString;
        // Debug.Log(subject_name);
        if (subjects.ContainsKey(subject_name))
        {
            GameObject subject = subjects[subject_name];
            subjects.Remove(subject_name);

            if (subject)
            {
                Destroy(subject);
            }
        }

        /// trigger game won if all subjects have reached the target
        if (subjects.Count == 0)
        {
            GameWon();            
        }
    }

    void GameWon()
    {
        /// Game won signal
        // EventManager.TriggerEvent(EventName.GameWonEvent, new EventParam());

        /// change points

        MenuManager.GoToMenu(MenuName.GameWon); 
    }

    void GameOver(EventParam eventParam)
    {
        /// change points
        
        MenuManager.GoToMenu(MenuName.GameOver);
    }



    void OnEnable()
    {
        EventManager.StartListening(EventName.TargetReached, SubjectCleanup);
        EventManager.StartListening(EventName.GameOverEvent, GameOver);
    }
    void OnDisable()
    {
        EventManager.StopListening(EventName.TargetReached, SubjectCleanup);
        EventManager.StopListening(EventName.GameOverEvent, GameOver);
    }

}
