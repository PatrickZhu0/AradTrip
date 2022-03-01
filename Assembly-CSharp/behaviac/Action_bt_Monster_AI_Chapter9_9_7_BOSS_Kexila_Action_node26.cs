using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003208 RID: 12808
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node26 : Action
	{
		// Token: 0x06014C9A RID: 85146 RVA: 0x00643118 File Offset: 0x00641518
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node26()
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
			item.skillID = 21559;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C9B RID: 85147 RVA: 0x006431A8 File Offset: 0x006415A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E7 RID: 58855
		private List<Input> method_p0;

		// Token: 0x0400E5E8 RID: 58856
		private bool method_p1;
	}
}
