using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

public class JogoDaForca : MonoBehaviour
{
    public TMP_InputField inputLetra;
    public TMP_Text textoPalavra;
    public TMP_Text textoErros;
    public TMP_Text textoResultado;

    private string palavra;
    private HashSet<char> letrasCertas = new HashSet<char>();
    private int erros = 0;
    private int maxErros = 6;

    void Start()
    {
        palavra = M.palavraEscolhida.ToUpper();

        letrasCertas.Clear();
        erros = 0;

        AtualizarTela();
    }

    public void TentarLetra()
    {
        string entrada = inputLetra.text.Trim().ToUpper();

        if (entrada.Length != 1)
            return;

        char letra = entrada[0];

        if (letrasCertas.Contains(letra))
        {
            textoResultado.text = "Voce ja tentou essa letra!";
            inputLetra.text = "";
            return;
        }

        letrasCertas.Add(letra);

        if (!palavra.Contains(letra))
        {
            erros++;
            textoResultado.text = "Voce errou!";
        }
        else
        {
            textoResultado.text = "Voce acertou!";
        }

        inputLetra.text = "";

        AtualizarTela();

        if (erros >= maxErros)
        {
            textoResultado.text = "Voce perdeu! Palavra: " + palavra;
            inputLetra.interactable = false;
        }
        else if (VerificarVitoria())
        {
            textoResultado.text = "Parabens! Voce ganhou!";
            inputLetra.interactable = false;
        }
    }

    void AtualizarTela()
    {
        StringBuilder exibicao = new StringBuilder();

        foreach (char letra in palavra)
        {
            if (letrasCertas.Contains(letra))
                exibicao.Append(letra + " ");
            else
                exibicao.Append("_ ");
        }

        textoPalavra.text = exibicao.ToString();
        textoErros.text = "Erros: " + erros + "/" + maxErros;
    }

    bool VerificarVitoria()
    {
        foreach (char letra in palavra)
        {
            if (!letrasCertas.Contains(letra))
                return false;
        }

        return true;
    }
}
