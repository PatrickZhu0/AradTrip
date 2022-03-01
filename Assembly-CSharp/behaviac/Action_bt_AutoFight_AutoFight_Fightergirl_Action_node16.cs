using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EE4 RID: 7908
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node16 : Action
	{
		// Token: 0x0601276D RID: 75629 RVA: 0x00566948 File Offset: 0x00564D48
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node16()
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
			item.skillID = 3006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601276E RID: 75630 RVA: 0x005669D8 File Offset: 0x00564DD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C160 RID: 49504
		private List<Input> method_p0;

		// Token: 0x0400C161 RID: 49505
		private bool method_p1;
	}
}
