using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021BD RID: 8637
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node35 : Action
	{
		// Token: 0x06012D09 RID: 77065 RVA: 0x00588DAC File Offset: 0x005871AC
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node35()
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
			item.skillID = 1009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012D0A RID: 77066 RVA: 0x00588E3C File Offset: 0x0058723C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6FC RID: 50940
		private List<Input> method_p0;

		// Token: 0x0400C6FD RID: 50941
		private bool method_p1;
	}
}
