using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 管理战场内所有角色
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
