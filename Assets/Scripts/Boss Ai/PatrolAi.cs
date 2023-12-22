using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolAi : StateMachineBehaviour
{
    GameObject points;
    GameObject rocketSprite;
    GameObject rocketSprite2;
    [SerializeField] GameObject rocket1;
    [SerializeField] GameObject rocket2;
    [SerializeField] float speed;
    [SerializeField] float waitTime;

    int randIndex;
    float timeValue;
    bool shoot = false;
    int counter = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        points = GameObject.FindGameObjectWithTag("partols");
        randIndex = 2;
        rocketSprite = GameObject.FindGameObjectWithTag("torpedo");
        rocketSprite2 = GameObject.FindGameObjectWithTag("torpedo2");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossPhaseOne(animator);

    }

    private void bossPhaseOne(Animator animator)
    {
        animator.transform.position = Vector3.Lerp(animator.transform.position, points.transform.GetChild(randIndex).position, speed * Time.deltaTime);
        if (Vector3.Distance(animator.transform.position, points.transform.GetChild(randIndex).position) < 0.2f)
        {
            if (timeValue > waitTime)
            {
                randIndex = Random.Range(0, points.transform.childCount);
                timeValue = 0;
                shoot = false;
                counter++;
            }
            else
            {
                timeValue += Time.deltaTime;
                if (counter > 5)
                {
                    if (shoot == false)
                    {
                        if (rocketSprite2 != null)
                        {
                            rocketSprite2.transform.position = Vector3.MoveTowards(rocketSprite2.transform.position,
                                animator.transform.position + new Vector3(-0.7f, -2, 0), 1 * Time.deltaTime);
                            if (Vector3.Distance(rocketSprite2.transform.position, animator.transform.position + new Vector3(-0.7f, -2, 0)) < 0.2f)
                            {
                                GameObject rocketBlack = Instantiate(rocket2, rocketSprite2.transform.position, Quaternion.identity);
                                rocketSprite2.transform.position = animator.transform.position + new Vector3(-0.7f, -0.45f, 0);
                                shoot = true;
                                counter = 0;
                            }
                        }
                    }
                }
                else if (counter >= 1)
                {

                    if (shoot == false)
                    {
                        if (rocketSprite != null)
                        {
                            rocketSprite.transform.position = Vector3.MoveTowards(rocketSprite.transform.position,
                                animator.transform.position + new Vector3(0.3600001f, -2, 0), 1 * Time.deltaTime);
                            if (Vector3.Distance(rocketSprite.transform.position, animator.transform.position + new Vector3(0.3600001f, -2, 0)) < 0.2f)
                            {
                                Instantiate(rocket1, rocketSprite.transform.position, Quaternion.identity);
                                rocketSprite.transform.position = animator.transform.position + new Vector3(0.3600001f, -0.7f, 0);
                                shoot = true;
                            }
                        }
                    }
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
