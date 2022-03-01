using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003DA5 RID: 15781
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node2 : Action
	{
		// Token: 0x060162DC RID: 90844 RVA: 0x006B4620 File Offset: 0x006B2A20
		public Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node2()
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
			item.skillID = 21360;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060162DD RID: 90845 RVA: 0x006B46B0 File Offset: 0x006B2AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB28 RID: 64296
		private List<Input> method_p0;

		// Token: 0x0400FB29 RID: 64297
		private bool method_p1;
	}
}
