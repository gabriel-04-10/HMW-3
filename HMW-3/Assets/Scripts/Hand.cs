using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    [SerializeField] private float animationSpeed;
    private Animator _animator;
    private SkinnedMeshRenderer _mesh;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private const string AnimatorGripParam = "Grip";
    private const string AnimatorTriggerParam = "Trigger";
    private static readonly int Grip = Animator.StringToHash(name: AnimatorGripParam);
    private static readonly int Triger = Animator.StringToHash(name: AnimatorTriggerParam);

    // physics movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;

    private void Start()
    {
        // physics movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        // teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    private void Update()
    {
        AnimateHand();
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        // position 
        var positionWithOffset = _followTarget.position;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (_followTarget.position - transform.position).normalized * (followSpeed * distance);

        // rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }

    
    
    private void AnimateHand()
    {
        if (Math.Abs(_gripCurrent-_gripTarget)>0)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget,maxDelta: Time.deltaTime*animationSpeed);
            _animator.SetFloat(AnimatorGripParam,_gripCurrent);
        }
        if (Math.Abs(_triggerCurrent-_triggerTarget)>0)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget,Time.deltaTime*animationSpeed);
            _animator.SetFloat(AnimatorTriggerParam,_triggerCurrent);
        }
    }
}
