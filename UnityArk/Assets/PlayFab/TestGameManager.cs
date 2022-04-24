using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

namespace PlayFabTesting
{
    public class TestGameManager : MonoBehaviour
    {
        [SerializeField] private Deflo.Deflo_PlayFabService _playFabSevice;
        [Space(15)]
        [Header("Login Panel")]
        [SerializeField] private GameObject _loginPanel;
        [Space(15)]
        [Header("Info Panel")]
        [SerializeField] private GameObject _userInfoPanel;
        [SerializeField] private TextMeshProUGUI _userIdLabel;
        [Space(5)]
        [Header("Items")]
        [SerializeField] private TextMeshProUGUI _itemsLabel;
        [SerializeField] private TextMeshProUGUI _swordBtnLabel;
        
        
        private LoginResult _loginResult;



        private void Start()
        { 
            HideAllPanels();
            _loginPanel.SetActive(true);
            Init();
        }

        private void Init()
        {
            // Playfab Account Login
            _playFabSevice.Init(OnServiceLoginSuccess, OnServiceLoginFailure);
        }

        private void HideAllPanels()
        {
            _userInfoPanel.SetActive(false);
            _loginPanel.SetActive(false);
        }

        private void OnPlayerLogin(LoginResult result)
        {
            HideAllPanels();
            Debug.Log($"Player Login successful");
            _loginResult = result;
            ShowUserInfoPanel();
        }

        private void OnServiceLoginFailure(PlayFabError result)
        {
            
        }

        private void OnServiceLoginSuccess(LoginResult result)
        {
           
        }

        private void ShowUserInfoPanel()
        {
            HideAllPanels();
            _userInfoPanel.SetActive(true);
            RefreshInfoPanel();
        }

        public void RefreshInfoPanel()
        {
            _userIdLabel.text = $"User Id: {_loginResult?.PlayFabId}. Just created: {_loginResult?.NewlyCreated}. Entity type: {_loginResult?.EntityToken.Entity.Type}";
            _itemsLabel.text = $"";
        }

        ///-------------------------------------------------
        /// Buttons 
        ///-------------------------------------------------
        public void OnPlayerLoginButtonPressed()
        {
            HideAllPanels();
            _playFabSevice.PlayerLogin(OnPlayerLogin);
        }

        public void OnUserInfoButtonPressed()
        {
            HideAllPanels();
            ShowUserInfoPanel();
        }

        public void OnBuySwordItemButtonPressed()
        {

            RefreshInfoPanel();
        }
    }
}
