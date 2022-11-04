using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    public float physics;
    public Damage() {

    }

    public static Damage operator *(Damage a, float b) {
        return new Damage {
            physics = a.physics * b
        };
    }
}
