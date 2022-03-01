using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003205 RID: 12805
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node22 : Action
	{
		// Token: 0x06014C94 RID: 85140 RVA: 0x00642FDC File Offset: 0x006413DC
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node22()
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
			item.skillID = 21558;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C95 RID: 85141 RVA: 0x0064306C File Offset: 0x0064146C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E3 RID: 58851
		private List<Input> method_p0;

		// Token: 0x0400E5E4 RID: 58852
		private bool method_p1;
	}
}
