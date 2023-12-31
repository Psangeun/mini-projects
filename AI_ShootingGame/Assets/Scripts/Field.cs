using UnityEngine;
using System.Collections;


/*
 *	フィールド生成プログラム
 *	Maruchu
 */
public class Field : MonoBehaviour
{





    public GameObject m_blockObject = null;                 //ブロックのプレハブ

    public GameObject m_player1Object = null;                   //プレーヤー1のプレハブ
    public GameObject m_player2Object = null;                   //プレーヤー2のプレハブ




    public static readonly int FIELD_GRID_X = 15;                    //フィールドのXグリッド数
    public static readonly int FIELD_GRID_Y = 15;                    //フィールドのYグリッド数

    public static readonly float BLOCK_SCALE = 2.0f;                    //ブロックのスケール(ブロック1つ分のサイズ)
    public static readonly Vector3 BLOCK_OFFSET = new Vector3(1, 1, 1); //ブロックの配置オフセット



    //配置物の種類
    public enum ObjectKind
    {
        Empty       //	0	空欄
        , Block     //	1	ブロック
        , Player1   //	2	プレーヤー1
        , Player2   //	3	プレーヤー2
    }

    public static readonly int[] GRID_OBJECT_DATA = new int[] {			//配置データ
	//	0 が空欄、1 がブロック
	1,  1,  1,  1,  1,  1,  1,  1,  1, 1, 1, 1, 1, 1, 1,
    1,  2,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 3, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  0,  0,  1,  0,  0,  0,  1, 0, 0, 0, 1, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  1,  0,  0,  0,  1,  0,  0, 0, 1, 0, 0, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  1,  0,  0,  0,  1,  0,  0, 0, 1, 0, 0, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  0,  0,  0,  1,  0,  0,  0,  1, 0, 0, 0, 1, 0, 1,
    1,  0,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 0, 1,
    1,  3,  1,  0,  1,  0,  1,  0,  1, 0, 1, 0, 1, 3, 1,
    1,  1,  1,  1,  1,  1,  1,  1,  1, 1, 1, 1, 1, 1, 1,


	//配置するときに上下が逆になるので注意
};



    private GameObject m_blockParent = null;                    //生成したブロックの親用オブジェクト






    /*
     *	起動時に呼び出される関数
     */
    private void Awake()
    {

        //フィールドの初期化
        InitializeField();
    }



    /*
     *	フィールドの初期化
     *	配列変数を初期化して外壁と柱を作る
     */
    private void InitializeField()
    {

        //ブロックの親を作る
        m_blockParent = new GameObject();
        m_blockParent.name = "BlockParent";
        m_blockParent.transform.parent = transform;


        //ブロックを作る
        GameObject originalObject;      //生成するブロックの元となるオブジェクト
        GameObject instanceObject;      //ブロックをとりあえず入れておく変数
        Vector3 position;           //ブロックの生成位置


        //外枠と中に柱を立てていく
        int gridX;
        int gridY;
        for (gridX = 0; gridX < FIELD_GRID_X; gridX++)
        {
            for (gridY = 0; gridY < FIELD_GRID_Y; gridY++)
            {

                //この位置には何を置くか
                switch ((ObjectKind)GRID_OBJECT_DATA[gridX + (gridY * FIELD_GRID_X)])
                {
                    case ObjectKind.Block:
                        //壁
                        originalObject = m_blockObject;
                        break;
                    case ObjectKind.Player1:
                        //プレーヤー
                        originalObject = m_player1Object;
                        break;
                    case ObjectKind.Player2:
                        //プレーヤー
                        originalObject = m_player2Object;
                        break;
                    default:
                        //それ以外は空欄
                        originalObject = null;
                        break;
                }

                //空欄ならここまで
                if (null == originalObject)
                {
                    continue;
                }


                //ブロックの生成位置
                position = new Vector3(gridX * BLOCK_SCALE, 0, gridY * BLOCK_SCALE) + BLOCK_OFFSET;             //UnityではXZ平面が地平線

                //ブロック生成							複製する対象		生成位置		回転
                instanceObject = Instantiate(originalObject, position, originalObject.transform.rotation) as GameObject;
                //名前を変更
                instanceObject.name = "" + originalObject.name + "(" + gridX + "," + gridY + ")";       //グリッドの位置を書いておく

                //ローカルスケール(大きさ)を変更
                instanceObject.transform.localScale = (Vector3.one * BLOCK_SCALE);              //Vector3.one は new Vector3( 1f, 1f, 1f) と同じ

                //前述の親の下につける
                instanceObject.transform.parent = m_blockParent.transform;
            }
        }
    }






}
