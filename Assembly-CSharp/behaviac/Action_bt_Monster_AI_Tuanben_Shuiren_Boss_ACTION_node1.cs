using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B4F RID: 15183
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node1 : Action
	{
		// Token: 0x06015E53 RID: 89683 RVA: 0x0069D76C File Offset: 0x0069BB6C
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node1()
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
			item.skillID = 21081;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015E54 RID: 89684 RVA: 0x0069D7FC File Offset: 0x0069BBFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F723 RID: 63267
		private List<Input> method_p0;

		// Token: 0x0400F724 RID: 63268
		private bool method_p1;
	}
}
