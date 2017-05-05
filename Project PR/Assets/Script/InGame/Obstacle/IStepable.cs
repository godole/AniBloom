using UnityEngine;
using System.Collections;

public interface IStepable
{
    Vector2 CalcStepPoint(RectTransform playerTransform);
    Vector2 CalcMoveVector(RectTransform playerTransform, float maxSpeed);
}