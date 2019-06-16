using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MidiJack
{
    public class MidiManager : MonoBehaviour
    {
        // キューブ群
        public GameObject[] meter;

        // 位置キャッシュ
        private Vector3[] _posList;

        // 8個のキューブに対応するノートナンバーを定義
        private int[] _noteNumberList = { 48, 50, 52, 53, 55, 57, 59, 60 };

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            // キューブ群の位置座標をキャッシュ
            _posList = meter.Select(cube => cube.transform.position).ToArray();
        }

        /// <summary>
        /// イベントループ 
        /// </summary>
        void Update()
        {
            for (int i = 0; i < meter.Length; i++)
            {
                // MIDIからノートナンバーに対応するKeyの出力を取得し、キューブのy座標に設定
                _posList[i].y = MidiMaster.GetKey(MidiChannel.Ch1, _noteNumberList[i]);

                // キューブ位置を更新
                meter[i].transform.position = _posList[i];
            }
        }
    }
}
