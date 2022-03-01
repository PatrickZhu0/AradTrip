using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003844 RID: 14404
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node18 : Action
	{
		// Token: 0x0601586E RID: 88174 RVA: 0x0067F134 File Offset: 0x0067D534
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node18()
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
			item.skillID = 21213;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601586F RID: 88175 RVA: 0x0067F1C4 File Offset: 0x0067D5C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F22E RID: 61998
		private List<Input> method_p0;

		// Token: 0x0400F22F RID: 61999
		private bool method_p1;
	}
}
