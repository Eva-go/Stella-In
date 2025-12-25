using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJudge();
        }
    }

    void TryJudge()
    {
        Note[] notes = FindObjectsOfType<Note>();
        Note closestNote = null;
        float minDiff = float.MaxValue;

        foreach (Note note in notes)
        {
            if (note.IsJudged) continue;

            float diff = note.GetTimeDiff();
            if (diff < minDiff)
            {
                minDiff = diff;
                closestNote = note;
            }
        }

        if (closestNote == null) return;

        if (minDiff <= 0.05f)
        {
            Debug.Log("Perfect");
            closestNote.Judge();
        }
        else if (minDiff <= 0.10f)
        {
            Debug.Log("Good");
            closestNote.Judge();
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
