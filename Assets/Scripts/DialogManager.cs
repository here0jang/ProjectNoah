using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    Dictionary<int, string[]> talkData;
    public TMPro.TextMeshProUGUI dialogText;
    public GameObject AI;

    public Image FadeImage;
    public GameObject Fade;
    private int i = 0;

    public Image AIIcon;

    void Awake()
    {
        dialogManager = this;
        talkData = new Dictionary<int, string[]>(); // int : �� ������Ʈ�� ID
        GenerateData();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine()
    {
        Color color = AIIcon.GetComponent<Image>().color;
        color.a = 0f;
        AIIcon.GetComponent<Image>().color = color;

        Color Fadecolor = FadeImage.GetComponent<Image>().color;
        Fadecolor.a = 1f;
        while (Fadecolor.a>=0)
        {
            Fadecolor.a -= 0.005f;
            FadeImage.GetComponent<Image>().color = Fadecolor;
            yield return new WaitForSeconds(0.005f);
        }
        Fade.SetActive(false);
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "AI �ý��� ����� �Ϸ�",
            "�Ŵ��� ������ ��ε�", "���ּ� �ý��� �翬��", "��", 
            "���ּ� ���� ���� �ƴϱ���.", "�ٽ� �λ� �帳�ϴ�, �÷��̾�.", "���ô�� AI�� �ֿ켱���� ������ ���� ���ϼ̽��ϴ�.",
        "���� ��� ���� �� �������� ���� ���Դϴ�.", "�÷��̾�, �����ε� �� ���� �� ���� �ֽñ� �ٶ��ϴ�.", "���� ����� ������������ ���� ���� ������",
        "����� ������ ���� ���� ���� �����Դϴ�." });
        // AI �������� ��� ����

        talkData.Add(1001, new string[] { "���� �ӹ� �Ŵ����� �ε� �Ǿ����ϴ�.", "���� �ֿ켱 ��ǥ�� ���� �ӹ��� �����ϱ� ����",
        "���� �������� ���ϱ� �ٶ��ϴ�."});

        // ���� ���������� ������ ����
        talkData.Add(1002, new string[] { "�÷��̾�, ����� �� �ϳ��ϳ� ���� �����ص帱 �� �����ϴ�.", "�ٽ� �����帳�ϴ�.",
        "���� �������� ���ϱ� �ٶ��ϴ�."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    IEnumerator PrintAIDialog(int DialogNum)
    {

        for (int i = 0; i < talkData[DialogNum].Length; i++)
        {
            string talkData = GetTalk(DialogNum, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }
    }

    public void ResetSystem()
    {
        StartCoroutine(ResetSystemDialog());
    }

    IEnumerator ResetSystemDialog()
    {
        yield return new WaitForSeconds(2f);
        AI.SetActive(true);

        Color color = AIIcon.GetComponent<Image>().color;
        for (int i = 0; i < 3; i++)
        {
            color.a = 0f;
            AIIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
            color.a = 1f;
            AIIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 11; i++)
        {
            string talkData = GetTalk(1000, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }

        AI.SetActive(false);
        color.a = 0f;
        AIIcon.GetComponent<Image>().color = color;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            color.a = 0f;
            AIIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
            color.a = 1f;
            AIIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
        }

        AI.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            string talkData = GetTalk(1001, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }
    }

    public void DoorLock()
    {
        StartCoroutine(PrintAIDialog(1002));
    }

}