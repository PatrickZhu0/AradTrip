using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F09 RID: 3849
public class ComMonsterItem : MonoBehaviour
{
	// Token: 0x06009658 RID: 38488 RVA: 0x001C73F4 File Offset: 0x001C57F4
	public void SetMonster(int id)
	{
		UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(id, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.mFg.enabled = (tableItem.Type == UnitTable.eType.BOSS);
			ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(tableItem2.IconPath, typeof(Sprite), true, 0U).obj as Sprite;
				if (null != sprite)
				{
					ETCImageLoader.LoadSprite(ref this.mImage, tableItem2.IconPath, true);
					return;
				}
			}
		}
		this.mImage.sprite = null;
		this.mImage.color = Color.red;
	}

	// Token: 0x06009659 RID: 38489 RVA: 0x001C74B8 File Offset: 0x001C58B8
	public void SetVisible(bool flag)
	{
		if (this.mImage != null)
		{
			this.mImage.enabled = flag;
		}
		if (this.mBg != null)
		{
			this.mBg.enabled = flag;
		}
		if (this.mFg != null)
		{
			this.mFg.enabled = flag;
		}
	}

	// Token: 0x04004D2B RID: 19755
	public Image mImage;

	// Token: 0x04004D2C RID: 19756
	public Image mBg;

	// Token: 0x04004D2D RID: 19757
	public Image mFg;
}
