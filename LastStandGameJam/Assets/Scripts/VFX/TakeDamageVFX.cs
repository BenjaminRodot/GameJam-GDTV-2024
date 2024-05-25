using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamageVFX : MonoBehaviour
{
    float _intensity = 0;
    PostProcessVolume _volume;
    Vignette _vignette;

    // Start is called before the first frame update
    void Awake()
    {
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if (!_vignette)
        {
            Debug.LogError("Vignette empty");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    public IEnumerator TakeDamageEffect(float intensity)
    {
        _intensity += intensity;
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(_intensity);

        yield return new WaitForSeconds(_intensity);

        while (_intensity > 0)
        {
            _intensity -= 0.01f;
            if(_intensity < 0) _intensity = 0;
            _vignette.intensity.Override(_intensity);
            yield return new WaitForSeconds(0.01f);
        }
        _vignette.enabled.Override(false);
        yield break;
    }
}
