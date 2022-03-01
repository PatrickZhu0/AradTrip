using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200390D RID: 14605
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node82 : Action
	{
		// Token: 0x060159F5 RID: 88565 RVA: 0x00687624 File Offset: 0x00685A24
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node82()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21202;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060159F6 RID: 88566 RVA: 0x006876B4 File Offset: 0x00685AB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F38D RID: 62349
		private List<Input> method_p0;

		// Token: 0x0400F38E RID: 62350
		private bool method_p1;
	}
}
