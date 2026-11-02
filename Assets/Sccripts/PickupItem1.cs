using System;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("아이템 정보")]
    [SerializeField] private string itemName = "아이템";
    [SerializeField] private int amount = 1;

    [SerializeField] private QuestManager questManager;

    [Header("화면 연출")]
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float floatingHeight = 0.15f;
    [SerializeField] private float floatingSpeed = 2f;

    private InventoryItems inventory;
    private Vector3 startPosition;

    private void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        Inventory = FindFirstObjectByType<InventoryItems>;
    }


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        float y = Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        transform.position = startPosition + Vector3.up * y;
    }

    public void Collect()
    {
        if (inventory == null)
        {
            Debug.Log("SimpleInventory를 찾을 수 없습니다.");
            return;
        }

        if (inventory.AddItem(itemName, amount) == false)
        {
            return;
        }

        Debug.Log(itemName + " " + amount + "개 획득");

        if (questManager != null)
        {
            questManager.AddQuestItem(itemName, amount);
        }

        Destroy(gameObject);
    }

    public string GetltemName()
    {
        return itemName;
    }

    internal string GetItemName()
    {
        throw new NotImplementedException();
    }
}