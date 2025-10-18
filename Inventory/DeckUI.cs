using Cards;
using UnityEngine;

namespace Inventory
{
    public class DeckUI : MonoBehaviour
    {
        public PlayerDeck playerDeck;
        public GameObject cardUIPrefab;
        public Transform container;

        void Start() => Refresh();

        public void Refresh()
        {
            foreach (Transform child in container)
                Destroy(child.gameObject);

            foreach (CardData card in playerDeck.ownedCards)
            {
                GameObject ui = Instantiate(cardUIPrefab, container);
                ui.GetComponent<CardUI>().Setup(card);
            }
        }
    }
}