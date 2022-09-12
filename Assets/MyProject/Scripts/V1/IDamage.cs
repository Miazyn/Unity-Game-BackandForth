using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    int fullHealth { get; set; }
    public int TakeDamage(int damage);

}
