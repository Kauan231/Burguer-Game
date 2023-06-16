using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HamburguerGame {
    public enum ValidIngredients {
        Cheese,
        Cucumber,
        Patty,
        Salad,
        Tomato,
        BreadBottom,
        BreadTop
    }

    [CreateAssetMenu]
    public class Hamburguer : ScriptableObject {
        public string RecipeName;
        public List<ValidIngredients> Ingredients;
    }

}
