using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AAE RID: 15022
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node13 : Action
	{
		// Token: 0x06015D1E RID: 89374 RVA: 0x00697B70 File Offset: 0x00695F70
		public Action_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node13()
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
			item.skillID = 21406;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D1F RID: 89375 RVA: 0x00697C00 File Offset: 0x00696000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F63D RID: 63037
		private List<Input> method_p0;

		// Token: 0x0400F63E RID: 63038
		private bool method_p1;
	}
}
