using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Construction : NetworkBehaviour {

    public Material translucentMaterial;
    public Collider terrainCollider;
    private ConstructionDB db;
    private ConstructionItem buildItem = null;
    private GameObject currentBuilding;


    void Start() {
        terrainCollider = GameObject.Find("Terrain").GetComponent<Collider>();
        db = GetComponent<ConstructionDB>();
        buildItem = db.buildings[0];
    }

    void Update() {
        if (buildItem != null)
        {

            if (currentBuilding == null)
            {
                currentBuilding = Instantiate(buildItem.prefab, Vector3.zero, Quaternion.identity);
                currentBuilding.GetComponentInChildren<Renderer>().material = translucentMaterial;
                currentBuilding.GetComponent<NetworkTransform>().sendInterval = .008f;
                CmdSpawnPreview(currentBuilding);
            }
            
            else
            {
                currentBuilding.transform.Rotate(Vector3.up, Input.GetAxis("Mouse ScrollWheel") * 10);

                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit floorHit;
                if (terrainCollider.Raycast(camRay, out floorHit, 1000))
                    currentBuilding.transform.position = floorHit.point;
            }
        }
    }

    [Command]
    void CmdSpawnPreview(GameObject building)
    {
        NetworkServer.SpawnWithClientAuthority(building, base.connectionToClient);
    }

    /*[ClientRpc]
    void RCPSpawnPreview(GameObject building)
    {
        building.GetComponentInChildren<Renderer>().material = translucentMaterial;
        building.GetComponent<NetworkTransform>().sendInterval = .008f;
    }

    [Command]
    void CmdSpawnBuilding(ConstructionItem item, GameObject preview, Vector3 position, Quaternion rotation)
    {
        GameObject building = Instantiate(buildItem.prefab, position, rotation);
        NetworkServer.Spawn(building);
        NetworkServer.Destroy(preview);
    }*/
}
