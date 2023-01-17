using System.Collections;
using UnityEngine;

public class Gamelogic : MonoBehaviour {
    
    public GameObject Cam;
    public GameObject Sphere;
    public GameObject instObj;
    public GameObject Wall;

    public float moveSpeed = 5F;
    public float JumpPower = 5F;
    public float Gravity = 5F;

    bool running;

    void Start(){
        Gameplay();
    }
    void Update(){
        Move();
    }    
    void Gameplay(){
        Cam = Instantiate(Cam, new Vector3(0, 0, -10), Quaternion.identity);
        Sphere = Instantiate(Sphere, new Vector3(-7, 0, 0), Quaternion.identity);
        Wall = Instantiate(Wall, new Vector3(0, 0, 0), Quaternion.identity);
        StartCoroutine(InstWall(1));
        StartCoroutine(InstObj(1));
        StartCoroutine(DelObj(1));
        StartCoroutine(DelWall(1));
        StartCoroutine(Speed(15));
    }
    void Move(){
        Cam.transform.Translate(1 * moveSpeed * Time.deltaTime, 0, 0);        
        Sphere.transform.Translate(1 * moveSpeed * Time.deltaTime, -1 * Gravity * Time.deltaTime, 0);
        if (Sphere.transform.position.y == -3 || Sphere.transform.position.y < -3) {
            Sphere.transform.Translate(0, 1 * Gravity * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            Sphere.transform.Translate(0, 3 * JumpPower * Time.deltaTime, 0);
            if (Sphere.transform.position.y == 3 || Sphere.transform.position.y > 3){
                Sphere.transform.Translate(0, -3 * JumpPower * Time.deltaTime, 0);
            }
        }        
    }
    IEnumerator Speed(int time){
        running = true;    
        while (true) {            
            moveSpeed = moveSpeed * 1.5F;
            yield return new WaitForSeconds(time);
        }        
    }    
    IEnumerator InstObj(int time){
        running = true;
        while (running){
            instObj = Instantiate(instObj, new Vector3(Sphere.transform.position.x + moveSpeed + 50, Random.Range( 3f, -3f), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);            
        }        
    }
    IEnumerator InstWall(int time){
        running = true;
        while (running){
            Wall = Instantiate(Wall, new Vector3(Sphere.transform.position.x + moveSpeed + 100, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator DelObj(int time){
        running = true;
        while (running){
            Destroy(instObj, 20);            
            yield return new WaitForSeconds(time);            
        }
    }
    IEnumerator DelWall(int time){
        running = true;
        while (running){
            Destroy(Wall, 20);
            yield return new WaitForSeconds(time);
        }
    }
}