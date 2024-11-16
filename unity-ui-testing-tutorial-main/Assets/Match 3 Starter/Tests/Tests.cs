using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Tests
{
    private BoardManager boardManager;
    private Tile tileA;
    private Tile tileB;

    // variable de los sprites
    private Sprite candyA; 
    private Sprite candyB; 

    [SetUp]
    public void SetUp()
    {
        // instancia de BM
        GameObject boardObject = new GameObject();
        boardManager = boardObject.AddComponent<BoardManager>();

        // hago un tablero de 3x3 para probar
        boardManager.InitializeBoard(3, 3);

        // creamos los tiles
        tileA = new GameObject().AddComponent<Tile>();
        tileB = new GameObject().AddComponent<Tile>();

        // buscamos los sprites y los cargamos
        candyA = Resources.Load<Sprite>("Sprites/Characters/Blue"); 
        candyB = Resources.Load<Sprite>("Sprites/Characters/Green"); 

        // verifico que no sean nullos
        //if (candyA == null) Debug.LogError("No se pudo cargar el Sprite de CandyA");
        //if (candyB == null) Debug.LogError("No se pudo cargar el Sprite de CandyB");

        // asigno el sprite al tile
        tileA.SetCandyType(candyA);
        tileB.SetCandyType(candyB);

        // debug para ver si funciono (borrar al subir)
        //Debug.Log($"Candy a: {tileA.GetCandyType()?.name}");
        //Debug.Log($"candy b: {tileB.GetCandyType()?.name}");

        

    }

    [Test]
    public void TestSwapTile()
    {
        // debug para ver los candys antes de cambiarlos (borrar al subir)
        Debug.Log($"candy a: {tileA.GetCandyType()?.name} | se esperaba: {candyA?.name}");
        Debug.Log($"candy b: {tileB.GetCandyType()?.name} | se esperaba: {candyB?.name}");

        // cambiamos o swapeamos
        boardManager.SwapTile(tileA, tileB);

        // uso debug para ver si se logro la funcion (borrar al subir)
        Debug.Log($"candy a despues del cambio: {tileA.GetCandyType()?.name} | se esperaba: {candyB?.name}");
        Debug.Log($"candy b despues del cambio: {tileB.GetCandyType()?.name} | se esperaba: {candyA?.name}");

        // Verificar que los tipos de caramelos se han intercambiado correctamente
        Assert.AreEqual(tileA.GetCandyType(), candyB, "Tile A deberia tener el candy B despues del intercambio");
        Assert.AreEqual(tileB.GetCandyType(), candyA, "Tile B deberia tener el candy A despues del intercambio");
    }
    [Test]
    public void CombinacionFichasTres(){
        Sprite matchType = Resources.Load<Sprite>("Sprites/Characters");

        GameObject tile1 =  new GameObject();
        GameObject tile2 =  new GameObject();
        GameObject tile3 =  new GameObject();

        var tileComponent1 = tile1.AddComponent<Tile>();
        var tileComponent2 = tile2.AddComponent<Tile>();
        var tileComponent3 = tile3.AddComponent<Tile>();

        tileComponent1.SetCandyType(matchType);
        tileComponent2.SetCandyType(matchType);
        tileComponent3.SetCandyType(matchType);

        bool isMatch = tileComponent1.GetCandyType() == tileComponent2.GetCandyType() &&
                        tileComponent2.GetCandyType() == tileComponent3.GetCandyType();

        Assert.IsTrue(isMatch, "No se detecto combinacion");
    }
}