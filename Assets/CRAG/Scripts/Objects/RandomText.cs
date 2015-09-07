using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CRAG
{
    public class RandomText : MonoBehaviour
    {
        [TextArea]
        public List<string> facts;
        public TextMesh text;

        public void OnDisplayFact()
        {
            string fact = facts[Random.Range(0, facts.Count - 1)];
            text.text = fact;
        }

        public void OffDisplayFact()
        {
            text.text = "";
        }
    }
}

