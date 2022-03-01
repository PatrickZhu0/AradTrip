using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020010D4 RID: 4308
public class InstituteFinishFrame : ClientFrame
{
	// Token: 0x0600A302 RID: 41730 RVA: 0x002154BE File Offset: 0x002138BE
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Battle/Finish/InstituteFinishFrame";
	}

	// Token: 0x0600A303 RID: 41731 RVA: 0x002154C8 File Offset: 0x002138C8
	protected override void _bindExUI()
	{
		base._bindExUI();
		this.awardContainer = this.mBind.GetGameObject("awardContainer");
		this.nextBtn = this.mBind.GetCom<Button>("nextBtn");
		this.returnBtn = this.mBind.GetCom<Button>("returnBtn");
		this.title = this.mBind.GetCom<Text>("title");
		this.hassPass = this.mBind.GetGameObject("haveAwarded");
	}

	// Token: 0x0600A304 RID: 41732 RVA: 0x0021554C File Offset: 0x0021394C
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
		List<InstituteTable> jobInstituteData = Singleton<TableManager>.instance.GetJobInstituteData((int)BattleMain.instance.GetLocalPlayer(0UL).playerInfo.occupation);
		InstituteTable instituteTable = jobInstituteData.Find((InstituteTable x) => x.ID == InstituteFrame.id);
		InstituteFrame.id++;
		this.nextData = jobInstituteData.Find((InstituteTable x) => x.ID == InstituteFrame.id);
		this.nextBtn.gameObject.CustomActive(this.nextData != null && this.nextData.LevelLimit <= (int)DataManager<PlayerBaseData>.GetInstance().Level);
		this.ShowAwardInfo(instituteTable);
		this.title.text = instituteTable.Title;
		this.nextBtn.onClick.AddListener(new UnityAction(this.ChallengeNext));
		this.returnBtn.onClick.AddListener(new UnityAction(this.ReturnTown));
		this.batleFrame = (Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(InstituteBattleFrame)) as InstituteBattleFrame);
		this.hassPass.CustomActive(this.batleFrame.hasPassed);
	}

	// Token: 0x0600A305 RID: 41733 RVA: 0x00215698 File Offset: 0x00213A98
	private void ShowAwardInfo(InstituteTable data)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(data.MissionID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			string[] array = tableItem.Award.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2.Length == 2)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					if (itemData != null)
					{
						itemData.Count = int.Parse(array2[1]);
						ComItem comItem = base.CreateComItem(this.awardContainer);
						comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						});
						if (this.hassPass)
						{
							comItem.ItemData.IsSelected = true;
							comItem.SetShowSelectState(true);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600A306 RID: 41734 RVA: 0x00215794 File Offset: 0x00213B94
	private void ReturnTown()
	{
		Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
	}

	// Token: 0x0600A307 RID: 41735 RVA: 0x002157A3 File Offset: 0x00213BA3
	private void ChallengeNext()
	{
		if (this.nextData != null)
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(InstituteFrame._commonStart(this.nextData.DungeonID, 1));
		}
	}

	// Token: 0x04005ADC RID: 23260
	private GameObject awardContainer;

	// Token: 0x04005ADD RID: 23261
	private GameObject hassPass;

	// Token: 0x04005ADE RID: 23262
	private Button nextBtn;

	// Token: 0x04005ADF RID: 23263
	private Button returnBtn;

	// Token: 0x04005AE0 RID: 23264
	private InstituteTable nextData;

	// Token: 0x04005AE1 RID: 23265
	private InstituteBattleFrame batleFrame;

	// Token: 0x04005AE2 RID: 23266
	private Text title;
}
