using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

namespace PlayFabTesting
{
    public class TestGameManager : MonoBehaviour
    {
        [SerializeField] private Deflo.Deflo_PlayFabService _playFabSevice;
        [SerializeField] private GameObject _loginPanel;
        [SerializeField] private GameObject _userInfoPanel;
        [SerializeField] private TextMeshProUGUI _userIdLabel;
        
        
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

        private void ShowUserInfoPanel()
        {
            HideAllPanels();
            _userInfoPanel.SetActive(true);
            _userIdLabel.text = 
                $"User Id: {_loginResult?.PlayFabId}\n" +
                $"Just created: {_loginResult?.NewlyCreated}";
        }
    }
}
