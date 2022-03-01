using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021C5 RID: 8645
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node45 : Action
	{
		// Token: 0x06012D19 RID: 77081 RVA: 0x005891F0 File Offset: 0x005875F0
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node45()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012D1A RID: 77082 RVA: 0x00589280 File Offset: 0x00587680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C70C RID: 50956
		private List<Input> method_p0;

		// Token: 0x0400C70D RID: 50957
		private bool method_p1;
	}
}
