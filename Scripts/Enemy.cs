using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Enemy : MonoBehaviour
{
    public float speed = 10;
    private Transform[] positions;
    private int index = 0;
    public GameObject explosionEffect;

    //��ɱ�����ӽ�Ǯ
    public float bounty = 25;

    public float hp = 150;
    private float totalHp;
    private UnityEngine.UI.Slider hpSlider;

    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.positions;
        totalHp = hp;
        hpSlider = GetComponentInChildren<UnityEngine.UI.Slider>();//������������������

        GameObject buildManagerObject = GameObject.Find("BuildManager");
        buildManager = buildManagerObject.GetComponent<BuildManager>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }


    //�ﵽ�յ�
    void ReachDestination()
    {
        GameManager.Instance.Failed();//��Ϸʧ��
        GameObject.Destroy(this.gameObject);
    }
    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }
    public void TakeDamage(float damage)//-hp
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        } 
    }
    void Die()
        {
            GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
            buildManager.ChangeMoney((int)bounty);
            Destroy(effect, 1f);
            Destroy(this.gameObject);
        }
     

}
