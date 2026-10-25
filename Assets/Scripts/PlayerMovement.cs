using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement pm;

    private Animator anim;
    private bool walking;
    private Vector3 endPoint;
    private RectTransform trans;
    private float firstX;

    void Start(){
        pm = this;

        anim = this.GetComponent<Animator>();
        endWalk();
        endPoint = Vector3.zero;
        trans = this.GetComponent<RectTransform>();
    }

    void Update(){
        if (walking){
            // idk if linear interpolation is the best way to do this, since you always start with a jump...
            trans.position = Vector3.Lerp(trans.position, endPoint, 3f * Time.deltaTime);
            if (Vector3.Distance(trans.position, endPoint) < 10f){
                trans.position = endPoint;
                endWalk();
            }
        }
    }

    public void walk(Vector3 end){
        anim.SetBool("Walk", true);
        walking = true;
        firstX = trans.position.x;
        if (firstX > end.x){
            trans.localScale = new Vector3(-1, 1, 1);
        }
        else{
            trans.localScale = new Vector3(1, 1, 1);
        }
        endPoint = end;
    }

    protected internal void endWalk(){
        anim.SetBool("Walk", false);
        walking = false;
    }

    protected internal bool getWalking(){
        return walking;
    }
}