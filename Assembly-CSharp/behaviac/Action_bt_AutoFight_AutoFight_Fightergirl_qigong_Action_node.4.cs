using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F02 RID: 7938
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node14 : Action
	{
		// Token: 0x060127A8 RID: 75688 RVA: 0x005680A4 File Offset: 0x005664A4
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node14()
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
			item.skillID = 3117;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127A9 RID: 75689 RVA: 0x00568134 File Offset: 0x00566534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C19D RID: 49565
		private List<Input> method_p0;

		// Token: 0x0400C19E RID: 49566
		private bool method_p1;
	}
}
