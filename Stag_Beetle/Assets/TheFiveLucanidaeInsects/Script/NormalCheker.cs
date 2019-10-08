using UnityEngine;
using System.Collections;

/// <summary>
/// 2015 05 29 NormalChker Script
/// Script that will be the position and angle of the ground of the insect rotates read insects automatically.
/// 곤충의 위치와 지면의 각도를 읽어들여 곤충을 자동으로 회전시켜 주는 스크립트.
/// </summary>
public class NormalCheker : MonoBehaviour
{
    public float MfThreshold = 0.05f;
    public bool MbIsActive = false;

    private Ray _mRay;
    private RaycastHit _mHit;
    private Vector3 _mOldNormal;
    private GameObject _mInterpolationObj;
    


	// Use this for initialization
	void Start ()
	{
        _mInterpolationObj = new GameObject("InterpolationObj");
	    _mOldNormal = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Other Rotate Operator Code

        if (MbIsActive)
            NormalCheck();
	}

    private void NormalCheck()
    {
        float rot = gameObject.transform.rotation.eulerAngles.y;
        _mRay = new Ray(transform.position, -transform.up);
//        Debug.DrawRay(transform.position, -transform.up * 20);
        if (Physics.Raycast(_mRay.origin, _mRay.direction, out _mHit, 50))
        {
            if (_mOldNormal.y >= transform.up.y + MfThreshold || _mOldNormal.y <= transform.up.y - MfThreshold)
            {
                _mInterpolationObj.transform.rotation = transform.rotation;
                _mInterpolationObj.transform.up = _mHit.normal;

                _mInterpolationObj.transform.Rotate(0.0f, rot, 0.0f);
                Quaternion afterRotation = _mInterpolationObj.transform.rotation;

                StartCoroutine(SetDestinaton(afterRotation));
            }
            _mOldNormal = _mHit.normal;
        }
    }                  


    public IEnumerator SetDestinaton(Quaternion after)
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, after, Time.deltaTime * 3.0f);
        yield return null;
    }

}
