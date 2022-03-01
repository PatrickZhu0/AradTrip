using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A7 RID: 5287
	internal class BetterEquipmentFrame : ClientFrame
	{
		// Token: 0x0600CCEC RID: 52460 RVA: 0x00325611 File Offset: 0x00323A11
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600CCED RID: 52461 RVA: 0x00325613 File Offset: 0x00323A13
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600CCEE RID: 52462 RVA: 0x00325615 File Offset: 0x00323A15
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/BetterEquipmentFrame";
		}

		// Token: 0x0600CCEF RID: 52463 RVA: 0x0032561C File Offset: 0x00323A1C
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.ClearData();
			this.frameMgr.CloseFrame<BetterEquipmentFrame>(this, false);
		}

		// Token: 0x0600CCF0 RID: 52464 RVA: 0x00325631 File Offset: 0x00323A31
		private void ClearData()
		{
			this.CreateEleObjNum = 0;
			this.fTimeIntreval = 0f;
			this.itemObjList.Clear();
		}

		// Token: 0x0600CCF1 RID: 52465 RVA: 0x00325650 File Offset: 0x00323A50
		public void UpdateInterface(List<BetterEquipmentData> data)
		{
			List<BetterEquipmentData> list = new List<BetterEquipmentData>();
			for (int i = 0; i < data.Count; i++)
			{
				if (data[i].DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
				{
					list.Add(data[i]);
				}
			}
			if (list.Count > this.CreateEleObjNum)
			{
				for (int j = 0; j < list.Count - this.CreateEleObjNum; j++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ElementPath, true, 0U);
					if (gameObject == null)
					{
						Logger.LogError("can't create obj in MailFrame");
						return;
					}
					this.itemObjList.Add(gameObject);
					Utility.AttachTo(gameObject, this.ObjRoot, false);
				}
				this.CreateEleObjNum = list.Count;
			}
			for (int k = 0; k < this.CreateEleObjNum; k++)
			{
				if (k < list.Count)
				{
					BetterEquipmentData betterEquipmentData = list[k];
					this.itemObjList[k].SetActive(true);
					Text[] componentsInChildren = this.itemObjList[k].GetComponentsInChildren<Text>();
					for (int l = 0; l < componentsInChildren.Length; l++)
					{
						if (componentsInChildren[l].name == "name")
						{
							componentsInChildren[l].text = betterEquipmentData.name;
						}
						else if (componentsInChildren[l].name == "PreData")
						{
							componentsInChildren[l].text = betterEquipmentData.PreData;
						}
						else if (componentsInChildren[l].name == "CurData")
						{
							componentsInChildren[l].text = betterEquipmentData.CurData;
							if (betterEquipmentData.DataState == EquipmentDataState.PROPERTY_UP)
							{
								componentsInChildren[l].color = new Color(0.078431375f, 0.9254902f, 0.015686275f);
							}
							else if (betterEquipmentData.DataState == EquipmentDataState.PROPERTY_DOWN)
							{
								componentsInChildren[l].color = new Color(0.9529412f, 0f, 0f);
							}
							else
							{
								componentsInChildren[l].color = new Color(1f, 1f, 1f);
							}
						}
					}
					Image[] componentsInChildren2 = this.itemObjList[k].GetComponentsInChildren<Image>();
					for (int m = 0; m < componentsInChildren2.Length; m++)
					{
						if (componentsInChildren2[m].name == "up")
						{
							if (betterEquipmentData.DataState == EquipmentDataState.PROPERTY_UP)
							{
								componentsInChildren2[m].gameObject.SetActive(true);
							}
							else
							{
								componentsInChildren2[m].gameObject.SetActive(false);
							}
						}
						else if (componentsInChildren2[m].name == "down")
						{
							if (betterEquipmentData.DataState == EquipmentDataState.PROPERTY_DOWN)
							{
								componentsInChildren2[m].gameObject.SetActive(true);
							}
							else
							{
								componentsInChildren2[m].gameObject.SetActive(false);
							}
						}
					}
				}
				else
				{
					this.itemObjList[k].SetActive(false);
				}
			}
		}

		// Token: 0x0600CCF2 RID: 52466 RVA: 0x0032597A File Offset: 0x00323D7A
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600CCF3 RID: 52467 RVA: 0x0032597D File Offset: 0x00323D7D
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeIntreval += timeElapsed;
			if (this.fTimeIntreval > 1.2f)
			{
				this.OnClose();
			}
		}

		// Token: 0x0400775E RID: 30558
		private string ElementPath = "UI/Prefabs/BetterEquipmentEle";

		// Token: 0x0400775F RID: 30559
		private int CreateEleObjNum;

		// Token: 0x04007760 RID: 30560
		private float fTimeIntreval;

		// Token: 0x04007761 RID: 30561
		private List<GameObject> itemObjList = new List<GameObject>();

		// Token: 0x04007762 RID: 30562
		[UIObject("middle_back/Scroll View/Viewport/Content")]
		protected GameObject ObjRoot;
	}
}
