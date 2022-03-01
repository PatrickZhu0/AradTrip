using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003215 RID: 12821
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18 : Action
	{
		// Token: 0x06014CB4 RID: 85172 RVA: 0x00643668 File Offset: 0x00641A68
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18()
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

		// Token: 0x06014CB5 RID: 85173 RVA: 0x006436F8 File Offset: 0x00641AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5FA RID: 58874
		private List<Input> method_p0;

		// Token: 0x0400E5FB RID: 58875
		private bool method_p1;
	}
}
