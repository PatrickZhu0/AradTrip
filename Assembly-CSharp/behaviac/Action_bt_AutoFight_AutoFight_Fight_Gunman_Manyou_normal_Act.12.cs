using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002191 RID: 8593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node30 : Action
	{
		// Token: 0x06012CB2 RID: 76978 RVA: 0x00586DF4 File Offset: 0x005851F4
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node30()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CB3 RID: 76979 RVA: 0x00586E84 File Offset: 0x00585284
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6A5 RID: 50853
		private List<Input> method_p0;

		// Token: 0x0400C6A6 RID: 50854
		private bool method_p1;
	}
}
