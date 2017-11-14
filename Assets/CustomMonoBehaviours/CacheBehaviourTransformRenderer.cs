using UnityEngine;

/// <summary>
/// Transform と Renderer がキャッシュされた MonoBehaivour 。
/// 通常の MonoBehaviour より Awake のパフォーマンスが悪い点に注意します。
/// 継承クラスでは Awake を override し、base.Awake を呼ぶ必要があります。
/// </summary>
public class CacheBehaviourTransformRenderer : CacheBehaviourTransform
{
    #region Field

    /// <summary>
    /// キャッシュされた Renderer 。
    /// </summary>
    [HideInInspector]
    public new Renderer renderer;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// キャッシュのために通常の MonoBehaviour よりパフォーマンスが悪い点に注意します。
    /// 継承クラスでは override し、base.Awake を呼ぶ必要があります。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        this.renderer  = this.GetComponent<Renderer>();
    }

    #endregion Method
}