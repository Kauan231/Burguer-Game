using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace HamburguerGame {
    public class AddOrRemoveIngredient : MonoBehaviour
    {
        [SerializeField] private GameObject InstancesPivot, Cheese, Patty, Cucumber, Salad, Tomato, BreadTop, BreadBottom;
        [SerializeField] private HamburguerManager _control;
        private List<ValidIngredients> CurrentIngredientsSelected = new List<ValidIngredients>();
        public List<GameObject> InstantiatedIngredients = new List<GameObject>();
        private GameObject _lastAddedItem;

        private void InstanceIngredients(GameObject _template) {
            if(InstantiatedIngredients.Any()) {
                if(InstantiatedIngredients.Last() == null)
                {
                    InstantiatedIngredients.Remove(InstantiatedIngredients.Last());
                }
                _lastAddedItem = InstantiatedIngredients.Last();
                _lastAddedItem.GetComponent<BoxCollider>().enabled = false;
            }
    
            GameObject _instance = Instantiate(_template);
            _instance.transform.parent = InstancesPivot.transform;
            
            if(_lastAddedItem == null) {
                _instance.transform.localPosition =  new Vector3(0f, 0f, 0f);
            }
            else if ((_lastAddedItem.tag == "Tomato") || (_lastAddedItem.tag == "Cucumber")) {
                GameObject ChildrenObj = _lastAddedItem.transform.GetChild(0).gameObject;
                float _distanceFromLastObject = ChildrenObj.GetComponent<Renderer>().bounds.size.y + _lastAddedItem.transform.localPosition.y;
                _instance.transform.localPosition =  new Vector3(0f, _distanceFromLastObject, 0f);
            }
            else {
                float _distanceFromLastObject = _lastAddedItem.GetComponent<Renderer>().bounds.size.y + _lastAddedItem.transform.localPosition.y;
                _instance.transform.localPosition =  new Vector3(0f, _distanceFromLastObject, 0f);
            }
            _instance.transform.localScale = _template.transform.localScale;
            _instance.SetActive(true);
            InstantiatedIngredients.Add(_instance);
        }

        public void AddIngredientFunction(string _ingredient)
        {
            if(!CurrentIngredientsSelected.Any()      && !_ingredient.Equals("BreadBottom")) return;    
            if((CurrentIngredientsSelected.Count > 3) && !_ingredient.Equals("BreadTop"))    return;    
            
            ValidIngredients SelectedIngredient = (ValidIngredients)Enum.Parse(typeof(ValidIngredients), _ingredient);
            CurrentIngredientsSelected.Add(SelectedIngredient);
            switch(SelectedIngredient)
            {
                case ValidIngredients.Cheese:
                    InstanceIngredients(Cheese);
                    break;
                case ValidIngredients.Patty:
                    InstanceIngredients(Patty);
                    break;
                case ValidIngredients.Cucumber:
                    InstanceIngredients(Cucumber);
                    break;
                case ValidIngredients.Salad:
                    InstanceIngredients(Salad);
                    break;
                case ValidIngredients.Tomato:
                    InstanceIngredients(Tomato);
                    break;
                case ValidIngredients.BreadBottom:
                    InstanceIngredients(BreadBottom);
                    break;
                case ValidIngredients.BreadTop:
                    InstanceIngredients(BreadTop);
                    _control.CheckHamburguer(CurrentIngredientsSelected);
                    break;
                default:
                    break;
            }
        }
        public void RemoveIngredientFunction(GameObject _ingredientToRemove) {
            ValidIngredients SelectedIngredient = (ValidIngredients)Enum.Parse(typeof(ValidIngredients), _ingredientToRemove.tag);
            CurrentIngredientsSelected.Remove(SelectedIngredient);
            InstantiatedIngredients.Remove(_ingredientToRemove);
            Destroy(_ingredientToRemove);
            
            if(InstantiatedIngredients.Any()) {
                InstantiatedIngredients.Last().GetComponent<BoxCollider>().enabled = true;
            }
        }

        public void ResetHamburguerSelection() {
            foreach(GameObject instance in InstantiatedIngredients) {
                Destroy(instance);
            }
            InstantiatedIngredients.Clear();
            CurrentIngredientsSelected.Clear();
        }
    }
}

