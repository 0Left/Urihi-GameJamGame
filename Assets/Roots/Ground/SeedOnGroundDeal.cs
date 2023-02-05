using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedOnGroundDeal : MonoBehaviour
{
    [SerializeField] private GameObject ladderRoot;
    // Start is called before the first frame update
    public void startGrowing(){
        StartCoroutine(startGrow());
    }
    IEnumerator startGrow(){
        //camera shake
        yield return new WaitForSeconds(0.2f);
        Instantiate(ladderRoot,new Vector3(transform.position.x,transform.position.y+2.5f,0.1f), transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
