using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C16 RID: 11286
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node125 : Action
	{
		// Token: 0x0601412B RID: 82219 RVA: 0x00606110 File Offset: 0x00604510
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node125()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21834;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601412C RID: 82220 RVA: 0x006061A1 File Offset: 0x006045A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB00 RID: 56064
		private List<Input> method_p0;

		// Token: 0x0400DB01 RID: 56065
		private bool method_p1;
	}
}
