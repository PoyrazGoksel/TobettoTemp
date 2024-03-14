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
    
    private List<Vector2Int> _spawnLocStack = new();

    private void Start()
    {
        _spawnLocStack.Add(new Vector2Int(0, 0));
        StartCoroutine(CubeRainRoutine());
        StartCoroutine(InputListenerRoutine());
    }

    private void InstantiateCube(Vector3 newCubePos)
    {
        GameObject newObj = Instantiate(_cubePrefab, transform);
        newObj.transform.localPosition = newCubePos;
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

    private void Awake() {}

    private IEnumerator CubeRainRoutine()
    {
        int lastX = 0;
        int lastZ = 0;

        while(true)
        {
            int randX = Random.Range(0, _xSize);
            int randZ = Random.Range(0, _zSize);

            if(lastX == randX && lastZ == randZ)
            {
                randX = _spawnLocStack[^1].x;
                randZ = _spawnLocStack[^1].y;
            }
            
            Vector3 newCubePos = new(randX, transform.position.y, randZ);

            _spawnLocStack.Add(new Vector2Int(randX, randZ));

            if(_spawnLocStack.Count > _index)
            {
                _spawnLocStack.Remove(_spawnLocStack[_index]);
            }
            
            InstantiateCube(newCubePos);

            lastX = randX;
            lastZ = randZ;
            yield return new WaitForSeconds(_seconds);
        }
    }
}