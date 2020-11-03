using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateShip : MonoBehaviour
{
    public GameObject UIControler;

    public GameObject[] cameras;
    public GameObject statsDisplayer;

    public GameObject[] ships;
    public GameObject node;


    /// <summary>
    /// Method to change player's ship and place new in it's place
    /// </summary>
    /// <param name="newShipID"> Just ID of new ship</param>
    /// <param name="oldShip"> Old ship that you're changing from</param>
    public void ChangeShip(int newShipID, GameObject oldShip)
    {
        GameObject newShip = Instantiate(ships[newShipID], oldShip.transform.position, oldShip.transform.rotation);
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
        Destroy(oldShip);
    }
    /// <summary>
    /// Method to change player's ship and place it not in place of old
    /// </summary>
    /// <param name="newShipID"> Just ID of new ship</param>
    /// <param name="oldShip"> Old ship that you're changing from</param>
    /// <param name="where"> If you want to place ship not in position of old one</param>
    public void ChangeShip(int newShipID, GameObject oldShip, Transform where)
    {
        GameObject newShip = Instantiate(ships[newShipID], where.position, where.rotation);
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
        Destroy(oldShip);
    }
    /// <summary>
    /// Function to give player a first ship
    /// </summary>
    /// <param name="shipID"> Just ID of new ship</param>
    /// <param name="where"> Coordinates where to put new ship</param>
    public void GivePlayerAShip(int shipID, Transform where)
    {
        GameObject newShip = Instantiate(ships[shipID], where.position, where.rotation);
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
    }
    /// <summary>
    /// Overload
    /// </summary>
    /// <param name="shipID"> Just ID of new ship</param>
    /// <param name="where"> Coordinates where to put new ship</param>
    public void GivePlayerAShip(int shipID, Vector3 whereP, Quaternion whereQ)
    {
        GameObject newShip = Instantiate(ships[shipID], whereP, whereQ);
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
    }
    /// <summary>
    /// Overload
    /// </summary>
    /// <param name="shipID"> Just ID of new ship</param>
    /// <param name="where"> Coordinates where to put new ship</param>
    public void GivePlayerAShip(int shipID, Vector3 whereP)
    {
        GameObject newShip = Instantiate(ships[shipID], whereP, new Quaternion(0,0,0,0));
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
    }
    public void GivePlayerAShipButton(int shipID)
    {
        Debug.Log("Harder daddy!");
        GivePlayerAShip(shipID, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
    }
    public void GiveRandomShipNP()
    {
        GameObject newShip = Instantiate(ships[Random.Range(0, ships.Length)], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        newShip.AddComponent<Player_Controler_v2>();

        UIControler.GetComponent<UIControler>().ChangeUIDisplayedTo(1);
        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].GetComponent<Camera_Movement>().objectToFollow = newShip.transform;
        }
    }
}
