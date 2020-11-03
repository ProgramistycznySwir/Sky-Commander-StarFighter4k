using UnityEngine;

public class MarchingBullet : MonoBehaviour
{
    public int teamID;
    public float velocity;
    public float range;
    public float damage;
    public int matterialisationDelay;

    [SerializeField]
    private bool stopped = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stopped)
        {
            float _distance = velocity * Time.fixedDeltaTime;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _distance);
            if (hit && matterialisationDelay <= 0)
            {
                Stats _stats;
                if (_stats = hit.collider.GetComponentInParent<Stats>())
                    Hit(_stats);
                else
                    Stop();
            }
            Move(_distance);
            matterialisationDelay--;
        }
    }
    /// <summary>
    /// Sets stats of projectile
    /// </summary>
    /// <param name="teamID"> ID of team, for prevenging friendly fire (in frames)</param>
    /// <param name="speed"> speed of projectile</param>
    /// <param name="range"> distance after which projectile decays</param>
    /// <param name="dmg"> damage dealt by projectile</param>
    /// <param name="mD"> matterialisationDelay (in frames)</param>
    public void SetStats(int teamID, float speed, float range, float dmg, int mD)
    {
        this.teamID = teamID;
        velocity = speed;
        this.range = range;
        damage = dmg;
        matterialisationDelay = mD;
    }


    private void Hit(Stats _stats)
    {
        if(_stats.teamID == teamID)
            return;
        DealDamage(_stats);
        Stop();
    }

    private void Move(float _distance)
    {
        transform.Translate(0, _distance, 0);
        range -= _distance;
        if(range < 0)
            Stop();
    }

    private void Stop()
    {
        stopped = true;

        GetComponent<SpriteRenderer>().enabled = false;

        Destroy(gameObject, 1f);
    }

    private void DealDamage(Stats stats)
    {
        stats.TakeDamage(damage);
    }
}
