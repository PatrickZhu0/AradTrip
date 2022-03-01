using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036BA RID: 14010
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node5 : Action
	{
		// Token: 0x0601558E RID: 87438 RVA: 0x006705CC File Offset: 0x0066E9CC
		public Action_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node5()
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
			item.skillID = 5420;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601558F RID: 87439 RVA: 0x0067065C File Offset: 0x0066EA5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF62 RID: 61282
		private List<Input> method_p0;

		// Token: 0x0400EF63 RID: 61283
		private bool method_p1;
	}
}
