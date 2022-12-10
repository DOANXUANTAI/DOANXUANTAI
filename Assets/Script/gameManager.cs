using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private static gameManager _instances;
    public static gameManager Instances => _instances;
    [field: SerializeField] public storage storage { private set; get; }
    [SerializeField] MouseFollowMethod _mouse;
    [SerializeField] gridSystem _grid;
    [SerializeField] cameraFollow _camera;
    private BoundsInt preveArae;
    [SerializeField] menuController controller;
    [SerializeField] constructionEnemy _constructionEnemy;
    private bool isWin = false;
    [SerializeField] GameObject menuWin;
    [SerializeField] AudioManager AU;
private void Awake()
    {
        Time.timeScale = 1;
        if (_instances != this && _instances != null)
        {


            Destroy(this);
                
                }
        else
        {


            _instances = this;

        }

        storage.InitialStorage();

        controller.Head.onReady();

        foreach (var item in storage.returnList())
        {


            controller.Head.changeValues(item.Key, item.Value.ToString());


        }
        controller.MenuCreate();
        _constructionEnemy.createEnemy();

        //AU.playSource("groundMusic");
    }



    private void Update()
    {


        if (isWin)
        {

            Time.timeScale = 0;
            menuWin.gameObject.SetActive(true);
            return;

        }



        if (_mouse.gameObject.activeSelf)
        {
            if (!_grid.gameObject.activeSelf)
            {

                _grid.gameObject.SetActive(true);

            }
          
            if (Input.GetMouseButton(0))
            {
                _grid.clear(preveArae);
                Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _mouse.moveMouse(position);
                _mouse.setArea();
              
                _grid.followBuilding(_mouse.getArea());
                preveArae = _mouse.getArea();
            }

            return;

        }
        if (_grid.gameObject.activeSelf)
        {

            _grid.gameObject.SetActive(false);

        }

            _camera.moveCamera();

  
        
    }

    public void checkConstruction()
    {// kiem tra xem win hay chua

        isWin = (_constructionEnemy.getNumber()==0)? true: false;


    }

    public void updateStorage(List< MaterialIO > material ,List<int> number)
    {
        // cap nhat lai du lieu cho header


        storage.returnMaterial(material, number);

        foreach (var item in storage.returnList())
        {


            controller.Head.changeValues(item.Key, item.Value.ToString());


        }

    }

}
