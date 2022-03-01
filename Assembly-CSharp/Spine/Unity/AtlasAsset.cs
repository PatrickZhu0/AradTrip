using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E2 RID: 18914
	public class AtlasAsset : ScriptableObject
	{
		// Token: 0x17002416 RID: 9238
		// (get) Token: 0x0601B493 RID: 111763 RVA: 0x00865EE6 File Offset: 0x008642E6
		public bool IsLoaded
		{
			get
			{
				return this.atlas != null;
			}
		}

		// Token: 0x0601B494 RID: 111764 RVA: 0x00865EF4 File Offset: 0x008642F4
		public static AtlasAsset CreateRuntimeInstance(TextAsset atlasText, Material[] materials, bool initialize)
		{
			AtlasAsset atlasAsset = ScriptableObject.CreateInstance<AtlasAsset>();
			atlasAsset.Reset();
			atlasAsset.atlasFile = atlasText;
			atlasAsset.materials = materials;
			if (initialize)
			{
				atlasAsset.GetAtlas();
			}
			return atlasAsset;
		}

		// Token: 0x0601B495 RID: 111765 RVA: 0x00865F2C File Offset: 0x0086432C
		public static AtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Material materialPropertySource, bool initialize)
		{
			string text = atlasText.text;
			text = text.Replace("\r", string.Empty);
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			List<string> list = new List<string>();
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i].Trim().Length == 0)
				{
					list.Add(array[i + 1].Trim().Replace(".png", string.Empty));
				}
			}
			Material[] array2 = new Material[list.Count];
			int j = 0;
			int count = list.Count;
			while (j < count)
			{
				Material material = null;
				string a = list[j];
				int k = 0;
				int num = textures.Length;
				while (k < num)
				{
					if (string.Equals(a, textures[k].name, StringComparison.OrdinalIgnoreCase))
					{
						material = new Material(materialPropertySource);
						material.mainTexture = textures[k];
						break;
					}
					k++;
				}
				if (!(material != null))
				{
					throw new ArgumentException("Could not find matching atlas page in the texture array.");
				}
				array2[j] = material;
				j++;
			}
			return AtlasAsset.CreateRuntimeInstance(atlasText, array2, initialize);
		}

		// Token: 0x0601B496 RID: 111766 RVA: 0x00866060 File Offset: 0x00864460
		public static AtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Shader shader, bool initialize)
		{
			if (shader == null)
			{
				shader = Shader.Find("Spine/Skeleton");
			}
			Material materialPropertySource = new Material(shader);
			return AtlasAsset.CreateRuntimeInstance(atlasText, textures, materialPropertySource, initialize);
		}

		// Token: 0x0601B497 RID: 111767 RVA: 0x00866097 File Offset: 0x00864497
		private void Reset()
		{
			this.Clear();
		}

		// Token: 0x0601B498 RID: 111768 RVA: 0x0086609F File Offset: 0x0086449F
		public virtual void Clear()
		{
			this.atlas = null;
		}

		// Token: 0x0601B499 RID: 111769 RVA: 0x008660A8 File Offset: 0x008644A8
		public virtual Atlas GetAtlas()
		{
			if (this.atlasFile == null)
			{
				Debug.LogError("Atlas file not set for atlas asset: " + base.name, this);
				this.Clear();
				return null;
			}
			if (this.materials == null || this.materials.Length == 0)
			{
				Debug.LogError("Materials not set for atlas asset: " + base.name, this);
				this.Clear();
				return null;
			}
			if (this.atlas != null)
			{
				return this.atlas;
			}
			Atlas result;
			try
			{
				this.atlas = new Atlas(new StringReader(this.atlasFile.text), string.Empty, new MaterialsTextureLoader(this));
				this.atlas.FlipV();
				result = this.atlas;
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Error reading atlas file for atlas asset: ",
					base.name,
					"\n",
					ex.Message,
					"\n",
					ex.StackTrace
				}), this);
				result = null;
			}
			return result;
		}

		// Token: 0x0601B49A RID: 111770 RVA: 0x008661C8 File Offset: 0x008645C8
		public Mesh GenerateMesh(string name, Mesh mesh, out Material material, float scale = 0.01f)
		{
			AtlasRegion atlasRegion = this.atlas.FindRegion(name);
			material = null;
			if (atlasRegion != null)
			{
				if (mesh == null)
				{
					mesh = new Mesh();
					mesh.name = name;
				}
				Vector3[] array = new Vector3[4];
				Vector2[] array2 = new Vector2[4];
				Color[] colors = new Color[]
				{
					Color.white,
					Color.white,
					Color.white,
					Color.white
				};
				int[] triangles = new int[]
				{
					0,
					1,
					2,
					2,
					3,
					0
				};
				float num = (float)atlasRegion.width / -2f;
				float num2 = num * -1f;
				float num3 = (float)atlasRegion.height / 2f;
				float num4 = num3 * -1f;
				array[0] = new Vector3(num, num4, 0f) * scale;
				array[1] = new Vector3(num, num3, 0f) * scale;
				array[2] = new Vector3(num2, num3, 0f) * scale;
				array[3] = new Vector3(num2, num4, 0f) * scale;
				float u = atlasRegion.u;
				float v = atlasRegion.v;
				float u2 = atlasRegion.u2;
				float v2 = atlasRegion.v2;
				if (!atlasRegion.rotate)
				{
					array2[0] = new Vector2(u, v2);
					array2[1] = new Vector2(u, v);
					array2[2] = new Vector2(u2, v);
					array2[3] = new Vector2(u2, v2);
				}
				else
				{
					array2[0] = new Vector2(u2, v2);
					array2[1] = new Vector2(u, v2);
					array2[2] = new Vector2(u, v);
					array2[3] = new Vector2(u2, v);
				}
				mesh.triangles = new int[0];
				mesh.vertices = array;
				mesh.uv = array2;
				mesh.colors = colors;
				mesh.triangles = triangles;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				material = (Material)atlasRegion.page.rendererObject;
			}
			else
			{
				mesh = null;
			}
			return mesh;
		}

		// Token: 0x04013014 RID: 77844
		public TextAsset atlasFile;

		// Token: 0x04013015 RID: 77845
		public Material[] materials;

		// Token: 0x04013016 RID: 77846
		protected Atlas atlas;
	}
}
