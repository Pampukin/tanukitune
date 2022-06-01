//タヌキのオブジェクトが消える処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private bool isDestroy = false;

    /// </summary>
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent == null)
        {
            if (other.gameObject.tag == "apple")
            {
                if(this.gameObject.tag == "Enemy" && !isDestroy)
                {
                    RandomPop.countE--;
                    AudioSouce.play0();
                    isDestroy = true;
                }

                if (this.gameObject.tag == "Friend" && !isDestroy)
                {
                    RandomPop.countF--;
                    gameSystem.pro++;
                    AudioSouce.play1();

                    isDestroy = true;

                }
                    Destroy(this.gameObject, 0.075f);
            }
        else if(other.gameObject.tag == "kaki"){
                if (this.gameObject.tag == "Enemy" && !isDestroy)
                {
                    RandomPop.countE--;
                    AudioSouce.play0();
                    isDestroy = true;
                }

                if (this.gameObject.tag == "Friend" && !isDestroy)
                {
                    RandomPop.countF--;
                    AudioSouce.play0();
                    isDestroy = true;

                }
                    Destroy(this.gameObject, 0.075f);

            }
        }

        if (other.gameObject.tag == "Tree")
        {

            if (this.gameObject.tag == "Enemy" && RandomPop.countE > 1 && !isDestroy)
            {

                gameSystem.pro -= 0.5f;
                AudioSouce.play2();
                RandomPop.countE--;
                isDestroy = true;

            }
            else if (this.gameObject.tag == "Friend" && RandomPop.countF > 1 && !isDestroy)
            {
                RandomPop.countF--;
                isDestroy = true;

            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {

            if (this.gameObject.tag == "Enemy" && RandomPop.countE > 1 && !isDestroy)
            {

                gameSystem.pro -= 0.25f;
                AudioSouce.play2();
                RandomPop.countE--;
                isDestroy = true;

            }
            else if (this.gameObject.tag == "Friend" && RandomPop.countF > 1 && !isDestroy)
            {
                RandomPop.countF--;
                isDestroy = true;

            }
            Destroy(gameObject);
        }
    }


}

