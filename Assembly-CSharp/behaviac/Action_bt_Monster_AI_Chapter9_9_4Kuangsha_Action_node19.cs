using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003185 RID: 12677
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node19 : Action
	{
		// Token: 0x06014BA1 RID: 84897 RVA: 0x0063D938 File Offset: 0x0063BD38
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node19()
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
			item.skillID = 21542;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BA2 RID: 84898 RVA: 0x0063D9C8 File Offset: 0x0063BDC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E50D RID: 58637
		private List<Input> method_p0;

		// Token: 0x0400E50E RID: 58638
		private bool method_p1;
	}
}
