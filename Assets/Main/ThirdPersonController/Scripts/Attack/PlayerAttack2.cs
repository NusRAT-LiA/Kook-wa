using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack2 : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private AudioClip attackSound;

    private int _animIDAttack;
    private bool _hasAnimator;
    private bool _isAttacking;
    private Animator _animator;
    private Animator spiderAnimator;
    private NavMeshAgent agent;
    public GameObject firePrefab;
    private GameObject currentFire;
    public PotionBar potionBar;
    public ParticleSystem kamehameha;

    public GameObject spider;
    // Start is called before the first frame update
    void Start()
    {
        spiderAnimator = spider.GetComponent<Animator>();
        agent = spider.GetComponent<NavMeshAgent>();
        _hasAnimator = TryGetComponent(out _animator);
        SignAnimationIDs();
    }

    private void SignAnimationIDs()
        {
            _animIDAttack = Animator.StringToHash("Attack");
        }

    // Update is called once per frame
    void Update()
    {
        _hasAnimator = TryGetComponent(out _animator);
        if (Input.GetKeyDown(KeyCode.Q)&&!_isAttacking&&potionBar.slider.value > 0)
        {
                float attackDistance = 20f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, attackDistance, attackLayerMask))
                {
                    if (raycastHit.transform.CompareTag("Spider"))
                    {
                        if (attackSound != null)
                    {
                        AudioSource.PlayClipAtPoint(attackSound, transform.position);
                    }
                        potionBar.ReduceSpellBar();
                       Debug.Log("Korche");
                       StartCoroutine(TriggerAttackAnimation2());
                       spiderAnimator.SetTrigger("dead");
                       currentFire = Instantiate(firePrefab, spider.transform.position, Quaternion.identity);
                       Destroy(currentFire, 25.0f);
                       
                      StartCoroutine(deathPaused());
                      //  
                      

                    }
                    
                }
        }
    }

    private IEnumerator TriggerAttackAnimation2()
        {
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDAttack, true);
            }
            _isAttacking = true;
            kamehameha.Play();

            float spellAnimationDuration = 1.0f;
            yield return new WaitForSeconds(spellAnimationDuration);

            _isAttacking = false;
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDAttack, false);
            }
        }

         private IEnumerator deathPaused()
         {
            agent.enabled = false;
            yield return new WaitForSeconds(25.0f);
            agent.enabled = true;
            spiderAnimator.SetTrigger("walk");
         }
}
