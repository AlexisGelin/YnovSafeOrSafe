using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public Vector2 EffectMultiplier = new Vector2(0, .5f);

    [SerializeField] Transform cameraTransform;
    Vector3 lastCameraPos;
    float textureUnitSizeX, textureUnitSizeY;


    private void Start()
    {
        lastCameraPos = cameraTransform.position;
        Sprite _sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = _sprite.texture;
        textureUnitSizeX = texture.width / _sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / _sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMouv = cameraTransform.position - lastCameraPos;
        transform.position += new Vector3(deltaMouv.x * EffectMultiplier.x, deltaMouv.y * EffectMultiplier.y);
        lastCameraPos = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPosX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPosX, transform.position.y);
        }

        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPosY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPosY);
        }

    }
}
