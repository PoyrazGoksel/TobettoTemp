using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private int _index = 10;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _seconds;
    [SerializeField] private int _xSize;
    [SerializeField] private int _zSize;
    [SerializeField] private float _moveSpeed;

    private void Awake() {}

    private void Start()
    {
        StartCoroutine(CubeRainRoutine());
        StartCoroutine(InputListenerRoutine());
    }

    private IEnumerator InputListenerRoutine()
    {
        float moveDelta = _moveSpeed * Time.deltaTime;

        while(true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                Vector3 currPos = transform.position;
                currPos.z += moveDelta;
                transform.position = currPos;
            }

            if(Input.GetKey(KeyCode.S))
            {
                Vector3 currPos = transform.position;
                currPos.z -= moveDelta;
                transform.position = currPos;
            }

            if(Input.GetKey(KeyCode.D))
            {
                Vector3 currPos = transform.position;
                currPos.x += moveDelta;
                transform.position = currPos;
            }

            if(Input.GetKey(KeyCode.A))
            {
                Vector3 currPos = transform.position;
                currPos.x -= moveDelta;
                transform.position = currPos;
            }

            yield return null;
        }
    }

    private IEnumerator CubeRainRoutine()
    {
        while(true)
        {
            Vector3 currPos = transform.position;
            
            int randX = Random.Range(0, _xSize);
            int randZ = Random.Range(0, _zSize);

            Vector3 newCubePos = new(currPos.x + randX, currPos.y, currPos.z + randZ);

            InstantiateCube(newCubePos);

            yield return new WaitForSeconds(_seconds);
        }
    }

    private void InstantiateCube(Vector3 newCubePos)
    {
        GameObject newObj = Instantiate(_cubePrefab);
        newObj.transform.position = newCubePos;
    }
}