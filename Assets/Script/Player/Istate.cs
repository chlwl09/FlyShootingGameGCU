using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate
{
    void OperateEnter();
    void OperateUpdate();
    void OperateExit();
}
