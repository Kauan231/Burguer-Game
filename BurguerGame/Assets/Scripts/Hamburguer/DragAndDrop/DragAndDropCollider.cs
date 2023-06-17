using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HamburguerGame {
    public class DragAndDropCollider : MonoBehaviour
    {      
        [SerializeField] private AddOrRemoveIngredient _IngredientManager;
        void OnTriggerEnter(Collider col) {
            if(col.gameObject.layer ==  LayerMask.NameToLayer("OnHamburguer")) return;
            _IngredientManager.AddIngredientFunction(col.gameObject.tag);
            Destroy(col.gameObject);
        }
        void OnTriggerExit(Collider col) {
            _IngredientManager.RemoveIngredientFunction(col.gameObject);
        }
    }

}
