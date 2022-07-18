using UnityEngine;

public class DifferencesCollider : MonoBehaviour
{
    public void ActivateImage()
    {
        transform.parent.GetChild(0).gameObject.SetActive(false);
        transform.parent.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Gameplay").GetComponent<DifferencesVerifier>().IncrementErrorFound();
    }
}
