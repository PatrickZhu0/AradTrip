using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C00 RID: 11264
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node47 : Action
	{
		// Token: 0x060140FF RID: 82175 RVA: 0x00605B18 File Offset: 0x00603F18
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node47()
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
			item.skillID = 21960;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014100 RID: 82176 RVA: 0x00605BA9 File Offset: 0x00603FA9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAE0 RID: 56032
		private List<Input> method_p0;

		// Token: 0x0400DAE1 RID: 56033
		private bool method_p1;
	}
}
