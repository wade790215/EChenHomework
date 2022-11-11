using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{   
    //Tips 抽象層方法不要傳參數，用其他方式注入
    public void DrawAttack();
}
