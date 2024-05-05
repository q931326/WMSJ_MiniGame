using UnityEngine;

public class IsChangeColor : MonoBehaviour
{
 // 根据你的条件调整这个布尔值，true表示可以推动，false表示不可以
    public bool canBePushed;

    private Rigidbody2D rb2d;
    private new Renderer renderer;
    [SerializeField]string SceneName;
    void Start()
    {
        if(GameProgressManager.Instance.IsLevelUnlocked(SceneName)){
            canBePushed = true;
        }
        // 获取附加到物体上的Rigidbody2D组件
        rb2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        // 默认情况下，如果物体应该开始时不可推动，可以在这里设置为Kinematic
        if (!canBePushed)
        {
            rb2d.bodyType = RigidbodyType2D.Kinematic;
        }
        UpdateColor();
    }

    // 根据条件更新Rigidbody2D的BodyType
    public void UpdatePushability()
    {
        if (canBePushed)
        {
            // 如果符合条件，允许物理影响，设为Dynamic
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            UpdateColor();
        }
        else
        {
            // 如果不符合条件，不允许物理影响，设为Kinematic
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            UpdateColor(); 
        }
    }
    private void UpdateColor()
    {
        Color newColor = canBePushed ? renderer.material.color:Color.black; // 如果不可以推动，变为黑色；否则保持原色
        renderer.material.color = newColor; // 应用新颜色
    }
}
