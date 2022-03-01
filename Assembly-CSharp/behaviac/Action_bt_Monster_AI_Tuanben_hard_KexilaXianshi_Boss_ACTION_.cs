using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C70 RID: 15472
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node81 : Action
	{
		// Token: 0x06016087 RID: 90247 RVA: 0x006A8B84 File Offset: 0x006A6F84
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node81()
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
			item.skillID = 21053;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016088 RID: 90248 RVA: 0x006A8C14 File Offset: 0x006A7014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F90E RID: 63758
		private List<Input> method_p0;

		// Token: 0x0400F90F RID: 63759
		private bool method_p1;
	}
}
