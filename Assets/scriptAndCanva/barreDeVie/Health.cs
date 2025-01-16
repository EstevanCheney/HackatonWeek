using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public DeathMen DeathMenu;

    public Image healthBarImage;
    public TextMeshProUGUI interactionCounter;
    
    void Update()
    {
        UpdateHealthBar();
        if (Input.GetKeyDown(KeyCode.A) && CanHeal())
        {
            health = 100f;
            interactionCounter.text = "0/1";
        }
        if (health <= 0)
        {
            DeathMenu.gameObject.SetActive(true);
            DeathMenu.ShowDeathMenu();
        }
    }

    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = health / maxHealth;
    }

    public void Damage(float damageAmount)
    {
        health = Mathf.Clamp(health - damageAmount, 0f, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        health = Mathf.Clamp(health + healAmount, 0f, maxHealth);
        UpdateHealthBar();
    }

    private bool CanHeal()
    {
        return interactionCounter != null && interactionCounter.text == "1/1";
    }
}
