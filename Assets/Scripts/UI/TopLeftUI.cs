﻿using UnityEngine;
using UnityEngine.UI;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.UI
{
    public class TopLeftUI : BaseUI, IHealthBar
    {
        [SerializeField] private Text _text;
        [SerializeField] private Slider _slider;

        private DataPlayer _dataPlayer;

        public override void Execute()
        {
            //_text.text = nameof(TopLeftUI);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        public override void GetPlayerData(DataPlayer dataPlayer)
        {
            _dataPlayer = dataPlayer;
        }
        public override void CheckHealth()
        {
            _slider.value = _dataPlayer.PlayerGO.GetComponent<PlayerView>().GetHealth().CurrentHP;
        }
    }
}
