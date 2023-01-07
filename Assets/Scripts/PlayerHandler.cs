using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour {

    Transform playerTransform;

    float moveX;
    float moveY;
    Vector2 moveVector;

    bool isMoving = false;

    [SerializeField]
    private UnityEvent movedToNewspot;

    [SerializeField]
    private MapManager mm;

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

                if (mm.PreMove(moveVector + (Vector2)playerTransform.position) == false) {
                    moveVector = new Vector2(moveX, 0);
                }


            } else {
                moveVector = new Vector2(moveX, 0);
            }


            if (moveVector != Vector2.zero && mm.PreMove(moveVector + (Vector2)playerTransform.position) == true) {
                isMoving = true;
                StartCoroutine(SmoothMove(moveVector, 0.1f));
            }
        }
    }

    IEnumerator SmoothMove(Vector2 movement, float time) {
        Vector2 startingPos = playerTransform.position;
        Vector2 finalPos = startingPos + movement;
        float elapsedTime = 0;

        while ((Vector2)playerTransform.position != finalPos) {
            playerTransform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(time / 60);
        }

        movedToNewspot.Invoke();
        isMoving = false;
    }

}
