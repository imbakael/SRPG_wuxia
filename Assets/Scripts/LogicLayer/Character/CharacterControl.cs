using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl {

    private List<Character> players;
    private List<Character> enemies;

    public Queue<Character> CalcuAttackSort() {
        Queue<Character> queue = new Queue<Character>();
        foreach (Character item in enemies) {
            queue.Enqueue(item);
        }
        return queue;
    }
}
