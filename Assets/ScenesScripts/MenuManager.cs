using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nameLevelGame;
    [SerializeField] private GameObject panelHomeMenu;
    [SerializeField] private GameObject panelOptions;


    public void NewGame() {
        SceneManager.LoadScene(nameLevelGame);
    }

    public void OpenOptions() {
        panelHomeMenu.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void CloseOptions() {
        panelOptions.SetActive(false);
        panelHomeMenu.SetActive(true);
    }

    public void Quit() {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
