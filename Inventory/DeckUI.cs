using dzem.Cards;
using UnityEngine;

namespace dzem.Inventory
{
    public class DeckUI : MonoBehaviour
    {
        public PlayerDeck playerDeck;
        public GameObject cardUIPrefab;
        public Transform container;

        void Start() => Refresh();

        private void Refresh()
        {
            foreach (Transform child in container)
                Destroy(child.gameObject);
            
            foreach (CardData card in playerDeck.ActiveCards)
            {
                var cardUI = Instantiate(cardUIPrefab, container);
                var ui = cardUI.GetComponent<CardUI>();
                ui.Setup(card, playerDeck);
            }
        }
    }
}