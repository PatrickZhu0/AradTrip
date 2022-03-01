using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001709 RID: 5897
	public class StorageGroupFrame : ClientFrame
	{
		// Token: 0x0600E7A8 RID: 59304 RVA: 0x003D1780 File Offset: 0x003CFB80
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length >= 2)
				{
					ItemGroupData itemGroupData = new ItemGroupData();
					itemGroupData.isPackage = (int.Parse(array[0]) == 1);
					itemGroupData.ePackageType = (EPackageType)int.Parse(array[1]);
					if (array.Length == 3)
					{
						itemGroupData.openDecompose = (int.Parse(array[2]) == 1);
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<StorageGroupFrame>(FrameLayer.Middle, itemGroupData, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("PackageFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x0600E7A9 RID: 59305 RVA: 0x003D1830 File Offset: 0x003CFC30
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/StorageGroupFrame";
		}

		// Token: 0x0600E7AA RID: 59306 RVA: 0x003D1838 File Offset: 0x003CFC38
		protected override void _OnOpenFrame()
		{
			ItemGroupData itemGroupData = this.userData as ItemGroupData;
			if (itemGroupData == null)
			{
				itemGroupData = new ItemGroupData();
				itemGroupData.isPackage = true;
				itemGroupData.ePackageType = EPackageType.Equip;
			}
			if (itemGroupData.isPackage)
			{
				this.m_packageFrame = (this.frameMgr.OpenFrame<StoragePackageFrame>(this.m_objContentRight, itemGroupData.ePackageType, string.Empty) as StoragePackageFrame);
				this.m_labTitle.text = TR.Value("package_title_name");
				this.m_comHelp.eType = HelpFrame.HelpType.HT_PACKAGE;
			}
			else
			{
				this.m_storageFrame = (this.frameMgr.OpenFrame<StorageFrame>(this.m_objContentLeft, null, string.Empty) as StorageFrame);
				this.m_packageFrame = (this.frameMgr.OpenFrame<StoragePackageFrame>(this.m_objContentRight, itemGroupData.ePackageType, string.Empty) as StoragePackageFrame);
				this.m_labTitle.text = TR.Value("storage_title");
				this.m_comHelp.eType = HelpFrame.HelpType.HT_STORAGE;
			}
			if (itemGroupData.openDecompose && this.m_packageFrame != null)
			{
				this.m_packageFrame.OpenQuickDecompose();
			}
			this._RegisterUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600E7AB RID: 59307 RVA: 0x003D1974 File Offset: 0x003CFD74
		protected override void _OnCloseFrame()
		{
			if (this.m_packageFrame != null)
			{
				this.frameMgr.CloseFrame<StoragePackageFrame>(this.m_packageFrame, false);
				this.m_packageFrame = null;
			}
			if (this.m_storageFrame != null)
			{
				this.frameMgr.CloseFrame<StorageFrame>(this.m_storageFrame, false);
				this.m_storageFrame = null;
			}
			this._UnRegisterUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600E7AC RID: 59308 RVA: 0x003D19E2 File Offset: 0x003CFDE2
		protected void _RegisterUIEvent()
		{
		}

		// Token: 0x0600E7AD RID: 59309 RVA: 0x003D19E4 File Offset: 0x003CFDE4
		protected void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600E7AE RID: 59310 RVA: 0x003D19E6 File Offset: 0x003CFDE6
		[UIEventHandle("BG/Title/Close")]
		protected void _OnClose()
		{
			this.frameMgr.CloseFrame<StorageGroupFrame>(this, false);
		}

		// Token: 0x04008C82 RID: 35970
		private StoragePackageFrame m_packageFrame;

		// Token: 0x04008C83 RID: 35971
		private StorageFrame m_storageFrame;

		// Token: 0x04008C84 RID: 35972
		[UIControl("BG/Title/Name", null, 0)]
		private Text m_labTitle;

		// Token: 0x04008C85 RID: 35973
		[UIObject("Content/Left")]
		private GameObject m_objContentLeft;

		// Token: 0x04008C86 RID: 35974
		[UIObject("Content/Right")]
		private GameObject m_objContentRight;

		// Token: 0x04008C87 RID: 35975
		[UIControl("BG/Title/Help", null, 0)]
		private HelpAssistant m_comHelp;
	}
}
