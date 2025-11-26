/*using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NPC_Wander_Tests
{
    [UnityTest]
    public IEnumerator NPC_Wander_Picks_New_Target_Inside_Area()
    {
        // ---------- Arrange ----------
        // GameObject principal
        var obj = new GameObject("NPC_Wander");

        // Rigidbody2D precisa existir antes do Awake do NPC_Wander
        obj.AddComponent<Rigidbody2D>();

        // Child com Animator, para o GetComponentInChildren<Animator>() não voltar null
        var child = new GameObject("AnimatorChild");
        child.transform.SetParent(obj.transform);
        child.AddComponent<Animator>();

        // Agora adiciona o NPC_Wander (Awake roda aqui)
        var wander = obj.AddComponent<NPC_Wander>();

        // Configura a área de wander
        wander.StartingPosition = Vector2.zero;
        wander.WanderWidth = 4f;
        wander.WanderHeigh = 4f;
        wander.pauseDuration = 0.1f; // pequeno pra ficar rápido no teste

        // Garante um target inicial "neutro"
        wander.target = Vector2.zero;

        // ---------- Act ----------
        // Força a coroutine que escolhe um novo destino
        // Usa a versão por string para conseguir chamar o método privado
        wander.StartCoroutine("PauseAndPickNewDestination");

        // Espera a pausa + uma folguinha
        yield return new WaitForSeconds(wander.pauseDuration + 0.05f);

        // ---------- Assert ----------
        // A área é um retângulo de (-2,-2) até (2,2)
        float halfWidth = wander.WanderWidth / 2f;
        float halfHeight = wander.WanderHeigh / 2f;

        Assert.IsTrue(
            wander.target.x >= wander.StartingPosition.x - halfWidth &&
            wander.target.x <= wander.StartingPosition.x + halfWidth &&
            wander.target.y >= wander.StartingPosition.y - halfHeight &&
            wander.target.y <= wander.StartingPosition.y + halfHeight,
            $"Target fora da área! Target = {wander.target}"
        );
    }
}*/
