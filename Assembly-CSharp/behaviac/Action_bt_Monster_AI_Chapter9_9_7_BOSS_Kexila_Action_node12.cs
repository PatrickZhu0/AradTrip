using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003202 RID: 12802
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12 : Action
	{
		// Token: 0x06014C8E RID: 85134 RVA: 0x00642EA0 File Offset: 0x006412A0
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12()
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
			item.skillID = 21561;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C8F RID: 85135 RVA: 0x00642F30 File Offset: 0x00641330
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5DF RID: 58847
		private List<Input> method_p0;

		// Token: 0x0400E5E0 RID: 58848
		private bool method_p1;
	}
}
