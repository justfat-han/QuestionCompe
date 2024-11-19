using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Pertanyaan", menuName = "ScriptableObjects/Pertanyaan", order = 3)]
public class QuestionData : ScriptableObject
{
    public string question;
    public string category;
    [Tooltip("The correct answer should always be listed first, they are ranzomized later")]
    public string[] answers;
}