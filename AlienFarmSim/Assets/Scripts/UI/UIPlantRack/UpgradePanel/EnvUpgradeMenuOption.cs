using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnvUpgradeMenuOption : RowUpgradeMenuOption
{
    public EnvMenuManager manager;

    public RowEnvironmentSO environment;

    [SerializeField] private TextMeshProUGUI description;


    // public void OnEnable(){
    //     updateInfo();
    // }
    

    public void updateInfo(){
        setName(environment.getName());
        setPrice(environment.getPrice());
        setDescription(environment.getDescription());
        setImage(environment.getIcon());
    }


    public void setDescription(string str){
        description.SetText(str);
    }

    public void setEnvironment(RowEnvironmentSO env){
        environment = env;
        updateInfo();
    }


    public void applyEnvironment(){
        manager.applyEnvironment(environment);
    }
}
