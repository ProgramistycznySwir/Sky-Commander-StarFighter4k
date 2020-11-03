using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    static PlayerStats player_;
    static PlayerStats player { get { return player_;} }

    // Start is called before the first frame update
    void Start()
    {
        player_ = this;
    }
}
