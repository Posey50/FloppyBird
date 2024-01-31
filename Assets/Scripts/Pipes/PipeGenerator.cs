using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    /// <summary>
    /// Pipes generation loop.
    /// </summary>
    public Coroutine GenerationCoroutine { get; private set; }

    /// <summary>
    /// All types of pipes.
    /// </summary>
    [SerializeField]
    private List<GameObject> _pipes;

    /// <summary>
    /// Delay between two pipes.
    /// </summary>
    [SerializeField]
    private float _timeBetweenTwoPipes;

    /// <summary>
    /// Called to generate a pipe.
    /// </summary>
    public void GeneratePipe()
    {
        GameObject pipeToInstantiate = _pipes[Random.Range(0, _pipes.Count)];
        Instantiate(pipeToInstantiate, new Vector3(transform.position.x, pipeToInstantiate.transform.position.y, transform.position.z), Quaternion.identity);
    }

    /// <summary>
    /// Called to start the pipes generation.
    /// </summary>
    public void StartGeneration()
    {
        GenerationCoroutine = StartCoroutine(Generation());
    }

    /// <summary>
    /// Called to stop the generation.
    /// </summary>
    public void StopGeneration()
    {
        if (GenerationCoroutine != null)
        {
            StopCoroutine(GenerationCoroutine);
        }
    }

    /// <summary>
    /// Generates pipes with a delay.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Generation()
    {
        yield return new WaitForSeconds(_timeBetweenTwoPipes);

        GeneratePipe();

        GenerationCoroutine = StartCoroutine(Generation());
    }
}
