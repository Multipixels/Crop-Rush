using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour {

    Transform playerTransform;

    [SerializeField]
    AudioSource moveSound;

    float moveX;
    float moveY;
    Vector2 moveVector;

    bool isMoving = false;

    [SerializeField]
    private UnityEvent movedToNewspot;

    [SerializeField]
    private MapManager mm;

    [SerializeField]
    private RushManager rm;

    public void Move(InputAction.CallbackContext context) {
        float moveVal = context.ReadValue<float>();

        if (context.action.name == "Horizontal") {
            moveX = moveVal;
        } else if (context.action.name == "Vertical") {
            moveY = moveVal;
        } else {
            Debug.Log("This shouldn't be happening.");
        }
    }

    // Start is called before the first frame update
    void Start() {
        moveVector = new Vector2(0, 0);
        playerTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update() {
        if (isMoving == false) {
            if (moveY != 0) {
                moveVector = new Vector2(0, moveY);

                try {
                    if (mm.PreMove(moveVector + (Vector2)playerTransform.position) == false) {
                        moveVector = new Vector2(moveX, 0);
                    }
                } catch {
                    if (rm.PreMove(moveVector + (Vector2)playerTransform.position) == false) {
                        moveVector = new Vector2(moveX, 0);
                    }
                }


            } else {
                moveVector = new Vector2(moveX, 0);
            }


            try {
                if (moveVector != Vector2.zero && mm.PreMove(moveVector + (Vector2)playerTransform.position) == true) {
                    isMoving = true;
                    StartCoroutine(SmoothMove(moveVector, 0.1f));
                }
            } catch {
                if (moveVector != Vector2.zero && rm.PreMove(moveVector + (Vector2)playerTransform.position) == true) {
                    isMoving = true;
                    StartCoroutine(SmoothMove(moveVector, 0.1f));
                }
            }
        }
    }

    IEnumerator SmoothMove(Vector2 movement, float time) {

        if(movement == new Vector2(1,0)) {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(movement == new Vector2(-1,0)) {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        } else if (movement == new Vector2(0, 1)) {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        } else if (movement == new Vector2(0, -1)) {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        moveSound.volume = PlayerPrefs.GetFloat("audioVolume");
        moveSound.Play();

        Vector2 startingPos = playerTransform.position;
        Vector2 finalPos = startingPos + movement;
        float elapsedTime = 0;

        while ((Vector2)playerTransform.position != finalPos) {
            playerTransform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(time / 60);
        }

        movedToNewspot.Invoke();
        yield return new WaitForSeconds(0.03f);
        isMoving = false;
    }

}
