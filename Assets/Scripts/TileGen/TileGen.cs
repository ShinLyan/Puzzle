using UnityEngine;

public class TileGen : MonoBehaviour
{
    public string ImageFilename;

    private Texture2D mTextureOriginal;

    private void Start()
    {
        CreateBaseTexture();
    }

    private void CreateBaseTexture()
    {
        // Load the main image.
        mTextureOriginal = SpriteUtils.LoadTexture(ImageFilename);
        if (!mTextureOriginal.isReadable)
        {
            Debug.Log("Texture is not readable");
            return;
        }

        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpriteUtils.CreateSpriteFromTexture2D(
            mTextureOriginal,
            0,
            0,
            mTextureOriginal.width,
            mTextureOriginal.height);
    }
}
