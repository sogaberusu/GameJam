using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{
    public enum AnimState
    {
        IDLE_STATE = 0,
        MOVE_STATE,
        INTERACTIVE_STATE,
        ATTACK_STATE,
        GRETTING_STATE
    }
    private AnimState animState;                       
    
    public string[] MsIdleAnim;                          
    public string[] MsMoveAnim;                          
    public string[] MsInteractiveAnim;                   
    public string[] MsAttackAnim;

    private delegate void UpdateDelegate();
    UpdateDelegate updateAnimDelegate;
    UpdateDelegate saveDelegate;

    private float _mFAnimTime = 0f;
    

    // Use this for initialization
    void Start()
    {
        updateAnimDelegate = IdleAnimPlay;
        animState = AnimState.IDLE_STATE;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateAnimDelegate != null)
            updateAnimDelegate();
    }

    void IdleAnimPlay(bool Setting)
    {
        //Setting �� �߰�
    }

    void IdleAnimPlay()
    {
        //�������.
        if (MsIdleAnim.Length == 0)
        {
            return;
        }

        if (_mFAnimTime < Time.time)
        {
            int value = Random.Range(0, MsIdleAnim.Length);
            _mFAnimTime = Time.time + GetComponent<Animation>()[MsIdleAnim[value]].length;
            GetComponent<Animation>().CrossFade(MsIdleAnim[value]);
        }
    }

    void MoveAnimPlay()
    {
        if (MsMoveAnim == null)
        {
            updateAnimDelegate = IdleAnimPlay;
            return;
        }

        if (_mFAnimTime < Time.time)
        {
            int value = Random.Range(0, MsMoveAnim.Length);
            _mFAnimTime = Time.time + GetComponent<Animation>()[MsMoveAnim[value]].length;
            GetComponent<Animation>().CrossFade(MsMoveAnim[value]);
        }
    }

    void InteractiveAnimPlay()
    {
        if (MsInteractiveAnim == null)
        {
            updateAnimDelegate = IdleAnimPlay;
            return;
        }

        int value = Random.Range(0, MsInteractiveAnim.Length);
        _mFAnimTime = Time.time + GetComponent<Animation>()[MsInteractiveAnim[value]].length;
        GetComponent<Animation>().CrossFade(MsInteractiveAnim[value]);

        updateAnimDelegate = saveDelegate;
        animState = AnimState.IDLE_STATE;
    }

    void AttackAnimPlay()
    {
        if (MsInteractiveAnim == null)
        {
            updateAnimDelegate = IdleAnimPlay;
            return;
        }

        int value = Random.Range(0, MsAttackAnim.Length);
        _mFAnimTime = Time.time + GetComponent<Animation>()[MsAttackAnim[value]].length;
        GetComponent<Animation>().CrossFade(MsAttackAnim[value]);

        updateAnimDelegate = saveDelegate;
        animState = AnimState.IDLE_STATE;
    }

    void AnimStateSet(AnimState state)
    {
        if (animState == state)
            return;

        animState = state;
        if (animState == AnimState.IDLE_STATE)
        {
            updateAnimDelegate = IdleAnimPlay;
            _mFAnimTime = 0.0f;

        }
        else if (animState == AnimState.MOVE_STATE)
        {
            updateAnimDelegate = MoveAnimPlay;
            _mFAnimTime = 0.0f;
        }
        else if (animState == AnimState.ATTACK_STATE)
        {
            updateAnimDelegate = AttackAnimPlay;
            _mFAnimTime = 0.0f;
        }
        else if (animState == AnimState.INTERACTIVE_STATE)
        {
            saveDelegate = updateAnimDelegate;
            updateAnimDelegate = InteractiveAnimPlay;
            _mFAnimTime = 0.0f;
        }
    }


}
