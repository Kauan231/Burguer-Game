using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


namespace HamburguerGame {
    
    public class Control : MonoBehaviour
    {
        private UnityEngine.Object[] ScriptableObjects;
        private List<Hamburguer> CustomersOrders = new List<Hamburguer>();
        private List<ValidIngredients> CurrentIngredientsSelected = new List<ValidIngredients>();
        private ShowRecipe _ShowRecipe;
        public Hamburguer CurrentHamburguer;

        [SerializeField] private GameObject InstancesPivot, Cheese, Patty, Cucumber, Salad, Tomato, BreadTop, BreadBottom;
        private List<GameObject> InstantiatedIngredients = new List<GameObject>();
        private GameObject _lastAddedItem;
        private void InstanceIngredients(GameObject _template) {
            GameObject _instance = Instantiate(_template);
            _instance.transform.parent = InstancesPivot.transform;
            _instance.transform.localPosition =  new Vector3(0f, _lastAddedItem.transform.localPosition.y + .01f , 0f);
            _instance.transform.localScale = _template.transform.localScale;
            InstantiatedIngredients.Add(_instance);
            _instance.SetActive(true);
            _lastAddedItem = _instance;
        }

        public void AddIngredient(string _ingredient)
        {
            if(!CurrentIngredientsSelected.Any() && !_ingredient.Equals("BreadBottom")) return;    
            
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
                        CheckHamburguer();
                        break;
                    default:
                        break;
                }
        }

        private void CheckHamburguer()
        {
            var Comparison =  CurrentHamburguer.Ingredients.Intersect(CurrentIngredientsSelected);
            int _count = Comparison.Count();
            Debug.Log(Comparison);
            if(_count < 3) Debug.Log("ERRO");
        }

        private void Start()
        {
            ScriptableObjects = Resources.LoadAll("Hamburguers", typeof(Hamburguer));
            foreach(Hamburguer hb in ScriptableObjects)
            {
                CustomersOrders.Add(hb);
            }
            _ShowRecipe = GetComponent<ShowRecipe>();   
            _lastAddedItem = InstancesPivot;
        }

        
        private void Update(){
            if(Input.GetKeyDown(KeyCode.K)) _ShowRecipe.ChangeRecipe();
        }
    
    }

}
