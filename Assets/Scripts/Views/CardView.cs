using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardClass;
    [SerializeField] private SpriteRenderer cardImage;
    [SerializeField] private GameObject wrapper;
    [SerializeField] private LayerMask dropAreaLayer;

    public Card card { get; private set; }
    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;

    public void Setup(Card card)
    {
        this.card = card;
        title.text = card.title;
        cost.text = card.cost.ToString();
        description.text = card.description;
        cardClass.text = card.cardClass;
        cardImage.sprite = card.sprite;
    }

    private void OnMouseEnter()
    {
        if (!Interactions.Instance.PlayerCanHover())
            return;

        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, -2, 0);
        CardViewHoverSystem.Instance.Show(card, pos);
    }

    private void OnMouseExit()
    {
        if (!Interactions.Instance.PlayerCanHover())
            return;

        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!Interactions.Instance.PlayerCanInteract())
            return;
        //if (card.delayedEffects != null)
        //{
        //    ManualTargetingSystem.Instance.StartTargeting(transform.position);
        //
        //else
        //{
            Interactions.Instance.PlayerIsDragging = true;
            wrapper.SetActive(true);
            CardViewHoverSystem.Instance.Hide();
            dragStartPosition = transform.position;
            dragStartRotation = transform.rotation;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
        //}
    }

    private void OnMouseDrag()
    {
        if (!Interactions.Instance.PlayerCanInteract())
            return;
        //if (card.delayedEffects != null)
            //return;

        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void OnMouseUp()
    {
        if (!Interactions.Instance.PlayerCanInteract())
            return;
        //if (card.delayedEffects != null)
        //{
            // NEED CHANGE
        //    EnemyView target = ManualTargetingSystem.Instance.EndTargeting(MouseUtil.GetMousePositionInWorldSpace(-1));
        //    if (target != null && ManaSystem.Instance.HasEnoughMana(card.cost))
        //    {
        //        PlayCardGA playCardGA = new(card, target);
        //        ActionSystem.Instance.Perform(playCardGA);
        //    }
        //}
        //else
        //{
            if (ManaSystem.Instance.HasEnoughMana(card.cost)
                && Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, dropAreaLayer))
            {
                PlateView hitPlate = hit.collider.gameObject.GetComponent<PlateView>();
                PlayCardGA playCardGA = new(card, hitPlate);
                ActionSystem.Instance.Perform(playCardGA);
            }
            else
            {
                transform.position = dragStartPosition;
                transform.rotation = dragStartRotation;
            }
            Interactions.Instance.PlayerIsDragging = false;
        //}
    }
}
