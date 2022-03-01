using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C40 RID: 7232
	public class TeamDuplicationHeadControl : MonoBehaviour
	{
		// Token: 0x06011C42 RID: 72770 RVA: 0x00534157 File Offset: 0x00532557
		private void Awake()
		{
		}

		// Token: 0x06011C43 RID: 72771 RVA: 0x00534159 File Offset: 0x00532559
		private void OnEnable()
		{
		}

		// Token: 0x06011C44 RID: 72772 RVA: 0x0053415B File Offset: 0x0053255B
		private void OnDisable()
		{
		}

		// Token: 0x06011C45 RID: 72773 RVA: 0x0053415D File Offset: 0x0053255D
		private void OnDestroy()
		{
		}

		// Token: 0x06011C46 RID: 72774 RVA: 0x0053415F File Offset: 0x0053255F
		public void Init()
		{
			this.InitControlData();
			this.InitControl();
		}

		// Token: 0x06011C47 RID: 72775 RVA: 0x0053416D File Offset: 0x0053256D
		private void InitControlData()
		{
		}

		// Token: 0x06011C48 RID: 72776 RVA: 0x00534170 File Offset: 0x00532570
		private void InitControl()
		{
			if (this.nameText != null)
			{
				this.nameText.text = DataManager<PlayerBaseData>.GetInstance().Name;
			}
			if (this.professionText != null)
			{
				this.professionText.text = TeamDuplicationUtility.GetJobName(DataManager<PlayerBaseData>.GetInstance().JobTableID, 0);
			}
			this.InitHead();
		}

		// Token: 0x06011C49 RID: 72777 RVA: 0x005341D8 File Offset: 0x005325D8
		private void InitHead()
		{
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					text = tableItem2.IconPath;
				}
			}
			if (this.headIcon != null && !string.IsNullOrEmpty(text))
			{
				ETCImageLoader.LoadSprite(ref this.headIcon, text, true);
			}
			int id = HeadPortraitFrameDataManager.iDefaultHeadPortraitID;
			if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID > 0)
			{
				id = HeadPortraitFrameDataManager.WearHeadPortraitFrameID;
			}
			string headPortraitFramePath = HeadPortraitFrameDataManager.GetHeadPortraitFramePath(id);
			if (this.headFrameIcon != null && !string.IsNullOrEmpty(headPortraitFramePath))
			{
				ETCImageLoader.LoadSprite(ref this.headFrameIcon, headPortraitFramePath, true);
			}
		}

		// Token: 0x0400B912 RID: 47378
		[Space(15f)]
		[Header("HeadIcon")]
		[Space(5f)]
		[SerializeField]
		private Image headIcon;

		// Token: 0x0400B913 RID: 47379
		[SerializeField]
		private Image headFrameIcon;

		// Token: 0x0400B914 RID: 47380
		[Space(15f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text nameText;

		// Token: 0x0400B915 RID: 47381
		[SerializeField]
		private Text professionText;
	}
}
