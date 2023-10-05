using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Transform spawnObjectPrefab;
    private Transform _spawnedObjectTransform;
    private Renderer _sprite;
    private readonly NetworkVariable<Color32> _color = new (new Color32(r:255,g:255,b:255,a:255), NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public override void OnNetworkSpawn()
    {
        _sprite = gameObject.transform.Find("Capsule").GetComponent<Renderer>();
        _color.OnValueChanged += (_, _) =>
        {
            Debug.Log(OwnerClientId + " ; " + _color.Value);
            _sprite.material.color = _color.Value;
        };
    }
    
    private void Update()
    {
        
        if (!IsOwner) return;
        
        var moveDir = new Vector3();

        if (Input.GetKeyDown(KeyCode.T)) 
        {
            _color.Value = new Color32((byte)Random.Range(0,255),(byte)Random.Range(0,255),(byte)Random.Range(0,255),255);
        }
        
        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;
        
        const float moveSpeed = 3f;
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }
}
