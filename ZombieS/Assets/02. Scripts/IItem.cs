using UnityEngine;

public interface IItem 
{
    // 무조건 구현해야할 제약 , 메서드 

    /// <summary>
    /// 아이템을 사용하는 메서드 
    /// </summary>
    void Use(GameObject target);
}
