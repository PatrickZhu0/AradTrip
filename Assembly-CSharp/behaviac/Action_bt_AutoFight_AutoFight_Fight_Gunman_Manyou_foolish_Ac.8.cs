using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002139 RID: 8505
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node20 : Action
	{
		// Token: 0x06012C04 RID: 76804 RVA: 0x00582DD4 File Offset: 0x005811D4
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node20()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012C05 RID: 76805 RVA: 0x00582E64 File Offset: 0x00581264
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5F7 RID: 50679
		private List<Input> method_p0;

		// Token: 0x0400C5F8 RID: 50680
		private bool method_p1;
	}
}
