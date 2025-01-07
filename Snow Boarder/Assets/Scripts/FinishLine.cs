using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // file -> save as 에서 첫 화면 unity파일로 scene 폴더에 저장하고
            // file -> build settings에서 add open scenes 눌러서 업로드 하고
            // 아래 괄호에 scene 인덱스 번호 넣기
            SceneManager.LoadScene(0);
        }

    }
}
