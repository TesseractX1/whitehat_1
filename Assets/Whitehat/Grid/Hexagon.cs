namespace Whitehat.Grid
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Hexagon : MonoBehaviour
    {
        [SerializeField] private Renderer renderers;
        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                renderers.gameObject.SetActive(value);
            }
        }
        private List<Building> lightingBuildings=new List<Building>();
        public void AddLightingBuilding(Building building) { lightingBuildings.Add(building); }
        public void RemoveLightingBuilding(Building building) { lightingBuildings.Remove(building); }

        public bool isCore;
        public Vector2 axis;
        public Building building;

        void Update()
        {
            Visible = lightingBuildings.Count > 0;
            if (visible)
            {
                renderers.gameObject.SetActive(GetComponent<Renderer>().isVisible);
            }
        }

        public void Build(GameObject buildingPrefab)
        {
          //  if (building) { return; }
            building = GameObject.Instantiate(buildingPrefab, transform).GetComponent<Building>();
            building.hex = this;
        }

        public void Empty()
        {
            if (!building) { return; }
            building.ClearLightUp();
            GameObject.Destroy(building.gameObject);
            building = null;
        }

        public void OnClick()
        {
            print("clicked");
        }

    }
}
