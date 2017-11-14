﻿using UnityEngine;

/// <summary>
/// Bounds を持った MonoBehaviour です。
/// </summary>
[ExecuteInEditMode]
public class BoundsBehaviourBase : MonoBehaviour
{
    #region Field

    /// <summary>
    /// Bounds 。
    /// </summary>
    public Bounds bounds;

    /// <summary>
    /// Gizmo を描画するかどうか。
    /// </summary>
    public bool drawGizmo;

    /// <summary>
    /// Gizmo の色。
    /// </summary>
    public Color gizmoColor = Color.white;

    /// <summary>
    /// キャッシュされた Transform 。
    /// </summary>
    protected Transform transformCache;

    #endregion Field

    #region Property

    /// <summary>
    /// キャッシュされた Transform 。
    /// 実体は Property で、更新すると Updatebounds メソッドが呼び出されます。
    /// </summary>
    public new Transform transform
    {
        get { return this.transformCache; }
        set
        {
            this.transformCache = value;
            UpdateBounds();
        }
    }

    #endregion Property

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// キャッシュのために通常の MonoBehaviour よりパフォーマンスが悪い点に注意します。
    /// 継承クラスでは override して base.Awake を呼ぶ必要があります。
    /// </summary>
    protected virtual void Awake()
    {
        this.transformCache = base.transform;
        UpdateBounds();
    }

    /// <summary>
    /// 更新時に呼び出されます。
    /// </summary>
    protected virtual void Update()
    {
        UpdateBounds();
    }

    /// <summary>
    /// Gizmo の秒化時に呼び出されます。
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        if (this.drawGizmo)
        {
            Color previousColor = Gizmos.color;
            Gizmos.color = this.gizmoColor;
            Gizmos.DrawWireCube(this.bounds.center, this.bounds.size);
            Gizmos.color = previousColor;
        }
    }

    /// <summary>
    /// Bounds を更新します。Transform が更新されるときなどに任意に呼び出します。
    /// </summary>
    public virtual void UpdateBounds()
    {
        this.bounds.center = this.transformCache.position;
    }

    #endregion Method
}