using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F12 RID: 7954
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node16 : Action
	{
		// Token: 0x060127C8 RID: 75720 RVA: 0x0056876C File Offset: 0x00566B6C
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node16()
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
			item.skillID = 3008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127C9 RID: 75721 RVA: 0x005687FC File Offset: 0x00566BFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1BD RID: 49597
		private List<Input> method_p0;

		// Token: 0x0400C1BE RID: 49598
		private bool method_p1;
	}
}
