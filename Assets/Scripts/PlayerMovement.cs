using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement pm;

    private Animator anim;
    private bool walking;
    private Vector3 endPoint;
    private RectTransform trans;

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
            trans.position = Vector3.Lerp(trans.position, endPoint, 0.01f);
            if (Vector3.Distance(trans.position, endPoint) < 10f){
                trans.position = endPoint;
                endWalk();
            }
        }
    }

    public void walk(Vector3 end){
        anim.SetBool("Walk", true);
        walking = true;
        endPoint = end;
    }

    protected internal void endWalk(){
        anim.SetBool("Walk", false);
        walking = false;
    }
}