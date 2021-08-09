using System.Collections;
using System.Collections.Generic;
using DanmakU.Fireables;
using UnityEngine;

namespace DanmakU {

[AddComponentMenu("DanmakU/Danmaku Emitter")]
public class DanmakuEmitter : DanmakuBehaviour {

  public DanmakuPrefab DanmakuType;

  public Range Speed = 5f;
  public Range AngularSpeed;
  public Color Color = Color.white;
  public Range FireRate = 5;
  public float FrameRate;
  public Arc Arc;
  public Line Line;

  float timer;
  DanmakuConfig config;
  IFireable fireable;
  bool firstFrame = true;
  public float processedAngularSpeed;
        float newtimer;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
        void Start() {
    if (DanmakuType == null) {
      Debug.LogWarning($"Emitter doesn't have a valid DanmakuPrefab", this);
      return;
    }
    var set = CreateSet(DanmakuType);
    set.AddModifiers(GetComponents<IDanmakuModifier>());
    fireable = Arc.Of(Line).Of(set);
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
            newtimer += Time.deltaTime;
    if (!firstFrame)
    {
        if (fireable == null) return;
        if (transform.rotation.z > 0.501f)
        {
            processedAngularSpeed = -AngularSpeed.GetValue();
        }
        else
        {
            processedAngularSpeed = AngularSpeed.GetValue();
        }
                //Debug.Log(transform.rotation.z);
        var deltaTime = Time.deltaTime;
        if (FrameRate > 0)
        {
            deltaTime = 1f / FrameRate;
        }
        timer -= deltaTime;
        if (timer < 0)
        {
            config = new DanmakuConfig
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad,
                Speed = Speed,
                AngularSpeed = processedAngularSpeed,
                Color = Color
            };
            fireable.Fire(config);
            timer = 1f / FireRate.GetValue();
        }
    }
    else
    {
        firstFrame = false;
    }
  }

}

}