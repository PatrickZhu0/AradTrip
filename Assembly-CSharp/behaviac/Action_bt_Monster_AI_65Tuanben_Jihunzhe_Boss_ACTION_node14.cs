using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F12 RID: 12050
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14 : Action
	{
		// Token: 0x060146FB RID: 83707 RVA: 0x00625A64 File Offset: 0x00623E64
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14()
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
			item.skillID = 21616;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146FC RID: 83708 RVA: 0x00625AF4 File Offset: 0x00623EF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E072 RID: 57458
		private List<Input> method_p0;

		// Token: 0x0400E073 RID: 57459
		private bool method_p1;
	}
}
