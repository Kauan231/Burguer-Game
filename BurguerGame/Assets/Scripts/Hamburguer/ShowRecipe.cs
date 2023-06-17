using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace HamburguerGame {
    public class ShowRecipe : MonoBehaviour
    {
        [SerializeField] private GameObject Cheese, Patty, Cucumber, Salad, Tomato;
        [SerializeField] private GameObject InstancesParent;
        [SerializeField] private Text RecipeNameUI, IngredientsUI;
        public List<GameObject> InstantiatedObjectsUI = new List<GameObject>();

        float Item1_Position = .34f;
        float Item2_Position = .51f;
        float Item3_Position = .77f;


        private void ChangeVerticalPositon(Transform _transform, int _iterator) {
            switch(_iterator){
                case 0:
                    _transform.localPosition = new Vector3(_transform.localPosition.x, Item1_Position, _transform.localPosition.z);
                    break;
                case 1:
                    _transform.localPosition = new Vector3(_transform.localPosition.x, Item2_Position, _transform.localPosition.z);
                    break;
                case 2:
                    _transform.localPosition = new Vector3(_transform.localPosition.x, Item3_Position, _transform.localPosition.z);
                    break;
                default:
                    break;
            }
        }
        
        private void InstanceUIItem(GameObject _template, int _iterator) {
            GameObject _instance = Instantiate(_template, _template.transform.position, _template.transform.rotation);
            _instance.transform.parent = InstancesParent.transform;
            _instance.transform.localScale = _template.transform.localScale;
            InstantiatedObjectsUI.Add(_instance);
            ChangeVerticalPositon(_instance.transform, _iterator);
            _instance.SetActive(true);
        }
        

        public void ChangeRecipe(Hamburguer _currentHamburguer)
        {
            foreach(GameObject Instance in InstantiatedObjectsUI) { 
                Destroy(Instance);
            };

            InstantiatedObjectsUI.Clear();
            IngredientsUI.text = string.Empty;
            RecipeNameUI.text = _currentHamburguer.RecipeName;

            for(int i = 0; i < 3; i++){
                switch(_currentHamburguer.Ingredients[i])
                {
                    case ValidIngredients.Cheese:
                        InstanceUIItem(Cheese, i);
                        IngredientsUI.text = IngredientsUI.text + "- Queijo \n";
                        break;
                    case ValidIngredients.Patty:
                        InstanceUIItem(Patty, i);
                        IngredientsUI.text = IngredientsUI.text + "- Carne \n";
                        break;
                    case ValidIngredients.Cucumber:
                        InstanceUIItem(Cucumber, i);
                        IngredientsUI.text = IngredientsUI.text + "- Picles \n";
                        break;
                    case ValidIngredients.Salad:
                        InstanceUIItem(Salad, i);
                        IngredientsUI.text = IngredientsUI.text + "- Salada \n";
                        break;
                    case ValidIngredients.Tomato:
                        InstanceUIItem(Tomato, i);
                        IngredientsUI.text = IngredientsUI.text + "- Tomate \n";
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
