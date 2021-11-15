using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float despawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DespawnObject", despawnTimer);
    }

    private void DespawnObject()
    {
        Destroy(gameObject);
    }
}
