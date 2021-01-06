using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

///
/// Game settings based on csv file 
/// Also contain default when csv file fails
///
public class ConfigureSettings
{
    const string ConfigFile = "configurations.csv";
    private Dictionary<string, Dictionary<string, string>> configDictionary = new Dictionary<string, Dictionary<string, string>>();

    public ConfigureSettings()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath,
                ConfigFile
            ));
            
            /// first line is the header
            string currentLine = input.ReadLine();

            currentLine = input.ReadLine();
            while (currentLine != null)
            {
                
                string[] tokens = currentLine.Split(',');

                char[] charsToTrim = {' '};
                for (int i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].Trim(charsToTrim);
                }

                if (configDictionary.ContainsKey(tokens[0]))
                {  
                    try
                    {
                        Dictionary<string, string> target = configDictionary[tokens[0]];
                        target.Add(tokens[1], tokens[2]); 
                        configDictionary[tokens[0]] = target;
                    }
                    catch (ArgumentException)
                    {
                        Debug.Log("[ConfigureSettings] Config file contain duplicates");
                    }
                }
                else
                { 
                    Dictionary<string, string> target = new Dictionary<string, string>()
                    {
                        { tokens[1], tokens[2] }
                    };
                    configDictionary.Add( tokens[0], target );
                }
  
                currentLine = input.ReadLine();
            }         
        }
        catch (Exception e)
        {
            Debug.Log(e);
            SetToDefaultValues();
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }

    } 

    /// note if target or key doesnt exist, error will be thrown
    public string GetValue(string target, string key)
    {
        try 
        {
            return configDictionary[target][key];
        }
        catch (Exception e)
        {
            Debug.Log(e);
            SetToDefaultValues();
            return configDictionary[target][key];
        }
    }

    void SetToDefaultValues()
    {
        configDictionary = new Dictionary<string, Dictionary<string, string>>()
        {
            { "Target", new Dictionary<string, string>()
                {
                    { "x_min", "-4.0" },
                    { "x_max", "4.0"  }, 
                    { "z_min", "-8.0" },
                    { "z_max", "-6.0" },
                    { "easy", "2.00" },
                    { "hard", "1.25" },
                }
            },  
            { "Subject", new Dictionary<string, string>()
                {
                    { "x_min", "-3.0" },
                    { "x_max", "3.0"  }, 
                    { "z_min", "-13.0" },
                    { "z_max", "-12.0" },
                    { "subjects", "Cube|Ball" },
                }
            },  
            { "Ball", new Dictionary<string, string>()
                {
                    { "easy", "0" },
                    { "hard", "1"  }, 
                }
            },  
            { "Cube", new Dictionary<string, string>()
                {
                    { "easy", "1" },
                    { "hard", "3"  }, 
                }
            },           
            { "Shoulder", new Dictionary<string, string>()
                {
                    { "angle_min", "-200" },
                    { "angle_max", "200"  }, 
                    { "force_multiplier", "30" },
                    { "target_velocity", "50" }
                }
            },
            { "Arm_segment", new Dictionary<string, string>()
                {
                    { "angle_min", "-30" },
                    { "angle_max", "60"  }, 
                    { "force_multiplier", "80" },
                    { "target_velocity", "100" }
                }
            },
            { "Forarm_segment", new Dictionary<string, string>()
                {
                    { "angle_min", "-30" },
                    { "angle_max", "120"  }, 
                    { "force_multiplier", "50" },
                    { "target_velocity", "200" }
                }
            },
            { "Hand_segment", new Dictionary<string, string>()
                {
                    { "angle_min", "-90" },
                    { "angle_max", "90"  }, 
                    { "force_multiplier", "50" },
                    { "target_velocity", "50" }
                }
            }
        };
    }
}
