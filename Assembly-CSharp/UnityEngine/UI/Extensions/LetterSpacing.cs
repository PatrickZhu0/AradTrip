using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GamePool;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AEE RID: 19182
	[ExecuteInEditMode]
	[AddComponentMenu("UI/Effects/Extensions/Letter Spacing")]
	public class LetterSpacing : BaseMeshEffect
	{
		// Token: 0x0601BE70 RID: 114288 RVA: 0x00889C44 File Offset: 0x00888044
		protected LetterSpacing()
		{
		}

		// Token: 0x170025E6 RID: 9702
		// (get) Token: 0x0601BE71 RID: 114289 RVA: 0x00889C4C File Offset: 0x0088804C
		// (set) Token: 0x0601BE72 RID: 114290 RVA: 0x00889C54 File Offset: 0x00888054
		public float spacing
		{
			get
			{
				return this.m_spacing;
			}
			set
			{
				if (this.m_spacing == value)
				{
					return;
				}
				this.m_spacing = value;
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x0601BE73 RID: 114291 RVA: 0x00889C88 File Offset: 0x00888088
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!this.IsActive())
			{
				return;
			}
			List<UIVertex> list = new List<UIVertex>();
			vh.GetUIVertexStream(list);
			Text component = base.GetComponent<Text>();
			if (component == null)
			{
				Debug.LogWarning("LetterSpacing: Missing Text component");
				return;
			}
			bool flag = this.bUseMatch;
			string[] array = component.text.Split(new char[]
			{
				'\n'
			});
			float num = this.spacing * (float)component.fontSize / 100f;
			float num2 = 0f;
			int num3 = 0;
			switch (component.alignment)
			{
			case 0:
			case 3:
			case 6:
				num2 = 0f;
				break;
			case 1:
			case 4:
			case 7:
				num2 = 0.5f;
				break;
			case 2:
			case 5:
			case 8:
				num2 = 1f;
				break;
			}
			foreach (string text in array)
			{
				float num4 = (float)(text.Length - 1) * num * num2;
				List<Match> list2 = null;
				if (flag)
				{
					list2 = ListPool<Match>.Get();
					for (int j = 0; j < LetterSpacing.ms_Regexs.Length; j++)
					{
						MatchCollection matchCollection = LetterSpacing.ms_Regexs[j].Matches(text);
						IEnumerator enumerator = matchCollection.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if ((enumerator.Current as Match).Success)
							{
								list2.Add(enumerator.Current as Match);
							}
						}
					}
				}
				int k = 0;
				int num5 = 0;
				while (k < text.Length)
				{
					int index = num3 * 6;
					int index2 = num3 * 6 + 1;
					int index3 = num3 * 6 + 2;
					int index4 = num3 * 6 + 3;
					int index5 = num3 * 6 + 4;
					int num6 = num3 * 6 + 5;
					if (num6 > list.Count - 1)
					{
						return;
					}
					UIVertex value = list[index];
					UIVertex value2 = list[index2];
					UIVertex value3 = list[index3];
					UIVertex value4 = list[index4];
					UIVertex value5 = list[index5];
					UIVertex value6 = list[num6];
					bool flag2 = false;
					if (list2 != null)
					{
						for (int l = 0; l < list2.Count; l++)
						{
							if (k >= list2[l].Index && k < list2[l].Index + list2[l].Length)
							{
								flag2 = true;
								break;
							}
						}
					}
					Vector3 vector;
					if (!flag)
					{
						vector = Vector3.right * (num * (float)k - num4);
					}
					else
					{
						vector = Vector3.right * (num * (float)num5 - num4);
						if (!flag2)
						{
							num5++;
						}
					}
					value.position += vector;
					value2.position += vector;
					value3.position += vector;
					value4.position += vector;
					value5.position += vector;
					value6.position += vector;
					list[index] = value;
					list[index2] = value2;
					list[index3] = value3;
					list[index4] = value4;
					list[index5] = value5;
					list[num6] = value6;
					num3++;
					k++;
				}
				if (list2 != null)
				{
					ListPool<Match>.Release(list2);
				}
				num3++;
			}
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
		}

		// Token: 0x04013742 RID: 79682
		[SerializeField]
		private float m_spacing;

		// Token: 0x04013743 RID: 79683
		public static Regex[] ms_Regexs = new Regex[]
		{
			new Regex("<color=#[0-9A-Fa-f]{6,8}>"),
			new Regex("</color>")
		};

		// Token: 0x04013744 RID: 79684
		public bool bUseMatch;
	}
}
