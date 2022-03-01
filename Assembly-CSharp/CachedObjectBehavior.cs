using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000DB2 RID: 3506
public class CachedObjectBehavior : MonoBehaviour
{
	// Token: 0x06008DDE RID: 36318 RVA: 0x001A62FF File Offset: 0x001A46FF
	public void Create()
	{
		if (!this.bCreate)
		{
			this.bCreate = true;
		}
	}

	// Token: 0x04004663 RID: 18019
	public CachedObjectBehavior.CreateType eCreateType;

	// Token: 0x04004664 RID: 18020
	public GameObject goParent;

	// Token: 0x04004665 RID: 18021
	public GameObject goPrefab;

	// Token: 0x04004666 RID: 18022
	public bool IsOpenCreate = true;

	// Token: 0x04004667 RID: 18023
	public CachedObjectBehavior.UIBinder[] uiBinders;

	// Token: 0x04004668 RID: 18024
	private bool bCreate;

	// Token: 0x02000DB3 RID: 3507
	public enum CreateType
	{
		// Token: 0x0400466A RID: 18026
		CT_USE_COPY,
		// Token: 0x0400466B RID: 18027
		CT_USE_CURRENT,
		// Token: 0x0400466C RID: 18028
		CT_COUNT
	}

	// Token: 0x02000DB4 RID: 3508
	public class UIBinderAttribute : Attribute
	{
		// Token: 0x06008DDF RID: 36319 RVA: 0x001A6313 File Offset: 0x001A4713
		public UIBinderAttribute(Type type)
		{
			this.type = type;
		}

		// Token: 0x170018CB RID: 6347
		// (get) Token: 0x06008DE0 RID: 36320 RVA: 0x001A6322 File Offset: 0x001A4722
		public Type Type
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x0400466D RID: 18029
		private Type type;
	}

	// Token: 0x02000DB5 RID: 3509
	[Serializable]
	public class UIBinder
	{
		// Token: 0x0400466E RID: 18030
		public GameObject goLocal;

		// Token: 0x0400466F RID: 18031
		public string varName;

		// Token: 0x04004670 RID: 18032
		public CachedObjectBehavior.UIBinder.BinderType eBinderType = CachedObjectBehavior.UIBinder.BinderType.BT_INVALID;

		// Token: 0x02000DB6 RID: 3510
		public enum BinderType
		{
			// Token: 0x04004672 RID: 18034
			[CachedObjectBehavior.UIBinderAttribute(typeof(Text))]
			BT_TEXT,
			// Token: 0x04004673 RID: 18035
			[CachedObjectBehavior.UIBinderAttribute(typeof(Button))]
			BT_BUTTON,
			// Token: 0x04004674 RID: 18036
			[CachedObjectBehavior.UIBinderAttribute(typeof(Toggle))]
			BT_TOGGLE,
			// Token: 0x04004675 RID: 18037
			[CachedObjectBehavior.UIBinderAttribute(typeof(NewSuperLinkText))]
			BT_SUPERLINKTEXT,
			// Token: 0x04004676 RID: 18038
			[CachedObjectBehavior.UIBinderAttribute(typeof(Image))]
			BT_IMAGE,
			// Token: 0x04004677 RID: 18039
			[CachedObjectBehavior.UIBinderAttribute(typeof(GameObject))]
			BT_GAMEOBJECT,
			// Token: 0x04004678 RID: 18040
			BT_INVALID,
			// Token: 0x04004679 RID: 18041
			BT_COUNT = 6
		}
	}
}
