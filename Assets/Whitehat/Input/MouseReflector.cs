﻿namespace Whitehat.Input
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Whitehat.Grid;

    public class MouseReflector : MonoBehaviour
    {
        public Camera mainCamera;
        public Hexagon mouseHex;

        [SerializeField]private SpriteRenderer mouseBuildingSprite;
        [SerializeField]private GameObject mouseBuildingPrefab;
        public void AssignBuildingPrefab(GameObject newPrefab) { mouseBuildingPrefab = newPrefab; }

        private RaycastHit hit;

        /* Use this for initialization
        void Start()
        {

        }*/

        // Update is called once per frame
        void Update()
        {
            if (Physics.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), mainCamera.transform.forward, out hit) && hit.collider.GetComponent<Hexagon>() && hit.collider.GetComponent<Hexagon>().Visible)
            {
                mouseHex = hit.collider.GetComponent<Hexagon>();

                if (Input.GetMouseButtonDown(0) && mouseBuildingPrefab && !mouseHex.building)
                {
                    mouseHex.Build(mouseBuildingPrefab);
                }

                if (Input.GetMouseButtonDown(1) && !mouseBuildingPrefab)
                {
                    mouseHex.Empty();
                }
                if(mouseHex.building){mouseBuildingSprite.color=Color.red;}else{mouseBuildingSprite.color=Color.white;}
                mouseBuildingSprite.enabled = true;
                mouseBuildingSprite.transform.parent = mouseHex.transform;
                mouseBuildingSprite.transform.localPosition = Vector3.zero;
            }
            else
            {
                mouseHex = null;
            }

            mouseBuildingSprite.sprite = mouseBuildingPrefab ? mouseBuildingPrefab.GetComponent<SpriteRenderer>().sprite : null;
        }
    }
}
