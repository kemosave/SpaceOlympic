using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRenderer : MonoBehaviour {
    private readonly int OFFSET_ID = Shader.PropertyToID("_Offset");

    [SerializeField]
    private Material m_dummyMaterial = null;

    private void Start() {
        if (LoopedField.Instance != null) {
            Vector3 fieldSize = LoopedField.Instance.FieldBounds.size;

            SetDummyMaterials(fieldSize);
            ExpandBounds(fieldSize);
        }

    }

    private void SetDummyMaterials(Vector3 i_fieldSize) {
        if (m_dummyMaterial == null) {
            return;
        }

        var renderer = GetComponentInChildren<Renderer>();
        if (renderer == null) {
            return;
        }


        // 周り八方向にダミー用のマテリアルでオブジェクトを描画する。
        // 専用のシェーダーを使っているマテリアル限定だけど……。
        var dummyMaterials = new Material[]
        {
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
            new Material( m_dummyMaterial ),
        };

        dummyMaterials[0].SetVector(OFFSET_ID, new Vector4(i_fieldSize.x, 0.0f, 0.0f, 0.0f));
        dummyMaterials[1].SetVector(OFFSET_ID, new Vector4(i_fieldSize.x, 0.0f, i_fieldSize.z, 0.0f));
        dummyMaterials[2].SetVector(OFFSET_ID, new Vector4(i_fieldSize.x, 0.0f, -i_fieldSize.z, 0.0f));
        dummyMaterials[3].SetVector(OFFSET_ID, new Vector4(-i_fieldSize.x, 0.0f, 0.0f, 0.0f));
        dummyMaterials[4].SetVector(OFFSET_ID, new Vector4(-i_fieldSize.x, 0.0f, i_fieldSize.z, 0.0f));
        dummyMaterials[5].SetVector(OFFSET_ID, new Vector4(-i_fieldSize.x, 0.0f, -i_fieldSize.z, 0.0f));
        dummyMaterials[6].SetVector(OFFSET_ID, new Vector4(0.0f, 0.0f, i_fieldSize.z, 0.0f));
        dummyMaterials[7].SetVector(OFFSET_ID, new Vector4(0.0f, 0.0f, -i_fieldSize.z, 0.0f));

        var materials = new List<Material>(renderer.materials);
        materials.AddRange(dummyMaterials);

        renderer.materials = materials.ToArray();
    }

    private void ExpandBounds(Vector3 i_fieldSize) {
        // メインのGameObjectが描画範囲から外れていても描画されるように、
        // boundsのサイズを大きくしておこう。
        var meshFilter = GetComponentInChildren<MeshFilter>();
        if (meshFilter == null) {
            return;
        }

        var bounds = meshFilter.mesh.bounds;
        bounds.size += i_fieldSize;
        meshFilter.mesh.bounds = bounds;
    }

} // class DummyRenderer
