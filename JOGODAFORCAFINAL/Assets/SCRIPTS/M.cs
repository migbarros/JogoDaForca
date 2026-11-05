using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M : MonoBehaviour
{
  
    public TMP_InputField inputPalavra;
    

    public static string palavraEscolhida;

    public void IniciarJogo()
    {
        palavraEscolhida = inputPalavra.text;

        if (palavraEscolhida.Length == 0)
        {
            return;
        }

        SceneManager.LoadScene("JogoDaForca");
    }

}
