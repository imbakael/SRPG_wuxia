using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 管理战场内所有角色
public class CharacterControl {

    private List<Character> allRoles;
    private List<Character> players;
    private List<Character> enemies;

    public void CreateAll() {

    }

    public Queue<Character> GetSortByAgi() {
        var sort = allRoles.Where(t => !t.IsDead && !t.IsWait).OrderByDescending(t => t.currentProperty.agi);
        var queue = new Queue<Character>();
        foreach (Character item in sort) {
            queue.Enqueue(item);
        }
        return queue;
    }

    public void RunOneCycleBuff() {
        for (int i = 0; i < allRoles.Count; i++) {
            allRoles[i].RunOneCycleBuff();
        }
    }
}
