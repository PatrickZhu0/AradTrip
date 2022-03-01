using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D9F RID: 15775
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node10 : Action
	{
		// Token: 0x060162D0 RID: 90832 RVA: 0x006B4414 File Offset: 0x006B2814
		public Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node10()
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
			item.skillID = 21402;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060162D1 RID: 90833 RVA: 0x006B44A4 File Offset: 0x006B28A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB1D RID: 64285
		private List<Input> method_p0;

		// Token: 0x0400FB1E RID: 64286
		private bool method_p1;
	}
}
