using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // 定数定義：壁方向
    public const int WALL_FRONT = 1;    // 前
    public const int WALL_RIGHT = 2;    // 右
    public const int WALL_BACK = 3;     // 後
    public const int WALL_LEFT = 4;     // 左

    public GameObject panelWalls;       // 壁全体

    public GameObject buttonMassage;        // ボタン：メッセージ
    public GameObject buttonMassageText;    // メッセージテキスト

    private int wallNo; // 現在の向いている方向

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;    // スタート時点では「前」を向く
    }

    // Update is called once per frame
    void Update()
    {

    }

    // メモをタップ
    public void PushButtonMemo()
    {
        DisplayMessage("エッフェル塔と書いてある。");
    }

    // メッセージをタップ
    public void PushButtonMessage()
    {
        buttonMassage.SetActive(false);     // メッセージを消す
    }

    // 右(>)ボタンを押した
    public void PushButtonRight()
    {
        wallNo++;   // 方向を1つ右に
        // 「左」の一つ右は「前」
        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }
        DisplayWall();  // 壁表示更新
    }

    // 左(<)ボタンを押した
    public void PushButtonLeft()
    {
        wallNo--;   // 方向を一つ左に
        // 「前」の一つ左は「左」
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }
        DisplayWall();  // 壁表示更新
    }

    // メッセージを表示
    void DisplayMessage(string mes)
    {
        buttonMassage.SetActive(true);
        buttonMassageText.GetComponent<Text>().text = mes;
    }

    // 向いている方向の壁を表示
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:    // 前
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:    // 右
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:     // 後
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT:     // 左
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }
}
