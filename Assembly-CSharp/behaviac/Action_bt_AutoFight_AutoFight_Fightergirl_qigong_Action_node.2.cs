using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EF9 RID: 7929
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node41 : Action
	{
		// Token: 0x06012796 RID: 75670 RVA: 0x00567CE4 File Offset: 0x005660E4
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node41()
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
			item.skillID = 3110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012797 RID: 75671 RVA: 0x00567D74 File Offset: 0x00566174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C18A RID: 49546
		private List<Input> method_p0;

		// Token: 0x0400C18B RID: 49547
		private bool method_p1;
	}
}
