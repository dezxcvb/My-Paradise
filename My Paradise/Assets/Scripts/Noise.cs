using UnityEngine;

public class Noise : MonoBehaviour {
    public Material mat;
    public Texture2D noiseTex;

    void Start() {
        mat.SetTexture("_NoiseTex", noiseTex);
    }

    void FixedUpdate() {
        mat.SetFloat("_NoiseOffset", Time.time * 0.05f);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        Graphics.Blit(src, dst, mat);
    }
}