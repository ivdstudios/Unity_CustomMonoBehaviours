using UnityEngine;

/// <summary>
/// BoundsBehaviour をキャプチャするようにカメラを設定します。
/// </summary>
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class BoundsCaptureCamera : CacheBehaviourTransform
{
    #region Field

    /// <summary>
    /// キャプチャする BoundsBehaviour 。
    /// </summary>
    public BoundsBehaviour boundsBehaviour;

    /// <summary>
    /// 設定するカメラ。
    /// </summary>
    protected new Camera camera;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        this.camera = base.GetComponent<Camera>();

        InitializeSettings();

        this.boundsBehaviour.boundsUpdateEvent.RemoveListener(this.BoundsUpdateEventHandler);
        this.boundsBehaviour.boundsUpdateEvent.AddListener(this.BoundsUpdateEventHandler);
    }

    /// <summary>
    /// 設定を初期化します。
    /// </summary>
    protected virtual void InitializeSettings()
    {
        // NOTE:
        // rect を設定してから、orthographicSize を設定する必要があります。
        // 任意のアスペクト比を指定して強制する必要があります。
        // 指定しないとき RenderTexture や、ScreenSize の影響を受けてしまうためです。

        this.camera.orthographic = true;
        this.camera.rect = new Rect(0, 0, this.boundsBehaviour.bounds.size.x, this.boundsBehaviour.bounds.size.y);
        this.camera.orthographicSize = this.camera.rect.height / 2;
        this.camera.aspect = this.camera.rect.width / this.camera.rect.height;

        // NOTE:
        // 座標を合わせます。投影距離や回転などを合わせることも考えられますが、止めました。
        // 投影距離は自由度が高い方が良いです。例えば Bounds 以外に間に描画したいものが現れる可能性があります。

        this.transform.position = new Vector3(this.boundsBehaviour.bounds.center.x,
                                              this.boundsBehaviour.bounds.center.y,
                                              this.transform.position.z);
    }

    /// <summary>
    /// BoundsBehaviour が更新されたときに呼び出されます。
    /// BoundsBehaviour.BoundsUpdateEvent に登録して使います。
    /// </summary>
    /// <param name="boundsBehaviour">
    /// 更新された BoundsBehaviour 。
    /// </param>
    public void BoundsUpdateEventHandler(BoundsBehaviour boundsBehaviour)
    {
        InitializeSettings();
    }

    #endregion Method
}