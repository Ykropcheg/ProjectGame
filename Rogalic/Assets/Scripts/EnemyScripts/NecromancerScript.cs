using UnityEngine;

public class NecromancerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPoint;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject SkeletonHead;
    [SerializeField] private Animator aniim;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        aniim = GetComponent<Animator>();
        SkeletonHead = Resources.Load<GameObject>("Skeleton_Head");
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("AnimPlay", 5f);
    }

    public void SkeletonCast(){
        Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
    }

    public void AnimPlay(){
        aniim.Play("Necromancerv2_cast3");
    }
}
