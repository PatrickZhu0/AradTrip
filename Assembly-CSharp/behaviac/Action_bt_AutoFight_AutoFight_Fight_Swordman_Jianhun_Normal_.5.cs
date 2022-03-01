using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022FD RID: 8957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node46 : Action
	{
		// Token: 0x06012F73 RID: 77683 RVA: 0x0059AE60 File Offset: 0x00599260
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1911;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 910;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1911;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012F74 RID: 77684 RVA: 0x0059AF4C File Offset: 0x0059934C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C98E RID: 51598
		private List<Input> method_p0;

		// Token: 0x0400C98F RID: 51599
		private bool method_p1;
	}
}
