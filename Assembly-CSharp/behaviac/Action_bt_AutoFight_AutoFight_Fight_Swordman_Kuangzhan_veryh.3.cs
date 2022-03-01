using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002419 RID: 9241
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node22 : Action
	{
		// Token: 0x0601318D RID: 78221 RVA: 0x005A9D20 File Offset: 0x005A8120
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node22()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601318E RID: 78222 RVA: 0x005A9DB0 File Offset: 0x005A81B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBB7 RID: 52151
		private List<Input> method_p0;

		// Token: 0x0400CBB8 RID: 52152
		private bool method_p1;
	}
}
