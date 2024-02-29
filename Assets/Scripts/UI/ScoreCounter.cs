using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fruitText;
    [SerializeField] private CollectFruit fruitCollector;
    private int points;

    private void Start()
    {
        fruitText = FindObjectOfType<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        fruitCollector.onCollect += HandleScoreChange;
    }

    private void OnDisable()
    {
        fruitCollector.onCollect -= HandleScoreChange;
    }

    private void HandleScoreChange()
    {
        points++;
        fruitText.text = "" + points;
    }
}
