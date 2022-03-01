using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003CFD RID: 15613
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node2 : Action
	{
		// Token: 0x06016199 RID: 90521 RVA: 0x006AE2E4 File Offset: 0x006AC6E4
		public Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node2()
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
			item.skillID = 21177;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601619A RID: 90522 RVA: 0x006AE374 File Offset: 0x006AC774
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA32 RID: 64050
		private List<Input> method_p0;

		// Token: 0x0400FA33 RID: 64051
		private bool method_p1;
	}
}
