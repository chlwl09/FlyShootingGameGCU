using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPoint;

    public void SelectCharacter(int characterIndex)
    {
        if (characterIndex < 0 || characterIndex >= characterPrefabs.Length)
        {
            Debug.LogError("Invalid character index.");
            return;
        }

        // 선택된 캐릭터 프리팹 생성
        Instantiate(characterPrefabs[characterIndex], spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"{characterPrefabs[characterIndex].name} 생성됨.");
    }
}
