using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200316E RID: 12654
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node36 : Action
	{
		// Token: 0x06014B73 RID: 84851 RVA: 0x0063D1FC File Offset: 0x0063B5FC
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node36()
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
			item.skillID = 21545;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B74 RID: 84852 RVA: 0x0063D28C File Offset: 0x0063B68C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4EB RID: 58603
		private List<Input> method_p0;

		// Token: 0x0400E4EC RID: 58604
		private bool method_p1;
	}
}
