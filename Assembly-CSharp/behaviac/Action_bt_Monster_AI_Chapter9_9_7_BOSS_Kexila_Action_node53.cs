using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003212 RID: 12818
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node53 : Action
	{
		// Token: 0x06014CAE RID: 85166 RVA: 0x0064352C File Offset: 0x0064192C
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node53()
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
			item.skillID = 21559;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014CAF RID: 85167 RVA: 0x006435BC File Offset: 0x006419BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F6 RID: 58870
		private List<Input> method_p0;

		// Token: 0x0400E5F7 RID: 58871
		private bool method_p1;
	}
}
