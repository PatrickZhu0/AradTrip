using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C37 RID: 11319
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node15 : Action
	{
		// Token: 0x0601416C RID: 82284 RVA: 0x006083B0 File Offset: 0x006067B0
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node15()
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
			item.skillID = 20778;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601416D RID: 82285 RVA: 0x00608440 File Offset: 0x00606840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB2F RID: 56111
		private List<Input> method_p0;

		// Token: 0x0400DB30 RID: 56112
		private bool method_p1;
	}
}
