using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _xAxis;
    [SerializeField] private int _zAxis;
    [SerializeField] private float _padding;
    
    private Vector3 _initPos;

    private void Start()
    {
        _initPos = transform.position;

        CreateGrid();
    }

    private void CreateGrid()
    {
        _initPos = transform.position; //TODO: _initPos = benim pozisyonum

        float initX = _initPos.x; //TODO: initX ben.pos.x
        
        for(int x = 0; x < _xAxis; x ++)
        {
            float initZ = _initPos.z; //TODO: initX ben.pos.z
            
            for(int z = 0; z < _zAxis; z ++)
            {
                Vector3 newCubePos = new(initX, _initPos.y, initZ);
                
                InstantiateCube(newCubePos);
                
                initZ += _padding;
            }
            
            initX += _padding;
        }
    }

    private void InstantiateCube(Vector3 newCubePos)
    {
        Instantiate(_cubePrefab, newCubePos, Quaternion.identity);
    }
}