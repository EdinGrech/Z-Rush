using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    waveConf waveConfig;
    short fixedDamageOverwrite;

    public void setWaveConfig(waveConf waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    public float returnDMG()
    {
        if(!waveConfig)
        {
            return fixedDamageOverwrite;
        }
        return waveConfig.readObstDmg();
    }

    public void setFixedDamageOverwrite(short fixedDamageOverwrite)
    {
        this.fixedDamageOverwrite = fixedDamageOverwrite;
    }
    
    public short retureFixedDamageOverwrite()
    {
        return fixedDamageOverwrite;
    }

    public void onHit()
    {
        Destroy(gameObject);
    }
}
