using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C19 RID: 11289
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node129 : Action
	{
		// Token: 0x06014131 RID: 82225 RVA: 0x00606214 File Offset: 0x00604614
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node129()
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
			item.skillID = 21835;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014132 RID: 82226 RVA: 0x006062A4 File Offset: 0x006046A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB03 RID: 56067
		private List<Input> method_p0;

		// Token: 0x0400DB04 RID: 56068
		private bool method_p1;
	}
}
