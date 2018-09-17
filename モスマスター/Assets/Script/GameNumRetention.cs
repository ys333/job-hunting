//using Mono.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HT             // HUMBERGER_TYPE
{
    TERI    = 0,    // テリヤキバーガー
    MOS     = 1,    // モスバーガー,
    DOUBLE  = 2,    // ダブルハンバーガー
    CHEESE  = 3,    // チーズバーガー
    //TERI_C  = 4,    // テリヤキチキンバーガー
    MOS_C   = 4,    // モスチーズバーガー
    //EBI     = 6,    // エビカツバーガー
    //FISH    = 7,    // フィッシュバーガー
    HUM     = 5,    //  ハンバーガー
    //SDACC   = 9,    //  スパイシーダブルアボガドチリチーズバーガー
    NUM     = 6,   // 合計
    NONE    = 999,  // なし
}

public enum HM             // HUMBERGER_MATERIAL
{
    WALL        = -2,       //  壁
    NONE        = -1,  // 空
    PAN_TOP     = 0,   // 上用パン
    PAN_BTM     = 1,   // 下用パン
    HUM_N       = 2,   // ハンバーグ(通常)
    //HUM_C       = 3,   // ハンバーグ(チキン)
    //HUM_F       = 4,   // ハンバーグ(魚肉)
    //HUM_E       = 5,   // ハンバーグ(エビ)
    LETTUCE     = 3,   // レタス
    TOMATO      = 4,   // トマト
    //ABOCADO     = 8,  // アボガド
    //CABBAGE     = 9,  // キャベツ
    CHEESE      = 5,  // チーズ
    HERA        = 6,  // ヘラ
    NUM         = 7,  // 合計
}

public struct HM_PER
{
    public int btm;
    public int top;

    public HM_PER(int _btm,int _top)
    {
        btm = _btm;
        top = _top;
    }
}

public class GameNumRetention{

    //++++++++++++++++++++++++++++++++++++++++
    // クラス変数
    //++++++++++++++++++++++++++++++++++++++++

    static GameNumRetention m_instance; // 静的変数1度作成されたら残り続ける

    int m_score;            // 点数
    float m_time;           // 時間
    int[] m_HUM_type_cnt;   // ハンバーガーの種類毎のカウンター
    HM_PER[] m_HUM_PER_list;// パーセンテージ割合
    string[] m_HUM_PASS_list;// Instantiateに渡すPASS


    // スコア配列データ
    ReadOnlyCollection<int> m_HUM_type_score = new ReadOnlyCollection<int>(
        new int[]{
            360,    // TERI   
            370,    // MOS    
            340,    // DOUBLE 
            250,    // CHEESE 
            //360,    // TERI_C 
            400,    // MOS_C  
            //390,    // EBI    
            //340,    // FISH   
            220 }    // HUM    
            //630 }   // SDACC  
        );

    // ハンバーガー種類データ(コンストラクタで情報格納)
    Dictionary<HT, HM[]> m_HUM_type_info;

    // コンストラクタ(クラスが生成されるときに呼び出される)
    GameNumRetention()
    {
        m_score = 0;
        m_time = 0;
        m_HUM_type_cnt = new int[(int)HT.NUM];

        // ハンバーガーの情報追加（時間ないのでここでつっこむ)
        // ほんとはデータとか準備したいんすけどね
        HM[] TERI   = { HM.PAN_TOP, HM.LETTUCE, HM.HUM_N, HM.PAN_BTM };
        HM[] MOS    = { HM.PAN_TOP, HM.TOMATO, HM.HUM_N, HM.PAN_BTM };
        HM[] DOUBLE = { HM.PAN_TOP, HM.HUM_N, HM.HUM_N, HM.PAN_BTM };
        HM[] CHEESE = { HM.PAN_TOP, HM.CHEESE, HM.HUM_N, HM.PAN_BTM };
        //HM[] TERI_C = { HM.PAN_TOP, HM.LETTUCE, HM.HUM_C, HM.PAN_BTM };
        HM[] MOS_C  = { HM.PAN_TOP, HM.TOMATO, HM.CHEESE, HM.HUM_N, HM.PAN_BTM };
        //HM[] EBI    = { HM.PAN_TOP, HM.CABBAGE, HM.HUM_E, HM.PAN_BTM };
        //HM[] FISH   = { HM.PAN_TOP, HM.HUM_F, HM.CHEESE, HM.PAN_BTM };
        HM[] HUM    = { HM.PAN_TOP, HM.HUM_N, HM.PAN_BTM };
        //HM[] SDACC  = { HM.PAN_TOP, HM.ABOCADO, HM.TOMATO, HM.LETTUCE, HM.CHEESE, HM.HUM_N, HM.HUM_N, HM.PAN_BTM };

        // 辞書に検索キー＋情報用の配列情報を追加
        m_HUM_type_info = new Dictionary<HT, HM[]>();
        m_HUM_type_info.Add(HT.TERI, TERI);
        m_HUM_type_info.Add(HT.MOS, MOS);
        m_HUM_type_info.Add(HT.DOUBLE, DOUBLE);
        m_HUM_type_info.Add(HT.CHEESE, CHEESE);
        //m_HUM_type_info.Add(HT.TERI_C, TERI_C);
        m_HUM_type_info.Add(HT.MOS_C, MOS_C);
        //m_HUM_type_info.Add(HT.EBI, EBI);
        //m_HUM_type_info.Add(HT.FISH, FISH);
        m_HUM_type_info.Add(HT.HUM , HUM);
        //m_HUM_type_info.Add(HT.SDACC, SDACC);

        // 生成するためのRandomRangeを持ってきて数値ごとに素材へ分けてる
        m_HUM_PER_list = new HM_PER[(int)HM.NUM];
        m_HUM_PER_list[(int)HM.PAN_TOP] = new HM_PER(1, 25);
        m_HUM_PER_list[(int)HM.PAN_BTM] = new HM_PER(26, 40);
        m_HUM_PER_list[(int)HM.HUM_N] = new HM_PER(41, 70);
        //m_HUM_PER_list[(int)HM.HUM_C] = new HM_PER(49, 57);
        //m_HUM_PER_list[(int)HM.HUM_F] = new HM_PER(58, 62);
       // m_HUM_PER_list[(int)HM.HUM_E] = new HM_PER(63, 68);
        m_HUM_PER_list[(int)HM.LETTUCE] = new HM_PER(71, 80);
        m_HUM_PER_list[(int)HM.TOMATO] = new HM_PER(81, 90);
        //m_HUM_PER_list[(int)HM.ABOCADO] = new HM_PER(83, 86);
        //m_HUM_PER_list[(int)HM.CABBAGE] = new HM_PER(87, 91);
        m_HUM_PER_list[(int)HM.CHEESE] = new HM_PER(91, 100);

        // 上で決めた素材の名前を返すためのやつ
        m_HUM_PASS_list = new string[(int)HM.NUM];
        m_HUM_PASS_list[(int)HM.PAN_TOP] = "TopBread";
        m_HUM_PASS_list[(int)HM.PAN_BTM] = "BottomBread";
        m_HUM_PASS_list[(int)HM.HUM_N] = "meat";
        //m_HUM_PASS_list[(int)HM.HUM_C] = "Chicken";
        //m_HUM_PASS_list[(int)HM.HUM_F] = "Fish";
        //m_HUM_PASS_list[(int)HM.HUM_E] = "ShrimpCutlet";
        m_HUM_PASS_list[(int)HM.LETTUCE] = "Lettuce";
        m_HUM_PASS_list[(int)HM.TOMATO] = "Tomato";
        //m_HUM_PASS_list[(int)HM.ABOCADO] = "Avocado";
        //m_HUM_PASS_list[(int)HM.CABBAGE] = "Cabbage";
        m_HUM_PASS_list[(int)HM.CHEESE] = "Cheese";



    }

