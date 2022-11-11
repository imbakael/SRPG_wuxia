
public class Damage {

    public float physics;
    public Damage() {

    }

    public static Damage operator *(Damage a, float b) {
        return new Damage {
            physics = a.physics * b
        };
    }

    public static Damage operator +(Damage a, Damage b) {
        return new Damage {
            physics = a.physics + b.physics
        };
    }
}
