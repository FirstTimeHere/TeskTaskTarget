using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    /// <summary>
    /// ƒанный класс должен был реализовать "уровень" без создани€ сцен или перехода между ними
    /// ѕросто обновл€ть мишень и добавл€ть дальность дл€ мишени
    /// </summary>
    private GameManager gameManager;
    private GameObject target;
    public float Duration = 0f;

    private bool clone = true;
   private void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        target=GameObject.Find("AllClones");
    }

   private void Update()
    {
        if (gameManager.score >= 100 && clone) 
        {
            DestroyAllCopies();
            StartCoroutine(Wait());
            clone = false;
            target.transform.position = new Vector3(0f, 0f, Duration + 10);
            Instantiate(target, target.transform);
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
    }

    private void DestroyAllCopies()
    {
        var cubs = new List<GameObject>();
        foreach (Transform child in target.transform)
        {
            cubs.Add(child.gameObject);
            cubs.ForEach(child=>Destroy(child));
        }

    }
}
