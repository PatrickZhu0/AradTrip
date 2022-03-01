using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AC4 RID: 15044
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node39 : Action
	{
		// Token: 0x06015D47 RID: 89415 RVA: 0x006986AC File Offset: 0x00696AAC
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node39()
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
			item.skillID = 21401;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D48 RID: 89416 RVA: 0x0069873C File Offset: 0x00696B3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F659 RID: 63065
		private List<Input> method_p0;

		// Token: 0x0400F65A RID: 63066
		private bool method_p1;
	}
}
