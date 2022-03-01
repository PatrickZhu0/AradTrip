using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001422 RID: 5154
	public class ComAdventureTeamGrade : MonoBehaviour
	{
		// Token: 0x0600C7C7 RID: 51143 RVA: 0x003059B4 File Offset: 0x00303DB4
		public ComAdventureTeamGrade()
		{
			string[,] array = new string[4, 2];
			array[0, 0] = AdventureTeamGradeTable.eGradeEnum.S.ToString();
			array[0, 1] = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_S";
			array[1, 0] = AdventureTeamGradeTable.eGradeEnum.A.ToString();
			array[1, 1] = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_A";
			array[2, 0] = AdventureTeamGradeTable.eGradeEnum.B.ToString();
			array[2, 1] = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_B";
			array[3, 0] = AdventureTeamGradeTable.eGradeEnum.C.ToString();
			array[3, 1] = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_C";
			this.gradeEnumWithResPath = array;
			this.gradeEnumWithImgNum = new int[,]
			{
				{
					6,
					3,
					0
				},
				{
					5,
					2,
					0
				},
				{
					4,
					1,
					0
				},
				{
					3,
					1,
					1
				},
				{
					2,
					1,
					2
				},
				{
					1,
					1,
					3
				}
			};
			base..ctor();
		}

		// Token: 0x0600C7C8 RID: 51144 RVA: 0x00305A84 File Offset: 0x00303E84
		private void Awake()
		{
			this.childCount = base.transform.childCount;
			this.images = new Image[this.childCount];
			this.layoutElements = new LayoutElement[this.childCount];
			for (int i = 0; i < this.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				if (!(child == null))
				{
					Image component = child.GetComponent<Image>();
					if (component)
					{
						this.images[i] = component;
					}
					LayoutElement component2 = child.GetComponent<LayoutElement>();
					if (component2)
					{
						this.layoutElements[i] = component2;
					}
				}
			}
		}

		// Token: 0x0600C7C9 RID: 51145 RVA: 0x00305B2F File Offset: 0x00303F2F
		private void OnDestroy()
		{
			this.gradeEnumWithResPath = null;
			this.gradeEnumWithImgNum = null;
		}

		// Token: 0x0600C7CA RID: 51146 RVA: 0x00305B40 File Offset: 0x00303F40
		public bool SetGradeImg(AdventureTeamGradeTable.eGradeEnum gradeEnum)
		{
			if (this.images == null || this.images.Length <= 0)
			{
				return false;
			}
			if (this.layoutElements == null || this.layoutElements.Length <= 0)
			{
				return false;
			}
			if (gradeEnum == AdventureTeamGradeTable.eGradeEnum.GradeEnum_None)
			{
				return false;
			}
			int num = 0;
			int num2 = -1;
			int i = 0;
			while (i < this.gradeEnumWithImgNum.GetLength(0))
			{
				int num3 = this.gradeEnumWithImgNum[i, 0];
				if (num3 == (int)gradeEnum)
				{
					int num4 = this.gradeEnumWithImgNum[i, 1];
					if (num4 > this.childCount)
					{
						Logger.LogError("ComAdventureTeamGrade Grade Img num length is too longer !");
						break;
					}
					num = num4;
					num2 = this.gradeEnumWithImgNum[i, 2];
					break;
				}
				else
				{
					i++;
				}
			}
			if (num2 < 0 || num2 >= this.gradeEnumWithResPath.GetLength(0))
			{
				return false;
			}
			string text = this.gradeEnumWithResPath[num2, 1];
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (num <= 0 || num > this.images.Length || num > this.layoutElements.Length)
			{
				return false;
			}
			bool result = false;
			for (int j = 0; j < this.images.Length; j++)
			{
				Image image = this.images[j];
				if (!(image == null))
				{
					if (j < num)
					{
						result = ETCImageLoader.LoadSprite(ref image, text, true);
						image.enabled = true;
					}
					else
					{
						image.sprite = null;
						image.enabled = false;
					}
				}
			}
			for (int k = 0; k < this.layoutElements.Length; k++)
			{
				LayoutElement layoutElement = this.layoutElements[k];
				if (!(layoutElement == null))
				{
					if (k < num)
					{
						layoutElement.ignoreLayout = false;
					}
					else
					{
						layoutElement.ignoreLayout = true;
					}
				}
			}
			return result;
		}

		// Token: 0x040072D4 RID: 29396
		public const string GRADE_C_RESPATH = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_C";

		// Token: 0x040072D5 RID: 29397
		public const string GRADE_B_RESPATH = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_B";

		// Token: 0x040072D6 RID: 29398
		public const string GRADE_A_RESPATH = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_A";

		// Token: 0x040072D7 RID: 29399
		public const string GRADE_S_RESPATH = "UI/Image/Packed/p_UI_List.png:UI_Paihangbang_S";

		// Token: 0x040072D8 RID: 29400
		[SerializeField]
		private Image[] images;

		// Token: 0x040072D9 RID: 29401
		[SerializeField]
		private LayoutElement[] layoutElements;

		// Token: 0x040072DA RID: 29402
		[SerializeField]
		private int childCount = 3;

		// Token: 0x040072DB RID: 29403
		private string[,] gradeEnumWithResPath;

		// Token: 0x040072DC RID: 29404
		private int[,] gradeEnumWithImgNum;
	}
}
