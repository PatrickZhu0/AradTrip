using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200387D RID: 14461
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node29 : Action
	{
		// Token: 0x060158DE RID: 88286 RVA: 0x00681570 File Offset: 0x0067F970
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node29()
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
			item.skillID = 21214;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060158DF RID: 88287 RVA: 0x00681600 File Offset: 0x0067FA00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F27C RID: 62076
		private List<Input> method_p0;

		// Token: 0x0400F27D RID: 62077
		private bool method_p1;
	}
}
