using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlotList : MonoBehaviour
{
    public UiInvenSlot prefab;
    public ScrollRect scrollRect;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < 10; i++)
            {
                var saveItemData = SaveItemData.GetRandomItem();
                var newInven = Instantiate(prefab, scrollRect.content);
                //프리팹 생성후 데이터 넣어주기
                newInven.SetItem(saveItemData);
            }
        }
    }
}
