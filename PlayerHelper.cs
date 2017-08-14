using UnityEngine;
using System.Collections;

public class PlayerHelper : MonoBehaviour
{
    public PokemonModel MyPokemonModel { get; set; }

    // Use this for initialization
    void Start()
    {
        MyPokemonModel = new PokemonModel()
        {
            PokemonType = ETypes.Pikachu,
            Health = 200,
            Damage = 10,
            Exp = 21
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
