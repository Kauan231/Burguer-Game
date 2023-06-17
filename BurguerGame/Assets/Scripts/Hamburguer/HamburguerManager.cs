using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Core;

namespace HamburguerGame {
    public class HamburguerManager : MonoBehaviour
    {
        private Manager _managerCore;
        private UnityEngine.Object[] ScriptableObjects;
        private List<Hamburguer> CustomersOrders = new List<Hamburguer>();
        private int CustomerOrderIterator;
        private ShowRecipe _ShowRecipe;
        [SerializeField] private AddOrRemoveIngredient _ingredientManager;
        public Hamburguer CurrentHamburguer;      
        public void CheckHamburguer(List<ValidIngredients> _SelectedIngredients)
        {
            bool isEqual = CurrentHamburguer.Ingredients.All(_SelectedIngredients.Contains);

            if(isEqual) {
                _managerCore.AddPoints();
            } else {
                _managerCore.RemovePoints();
            }
            
            if(CurrentHamburguer == CustomersOrders.Last()) {
                _managerCore.EndGame();
            } else {
                CustomerOrderIterator++;
                CurrentHamburguer = CustomersOrders[CustomerOrderIterator];
                _ShowRecipe.ChangeRecipe(CurrentHamburguer);
            }
            _ingredientManager.ResetHamburguerSelection();
        }

        private void Start()
        {
            ScriptableObjects = Resources.LoadAll("Hamburguers", typeof(Hamburguer));
            List<Hamburguer> TemporaryList = new List<Hamburguer>();
            foreach(Hamburguer _hamburguer in ScriptableObjects)
            {
                //CustomersOrders.Add(_hamburguer);
                TemporaryList.Add(_hamburguer);
            }
            System.Random _random = new System.Random();
            CustomersOrders = TemporaryList.OrderBy(_ => _random.Next()).ToList();
            CurrentHamburguer = CustomersOrders[0];
            CustomerOrderIterator = 0;

            _ShowRecipe        = GetComponent<ShowRecipe>();   
            _managerCore       = GetComponent<Manager>();
            _ingredientManager = GetComponent<AddOrRemoveIngredient>();

            _ShowRecipe.ChangeRecipe(CurrentHamburguer);
        }
    }

}