    //++++++++++++++++++++++++++++++++++++++++
    // プロパティ
    //++++++++++++++++++++++++++++++++++++++++

    //  基本的にはこのInstanceを経由してアクセスする
    public static GameNumRetention Instance
    {
        // ゲッター
        get
        {  
            // インスタンスがない場合は1度だけ新規作成
            if(m_instance == null)
            {
                m_instance = new GameNumRetention();
            }
            return m_instance;
        }
    }

    //++++++++++++++++++++++++++++++++++++++++
    // クラス関数
    //++++++++++++++++++++++++++++++++++++++++

    // スコア取得
    public int GetScore() { return m_score; }

    // スコア加算
    public void AddScore(int _add) { m_score += _add; }

    // スコアリセット
    public void ResetScore() { m_score = 0; }

    //---------------------------------------

    // 時間設定
    public void SetTimeNum(float _time) { m_time = _time; }

    // 時間のリセット
    public void ResetTimeNum() { m_time = 0; }

    // 時間取得
    public float GetTimeNum() { return m_time; }

    //---------------------------------------

    // ハンバーガーのマテリアルデータ取得（ランダムな１～１００の数字から）
    public HM GetHumberMaterial(int _num)
    {
        int num = -1;
        for(int i = 0; i < (int)HM.NUM; i++)
        {
            HM_PER temp = m_HUM_PER_list[i];
            if(temp.btm <= _num && temp.top >= _num)
            {
                num = i;
                break;
            }
        }

        return (HM)num;
    }

    public string GetHumberString(HM num)
    {
        string Material_name = m_HUM_PASS_list[(int)num];

        return Material_name;
    }


    // ハンバーガータイプ取得
    public HM[] GetHumburgerInfo(HT _type)
    {
        HM[] temp;
        if(!m_HUM_type_info.TryGetValue(_type, out temp))
        {
            temp = null;
        }

        
        return temp;
    }

    // ハンバーガーカウント加算
    public void AddHumbergerCount(HT _type, int _count)
    {
        m_HUM_type_cnt[(int)_type] += _count;
    }

    // ハンバーガーカウント初期化
    public void ResetHumbergerCount()
    {
        for(int i = 0; i < m_HUM_type_cnt.Length; i++)
        {
            m_HUM_type_cnt[i] = 0;
        }
    }

    // ハンバーガーカウント取得
    public int GetHumbergerCount(HT _type)
    {
        return m_HUM_type_cnt[(int)_type];
    }

    // 最大個数のハンバーガータイプを取得
    public HT GetMaximumHumbergerType()
    {
        int ret = (int)HT.NONE;
        int max = 0;
        for(int i = 0; i < m_HUM_type_cnt.Length; i++)
        {
            if(max <= m_HUM_type_cnt[i])
            {
                max = m_HUM_type_cnt[i];
                ret = i;
            }
        }

        return (HT)ret;
    }

    // ハンバーガータイプ毎のスコア取得
    public int GetHumbergerScore(HT _type)
    {
        return m_HUM_type_score[(int)_type];
    }

    //---------------------------------------
}
