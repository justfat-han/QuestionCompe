using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Roulette : MonoBehaviour
{
    public float RotatePower;
    public float StopPower;

    private Rigidbody2D rbody;
    int inRotate;

    // TextMeshProUGUI element to display the score
    [SerializeField] 
    private TextMeshProUGUI scoreText;

    public int score = 0;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    float t;

    private void Update()
    {
        // Update the score display
        UpdateScoreText();

        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower * Time.deltaTime;
            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if (rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                GetCategory();
                inRotate = 0;
                t = 0;
            }
        }
    }

    public void Rotate()
    {
        if (inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    public void GetCategory()
    {
        float rot = transform.eulerAngles.z;

        string selectedCategory = "";

        if (rot > 0 + 22 && rot <= 45 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 45);
            Debug.Log("Pilihan 1");
            selectedCategory = "Etnik";
        }
        else if (rot > 45 + 22 && rot <= 90 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90);
            Debug.Log("Pilihan 2");
            selectedCategory = "Umum";            
        }
        else if (rot > 90 + 22 && rot <= 135 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 135);
            Debug.Log("Pilihan 3");
            selectedCategory = "Sejarah";
        }
        else if (rot > 135 + 22 && rot <= 180 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 180);
            Debug.Log("Pilihan 4");
            selectedCategory = "Acak";
        }
        else if (rot > 180 + 22 && rot <= 225 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 225);
            Debug.Log("Pilihan 5");
            selectedCategory = "Kuliner";
        }
        else if (rot > 225 + 22 && rot <= 270 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 270);
            Debug.Log("Pilihan 6");
            selectedCategory = "Budaya";
        }
        else if (rot > 270 + 22 && rot <= 315 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 315);
            Debug.Log("Pilihan 7");
            selectedCategory = "Cagar Alam";
        }
        else if (rot > 315 + 22 && rot <= 360 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("Pilihan 8");
            selectedCategory = "Acak";
        }

        // Pass the selected category to the Question scene
        PlayerPrefs.SetString("SelectedCategory", selectedCategory);
        SceneManager.LoadScene("QuestionCompe");
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString("D5"); // D5 format for leading zeros
    }
}
