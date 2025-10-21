using UnityEngine;

namespace card_logic
{
    public class DeckUI : MonoBehaviour
    {
        public static DeckUI Instance { get; private set; }
        public GameObject cardUIPrefab;
        public Transform container;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        void Start() => Refresh();

        private void Refresh()
        {
            foreach (Transform child in container)
                Destroy(child.gameObject);
            foreach (CardData card in PlayerDeck.Instance.ActiveCards)
            {
                var cardUI = Instantiate(cardUIPrefab, container);
                var ui = cardUI.GetComponent<CardUI>();
                ui.Setup(card);
            }
        }

        public void CreateCard(CardData data)
        {
            var cardUI = Instantiate(cardUIPrefab, container);
            var ui = cardUI.GetComponent<CardUI>();
            ui.Setup(data);
        }
    }
}