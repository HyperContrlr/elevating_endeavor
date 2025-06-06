using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Text
{
    [CreateAssetMenu(fileName = "New Letter By Letter Text Effect", menuName = "TextMeshPro/Text Effects/Letter By Letter Text Effect")]
    public class TMPLetterByLetterEffect : TMPTextEffect
    {
        [SerializeField] private AnimationCurve _curve;

        [SerializeField] private float _speed = 1;
        [SerializeField] private float _spacing = 0.1f;

        public override void ModifyTextMesh(TMPro.TMP_TextInfo textInfo, List<Vector3> allVertices, float deltaTime, float time)
        {
            int j = 0;
            TMPro.TMP_MeshInfo meshInfo = textInfo.meshInfo[j];

            for (int i = 0; i < textInfo.characterCount; ++i)
            {
                TMPro.TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                if (charInfo.character.CompareTo(' ') == 0)
                    continue;

                byte alpha = (byte)(_curve.Evaluate((time * _speed) - (i * _spacing)) * 255);

                int bottomLeft = charInfo.vertexIndex;
                int topLeft = charInfo.vertexIndex + 1;
                int topRight = charInfo.vertexIndex + 2;
                int bottomRight = charInfo.vertexIndex + 3;

                if (bottomLeft >= meshInfo.colors32.Length)
                    meshInfo = textInfo.meshInfo[++j];

                meshInfo.colors32[bottomLeft] = new(meshInfo.colors32[bottomLeft].r, meshInfo.colors32[bottomLeft].g, meshInfo.colors32[bottomLeft].b, alpha);
                meshInfo.colors32[topLeft] = new(meshInfo.colors32[topLeft].r, meshInfo.colors32[topLeft].g, meshInfo.colors32[topLeft].b, alpha);

                meshInfo.colors32[topRight] = new(meshInfo.colors32[topRight].r, meshInfo.colors32[topRight].g, meshInfo.colors32[topRight].b, alpha);
                meshInfo.colors32[bottomRight] = new(meshInfo.colors32[bottomRight].r, meshInfo.colors32[bottomRight].g, meshInfo.colors32[bottomRight].b, alpha);
            }
        }
    }
}
