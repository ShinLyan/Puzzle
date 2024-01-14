using UnityEngine;

public class SpriteUtils : MonoBehaviour
{
    public static Sprite CreateSpriteFromTexture2D(Texture2D SpriteTexture,
      int x, int y, int w, int h, float PixelsPerUnit = 1.0f,
      SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        Sprite newSprite = Sprite.Create(
            SpriteTexture,
            new Rect(x, y, w, h),
            new Vector2(0, 0),
            PixelsPerUnit,
            0,
            spriteType);
        return newSprite;
    }

    public static Texture2D LoadTexture(string resourcePath)
    {
        Texture2D tex = Resources.Load<Texture2D>(resourcePath);
        return tex;
    }
}
