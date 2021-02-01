using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : Tutorial
{
    public override void First()
    {
        StartCoroutine(FirstAsync());
    }

    public IEnumerator FirstAsync()
    {
        yield return new WaitForSeconds(1.5f);
        // AudioManager.Instance.PlayEffect(lanternLight);
        yield return new WaitForSeconds(1.5f);
        Resume();
    }

    public override void Finish()
    {
        SceneLoader.Instance.Load(0);
    }
}
