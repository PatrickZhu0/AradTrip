using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200112F RID: 4399
	public class RoleItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600A736 RID: 42806 RVA: 0x0022DE10 File Offset: 0x0022C210
		private void Awake()
		{
			if (this.mSelectRoleBtn != null)
			{
				this.mSelectRoleBtn.onClick.RemoveAllListeners();
				this.mSelectRoleBtn.onClick.AddListener(delegate()
				{
					if (this.mOnSelectJobClick != null)
					{
						this.mOnSelectJobClick(this.mJobID);
					}
				});
			}
		}

		// Token: 0x0600A737 RID: 42807 RVA: 0x0022DE4F File Offset: 0x0022C24F
		public void OnItemVisiable(int jobID, OnSelectJobClick onSelectJobClick, int index)
		{
			this.mJobID = jobID;
			this.mOnSelectJobClick = onSelectJobClick;
			this.UpdateRoleItemInfo(this.mJobID, index);
		}

		// Token: 0x0600A738 RID: 42808 RVA: 0x0022DE6C File Offset: 0x0022C26C
		private void UpdateRoleItemInfo(int jobID, int idx)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mJobName != null)
			{
				ETCImageLoader.LoadSprite(ref this.mJobName, tableItem.CharacterCollectionArtLetting, true);
			}
			if (this.mGeObjectRenderer != null)
			{
				this.mGeObjectRenderer.gameObject.CustomActive(false);
			}
			if (this.mJobImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.mJobImage, tableItem.CharacterCollectionPhoto, true);
				this.mJobImage.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600A739 RID: 42809 RVA: 0x0022DF11 File Offset: 0x0022C311
		public void Dispose()
		{
			this.mJobID = 0;
			this.mOnSelectJobClick = null;
			if (this.mSelectRoleBtn != null)
			{
				this.mSelectRoleBtn.onClick.RemoveAllListeners();
			}
			this.mSelectRoleBtn = null;
		}

		// Token: 0x0600A73A RID: 42810 RVA: 0x0022DF49 File Offset: 0x0022C349
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04005D8B RID: 23947
		[SerializeField]
		private Image mJobName;

		// Token: 0x04005D8C RID: 23948
		[SerializeField]
		private GeObjectRenderer mGeObjectRenderer;

		// Token: 0x04005D8D RID: 23949
		[SerializeField]
		private Image mJobImage;

		// Token: 0x04005D8E RID: 23950
		[SerializeField]
		private Button mSelectRoleBtn;

		// Token: 0x04005D8F RID: 23951
		private int mJobID;

		// Token: 0x04005D90 RID: 23952
		private OnSelectJobClick mOnSelectJobClick;

		// Token: 0x04005D91 RID: 23953
		private int[] geObjectRenderLayers = new int[]
		{
			25,
			26,
			27,
			28,
			29,
			30
		};
	}
}
