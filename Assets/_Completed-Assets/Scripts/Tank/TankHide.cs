using Complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete {

    public class TankHide : MonoBehaviour {

        public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
        public Animator anim;                      // Spin animator
        public ParticleSystem tornadoPrefab;
        public float damagePerSecond; 
        public bool isHidden;

        private TankHealth tankHealth;
        private string m_HideButton;                // The input axis that is used for launching shells.
        private Rigidbody m_Rigidbody;              // Reference used to move the tank.
      



        private void Awake() {

            m_Rigidbody = GetComponent<Rigidbody>();
            
        }

        void Start() {
            tankHealth = GetComponent<TankHealth>();
            // tankHealth = m_Rigidbody.GetComponent<TankHealth>();
            Debug.Log("tankHealth " + tankHealth);
            isHidden = false;
            m_HideButton = "Hide" + m_PlayerNumber;
        }

        void Update() {
            if (Input.GetButtonDown(m_HideButton)) {
                if (!isHidden) {
                    HideMe();

                }

                else ShowMe();
            }


            if (isHidden) {
                tankHealth.TakeDamage(damagePerSecond);
            }
        }

        void HideMe() {
            anim.SetTrigger("hideMe");
            isHidden = true;
            ParticleSystem tornado = Instantiate(tornadoPrefab, transform.position, transform.rotation);
            tornado.Play();
            ParticleSystem.MainModule mainModule = tornado.main;
            Destroy(tornado.gameObject, mainModule.duration);
        }

        void ShowMe() {
            anim.SetTrigger("showMe");
            isHidden = false;
            ParticleSystem tornado = Instantiate(tornadoPrefab, transform.position, transform.rotation);
            tornado.Play();
            ParticleSystem.MainModule mainModule = tornado.main;
            Destroy(tornado.gameObject, mainModule.duration);
        }

        void IsHiddenEvent() {
            Debug.Log("IS HIDDEN EVENT");
        }

    }

}
