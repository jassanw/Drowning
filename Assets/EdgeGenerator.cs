using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeGenerator : MonoBehaviour
{
    [SerializeField] Edge edge;
    [SerializeField] GameObject edgeContainer;
    private int maxHeight;

    [SerializeField] Edge initialEdge;
    private Edge previousEdge;
    private Edge currentEdge;
    // Start is called before the first frame update
    void Start()
    {
        maxHeight = 0;
  
        Edge.HalfWayEdge += OnMiddleEdgeCollision;


    }

    private void OnDestroy()
    {
        Edge.HalfWayEdge -= OnMiddleEdgeCollision;
    }

    private void OnMiddleEdgeCollision()
    {
        maxHeight += 20;

        var newEdge = Instantiate(
          edge,
          new Vector3(0, maxHeight, 0),
          Quaternion.identity,
          edgeContainer.transform
        );

        if (previousEdge == null)
        {
            previousEdge = initialEdge;
        }
        else
        {
            Destroy(previousEdge.gameObject);
            previousEdge = currentEdge;
        }
        currentEdge = newEdge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
