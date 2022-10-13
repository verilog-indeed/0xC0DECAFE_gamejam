using UnityEngine;
using TMPro;

public class DeadBodyScript : MonoBehaviour
{
    bool InRange;
    [SerializeField] GameObject presskeyGO;
    TextMeshProUGUI PresKeyText;
    GameObject PlayerGO;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = true;
            PlayerGO = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = false;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        PresKeyText = presskeyGO.GetComponent<TextMeshProUGUI>();
        presskeyGO.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange)
        {
            presskeyGO.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                PlayerGO.GetComponent<PlayerProtoMovement>().IsSpirit = false;
                Destroy(gameObject);
            }
        }
    }
}
