namespace Whitehat.Grid
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Building : MonoBehaviour
    {
        public Hexagon hex;
        [SerializeField] private int initialRange;

        [SerializeField] private float distance = 2.5f;

        private List<Hexagon> lightenedUp = new List<Hexagon>();

        // Use this for initialization
        void Start()
        {
            LightUp(initialRange);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LightUp(int range)
        {
            foreach (RaycastHit hit in Physics.SphereCastAll(transform.position, distance * (range+1), Vector3.one))
            {
                if (Vector3.Distance(hit.collider.transform.position, transform.position) >= distance * (range+1))
                {
                    continue;
                }
                if (hit.collider.gameObject.GetComponent<Hexagon>())
                {
                    lightenedUp.Add(hit.collider.gameObject.GetComponent<Hexagon>());
                    hit.collider.gameObject.GetComponent<Hexagon>().AddLightingBuilding(this);
                    hit.collider.gameObject.GetComponent<Hexagon>().Visible = true;
                }
            }
        }

        public void ClearLightUp()
        {
            foreach(Hexagon hex in lightenedUp)
            {
                hex.RemoveLightingBuilding(this);
            }
            lightenedUp.Clear();
        }
    }
}