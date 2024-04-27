using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask attackLayerMask;

    private int _animIDAttack;
    private bool _hasAnimator;
    private bool _isAttacking;
    private Animator _animator;
    private Animator spiderAnimator;
    private Animator spiderAnimator2;
    private NavMeshAgent agent;
    private NavMeshAgent agent2;
    public GameObject firePrefab;
    private GameObject currentFire;
    public PotionBar potionBar;
    public ParticleSystem kamehameha;

    public GameObject spider;
    public GameObject spider2;
    // Start is called before the first frame update
    void Start()
    {
        spiderAnimator = spider.GetComponent<Animator>();
        spiderAnimator2 = spider2.GetComponent<Animator>();
        agent = spider.GetComponent<NavMeshAgent>();
        agent2 = spider2.GetComponent<NavMeshAgent>();
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
                        potionBar.ReduceSpellBar();
                       Debug.Log("Korche");
                       StartCoroutine(TriggerAttackAnimation());
                       spiderAnimator.SetTrigger("dead");
                       currentFire = Instantiate(firePrefab, spider.transform.position, Quaternion.identity);
                       Destroy(currentFire, 25.0f);
                       
                      StartCoroutine(deathPause());
                      //  
                      

                    }
                    if (raycastHit.transform.CompareTag("Spider2"))
                    {
                        potionBar.ReduceSpellBar();
                       Debug.Log("Korche");
                       StartCoroutine(TriggerAttackAnimation());
                       spiderAnimator2.SetTrigger("dead");
                       currentFire = Instantiate(firePrefab, spider2.transform.position, Quaternion.identity);
                       Destroy(currentFire, 25.0f);
                       
                      StartCoroutine(deathPause2());
                      //  
                      

                    }
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
            kamehameha.Play();

            float spellAnimationDuration = 1.0f;
            yield return new WaitForSeconds(spellAnimationDuration);

            _isAttacking = false;
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDAttack, false);
            }
        }

         private IEnumerator deathPause()
         {
            agent.enabled = false;
            yield return new WaitForSeconds(25.0f);
            agent.enabled = true;
            spiderAnimator.SetTrigger("walk");
         }
         private IEnumerator deathPause2()
         {
            agent2.enabled = false;
            yield return new WaitForSeconds(25.0f);
            agent2.enabled = true;
            spiderAnimator2.SetTrigger("walk");
         }
}
