using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AB3 RID: 15027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2 : Action
	{
		// Token: 0x06015D28 RID: 89384 RVA: 0x00697D54 File Offset: 0x00696154
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node2()
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

		// Token: 0x06015D29 RID: 89385 RVA: 0x00697DE4 File Offset: 0x006961E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F647 RID: 63047
		private List<Input> method_p0;

		// Token: 0x0400F648 RID: 63048
		private bool method_p1;
	}
}
