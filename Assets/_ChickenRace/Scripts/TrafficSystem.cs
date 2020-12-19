using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;

public class TrafficSystem : NetworkBehaviour
{
    public List<GameObject> Cars = new List<GameObject>();
    public GameObject strip;
    public bool Way;
    int PosZ;
    int StripPosX;
    private NetworkIdentity networkIdentity;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
    }
    void Start()
    {
        if (Way)
        {
            PosZ = 160;
            StripPosX = 1;
        }
        else
        {
            PosZ = -160;
            StripPosX = -1;
        }
        if (isServer)
        {
            StartCoroutine("Strip1");
        }

        //StartCoroutine("Strip2");
        //StartCoroutine("Strip3");
        //StartCoroutine("Strip4");

        if (base.hasAuthority)
        {
            spawn();
        }
        spawn();
    }
    IEnumerator Strip1()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        int rnd = Random.Range(0, Cars.Count);
        GameObject Car = Instantiate<GameObject>(Cars[rnd]);
        NetworkServer.Spawn(Car);
        Car.transform.DOMoveZ(PosZ, 20f);
        networkIdentity = Car.GetComponent<NetworkIdentity>();
        StartCoroutine("Strip1");
    }
    [Command]
    public void spawn()
    {
        GameObject Car = Instantiate<GameObject>(Cars[5]);
        NetworkServer.Spawn(Car);

        networkIdentity = Car.GetComponent<NetworkIdentity>();
    }
    IEnumerator Strip2()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        int rnd = Random.Range(0, Cars.Count);
        GameObject Car = Instantiate<GameObject>(Cars[rnd], new Vector3(strip.transform.position.x+2.5f * StripPosX, Cars[rnd].transform.position.y, strip.transform.position.z), Quaternion.Euler(0, -90 * StripPosX, 0));
        Car.transform.DOMoveZ(PosZ, 20f);

        StartCoroutine("Strip2");
    }
    IEnumerator Strip3()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        int rnd = Random.Range(0, Cars.Count);
        GameObject Car = Instantiate<GameObject>(Cars[rnd], new Vector3(strip.transform.position.x + 5f * StripPosX, Cars[rnd].transform.position.y, strip.transform.position.z), Quaternion.Euler(0, -90 * StripPosX, 0));
        Car.transform.DOMoveZ(PosZ, 20f);

        StartCoroutine("Strip3");
    }
    IEnumerator Strip4()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        int rnd = Random.Range(0, Cars.Count);
        GameObject Car = Instantiate<GameObject>(Cars[rnd], new Vector3(strip.transform.position.x + 7.5f * StripPosX, Cars[rnd].transform.position.y, strip.transform.position.z), Quaternion.Euler(0, -90 * StripPosX, 0));
        Car.transform.DOMoveZ(PosZ, 20f);

        StartCoroutine("Strip4");
    }
}
