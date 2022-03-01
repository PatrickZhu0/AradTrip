using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200324E RID: 12878
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node5 : Action
	{
		// Token: 0x06014D1C RID: 85276 RVA: 0x00645BB8 File Offset: 0x00643FB8
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node5()
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
			item.skillID = 21503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014D1D RID: 85277 RVA: 0x00645C48 File Offset: 0x00644048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E669 RID: 58985
		private List<Input> method_p0;

		// Token: 0x0400E66A RID: 58986
		private bool method_p1;
	}
}
