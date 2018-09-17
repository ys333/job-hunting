using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DownObject : MonoBehaviour
{

    [SerializeField]
    appear_set m_appear;
    // 移動座標
    Vector2 nowPos;      //  開始位置
    Vector2 mvPos;      //  移動距離

    // タッチ移動
    Vector2 touchPos;   // タッチした位置
    Vector2 firstPos;   // タッチした時の初期位置

    // 配列座標
    Vector2 r_num;      // 右座標
    Vector2 l_num;      // 左座標

    // 時間
    float downtime = 0;     // 落下時間
    float movetime = 0;     // 移動時間

    float m_time = 0;

    float stpx = 0.988f;     // 初期位置X座標
    float stpy = 4f;     // 初期位置Y座標

    float touch_time = 0.0f;

    int hum_num;    // ランダム生成された番号保持
    int[,] array;   // マップ管理座標
    Dictionary<string, GameObject> obj_list;
    Camera camera = null;

    bool first_touch;
    bool seisei;
    bool next_touch;
    bool SoundEfect;
    bool is_move;
    bool is_humberger_appear;
    bool GameStart;
    bool StopTime;
    bool Material_food;

    MapMove mapmove;
    GameObject MapArray;
    GameObject DW_object;
    GameObject meat;        // 生成したHMのprefabが入っている

    HM hum_material;                    // 生成する食材の種類
    string prefab_name;                 // 生成する食材の名前

    string Sound_Name;                  // 鳴らす音の名前
    public AudioClip Move_Efect;        // 移動音
    public AudioClip Stop_Efect;        // 落ちて止まった時
    public AudioClip Create_Efect;      // 完成した時
    public AudioClip comp_Efect;        // 完成音
    public AudioClip Set_Efect;         // カウントダウンSET
    public AudioClip Start_Efect;       // 開始音

    AudioClip Sound_Efect;              // 実際に鳴らすやつ
    AudioSource[] A_Source;             // AudioSourceを複数確保したい

    public GameObject MenuSelect;

    public Sprite m_pan_top;
    public Sprite m_pan_btm;

    public Text GameScore;

    // これ後でけす 
    string debug_array;

    //---------------------------------------------------------------------------------------
    // エンジンコールバック
    //---------------------------------------------------------------------------------------

    // Use this for initialization
    void Start()
    {

        #region 移動距離/初期座標

        float mvpx = 0.494f;
        float mvpy = 0.5f;
        mvPos = new Vector2(mvpx, mvpy);

        #endregion

        // 配列生成
        InitializeArray();

        touch_time = 0.0f;

        first_touch = false;
        seisei = true;
        next_touch = false;
        is_move = false;
        is_humberger_appear = false;
        StopTime = false;
        Material_food = true;

        // A_SourceにAudioSourceを入れる
        A_Source = gameObject.GetComponents<AudioSource>();


    }



    void Awake()
    {
        #region Find/配列

        // カメラ取得
        camera = Camera.main;

        r_num = new Vector2(-1, -1);
        l_num = new Vector2(-1, -1);
        obj_list = new Dictionary<string, GameObject>();

        #endregion

        // ゲーム開始前のカウントダウン
        GameStart = false;
        if (GameStart == false)
        {
            StartCoroutine(StartCountDown());
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            if (Time.timeScale == 1)
            {
                m_time += Time.deltaTime;
                DebugArray();

                if (is_humberger_appear) { return; }

                downtime += Time.deltaTime;
                movetime += Time.deltaTime;

                // 次の場所の配列のやつ
                int nrx = (int)r_num.x;
                int nlx = (int)l_num.x;
                int nry = (int)r_num.y + 1;
                int nly = (int)l_num.y + 1;
                
                if (Material_food)
                {
                    // ランダムで数字を生成
                    int num = Random.Range(1, 100);

                    // 数字をGameNumRetentionに渡して、どの種類の素材なのかを確認する
                    hum_material = GameNumRetention.Instance.GetHumberMaterial(num);

                    // 上の素材情報をもとに、ロードするパスデータを取得する
                    prefab_name = GameNumRetention.Instance.GetHumberString(hum_material);

                    Image Next_image = GameObject.Find("Canvas/NextMaterial").GetComponent<Image>();

                    Next_image.sprite = Resources.Load("Sprite/HumburgerMaterial/" + prefab_name, typeof(Sprite)) as Sprite;

                    Material_food = false;
                }
                #region 生成/完成関係
                // 生成のやつ
                if (array[0, 7] == (int)HM.NONE && array[0, 8] == (int)HM.NONE && seisei == true)
                {
                    // ハンバーガー完成確認
                    for (int tate = array.GetLength(0) - 1; tate >= 0; tate--)
                    {
                        for (int yoko = 0; yoko < array.GetLength(1); yoko++)
                        {
                            //Debug.Log("YOKO:" + yoko + " TATE:" + tate);
                            // 下のパン以外だったらcontinue
                            if (array[tate, yoko] != (int)HM.PAN_BTM) { continue; }

                            // ハンバーガーの種類分チェック
                            for (int HM_type = 0; HM_type < (int)HT.NUM; HM_type++)
                            {
                                HM[] hum = GameNumRetention.Instance.GetHumburgerInfo((HT)HM_type);

                                // エラーチェック
                                if (hum == null) { continue; }

                                int tate_check_end = tate - hum.Length;
                                if (tate_check_end < 0) { tate_check_end = 0; }
                                bool is_created = false;
                                int check_count = 0;

                                // ここから上にチェック
                                for (int tate_check = tate; tate_check > tate_check_end; tate_check--)
                                {
                                    // マップ配列とハンバーガー種類配列が同じだったら
                                    if (array[tate_check, yoko] == (int)hum[hum.Length - 1 - (tate - tate_check)] &&
                                        array[tate_check, yoko + 1] == (int)hum[hum.Length - 1 - (tate - tate_check)])
                                    {
                                        check_count++;
                                        // ハンバーガーの素材数分 確認できたら
                                        if (check_count == hum.Length)
                                        {
                                            // 処理
                                            Debug.Log("完成");
                                            is_created = true;
                                        }
                                    }
                                }

                                // 完成していたら
                                if (is_created)
                                {

                                    // 上にチェックしながら消していく
                                    for (int tate_check = tate; tate_check > tate_check_end; tate_check--)
                                    {
                                        // 配列の中の情報を消す
                                        array[tate_check, yoko] = (int)HM.NONE;
                                        array[tate_check, yoko + 1] = (int)HM.NONE;

                                        // keyをさくせいしてゲームオブジェクトをDictionaryから検索
                                        string key = tate_check.ToString() + yoko.ToString();
                                        GameObject ret = null;
                                        obj_list.TryGetValue(key, out ret);


                                        // retにゲームオブジェクトが帰ってきたら削除
                                        if (ret != null)
                                        {
                                            obj_list.Remove(key);
                                            Destroy(ret);

                                        }
                                    }

                                    // スコア取得
                                    int create_score = GameNumRetention.Instance.GetHumbergerScore((HT)HM_type);
                                    // スコアを加算
                                    GameNumRetention.Instance.AddScore(create_score);
                                    // 使用したハンバーガーを加算
                                    GameNumRetention.Instance.AddHumbergerCount((HT)HM_type, 1);
                                    Debug.Log(GameNumRetention.Instance.GetScore());

                                    Vector2 point = new Vector2(stpx - mvPos.x * 7, 4);

                                    is_humberger_appear = true;
                                    appear_set.CallFunc first = () =>
                                    {
                                        Sound_Efect = comp_Efect;
                                        SoundEfect = true; SoundEfelctPlay();
                                    };
                                    appear_set.CallFunc call = () => { is_humberger_appear = false; };
                                    m_appear.SetAppearHumberger((HT)HM_type, new Vector2(point.x + yoko * mvPos.x, point.y - (tate - ((tate - tate_check_end) / 2.0f)) * mvPos.y), first, call);

                                    // スコアを取得して表示
                                    GameScore.text = "" + GameNumRetention.Instance.GetScore();

                                }
                            }
                        }
                    }
                    #endregion


                    // ブロック作る（instanciate)
                    meat = Instantiate(Resources.Load("Prefab/" + prefab_name, typeof(GameObject)),
                        new Vector2(stpx, stpy), Quaternion.identity) as GameObject;

                    Material_food = true;

                    //ブロックやつ
                    DW_object = meat;
                    DW_object.transform.position = new Vector2(stpx, stpy);

                    hum_num = (int)hum_material; // meat とかバンズとか番号

                    // 座標を計算
                    array[0, 7] = hum_num; // l_num
                    array[0, 8] = hum_num; // r_num
                    l_num.x = 7; l_num.y = 0;
                    r_num.x = 8; r_num.y = 0;

                    nrx = (int)r_num.x;
                    nlx = (int)l_num.x;
                    nry = (int)r_num.y + 1;
                    nly = (int)l_num.y + 1;

                    seisei = false;

                    // もしタッチがされているなら、連続で物体移動を有効にしないようにnext_touchを無効にする
                    if (!first_touch) { next_touch = false; }

                    nowPos = DW_object.transform.position;

                }
                // 配列の移動やつとブロックの移動やつ
                else if (downtime > 2)
                {
                    // 移動できた場合
                    if (array[nly, nlx] == (int)HM.NONE && array[nry, nrx] == (int)HM.NONE)
                    {
                        SetNextPoint(nrx, nry, nlx, nly);
                        nry = (int)r_num.y + 1;
                        nly = (int)l_num.y + 1;

                        Sound_Efect = Move_Efect;
                        SoundEfect = true;
                    }

                    // どちらかにオブジェクトがあるので、移動できない場合
                    if (array[nly, nlx] != (int)HM.NONE || array[nry, nrx] != (int)HM.NONE)
                    {
                        AddStaticObjectList(l_num);

                        l_num = new Vector2(-1, -1);
                        r_num = new Vector2(-1, -1);

                        Sound_Efect = Stop_Efect;
                        SoundEfect = true;

                        seisei = true;
                    }
                }

                // 生成地点にブロックがあったら ゲームオーバー
                if (array[0, 7] != (int)HM.NONE && array[0, 8] != (int)HM.NONE && seisei == true)
                {
                    SceneManager.LoadScene("Result");
                    GameNumRetention.Instance.SetTimeNum(m_time);
                }

                #region 移動系
                // とりまマウスで操作
                if (Input.GetMouseButton(0) && next_touch && !seisei)
                {
                    touch_time += Time.deltaTime;

                    touchPos = camera.ScreenToWorldPoint(Input.mousePosition);
                    if (first_touch == true)
                    {
                        firstPos = touchPos;
                        first_touch = false;
                        is_move = false;
                    }

                    // とりま左移動
                    if (nlx - 1 >= 0 && firstPos.x > touchPos.x + 1 && movetime > 0.1f && array[(int)l_num.y, nlx - 1] == (int)HM.NONE)
                    {
                        array[(int)l_num.y, (int)l_num.x - 1] = hum_num;
                        array[(int)r_num.y, (int)r_num.x] = (int)HM.NONE;

                        l_num.x -= 1;
                        r_num.x -= 1;

                        nowPos.x -= mvPos.x;
                        movetime = 0f;

                        Sound_Efect = Move_Efect;
                        SoundEfect = true;

                        is_move = true;

                    }
                    // 逆に右移動
                    else if (nrx + 1 < array.GetLength(1) && firstPos.x < touchPos.x - 1 && movetime > 0.1f && array[(int)r_num.y, nrx + 1] == (int)HM.NONE)
                    {
                        array[(int)r_num.y, (int)r_num.x + 1] = hum_num;
                        array[(int)l_num.y, (int)l_num.x] = (int)HM.NONE;

                        l_num.x += 1;
                        r_num.x += 1;

                        nowPos.x += mvPos.x;
                        movetime = 0f;

                        Sound_Efect = Move_Efect;
                        SoundEfect = true;

                        is_move = true;
                    }

                    // 下に落ちる系
                    else if (firstPos.y > touchPos.y + 1 && array[nly, nlx] == (int)HM.NONE && array[nry, nrx] == (int)HM.NONE)
                    {
                        SetNextPoint(nrx, nry, nlx, nly);
                        nry = (int)r_num.y + 1;
                        nly = (int)l_num.y + 1;

                        is_move = true;

                        // 次の位置をチェックしてあげて、何かしらのオブジェクトがあるなら生成モードへ
                        if (array[nly, nlx] != (int)HM.NONE || array[nry, nrx] != (int)HM.NONE)
                        {
                            AddStaticObjectList(l_num);

                            l_num = new Vector2(-1, -1);
                            r_num = new Vector2(-1, -1);

                            Sound_Efect = Stop_Efect;
                            SoundEfect = true;

                            seisei = true;
                        }
                    }

                    DW_object.transform.position = nowPos;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    // 0.5秒以下
                    if (touch_time < 0.3f && next_touch && !is_move)
                    {
                        ChangePanType();
                    }

                    first_touch = true;
                    next_touch = true;
                    touch_time = 0.0f;
                }

                SoundEfelctPlay();
                #endregion
            }
        }
    }


    //---------------------------------------------------------------------------------------
    // 自作関数
    //---------------------------------------------------------------------------------------

    //++++++++++++++++++++++++++++++++
    //  アレイデータ作成
    public void InitializeArray()
    {
        // int[19,14]
        array = new int[19, 12]
        {
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
        };

        //ぶちこんでる 壁ね
        for (int i = 0; i < array.GetLength(0); i++)
        {
            array[i, 0] = (int)HM.WALL;
            array[i, array.GetLength(1) - 1] = (int)HM.WALL;
        }
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[array.GetLength(0) - 1, j] = (int)HM.WALL;
        }

        DebugArray();
    }

    //++++++++++++++++++++++++++++++++
    // 次の位置を設定
    void SetNextPoint(int _nrx, int _nry, int _nlx, int _nly)
    {
        nowPos.y -= mvPos.y;
        DW_object.transform.position = nowPos;
        downtime = 0f;

        array[_nly, _nlx] = hum_num;
        array[_nry, _nrx] = hum_num;
        array[(int)l_num.y, (int)l_num.x] = (int)HM.NONE;
        array[(int)r_num.y, (int)r_num.x] = (int)HM.NONE;

        r_num.y = _nry;
        l_num.y = _nly;
    }

    //++++++++++++++++++++++++++++++++
    //　動かなくなった奴はリストに追加
    void AddStaticObjectList(Vector2 _lpos)
    {
        string key = _lpos.y.ToString("f0") + _lpos.x.ToString("f0");
        obj_list.Add(key, DW_object);
    }

    //++++++++++++++++++++++++++++++++
    // S_Efect再生
    void SoundEfelctPlay()
    {
        if (SoundEfect && Sound_Efect != null)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(Sound_Efect);
            SoundEfect = false;
            Sound_Efect = null;
        }
    }

    //++++++++++++++++++++++++++++++++
    // パンのタイプチェンジ
    void ChangePanType()
    {
        // DW_objectが存在する
        if (DW_object)
        {
            // パンの切り替え(上下)
            if (hum_num == (int)HM.PAN_TOP)
            {
                hum_num = (int)HM.PAN_BTM;
                SpriteRenderer sr = DW_object.GetComponent<SpriteRenderer>();
                if (sr) { sr.sprite = m_pan_btm; }

                array[(int)l_num.y, (int)l_num.x] = hum_num;

                Sound_Efect = Create_Efect;
                SoundEfect = true;
            }
            else if (hum_num == (int)HM.PAN_BTM)
            {
                hum_num = (int)HM.PAN_TOP;
                SpriteRenderer sr = DW_object.GetComponent<SpriteRenderer>();
                if (sr) { sr.sprite = m_pan_top; }

                array[(int)r_num.y, (int)r_num.x] = hum_num;

                Sound_Efect = Create_Efect;
                SoundEfect = true;
            }
        }
    }

    //++++++++++++++++++++++++++++++++
    // これ後でけす DebugArrayぜんぶ
    void DebugArray()
    {
        debug_array = "";
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                debug_array += (array[i, j] >= 0) ? (array[i, j].ToString("D2") + ":") : (array[i, j].ToString() + ":");
            }
            debug_array += "\n";
        }
        //Debug.Log(debug_array);
    }

    //++++++++++++++++++++++++++++++++
    // 
    IEnumerator AppearHumberger()
    {


        yield return null;
    }

    IEnumerator StartCountDown()
    {
        // Canvas内のカウントダウンオブジェクトを取得
        Image Count = GameObject.Find("Canvas/CountDown").GetComponent<Image>();
        
        // CountのSpriteを変更している
        Count.sprite = Resources.Load("Sprite/GameScene/CountDown_3", typeof(Sprite)) as Sprite;
        Sound_Efect = Set_Efect;
        SoundEfect = true;
        SoundEfelctPlay();
        // 1秒待機
        yield return new WaitForSeconds(1.0f);
        Sound_Efect = Set_Efect;
        SoundEfect = true;
        SoundEfelctPlay();
        Count.sprite = Resources.Load("Sprite/GameScene/CountDown_2", typeof(Sprite)) as Sprite;

        yield return new WaitForSeconds(1.0f);
        Sound_Efect = Set_Efect;
        SoundEfect = true;
        SoundEfelctPlay();
        Count.sprite = Resources.Load("Sprite/GameScene/CountDown_1", typeof(Sprite)) as Sprite;

        yield return new WaitForSeconds(1.0f);
        Sound_Efect = Start_Efect;
        SoundEfect = true;
        SoundEfelctPlay();
        Count.sprite = Resources.Load("Sprite/GameScene/CountDown_Start", typeof(Sprite)) as Sprite;

        yield return new WaitForSeconds(1.0f);

        Destroy(Count);
        GameStart = true;
        A_Source[1].Play();
    }

    public void PauseButton() // ポーズボタン
    {
        if (GameStart)
        {

            // 押すとポーズなる
            if (!StopTime)
            {
                Time.timeScale = 0;
                MenuSelect.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                MenuSelect.SetActive(false);
            }
            // フラグを反転してる
            StopTime = !StopTime;
        }
    }

    // ポーズ中のリトライボタン
    public void RetryButton()
    {
        StopTime = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game_Scene");
    }


    // ポーズ中のホームバックボタン
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}



//http://qiita.com/pilkul/items/e8864882b3f7e59b05e3
//ここフリック操作別のやつ
