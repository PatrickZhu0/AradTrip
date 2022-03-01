using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001517 RID: 5399
	public class ChangeJobFinish : ClientFrame
	{
		// Token: 0x0600D1B8 RID: 53688 RVA: 0x0033BBE3 File Offset: 0x00339FE3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobFinish";
		}

		// Token: 0x0600D1B9 RID: 53689 RVA: 0x0033BBEA File Offset: 0x00339FEA
		protected override void _OnOpenFrame()
		{
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeJobFinishFrameOpen, null, null, null, null);
			this.InitAvatar();
			this.InitSkill();
		}

		// Token: 0x0600D1BA RID: 53690 RVA: 0x0033BC0B File Offset: 0x0033A00B
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D1BB RID: 53691 RVA: 0x0033BC0D File Offset: 0x0033A00D
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<ChangeJobFinish>(this, false);
		}

		// Token: 0x0600D1BC RID: 53692 RVA: 0x0033BC1C File Offset: 0x0033A01C
		[UIEventHandle("GoSkill")]
		private void OnGoSkill()
		{
			this.frameMgr.CloseFrame<ChangeJobFinish>(this, false);
			this.frameMgr.OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600D1BD RID: 53693 RVA: 0x0033BC40 File Offset: 0x0033A040
		private void InitAvatar()
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("职业ID找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogError("职业ID Mode表 找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
				}
				else
				{
					this.m_AvatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.m_AvatarRenderer, null, false);
					this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
					this.m_AvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
				}
				this.JobDesc.text = tableItem.JobDes[0];
				this.JobName.text = tableItem.Name;
				this.ArmorText.text = tableItem.RecDefence;
			}
		}

		// Token: 0x0600D1BE RID: 53694 RVA: 0x0033BD8C File Offset: 0x0033A18C
		private void InitSkill()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._InitSkill(tableItem.changeFinishShowSkills);
			}
		}

		// Token: 0x0600D1BF RID: 53695 RVA: 0x0033BDCC File Offset: 0x0033A1CC
		private void _InitSkill(IList<int> list)
		{
			if (list.Count != 3)
			{
				Logger.LogErrorFormat("[转职展示]转职技能列表输入个数 {0} 超过 {1}", new object[]
				{
					list.Count,
					3
				});
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(list[i], string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("[转职展示]职业技能{0}查找失败", new object[]
					{
						list[i]
					});
				}
				else
				{
					Text text = this.skillNames[i];
					Image image = this.skillImages[i];
					text.text = tableItem.Name;
					ETCImageLoader.LoadSprite(ref image, tableItem.Icon, true);
				}
			}
		}

		// Token: 0x04007AB8 RID: 31416
		private const int MaxSkillNum = 3;

		// Token: 0x04007AB9 RID: 31417
		[UIControl("left/JobDesc/JobName", null, 0)]
		protected Text JobName;

		// Token: 0x04007ABA RID: 31418
		[UIControl("left/JobDetail/ArmorPic/Text", null, 0)]
		protected Text ArmorText;

		// Token: 0x04007ABB RID: 31419
		[UIControl("left/JobDesc/des", null, 0)]
		protected Text JobDesc;

		// Token: 0x04007ABC RID: 31420
		[UIControl("left/SkillDetail/SkillList/Skill{0}/Name", typeof(Text), 1)]
		protected Text[] skillNames = new Text[3];

		// Token: 0x04007ABD RID: 31421
		[UIControl("left/SkillDetail/SkillList/Skill{0}/Image", typeof(Image), 1)]
		protected Image[] skillImages = new Image[3];

		// Token: 0x04007ABE RID: 31422
		[UIControl("Model", typeof(GeAvatarRendererEx), 0)]
		private GeAvatarRendererEx m_AvatarRenderer;
	}
}
