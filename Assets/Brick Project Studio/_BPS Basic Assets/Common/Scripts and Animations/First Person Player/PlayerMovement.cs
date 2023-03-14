using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] CharacterController controller;

        [SerializeField] float speed = 5f;
        [SerializeField] float gravity = -15f;

        [SerializeField] BackupScriptableObject backupScriptableObject;


        Vector3 velocity;


        private void Start()
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    if (backupScriptableObject.positionScene1 != new Vector3(0,0,0))
                        transform.position = backupScriptableObject.positionScene1;
                    break;
                case 1:
                    if (backupScriptableObject.positionScene2 != new Vector3(0, 0, 0))
                        transform.position = backupScriptableObject.positionScene2;
                    break;
                case 2:
                    if (backupScriptableObject.positionScene3 != new Vector3(0, 0, 0))
                        transform.position = backupScriptableObject.positionScene3;
                    break;
                default:
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (transform != null && transform.position != null) 
            { 
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 0:
                            backupScriptableObject.positionScene1 = transform.position;
                        break;
                    case 1:
                        backupScriptableObject.positionScene2 = transform.position;
                        break;
                    case 2:
                        backupScriptableObject.positionScene3 = transform.position;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}