using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F06 RID: 3846
	internal class ComMapScene : MonoBehaviour
	{
		// Token: 0x17001915 RID: 6421
		// (get) Token: 0x06009642 RID: 38466 RVA: 0x001C6F52 File Offset: 0x001C5352
		// (set) Token: 0x06009643 RID: 38467 RVA: 0x001C6F5A File Offset: 0x001C535A
		public string sceneName { get; set; }

		// Token: 0x17001916 RID: 6422
		// (get) Token: 0x06009644 RID: 38468 RVA: 0x001C6F63 File Offset: 0x001C5363
		// (set) Token: 0x06009645 RID: 38469 RVA: 0x001C6F6B File Offset: 0x001C536B
		public int levelLimit { get; private set; }

		// Token: 0x17001917 RID: 6423
		// (get) Token: 0x06009646 RID: 38470 RVA: 0x001C6F74 File Offset: 0x001C5374
		public float XRate
		{
			get
			{
				return this.m_sizeRate.x;
			}
		}

		// Token: 0x17001918 RID: 6424
		// (get) Token: 0x06009647 RID: 38471 RVA: 0x001C6F81 File Offset: 0x001C5381
		public float ZRate
		{
			get
			{
				return this.m_sizeRate.z;
			}
		}

		// Token: 0x17001919 RID: 6425
		// (get) Token: 0x06009648 RID: 38472 RVA: 0x001C6F8E File Offset: 0x001C538E
		public Vector3 offset
		{
			get
			{
				return this.m_vecOffset;
			}
		}

		// Token: 0x06009649 RID: 38473 RVA: 0x001C6F98 File Offset: 0x001C5398
		public void Initialize()
		{
			if (!this.m_bInited)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(this.SceneID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("ComMapScene: table id {0} is not exist!!", new object[]
					{
						this.SceneID
					});
					return;
				}
				ISceneData sceneData = DungeonUtility.LoadSceneData(tableItem.ResPath);
				if (sceneData == null)
				{
					Logger.LogErrorFormat("ComMapScene: table id {0} res path {1} is not exist!!", new object[]
					{
						this.SceneID,
						tableItem.ResPath
					});
					return;
				}
				this.sceneName = tableItem.Name;
				RectTransform component = base.GetComponent<RectTransform>();
				this.m_sizeRate.x = component.rect.width / (sceneData.GetLogicXSize().y - sceneData.GetLogicXSize().x);
				this.m_sizeRate.z = component.rect.height / (sceneData.GetLogicZSize().y - sceneData.GetLogicZSize().x);
				this.m_vecOffset = new Vector3(sceneData.GetLogicXSize().x, 0f, sceneData.GetLogicZSize().x);
				this.levelLimit = tableItem.LevelLimit;
				this.SetLock((int)DataManager<PlayerBaseData>.GetInstance().Level < this.levelLimit);
				if (this.labLockDesc != null)
				{
					this.labLockDesc.text = TR.Value("town_map_lock_desc", this.levelLimit);
				}
				this.m_bInited = true;
			}
		}

		// Token: 0x0600964A RID: 38474 RVA: 0x001C713A File Offset: 0x001C553A
		public void SetLock(bool a_bLock)
		{
			if (this.objLockRoot != null)
			{
				this.objLockRoot.SetActive(a_bLock);
			}
		}

		// Token: 0x0600964B RID: 38475 RVA: 0x001C7159 File Offset: 0x001C5559
		public void LoadBackgroundImg()
		{
			this.imgBackground.SafeSetImage(this.backImgPath, false);
		}

		// Token: 0x04004D1C RID: 19740
		public int SceneID;

		// Token: 0x04004D1D RID: 19741
		public int JumpTownId = -1;

		// Token: 0x04004D1E RID: 19742
		public ComButtonEx btnScene;

		// Token: 0x04004D1F RID: 19743
		public GameObject objLockRoot;

		// Token: 0x04004D20 RID: 19744
		public Text labLockDesc;

		// Token: 0x04004D21 RID: 19745
		public Image imgBackground;

		// Token: 0x04004D22 RID: 19746
		public string backImgPath = string.Empty;

		// Token: 0x04004D23 RID: 19747
		private bool m_bInited;

		// Token: 0x04004D24 RID: 19748
		private Vector3 m_sizeRate = Vector3.zero;

		// Token: 0x04004D25 RID: 19749
		private Vector3 m_vecOffset = Vector3.zero;
	}
}
