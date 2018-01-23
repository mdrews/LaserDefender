using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    private float speed = 5f;
    public float width = 10f;
    public float height = 5f;

    public bool goRight = true;

    public float padding = 1f;
    private float xmin = 0;
    private float xmax = 0;


	// Use this for initialization
	void Start () {

        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }
	
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

	// Update is called once per frame
	void Update () {
        Vector3 change;
        if((transform.position.x + .5*width) > xmax)
        {
            goRight = false;
        }
        else if ((transform.position.x - .5*width) < xmin)
        {
            goRight = true;
        }
        if (goRight == true)
        {
            change = Vector3.right;
        }
        else
        {
            change = Vector3.left;
        }

        transform.position += new Vector3(change.x * speed * Time.deltaTime, 0);
	}
}
