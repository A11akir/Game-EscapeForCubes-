using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private Gradient gradientBack;

    [SerializeField] private Image expBarFilling;
    [SerializeField] private SpriteRenderer spriteBarFilling;

    [Inject] ExpScript exp;

    private void Awake()
    {
        exp.ExpChanged += OnExpChanged; //observer
    }

    private void OnDestroy()
    {
        exp.ExpChanged -= OnExpChanged;
    }

    private void OnExpChanged(float valueAsPercantage)
    {
        expBarFilling.fillAmount = valueAsPercantage;
        expBarFilling.color = gradient.Evaluate(valueAsPercantage);
        spriteBarFilling.color = gradientBack.Evaluate(valueAsPercantage);
    }
}
