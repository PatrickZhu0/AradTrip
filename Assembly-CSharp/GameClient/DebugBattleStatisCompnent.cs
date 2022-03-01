using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004236 RID: 16950
	public class DebugBattleStatisCompnent
	{
		// Token: 0x0601775B RID: 96091 RVA: 0x00735380 File Offset: 0x00733780
		public void _loadBattleStatisticsUI()
		{
			this.objBattleSta = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/EditorHUD/BattleInfoPanel", true, 0U);
			Utility.AttachTo(this.objBattleSta, Singleton<ClientSystemManager>.instance.BottomLayer, false);
			Text[] componentsInChildren = this.objBattleSta.GetComponentsInChildren<Text>();
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].gameObject.name == "Text")
					{
						this.textBattleOut = componentsInChildren[i];
					}
					else if (componentsInChildren[i].gameObject.name == "BattleInfoStaticText")
					{
						this.textBattleStat = componentsInChildren[i];
					}
					else if (componentsInChildren[i].gameObject.name == "InputText")
					{
						this.textInput = componentsInChildren[i];
					}
				}
			}
			this.scroll = this.objBattleSta.GetComponentInChildren<ScrollRect>();
			Button componentInChildren = this.objBattleSta.GetComponentInChildren<Button>();
			if (componentInChildren != null)
			{
				componentInChildren.onClick.AddListener(delegate()
				{
					int num = 0;
					try
					{
						num = int.Parse(this.textInput.text);
					}
					catch (Exception ex)
					{
					}
					if (num == 0)
					{
						num = Global.Settings.defaultMonsterID;
					}
					BeActor playerActor = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
					BeActor beActor = BattleMain.instance.Main.CreateMonster(num, false, null, 0, -1, null, false);
					if (beActor != null)
					{
						beActor.StartAI(playerActor, true);
						VInt3 position = playerActor.GetPosition();
						Vec3 position2 = new Vec3(position.fx + (float)Random.Range(-2, 2), position.fy + 1f, position.fz);
						beActor.SetPosition(new VInt3(position2), false, true, false);
						UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(num, string.Empty, string.Empty);
						if (tableItem != null && tableItem.FloatValue > 0)
						{
							beActor.SetFloating(VInt.NewVInt(tableItem.FloatValue, 1000), true);
						}
					}
				});
			}
		}

		// Token: 0x0601775C RID: 96092 RVA: 0x0073549C File Offset: 0x0073389C
		public void BS_AddBattleInfo(string attacker, string defender, AttackResult result, int damage)
		{
			if (this.textBattleOut == null)
			{
				return;
			}
			this.battleInfo.attackTotalNum = this.battleInfo.attackTotalNum + 1;
			string text = string.Format("{0} 攻击 {1}, ", attacker, defender);
			if (result == AttackResult.MISS)
			{
				text += "<color=gray>未命中</color>";
				this.battleInfo.missNum = this.battleInfo.missNum + 1;
			}
			else if (result == AttackResult.NORMAL)
			{
				text += "<color=yellow>命中</color>";
				text += string.Format(" 并造成 <color=yellow>{0}</color> 伤害", damage);
				this.battleInfo.normalNum = this.battleInfo.normalNum + 1;
			}
			else if (result == AttackResult.CRITICAL)
			{
				text += "<color=red>暴击</color>";
				text += string.Format(" 并造成 <color=red>{0}</color> 伤害", damage);
				this.battleInfo.criticalNum = this.battleInfo.criticalNum + 1;
			}
			Text text2 = this.textBattleOut;
			text2.text += text;
			Text text3 = this.textBattleOut;
			text3.text += "\n";
			if (this.scroll != null)
			{
				this.scroll.verticalNormalizedPosition = 0f;
			}
			if (this.textBattleStat != null)
			{
				string text4 = string.Format("攻击总次数:{0} 普通:<color=yellow>{1}</color> 暴击:<color=red>{2}</color> MISS：{3}", new object[]
				{
					this.battleInfo.attackTotalNum,
					this.battleInfo.normalNum,
					this.battleInfo.criticalNum,
					this.battleInfo.missNum
				});
				this.textBattleStat.text = text4;
			}
		}

		// Token: 0x04010D71 RID: 68977
		private GameObject objBattleSta;

		// Token: 0x04010D72 RID: 68978
		private Text textBattleOut;

		// Token: 0x04010D73 RID: 68979
		private Text textBattleStat;

		// Token: 0x04010D74 RID: 68980
		private ScrollRect scroll;

		// Token: 0x04010D75 RID: 68981
		private Text textInput;

		// Token: 0x04010D76 RID: 68982
		private DebugBattleStatisCompnent.BattleStatics battleInfo;

		// Token: 0x02004237 RID: 16951
		private struct BattleStatics
		{
			// Token: 0x04010D77 RID: 68983
			public int attackTotalNum;

			// Token: 0x04010D78 RID: 68984
			public int normalNum;

			// Token: 0x04010D79 RID: 68985
			public int criticalNum;

			// Token: 0x04010D7A RID: 68986
			public int missNum;
		}
	}
}
