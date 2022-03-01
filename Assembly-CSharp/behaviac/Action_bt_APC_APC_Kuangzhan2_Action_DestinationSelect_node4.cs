using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DA9 RID: 7593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node4 : Action
	{
		// Token: 0x0601250C RID: 75020 RVA: 0x005585D8 File Offset: 0x005569D8
		public Action_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node4()
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
			item.skillID = 9706;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601250D RID: 75021 RVA: 0x00558668 File Offset: 0x00556A68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEFB RID: 48891
		private List<Input> method_p0;

		// Token: 0x0400BEFC RID: 48892
		private bool method_p1;
	}
}
