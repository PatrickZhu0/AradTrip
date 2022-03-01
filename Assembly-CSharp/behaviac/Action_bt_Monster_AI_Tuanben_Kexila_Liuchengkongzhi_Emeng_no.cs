using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AA9 RID: 15017
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node56 : Action
	{
		// Token: 0x06015D14 RID: 89364 RVA: 0x006979C0 File Offset: 0x00695DC0
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node56()
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
			item.skillID = 21405;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D15 RID: 89365 RVA: 0x00697A50 File Offset: 0x00695E50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F636 RID: 63030
		private List<Input> method_p0;

		// Token: 0x0400F637 RID: 63031
		private bool method_p1;
	}
}
