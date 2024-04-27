using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFire : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask attackLayerMask;

    private int _animIDAttack;
    private bool _hasAnimator;
    private bool _isAttacking;
    private Animator _animator;
    public GameObject firePrefab;
    private GameObject currentFire;
    public PotionBar potionBar;
    private GameObject logObject;
    public ParticleSystem rainParticleSystem;
    private AudioSource spellAudioSource;
    private Vector3 logPosition;

    void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        SignAnimationIDs();
        spellAudioSource = GetComponent<AudioSource>();
    }

    private void SignAnimationIDs()
        {
            _animIDAttack = Animator.StringToHash("Spell");
        }

        void Update()
    {
        _hasAnimator = TryGetComponent(out _animator);
        if (Input.GetKeyDown(KeyCode.T)&&!_isAttacking&&potionBar.slider.value>0)
        {
                float attackDistance = 10.0f;

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, attackDistance, attackLayerMask))
                {
                    Debug.Log("Lagtese");
                    spellAudioSource.Play();
                    if (raycastHit.transform.CompareTag("Log"))
                    {
                        logObject = raycastHit.transform.gameObject;
                        logPosition = logObject.transform.position;
                        potionBar.ReduceSpellBar();
                       Debug.Log("Korche");
                       StartCoroutine(TriggerAttackAnimation());
                       
                    }
                }
        }

        if (rainParticleSystem != null && rainParticleSystem.isPlaying)
        {
            if (currentFire != null&&logObject != null)
            {
                Debug.Log("Holaaa");
                ExtinguishFire();
                Destroy(logObject, 0.0f);
            }
        }
    }

    private IEnumerator TriggerAttackAnimation()
        {
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDAttack, true);
            }
            _isAttacking = true;

            float spellAnimationDuration = 1.0f;
            yield return new WaitForSeconds(spellAnimationDuration);

            currentFire = Instantiate(firePrefab, logPosition, Quaternion.identity);
            Destroy(currentFire, 25.0f);

            _isAttacking = false;
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDAttack, false);
            }
        }

    private void InstantiateFire(Vector3 position)
    {
        // Instantiate fire prefab at the collision position
        currentFire = Instantiate(firePrefab, position, Quaternion.identity);
    }

    private void ExtinguishFire()
    {
        Debug.Log(currentFire);
        Destroy(currentFire);
        currentFire = null;
    }
}