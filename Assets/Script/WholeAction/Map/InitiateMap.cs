using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class InitiateMap : MonoBehaviour
    {
        [ReadOnly(true)]
        public int mapW = 7;
        [ReadOnly(true)]
        public int mapH =7;
        [ReadOnly(true)]
        public bool isMoveRound = false;
        [ReadOnly(true)]
        public bool isRotateRound = false;

        public GameObject mapPre;
        public GameObject enemy;
        public Sprite barrierSprite;
        public Sprite barrierMoveTishi;
        public Sprite initiateSprite;

        private List<Transform> squareAssemble;
        private GameObject mapAssemble;
        private GameObject enemyAssemble;
        private List<AstarNote> pathList;
        private Sprite changeSprite;
        void Start ()
        {
            squareAssemble = new List<Transform>();
            mapAssemble = GameObject.Find("mapAssemble");
            enemyAssemble = GameObject.Find("enemyAssemble");

            AstarManager.GetInstance().InitMap(mapW, mapH);
            CreatSquare();
            GetPath();

            foreach (Transform t in mapAssemble.transform)
            {
                if (t != mapAssemble.transform)
                { squareAssemble.Add(t); }
            }
        }

        private void Update()
        {
            foreach (Transform square in squareAssemble)
            {
                changeSprite = null;
                if (ChargeStop(square))
                {
                   changeSprite = barrierSprite;
                }
                if(TransformNote(square).type==NoteType.initiate)
                {
                    changeSprite = initiateSprite;
                }
                MouseChoose.GetInstance().ChageSprite(square, changeSprite);
            }
            MoveBarrier();
        }

        void CreatSquare()
        {
            for (int i = 0; i < mapW; i++)
            {
                for (int j = 0; j < mapH; j++)
                {
                    GameObject mapSquare = Instantiate(mapPre);
                    mapSquare.transform.position = new Vector3(i + 0.1f * i, j + 0.1f * j, 0);
                    mapSquare.transform.SetParent(mapAssemble.transform, true);
                    mapSquare.name = i.ToSafeString() + "_" + j.ToSafeString();
                    mapSquare.tag = "MapSquare";
                }
            }
        }
        private void GetPath()
        {
            pathList =AstarManager.GetInstance().FindPath(new Vector2(3,2),new Vector2(1,5));
            for (int i = 0;i < pathList.Count;i++)
            {
                Debug.Log(pathList[i].x.ToString()+ pathList[i].y.ToString());
            }
        }
        public void InitiateEnemy(Vector2 enemyLocation)
        {
            int x = Mathf.FloorToInt(enemyLocation.x);
            int y = Mathf.FloorToInt(enemyLocation.y);
            GameObject mapLocation = GameObject.Find(x.ToString()+ y.ToString());
            GameObject enemyGameObject = Instantiate(enemy);
            enemyGameObject.transform.position = mapLocation.transform.position;
            enemyGameObject.transform.SetParent(enemyAssemble.transform, true);
            enemyGameObject.tag = "Enemy";
        }
         private AstarNote TransformNote(Transform square)
        {
            if (square == null) { return null; }
            else 
            {
                string[] squareName = square.gameObject.name.Split('_');
                int x = int.Parse(squareName[0]);
                int y = int.Parse(squareName[1]);
                return AstarManager.GetInstance().mapNotes[x, y];
            }
        }


        private void MoveBarrier()
        {
            Transform barrier = MouseChoose.GetInstance().GetHitTransform("MapSquare");
            if (barrier != null && ChargeStop(barrier))
            {
                ChooseMapSquare(barrier);
            }
        }
        private void ChooseMapSquare(Transform barrier)
        {
            foreach (Transform square in squareAssemble)
            {
                if (!ChargeStop(square)&& TransformNote(square).type!=NoteType.initiate && TransformNote(square).type != NoteType.luban)
                {
                    MouseChoose.GetInstance().ChageSprite(square, barrierMoveTishi);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Transform newBarrier = MouseChoose.GetInstance().GetHitTransform("MapSquare");
                Sprite newBarrierSprite = newBarrier.GetComponent<Sprite>();
                if (newBarrierSprite == barrierMoveTishi)
                {
                    TransformNote(newBarrier).type = NoteType.stop;
                    TransformNote(barrier).type = NoteType.walk;
                }
            }
        }

        private bool ChargeStop(Transform square)
        {
            if (TransformNote(square).type == NoteType.stop)
            { return true; }
            else { return false; }
        }
    }
}

