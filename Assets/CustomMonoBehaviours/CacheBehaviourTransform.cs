using UnityEngine;

/// <summary>
/// Transform がキャッシュされた MonoBehaivour 。
/// 通常の MonoBehaviour より Awake のパフォーマンスが悪い点に注意します。
/// 継承クラスでは Awake を override し、base.Awake を呼ぶ必要があります。
/// </summary>
public class CacheBehaviourTransform : MonoBehaviour
{
    #region Field

    /// <summary>
    /// キャッシュされた Transform 。
    /// </summary>
    [HideInInspector]
    public new Transform transform;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// キャッシュのために通常の MonoBehaviour よりパフォーマンスが悪い点に注意します。
    /// 継承クラスでは override して base.Awake を呼ぶ必要があります。
    /// </summary>
    protected virtual void Awake()
    {
        this.transform = base.transform;
    }

    #endregion Method
}